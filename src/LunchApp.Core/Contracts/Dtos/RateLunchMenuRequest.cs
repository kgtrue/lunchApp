using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateLunchMenuRequest: IRequest<RateLunchMenuResponse>
    {
       public RateLunchMenuRequest(int menuId , List<(int DishId, int ReviewScore)> reviewScores)
        {         
            MenuId = menuId;
            ReviewScores = reviewScores;
        }
        public int MenuId { get; private set; }
        public List<(int DishId, int ReviewScore)> ReviewScores { get; private set; }
    }
}
