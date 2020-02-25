using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Core.Entity
{
    public class Course
    {
        public Course(Menu lunchMenu, string name)
        {
            _ = lunchMenu ?? throw new NullReferenceException("lunch menu must not be null");
            _ = name ?? throw new NullReferenceException("Name must not be null");
            
            Name = name;
            LunchMenu = lunchMenu;
            CourseReviews = new List<CourseReview>();
            Id = LunchMenu.GetHashCode() + name.GetHashCode(); 
        }       

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Menu LunchMenu { get; private set; }  
        public virtual IList<CourseReview> CourseReviews { get; set; }

        public double AverageCourseReviewScore => 
            CourseReviews.Select(cr => cr.ReviewScore)
            .DefaultIfEmpty(0).
            Average();    
    }
}
