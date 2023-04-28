using NUnit.Framework;

namespace Hello_World
{
    public class Class1
    {
        [Test]
        
        public void AddTest() 
        {
            //Arrange
            double a = 2, b = 3;

            //Act
            double result = Calculator.Addition(a, b);

            //Assert
            Assert.AreEqual(a + b, result);
        }

        [Test]

        public void DivisionTest()
        {
            //Arrange
            double a = 4, b = 4;

            //Act
            double result = Calculator.Division(a, b);

            //Assert
            Assert.AreEqual(a / b, result);
        }

        [Test]
        public void DivideZeroTest()
        {
            //Arrange
            double a = 0, b = 4;

            //Act
            double result = Calculator.Division(a, b);

            //Assert
            Assert.AreEqual(a / b, result);
        }

        [Test]

        public void DivisionByZeroTest()
        {
            try
            {
                //Arrange
                double a = 2, b = 0;

                //Act
                double result = Calculator.Division(a, b);
            }
            catch(DivideByZeroException) 
            {
                Assert.Pass("Expected Division by zero caught");
            }
            catch(Exception)
            {
                Assert.Fail("Wrong exception caught");
            }
        }
    }
}