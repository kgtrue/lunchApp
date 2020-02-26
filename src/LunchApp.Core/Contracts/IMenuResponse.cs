using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface IMenuResponse
    {
        bool Result { get; set; }
        IMenu Menu { get; set; }
    }
}
