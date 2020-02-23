using LunchApp.Core.Contracts;
using LunchApp.Core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LunchApp.Core.Entity;

namespace LunchApp.Core.Interactors
{
    public class CreateLunchMenuInteractor : IRequestHandler<CreateLunchMenuRequest, CreateLunchMenuResponse>
    {
        private readonly ILunchMenuRepo lunchMenuRepo;
        private readonly ILunchMenuLookupRepo lunchMenuLookupRepo;

        public CreateLunchMenuInteractor(ILunchMenuRepo lunchMenuRepo, ILunchMenuLookupRepo lunchMenuLookupRepo)
        {
            this.lunchMenuRepo = lunchMenuRepo;
            this.lunchMenuLookupRepo = lunchMenuLookupRepo;
        }

        public CreateLunchMenuResponse Handle(CreateLunchMenuRequest message)
        {
            var errors = new List<string>();
            var lunchMenuLookup = lunchMenuLookupRepo.GetByDate(message.Date).Result;

            if (lunchMenuLookup != null)
            {
                var lunchMenu = new LunchMenu(lunchMenuLookup.Date);
                foreach (var courceLookup in lunchMenuLookup.Course)
                {
                    if (!lunchMenu.AddLunchMenuDish(courceLookup))
                    {
                        errors.Add($"The dish { courceLookup} can not be added to menu.");
                    }
                }
                lunchMenuRepo.SaveUpdate(lunchMenu);
            }
            else
            {
                errors.Add($"No menu exists on { message.Date.ToString("ddMMyy")}");
            }

            return new CreateLunchMenuResponse(!errors.Any(), errors);
        }
    }
}
