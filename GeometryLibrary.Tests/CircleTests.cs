using GeometryLibrary.Exceptions;
using GeometryLibrary.Figures;

namespace GeometryLibrary.Tests;

public class CircleTests
{
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void OneOfSidesIsLessThenZero_ShouldThrowArgumentException(double radius)
    {
        //Arrange, Act, Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Test]
    public void InputCorrectData_ShouldReturnCorrectArea()
    {
        //Arrange
        var circle = new Circle(3);

        //Act
        var result = circle.Area();

        //Assert
        Assert.That(result, Is.EqualTo(Math.PI * 9));
    }

    [Test]
    public void InputCorrectData_ShouldReturnCorrectPerimeter()
    {
        //Arrange
        var circle = new Circle(3);

        //Act
        var result = circle.Perimeter();

        //Assert
        Assert.That(result, Is.EqualTo(2 *Math.PI * 3));
    }

    [Test]
    [TestCase(double.MaxValue)]
    public void InputMaxValues_Perimeter_ShouldThrowCalculateOverflowException(double radius)
    {
        //Arrange
        var circle = new Circle(radius);

        //Assert
        Assert.Throws<CalculationOverflowException>(() => circle.Perimeter());
    }

    [Test]
    [TestCase(double.MaxValue)]
    public void InputMaxValues_Area_ShouldThrowCalculateOverflowException(double radius)
    {
        //Arrange
        var circle = new Circle(radius);

        //Assert
        Assert.Throws<CalculationOverflowException>(() => circle.Area());
    }
}
