using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Core.Entity
{
    public class Menu
    {
        public Menu(DateTime date)
        {
            Date = date;
            Courses = new List<Course>();
            Id = date.GetHashCode();
        }
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public virtual IList<Course> Courses { get; set; }
        public double AverageMenuReviewScore =>
            Courses.Select(cr => cr.AverageCourseReviewScore)
            .DefaultIfEmpty(0).
            Average();

        public bool AddMenuCourse(string name)
        {
            var course = new Course(this, name);
            if (Courses.Any(l => l.Id == course.Id)) { return false; }

            Courses.Add(course);
            return true;
        }
        public bool AddUpdateReview(int courseId, int reviewToken, int reviewScore)
        {
            if (!Courses.Any(c => c.Id == courseId))
                return false;

            if (reviewScore > 5 || reviewScore < 0)
                return false;

            var cource = Courses.Single(c => c.Id == courseId);
            if (cource.CourseReviews.Any(cr => cr.ReviewToken == reviewToken))
            {
                var review = cource.CourseReviews.SingleOrDefault(cr => cr.ReviewToken == reviewToken);
                review.ReviewScore = reviewScore;
            }
            else
            {
                cource.CourseReviews.Add(new CourseReview(cource, reviewToken, reviewScore));
            }

            return true;
        }
    }
}
