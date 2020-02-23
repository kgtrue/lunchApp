using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface ILunchMenuRepo
    {
        LunchMenu GetById(int id);
        LunchMenu GetByDate(DateTime date);
        void SaveUpdate(LunchMenu lunchMenu);
    }
}
