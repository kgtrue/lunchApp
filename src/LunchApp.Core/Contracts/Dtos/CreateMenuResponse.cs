using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class CreateMenuResponse : BaseResponse 
    {
        public CreateMenuResponse(bool result, List<string> messages, int? menuId) : base(result, messages)
        {
            MenuId = menuId; 
        }

        public int? MenuId { get; private set; }
    }
}
