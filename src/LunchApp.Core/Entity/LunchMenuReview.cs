using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Core.Entity
{
    public class LunchMenuReview
    {
        public LunchMenuReview(LunchMenu lunchMenu)
        {
            _ = lunchMenu ?? throw new NullReferenceException("Lunch menu must not be null");
            LunchMenu = lunchMenu; 
            LunchMenuDishReviews = new List<LunchDishReview>();
        }

        public LunchMenu LunchMenu { get; private set; }

        public IList<LunchDishReview> LunchMenuDishReviews { get; private set; }

        public void AddReview(int lunchDishId, int reviewScore)
        {
            if(LunchMenu.LunchDishes.Any(l=> l.)  )
        }
    }
}
