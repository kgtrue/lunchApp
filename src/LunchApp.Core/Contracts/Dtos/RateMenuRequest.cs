using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateMenuRequest: IRequest<RateMenuResponse>
    {
       public RateMenuRequest(int menuId , int revierwToken ,IList<(int courseId, int reviewScore)> reviewScores)
        {         
            MenuId = menuId;
            ReviewScores = reviewScores;
            RevierwToken = revierwToken;
        }
        public int MenuId { get; private set; }
        public int RevierwToken { get; private set; }
        public IList<(int courseId, int reviewScore)> ReviewScores { get; private set; }
    }
}
