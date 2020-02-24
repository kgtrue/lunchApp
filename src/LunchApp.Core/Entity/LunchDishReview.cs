using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Entity
{
    public class LunchDishReview
    {
        public LunchDishReview(LunchDish lunchDish, int reviewScore)
        {
            _ = lunchDish ?? throw new NullReferenceException("Dish must not be null");
            LunchDish = lunchDish;
            ReviewScore = reviewScore;
        }
        public LunchDish LunchDish { get; private set; }
        public int ReviewScore { get; private set; }
    }
}
