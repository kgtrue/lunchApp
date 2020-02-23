using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface ILunchMenuReviewRepo
    {
        void SaveUpdate(LunchMenuReview lunchMenu);
    }
}
