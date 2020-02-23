using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Core.Entity
{
    public class LunchMenu
    {
        public LunchMenu(DateTime date)
        {
            Date = date;
            LunchDishes = new List<LunchDish>();
            LunchMenuReviews = new List<LunchMenuReview>();
            Id = date.GetHashCode();
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public IList<LunchDish> LunchDishes { get; private set; }
        public IList<LunchMenuReview> LunchMenuReviews { get; private set; }
        public bool AddLunchMenuDish(string name)
        {
            var dish = new LunchDish(this, name);
            if (LunchDishes.Any(l => l.Id == dish.Id)) { return false; }
            LunchDishes.Add(dish);
            return true;
        }
        public double MenuRating => LunchMenuReviews.Average(x => x.MenuReviewScore);
    }
}
