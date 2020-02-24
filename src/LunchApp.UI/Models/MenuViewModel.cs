using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.UI.Models
{
    public class MenuViewModel
    {
        public DateTime SelectedDate { get; set; }
        public IList<CourseViewModel> Courses { get; set; }
    }
}
