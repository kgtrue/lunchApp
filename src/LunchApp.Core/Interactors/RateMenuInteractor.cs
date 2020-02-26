using LunchApp.Core.Contracts;
using LunchApp.Core.Contracts.Dtos;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.Core.Interactors
{
    public class RateMenuInteractor : IRequestHandler<RateMenuRequest, RateMenuResponse>
    {
        private readonly IMenuRepo menuRepo;
        public RateMenuInteractor(IMenuRepo menuRepo)
        {
            this.menuRepo = menuRepo;
        }
        public RateMenuResponse Handle(RateMenuRequest message)
        {
            var lunchMenu = menuRepo.GetById(message.MenuId);
            var errors = new List<string>();
            message.ReviewScores.ToList().ForEach(review =>
            {
                if (!lunchMenu.AddUpdateReview(review.courseId, message.RevierwToken, review.reviewScore))
                {
                    errors.Add($"Unable to register review for cource with id: {review.courseId} and score {review.reviewScore}");
                }
            });
            menuRepo.SaveUpdate(lunchMenu);
            return new RateMenuResponse(!errors.Any(), errors);
        }
    }
}
