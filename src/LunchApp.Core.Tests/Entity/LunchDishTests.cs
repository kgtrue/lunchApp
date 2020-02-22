using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LunchApp.Core.Tests.Entity
{
    public class LunchDishTests
    {
        [Fact]
        public void MenuNullCheck()
        {
            Assert.Throws<NullReferenceException>(()=> new LunchDish(null)) ;
        }

    }
}
