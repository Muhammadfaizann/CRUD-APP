using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Client
{
    public class RestClient
    {
        string baseUrl = "http://10.0.2.2:5097/";
        public RestClient()
        {

        }
        public async Task<T> GetAsync<T>(string subUrl)
        {
            try
            {
                var baseAddr = new Uri(baseUrl);
                var client = new HttpClient { BaseAddress = baseAddr };
                var response = await client.GetAsync(baseUrl + subUrl);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();
                    var productList = JsonConvert.DeserializeObject<T>(resContent);
                    return productList;
                }
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }
        public async Task<string> PostAsync(string subUrl, object request)
        {
            try
            {
                string url = baseUrl + subUrl;
                HttpClient client = new HttpClient();
                StringContent stringContent = new StringContent("");
                var json = JsonConvert.SerializeObject(request);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();
                    return resContent;
                }
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public async Task<string> DeleteAsync(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                var response = await client.DeleteAsync(baseUrl + url);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();
                    return resContent;
                }
                
            }
            catch (Exception ex) { 

            }
            return "";
        }

        public async Task<string> PutAsync(string subUrl, object request)
        {
            try
            {
                string url = baseUrl + subUrl;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                var json = JsonConvert.SerializeObject(request);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();
                    return resContent;
                }
            }
            catch (Exception ex) { 
            }
            return "";
        }
    }
}
