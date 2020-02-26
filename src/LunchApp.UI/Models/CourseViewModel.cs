using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.UI.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [Range(0, 5)]
        public int ReviewScore { get; set; }
        [DisplayName("Course rating")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double ReviewScoreAverage { get; set; }
    }
}
