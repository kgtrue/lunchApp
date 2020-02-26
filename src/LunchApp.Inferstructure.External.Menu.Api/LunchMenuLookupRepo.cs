using LunchApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;
using LunchApp.Inferstructure.External.Menu.Api.Dtos;

namespace LunchApp.Inferstructure.External.Menu.Api
{
    public class LunchMenuLookupRepo : ILunchMenuLookupRepo
    {
        private readonly HttpClient httpClient;

        public LunchMenuLookupRepo(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IMenuResponse> GetByDate(DateTime date)
        {
            var menuResponse = new MenuResponse();
            try
            {
                var mySerializer = new XmlSerializer(typeof(Entity.ExternalMenu));
                var response = await httpClient.GetStreamAsync($"/menu/{date.ToString("ddMMyy")}");
                var result = (Entity.ExternalMenu)mySerializer.Deserialize(response);
                return new MenuResponse() { Menu = result, Result = true };
            }
            catch (Exception)
            {
                return new MenuResponse();
            }

        }
    }
}
