using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Inferstructure.External.Menu.Api
{
    public interface IHttpRepository
    {
        string BaseUrl { get; set; }
    }
}
