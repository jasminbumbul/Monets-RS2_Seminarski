using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Monets.Api.Database;
using Monets.Api.Helper;
using Monets.Api.Interfaces;
using Monets.API.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class PreporukaService : IPreporukaService
    {
        private readonly MonetsContext Context;
        private readonly IMapper _mapper;
        private ImageHelper imageHelper = new ImageHelper();
        private static MLContext mlContext = null;
        private static ITransformer model = null;
        public PreporukaService(MonetsContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<List<Model.Jelo>> Preporuka(int id)
        {
            if (mlContext == null)
            {
                mlContext = new MLContext();

                var tmpData = Context.Rezervacija.Include("JeloRezervacija").ToList();
                var data = new List<ProductEntry>();

                foreach (var x in tmpData)
                {
                    if (x.JeloRezervacija.Count > 1)
                    {
                        var distinctItemId = x.JeloRezervacija.Select(y => y.JeloId).ToList();
                        distinctItemId.ForEach(y =>
                        {
                            var relatedItems = x.JeloRezervacija.Where(z => z.JeloId != y);

                            foreach (var z in relatedItems)
                            {
                                data.Add(new ProductEntry()
                                {
                                    ProductID = (uint)y,
                                    CoPurchaseProductID = (uint)z.JeloId
                                });
                            }
                        });
                    }
                }

                var traindata = mlContext.Data.LoadFromEnumerable(data);

                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                options.NumberOfIterations = 100;
                options.C = 0.00001;

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                model = est.Fit(traindata);

            }

            var allItems = Context.Jelo.Where(x => x.JeloId != id);

            var predictionResult = new List<Tuple<Database.Jelo, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine =
                    mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);

                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.JeloId
                });

                predictionResult.Add(new Tuple<Database.Jelo, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Take(3).ToList();

            var result = _mapper.Map<List<Model.Jelo>>(finalResult);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }
    }
}
