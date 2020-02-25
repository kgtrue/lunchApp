using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.UI.Models
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            Courses = new List<CourseViewModel>();
            Errors = new List<string>();
        }

        public int ReviewToken { get; set; }
        public int? Id { get; set; }
        [DisplayName("Dato")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime SelectedDate { get; set; }
        public IList<CourseViewModel> Courses { get; set; }
        public IList<string> Errors { get; set; }
        [DisplayName("Menu Rating")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double MenuRating { get; set; }
        public bool Answered { get; set; }
    }
}
