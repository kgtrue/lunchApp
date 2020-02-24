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
        private readonly ILunchMenuRepo lunchMenuRepo;
        private readonly ILunchMenuReviewRepo lunchMenuReviewRepo;
        private readonly ILunchMenuLookupRepo lunchMenuLookupRepo;
        public MenuController(ILunchMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo, ILunchMenuReviewRepo lunchMenuReviewRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuReviewRepo = lunchMenuReviewRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MenuViewModel() { SelectedDate = DateTime.Now.Date };
            var menu = await lunchMenuRepo.GetById(DateTime.Now.Date.GetHashCode());

            if (menu == null)
            {
                var interactor = new CreateLunchMenuInteractor(lunchMenuRepo, lunchMenuLookupRepo);
                var response = await interactor.Handle(new Core.Contracts.Dtos.CreateLunchMenuRequest(DateTime.Now.Date));
                if (response.Result)
                    menu = await lunchMenuRepo.GetById(response.MenuId.Value);

            }
            if (menu != null)
            {
                model.Id = menu.Id;
                model.Courses = menu.LunchDishes.Select(ld =>
                            new CourseViewModel()
                            {
                                Id = ld.Id,
                                Name = ld.Name,
                                ReviewScore = 0
                            }
                        ).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var interactor = new RateLunchMenuInteractor(lunchMenuRepo, lunchMenuReviewRepo);
                var response = await interactor.Handle(new Core.Contracts.Dtos.RateLunchMenuRequest(model.Id, model.Courses.Select(c => (c.Id, c.ReviewScore)).ToList()));
                if (response.Result)
                {
                    model.Errors.Clear();
                }
            }
            return View(model);
        }

    }
}