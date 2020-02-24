using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts
{
    public interface ILunchMenuRepo
    {
        Task<LunchMenu> GetById(int id);      
        void SaveUpdate(LunchMenu lunchMenu);
    }
}
