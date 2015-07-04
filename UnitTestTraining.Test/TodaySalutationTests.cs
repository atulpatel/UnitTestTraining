using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssert;
using UnitTestTraining;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace UnitTestTraining.Tests
{
    [TestClass()]
    public class TodaySalutationTests
    {

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TodaySalutation_Salutation_ShouldThrowException()
        {
            //Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(x => x.Now).Throws<ArgumentNullException>();
            var todaySalutation = new TodaySalutation(mockClock.Object);

            //Act
            var result = todaySalutation.Salutation();

            //Assert
            Assert.IsTrue(result == StringConstant.MORNING);
        }

        [TestMethod()]
        public void TodaySalutation_Salutation_ShouldReturnMorning()
        {
            //Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(x => x.Now).Returns(new DateTime(2015, 1, 1, 10, 0, 0));
            var todaySalutation = new TodaySalutation(mockClock.Object);

            //Act
            var result= todaySalutation.Salutation();

            //Assert
            Assert.IsTrue(result == StringConstant.MORNING);
        }

        [TestMethod()]
        public void TodaySalutation_Salutation_ShouldReturnAfterNoon()
        {
            //Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(x => x.Now).Returns(new DateTime(2015, 1, 1, 13, 0, 0));
            var todaySalutation = new TodaySalutation(mockClock.Object);

            //Act
            var result = todaySalutation.Salutation();

            //Assert
            Assert.IsTrue(result == StringConstant.AFTERNOON);

            result.ShouldBeEqualTo(StringConstant.AFTERNOON);
        }

        [TestMethod()]
        public void TodaySalutation_Salutation_ShouldReturnEvening()
        {
            //Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(x => x.Now).Returns(new DateTime(2015, 1, 1, 18, 0, 0));
            var todaySalutation = new TodaySalutation(mockClock.Object);

            //Act
            var result = todaySalutation.Salutation();

            //Assert
            Assert.IsTrue(result == StringConstant.EVENING);
        }
    }

    class MorningClock : IClock
    {
        public DateTime Now
        {
            get { return new DateTime(2015, 1, 1, 10, 0, 0); }
        }
    }

    class AfterNoonClock : IClock
    {
        public DateTime Now
        {
            get { return new DateTime(2015, 1, 1, 13, 0, 0); }
        }
    }


    class EveningNoonClock : IClock
    {
        public DateTime Now
        {
            get { return new DateTime(2015, 1, 1, 18, 0, 0); }
        }
    }
}
