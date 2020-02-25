using LunchApp.Core.Contracts;
using LunchApp.Core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LunchApp.Core.Entity;
using System.Threading.Tasks;

namespace LunchApp.Core.Interactors
{
    public class CreateMenuInteractor : IRequestHandler<CreateMenuRequest, CreateMenuResponse>
    {
        private readonly IMenuRepo lunchMenuRepo;
        private readonly ILunchMenuLookupRepo lunchMenuLookupRepo;

        public CreateMenuInteractor(IMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
        }

        public CreateMenuResponse Handle(CreateMenuRequest message)
        {
            var errors = new List<string>();
            var lunchMenuLookup = lunchMenuLookupRepo.GetByDate(message.Date).Result;
            int? menuId = null;
            if (lunchMenuLookup != null)
            {
                var lunchMenu = new Menu(lunchMenuLookup.Date);
                var exsistingMenu = lunchMenuRepo.GetById(lunchMenu.Id);

                if (exsistingMenu != null)
                {
                    errors.Add($"Menu already exists.");
                }

                foreach (var courceLookup in lunchMenuLookup.Course)
                {
                    if (!lunchMenu.AddMenuCourse(courceLookup))
                    {
                        errors.Add($"The dish { courceLookup} can not be added to menu.");
                    }
                }

                if (!errors.Any())
                {
                    lunchMenuRepo.SaveUpdate(lunchMenu);
                    menuId = lunchMenu.Id;
                }
            }
            else
            {
                errors.Add($"No menu exists on { message.Date.ToString("dd/MM/yy")}");
            }

            return new CreateMenuResponse(!errors.Any(), errors, menuId);
        }
    }
}
