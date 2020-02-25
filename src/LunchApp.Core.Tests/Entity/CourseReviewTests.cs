using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
namespace LunchApp.Core.Tests.Entity
{
    public class CourseReviewTests
    {
        [Fact]
        public void TestCourseNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new CourseReview(null, 1, 1));
        }
    }
}
