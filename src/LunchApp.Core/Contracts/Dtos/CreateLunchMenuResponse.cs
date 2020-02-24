using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class CreateLunchMenuResponse : BaseResponse 
    {
        public CreateLunchMenuResponse(bool result, List<string> messages, int? menuId) : base(result, messages)
        {
            MenuId = MenuId; 
        }

        public int? MenuId { get; private set; }
    }
}
