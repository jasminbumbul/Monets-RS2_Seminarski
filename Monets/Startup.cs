using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Interfaces;
using Monets.Api.Security;
using Monets.Api.Services;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(
                 builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                     ));
            services.AddMvc(x => x.Filters.Add<ErrorFilter>());
            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<MonetsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Monets API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddScoped<IJeloService, JeloService>();
            services.AddScoped<IKategorijaService, KategorijaService>();
            services.AddScoped<IMeniService, MeniService>();
            services.AddScoped<IRejtingService, RejtingService>();
            services.AddScoped<IStolService, StolService>();
            services.AddScoped<IRezervacijaService, RezervacijaService>();
            services.AddScoped<IJeloRezervacijaService, JeloRezervacijaService>();
            services.AddScoped<IKorisnickiRacun, KorisnickiRacunService>();
            services.AddScoped<IUposlenikService, UposlenikService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IKlijentService, KlijentService>();
            services.AddScoped<ITransakcijaService, TransakcijaService>();
            services.AddScoped<IPreporukaService, PreporukaService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IReadService<Model.Uloga, object>, BaseReadService<Model.Uloga, Uloga, object>>();
            services.AddScoped<IReadService<Model.Grad, object>, BaseReadService<Model.Grad, Grad, object>>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monets Api");
                c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
            });

            app.UseStaticFiles();

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
