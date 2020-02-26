using LunchApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Inferstructure.External.Menu.Api.Dtos
{
    public class MenuResponse : IMenuResponse
    {
        public bool Result { get; set; }
        public IMenu Menu { get; set; }
    }
}
