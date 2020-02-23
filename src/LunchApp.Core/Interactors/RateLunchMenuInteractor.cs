using LunchApp.Core.Contracts;
using LunchApp.Core.Contracts.Dtos;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Interactors
{
    public class RateLunchMenuInteractor : IRequestHandler<RateLunchMenuRequest, RateLunchMenuResponse>
    {
        private readonly ILunchMenuRepo lunchMenuRepo;
        private readonly ILunchMenuReviewRepo lunchMenuReviewRepo;
        public RateLunchMenuInteractor(ILunchMenuRepo lunchMenuRepo, ILunchMenuReviewRepo lunchMenuReviewRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuReviewRepo = lunchMenuReviewRepo;
        }

        public RateLunchMenuResponse Handle(RateLunchMenuRequest message)
        {
            var lunchMenu = lunchMenuRepo.GetById(message.MenuId);
            var lunchMenuReviwew = new LunchMenuReview(lunchMenu);
            message.ReviewScores.ForEach(lmr =>
            {
                lunchMenuReviwew.AddReview(lmr.DishId, lmr.ReviewScore);
            });

            var errors = new List<string>(); 

            lunchMenuReviewRepo.SaveUpdate(lunchMenuReviwew);
            return new RateLunchMenuResponse();
        }
    }
}
