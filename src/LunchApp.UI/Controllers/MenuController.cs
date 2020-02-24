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
        private readonly ILunchMenuLookupRepo lunchMenuLookupRepo;
        public MenuController(ILunchMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
        }

        public async Task<IActionResult> Index()
        {
            var interactor = new CreateLunchMenuInteractor(lunchMenuRepo, lunchMenuLookupRepo);
            var response = await interactor.Handle(new Core.Contracts.Dtos.CreateLunchMenuRequest(DateTime.Now.Date));
            var model = new MenuViewModel() { SelectedDate = DateTime.Now.Date };
            if (response.Result)
            {
                var menu = lunchMenuRepo.GetById(response.MenuId.Value);
                model.Courses = menu.LunchDishes.Select(ld =>
                    new CourseViewModel()
                    {
                    Name = ld.Name,
                    ReviewScore = ld.LunchDishRating
                    }
                ).ToList();
            }
            return View(model);
        }
    }
}