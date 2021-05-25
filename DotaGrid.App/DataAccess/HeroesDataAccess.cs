using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DotaGrid.Model;

namespace DotaGrid.App.DataAccess
{
    public class HeroesDataAccess
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private static readonly Uri heroBaseUri = new Uri("http://localhost:32168/api/Races");

        public async Task<Hero[]> GetHeroesAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(heroBaseUri);
            string json = await result.Content.ReadAsStringAsync();

            Hero[] heroes = JsonConvert.DeserializeObject<Hero[]>(json);

            return heroes;
        }

        internal async Task<bool> PostHeroesAsync(Hero hero)
        {
            string json = JsonConvert.SerializeObject(hero);
            HttpResponseMessage result = await _httpClient.PostAsync(heroBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedHero = JsonConvert.DeserializeObject<Hero>(json);
                hero.HeroId = returnedHero.HeroId;

                return true;
            }
            else
                return false;
        }

        internal async Task<bool> DeleteHeroesAsync(Hero hero)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(heroBaseUri, "heroes/" + hero.HeroId.ToString()));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> PutHeroesAsync(Hero hero)
        {
            string json = JsonConvert.SerializeObject(hero);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(heroBaseUri, "heroes/" + hero.HeroId.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }
    }
}
