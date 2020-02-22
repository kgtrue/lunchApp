using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Entity
{
    public class LunchDish
    {
        public LunchDish(LunchMenu lunchMenu)
        {
            _ = lunchMenu ?? throw new NullReferenceException("lunch menu must not be null"); 
        }
    }
}
