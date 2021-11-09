using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Monets.Model;
using Monets.Model.Requests;

namespace Monets.WinUI.Services
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<Uposlenik> Authenticate(AuthenticationRequest request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/Uposlenik/Login";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<Model.Uposlenik>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 400)
                {
                    throw new Exception("Korisnički račun ne postoji ili je deaktiviran.");
                }

                if (ex.Call.Response.StatusCode == 401)
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka!");
                }

                if (ex.Call.Response.StatusCode == 403)
                {
                    throw new Exception("Nemate permisije za pristup ovom resursu.");
                }
                throw;
            }
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija.");
                }
                if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("Nemate permisije za pristup ovom resursu.");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija.");
                }
                if (ex.Call.Response.StatusCode == 403)
                {
                    MessageBox.Show("Nemate permisije za pristup ovom resursu.");
                }
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    //stringBuilder.AppendLine($"{error.Key} - {string.Join(",", error.Value)}");
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                MessageBox.Show(stringBuilder.ToString(), "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default(T);
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    //stringBuilder.AppendLine($"{error.Key} - {string.Join(",", error.Value)}");
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                MessageBox.Show(stringBuilder.ToString(), "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default(T);
            }
        }

        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    //stringBuilder.AppendLine($"{error.Key} - {string.Join(",", error.Value)}");
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                MessageBox.Show(stringBuilder.ToString(), "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
    }
}
