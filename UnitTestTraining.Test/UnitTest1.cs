using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestTraining;

namespace UnitTestTraining.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MyMath_Add_ShouldReturnSum()
        {
            //Arrange
            var myMath = new MyMath();
            int x = 10;
            int y = 20;
            
            //Act
            var result= myMath.Add(x, y);

            //Assert
            Assert.IsTrue(result == 30);
        }
    }
}
