using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface ILunchMenuReviewRepo
    {
        LunchMenuReview GetById(Guid Id);

        IList<LunchMenuReview> GetAllMenuReviews(int menuId);

        void SaveUpdate(LunchMenuReview lunchMenu);
    }
}
