using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateLunchMenuRequest: IRequest<RateLunchMenuResponse>
    {
       public RateLunchMenuRequest(int menuId , IList<(int DishId, uint ReviewScore)> reviewScores)
        {         
            MenuId = menuId;
            ReviewScores = reviewScores;
        }
        public int MenuId { get; private set; }
        public IList<(int DishId, uint ReviewScore)> ReviewScores { get; private set; }
    }
}
