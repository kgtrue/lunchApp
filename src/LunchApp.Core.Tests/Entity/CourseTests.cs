using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LunchApp.Core.Tests.Entity
{
    public class CourseTests
    {
        [Fact]
        public void MenuNullCheck()
        {
            Assert.Throws<NullReferenceException>(()=> new Course(null, "")) ;
        }             
    }
}
