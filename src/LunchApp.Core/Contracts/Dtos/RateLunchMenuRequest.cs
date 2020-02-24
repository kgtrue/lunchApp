using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateLunchMenuRequest: IRequest<Task<RateLunchMenuResponse>>
    {
       public RateLunchMenuRequest(int menuId , IList<(int DishId, int ReviewScore)> reviewScores)
        {         
            MenuId = menuId;
            ReviewScores = reviewScores;
        }
        public int MenuId { get; private set; }
        public IList<(int DishId, int ReviewScore)> ReviewScores { get; private set; }
    }
}
