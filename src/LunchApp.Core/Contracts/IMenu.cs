using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface IMenu
    {
        DateTime Date { get; set; }
        string[] Course { get; set; }
    }
}
