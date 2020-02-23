using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Core.Entity
{
    public class LunchMenuReview
    {
        public Guid Id { get; private set; }

        public LunchMenuReview(LunchMenu lunchMenu)
        {
            _ = lunchMenu ?? throw new NullReferenceException("Lunch menu must not be null");
            LunchMenu = lunchMenu;
            LunchMenuDishReviews = new List<LunchDishReview>();
            Id = Guid.NewGuid();
        }

        public LunchMenu LunchMenu { get; private set; }
        public double MenuReviewScore => LunchMenuDishReviews.Average(x => x.ReviewScore);
        public IList<LunchDishReview> LunchMenuDishReviews { get; private set; }

        public bool AddReview(int lunchDishId, uint reviewScore)
        {
            if (!LunchMenu.LunchDishes.Any(ld => ld.Id == lunchDishId))
                return false;

            if (LunchMenuDishReviews.Any(l => l.LunchDish.Id == lunchDishId))
                return false;

            if (reviewScore > 5)
                return false;

            LunchMenuDishReviews.Add(new LunchDishReview(LunchMenu.LunchDishes.First(ld => ld.Id == lunchDishId), reviewScore));
            return true;
        }


    }
}
