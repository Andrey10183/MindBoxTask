using GeometryLibrary.Exceptions;
using GeometryLibrary.Figures;

namespace GeometryLibrary.Tests
{
    public class RectangleTests
    {
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void OneOfSidesIsLessThenZero_ShouldThrowArgumentException(double side1, double side2)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(side1, side2));
        }

        [Test] 
        public void InputCorrectData_ShouldReturnCorrectArea()
        {
            //Arrange
            var rectangle = new Rectangle(3, 4);

            //Act
            var area = rectangle.Area();

            //Assert
            Assert.That(area, Is.EqualTo(12));
        }

        [Test]
        public void InputCorrectData_ShouldReturnCorrectPerimeter()
        {
            //Arrange
            var rectangle = new Rectangle(3, 4);

            //Act
            var perimeter = rectangle.Perimeter();

            //Assert
            Assert.That(perimeter, Is.EqualTo(14));
        }

        [Test]
        [TestCase(3, 4, false)]
        [TestCase(4, 4, true)]
        public void IsSquare_ShouldReturnCorrectAnswer(double side1, double side2, bool isSquare)
        {
            //Arrange
            var rectangle = new Rectangle(side1, side2);

            //Act
            var result = rectangle.IsSquare();

            //Assert
            Assert.That(result, Is.EqualTo(isSquare));
        }

        [Test]
        [TestCase(3, double.MaxValue)]
        [TestCase(double.MaxValue, 4)]
        public void InputMaxValues_Perimeter_ShouldThrowCalculateOverflowException(double side1, double side2)
        {
            //Arrange
            var rectangle = new Rectangle(side1, side2);

            //Assert
            Assert.Throws<CalculationOverflowException>(() => rectangle.Perimeter());
        }

        [Test]
        [TestCase(3, double.MaxValue)]
        [TestCase(double.MaxValue, 4)]
        public void InputMaxValues_Area_ShouldThrowCalculateOverflowException(double side1, double side2)
        {
            //Arrange
            var rectangle = new Rectangle(side1, side2);

            //Assert
            Assert.Throws<CalculationOverflowException>(() => rectangle.Area());
        }
    }
}