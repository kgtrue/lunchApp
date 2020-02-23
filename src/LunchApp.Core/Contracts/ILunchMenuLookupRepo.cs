using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts
{
    public interface ILunchMenuLookupRepo
    {
        Task<IMenu> GetByDate(DateTime date);
    }
}
