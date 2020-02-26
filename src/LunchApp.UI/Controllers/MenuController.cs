using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchApp.Core.Contracts;
using LunchApp.Core.Interactors;
using LunchApp.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LunchApp.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepo lunchMenuRepo;
        private readonly ILunchMenuLookupRepo lunchMenuLookupRepo;
        private readonly IReviewRepo reviewRepo;
        public MenuController(IMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo, IReviewRepo reviewRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
            this.reviewRepo = reviewRepo; 
        }

        public IActionResult Index()
        {
            var date = DateTime.Now.Date;
            var reviewToken = DateTime.Now.GetHashCode();
            var model = new MenuViewModel() { SelectedDate = date, ReviewToken = reviewToken.GetHashCode() };
            var menu = lunchMenuRepo.GetById(date.GetHashCode());


            if (menu == null)
            {
                var interactor = new CreateMenuInteractor(lunchMenuRepo, lunchMenuLookupRepo);
                var response = interactor.Handle(new Core.Contracts.Dtos.CreateMenuRequest(date));
                if (response.Result)
                {
                    menu = lunchMenuRepo.GetById(response.MenuId.Value);
                }
                else
                {                  
                    model.Errors = response.Messages; 
                }
            }
            if (menu != null)
            {
                model.NumberOfReviews = reviewRepo.GetAllMenuReviews(menu.Id).Count(); 
                model.Id = menu.Id;
                model.MenuRating = menu.AverageMenuReviewScore;
                model.Courses = menu.Courses.Select(ld =>
                            new CourseViewModel()
                            {
                                Id = ld.Id,
                                Name = ld.Name,
                                ReviewScoreAverage = ld.AverageCourseReviewScore,
                            }
                        ).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(MenuViewModel model)
        {
            if (ModelState.IsValid && model.Id.HasValue)
            {
                var interactor = new RateMenuInteractor(lunchMenuRepo);
                var ratings = model.Courses.Select(c => (c.Id, c.ReviewScore)).ToList();
                var response = interactor.Handle(new Core.Contracts.Dtos.RateMenuRequest(model.Id.Value, model.ReviewToken, ratings));
                if (response.Result)
                {
                    model.Answered = true;
                    model.Errors.Clear();
                }
                else
                {
                    model.Errors = response.Messages;
                }

                var menu = lunchMenuRepo.GetById(model.Id.Value);
                model.MenuRating = menu.AverageMenuReviewScore;
                foreach (var cource in model.Courses)
                {
                    cource.ReviewScoreAverage = menu.Courses.Single(c => c.Id == cource.Id).AverageCourseReviewScore;
                }
            }
            return View(model);
        }

    }
}