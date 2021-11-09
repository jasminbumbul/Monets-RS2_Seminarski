using Monets.Api.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.API.Helpers
{
    public class ImageHelper
    {
        public async Task<byte[]> FindImage(string path)
        {
            try
            {
                return await System.IO.File.ReadAllBytesAsync(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> InsertImage(string putanja,int id, string imageName, byte[] byteArray)
        {
            try
            {
                if (byteArray.Length > 0 && byteArray != null)
                {
                    var filename = $"{putanja.ToLower()}_{id.ToString()}";
                    var extension = Path.GetExtension(imageName);
                    var newPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", putanja, $"{filename}{extension}");

                    await File.WriteAllBytesAsync(newPath, byteArray);

                    return $"{filename}{extension}";
                }
                else
                {
                    return "noimage.png";
                }
            }
            catch (Exception ex)
            {
                throw new UserException("Dogodila se greska prilikom dodavanja slike. Provjerite podatke");
            }
        }

        public async Task<string> ReplaceImage(string putanja, int id, string staraSlikaPutanja, string imageName, byte[] byteArray)
        {

            if (staraSlikaPutanja != "noimage.png")
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", putanja, $"{staraSlikaPutanja}");

                try
                {
                    File.Delete(path);
                }
                catch (Exception) { }
            }

            try
            {
                var filename = $"{putanja.ToLower()}_{id.ToString()}";
                var extension = Path.GetExtension(imageName);
                var newPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", putanja, $"{filename}{extension}");

                await File.WriteAllBytesAsync(newPath, byteArray);
                return $"{filename}{extension}";

            }
            catch (Exception ex)
            {
                throw new UserException("Dogodila se greska prilikom izmjene slike. Provjerite podatke");
            }
        }

    }
}
