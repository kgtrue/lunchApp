using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts.Dtos
{
    public class CreateMenuRequest : IRequest<CreateMenuResponse>
    {
        public CreateMenuRequest(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; private set; }
    }
}
