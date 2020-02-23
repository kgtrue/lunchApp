using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Entity
{
    public class LunchDish
    {
        public LunchDish(LunchMenu lunchMenu, string name)
        {
            _ = lunchMenu ?? throw new NullReferenceException("lunch menu must not be null");
            _ = name ?? throw new NullReferenceException("Name must not be null");
            
            Name = name;
            LunchMenu = lunchMenu;
            Id = LunchMenu.GetHashCode() + name.GetHashCode(); 
        }       

        public int Id { get; private set; }
        public string Name { get; private set; }
        public LunchMenu LunchMenu { get; private set; }
    }
}
