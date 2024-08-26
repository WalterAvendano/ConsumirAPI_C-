using Newtonsoft.Json;
using RYMApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RYMApi.Controllers
{
    public class CharacterrControllers
    {
        private HttpClient client;

        public CharacterrControllers()
        {
            client = new HttpClient();
        }

        public async Task<Characters> GetAllCharacters()
        {
            try
            {
                Characters characters = new Characters();
                HttpResponseMessage response = await
                client.GetAsync("https://rickandmortyapi.com/api/character");
                response.EnsureSuccessStatusCode();
                string responseJson = await response.Content.ReadAsStringAsync();
                characters = JsonConvert.DeserializeObject<Characters>(responseJson);
                return characters;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
