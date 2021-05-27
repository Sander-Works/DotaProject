﻿using DotaGrid.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotaGrid.App.DataAccess
{
    internal class MainAttributesDataAccess
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private static readonly Uri mainAttributesBaseUri = new Uri("http://localhost:44943/api/mainAttributes");

        public async Task<Mainattribute[]> GetMainAttributesAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(mainAttributesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Mainattribute[] mainAttributes = JsonConvert.DeserializeObject<Mainattribute[]>(json);

            return mainAttributes;
        }
        /*
        internal async Task<Hero[]> GetListedHeroesAsync(int mainAttributeId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(mainAttributesBaseUri, $"MainAttributes/{mainAttributeId}/Heroes"));
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Hero[]>(json);
        }
        */
    }
}
