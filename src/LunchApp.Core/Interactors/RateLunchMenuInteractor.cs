﻿using LunchApp.Core.Contracts;
using LunchApp.Core.Contracts.Dtos;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.Core.Interactors
{
    public class RateLunchMenuInteractor : IRequestHandler<RateLunchMenuRequest, Task<RateLunchMenuResponse>>
    {
        private readonly ILunchMenuRepo lunchMenuRepo;
        private readonly ILunchMenuReviewRepo lunchMenuReviewRepo;
        public RateLunchMenuInteractor(ILunchMenuRepo lunchMenuRepo, ILunchMenuReviewRepo lunchMenuReviewRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuReviewRepo = lunchMenuReviewRepo;
        }
        public async Task<RateLunchMenuResponse> Handle(RateLunchMenuRequest message)
        {
            var lunchMenu = await lunchMenuRepo.GetById(message.MenuId);
            var lunchMenuReviwew = new LunchMenuReview(lunchMenu);
            var errors = new List<string>();
            message.ReviewScores.ToList().ForEach(lmr =>
            {
                if (!lunchMenuReviwew.AddReview(lmr.DishId, lmr.ReviewScore))
                {
                    errors.Add($"unable to register review for {lunchMenu.LunchDishes.FirstOrDefault(ld => ld.Id == lmr.DishId).Name }");
                }
            });

            lunchMenuReviewRepo.SaveUpdate(lunchMenuReviwew);
            return new RateLunchMenuResponse(!errors.Any(), errors);
        }
    }
}
