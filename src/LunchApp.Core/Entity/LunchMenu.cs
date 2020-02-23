using System;
using System.Collections.Generic;
using System.Text;
using System.Linq:
namespace LunchApp.Core.Entity
{
    public class LunchMenu
    {
        public LunchMenu(DateTime date)
        {
            Date = date;
            LunchDishes = new List<LunchDish>();
            Id = date.GetHashCode();
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public List<LunchDish> LunchDishes { get; private set; }

        public LunchDish AddLunchMenuDish(string name)
        {
            var dish = new LunchDish(this, name);
            if(LunchDishes.Any( l=> l.Id == dish.Id)) { throw new Exception("Dublicate key"); }
            LunchDishes.Add(dish);
            return dish;
        }
    }
}
