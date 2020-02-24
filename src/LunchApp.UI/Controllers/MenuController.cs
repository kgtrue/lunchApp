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
        public MenuController(IMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
        }

        public IActionResult Index()
        {
            var model = new MenuViewModel() { SelectedDate = DateTime.Now.Date };
            var menu = lunchMenuRepo.GetById(DateTime.Now.Date.GetHashCode());

            if (menu == null)
            {
                var interactor = new CreateMenuInteractor(lunchMenuRepo, lunchMenuLookupRepo);
                var response = interactor.Handle(new Core.Contracts.Dtos.CreateMenuRequest(DateTime.Now.Date));
                if (response.Result)
                    menu = lunchMenuRepo.GetById(response.MenuId.Value);

            }
            if (menu != null)
            {
                model.Id = menu.Id;
                model.MenuRating = 0;
                model.Courses = menu.Courses.Select(ld =>
                            new CourseViewModel()
                            {
                                Id = ld.Id,
                                Name = ld.Name,
                                ReviewScoreAverage = 0
                            }
                        ).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var interactor = new RateMenuInteractor(lunchMenuRepo);
                var ratings = model.Courses.Select(c => (c.Id, c.ReviewScore)).ToList();
                var response = interactor.Handle(new Core.Contracts.Dtos.RateMenuRequest(model.Id, ratings));
                if (response.Result)
                {
                    model.Errors.Clear();
                }

                model.MenuRating = 0;
                foreach (var cource in model.Courses)
                {
                    cource.ReviewScoreAverage = 0;
                }

            }
            return View(model);
        }

    }
}