using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Entity
{
    public class CourseReview
    {
        public CourseReview(Course course, int reviewToken, int reviewScore)
        {
            _ = course ?? throw new NullReferenceException("Course must not be null");
            Course = course;
            ReviewScore = reviewScore;
            Id = DateTime.Now.GetHashCode();
            ReviewToken = reviewToken;
        }

        public int Id { get; private set; }
        public int ReviewToken { get; private set; }
        public Course Course { get; private set; }
        public int ReviewScore { get; set; }
    }
}
