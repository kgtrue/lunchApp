using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts.Dtos
{
    public class CreateLunchMenuRequest : IRequest<Task<CreateLunchMenuResponse>>
    {
        public CreateLunchMenuRequest(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; private set; }
    }
}
