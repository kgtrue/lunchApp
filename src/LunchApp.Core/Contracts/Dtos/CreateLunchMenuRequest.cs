using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
   public class CreateLunchMenuRequest : IRequest<CreateLunchMenuResponse>
    {
        public CreateLunchMenuRequest(DateTime date)
        {
            Date = date; 
        }
        public DateTime Date { get; private set; }
    }
}
