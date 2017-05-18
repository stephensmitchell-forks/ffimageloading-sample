﻿using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PixaImagenes.Entities;

namespace PixaImagenes
{
    public class PixaClient
    {
        public PixaClient(string key)
        {
            Key = key;
            Client = new HttpClient();
        }

        public PixaClient(string key, HttpClientHandler handler)
        {
            Key = key;
            Client = new HttpClient(handler);
        }

        public string Key { get; private set; }
        public HttpClient Client { get; }

        public async Task<Response> GetPhotos()
        {
            var url =
                "https://pixabay.com/api/" +
                "?key=5392706-f5e479ff283c464487f394f41" +
                "&q=yellow+flowers&image_type=photo&pretty=true";
            var stringResponse = await Client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response>(stringResponse);
        }
    }
}