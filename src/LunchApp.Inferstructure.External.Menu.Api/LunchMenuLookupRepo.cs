using LunchApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace LunchApp.Inferstructure.External.Menu.Api
{
    public class LunchMenuLookupRepo : ILunchMenuLookupRepo
    {
        private readonly HttpClient httpClient;

        public LunchMenuLookupRepo(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<IMenu> GetByDate(DateTime date)
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(Entity.Menu));
                var response = await httpClient.GetStreamAsync($"/menu/{date.ToString("ddMMyy")}");
                var result = (Entity.Menu)mySerializer.Deserialize(response);
                return result;
            }
            catch (Exception ex)
            {
                throw new RepoException(ex.Message, ex); 
            }
          
        }
    }
}
