using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts
{
    public interface IMenuRepo
    {
        Menu GetById(int id);      
        void SaveUpdate(Menu menu);
    }
}
