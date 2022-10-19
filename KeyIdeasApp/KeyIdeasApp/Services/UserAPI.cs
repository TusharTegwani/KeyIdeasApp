using KeyIdeasApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Java.Util;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace KeyIdeasApp.Services
{
    public class UserAPI
    {
        
        public const string BASE_URL = "https://jsonplaceholder.typicode.com/users";
        public static async Task<ObservableCollection<OneCallAPI>> GetOneCallAPIAsync()
        {
            //OneCallAPI user = new OneCallAPI();
            
            string url = String.Format(BASE_URL);
            var uri = new Uri(url);
            HttpClient httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(uri);
                // Console.WriteLine(response);    
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<ObservableCollection<OneCallAPI>>(content);
                   
                    return posts;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
