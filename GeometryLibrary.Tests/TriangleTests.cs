using GeometryLibrary.Exceptions;
using GeometryLibrary.Figures;

namespace GeometryLibrary.Tests;

public class TriangleTests
{
    [Test]
    [TestCase(0, 2, 2)]
    [TestCase(2, 0, 2)]
    [TestCase(2, 2, 0)]
    [TestCase(-1, 2, 2)]
    [TestCase(2, -1, 2)]
    [TestCase(2, 2, -1)]
    public void OneOfSidesIsLessThenZero_ShouldThrowArgumentException(double sideA, double sideB, double sideC)
    {
        //Arrange, Act, Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Test]
    public void InputCorrectData_Area_ShouldReturnCorrectArea()
    {
        //Arrange
        var triangle = new Triangle(3, 4, 5);

        //Act
        var area = triangle.Area();

        //Assert
        Assert.That(area, Is.EqualTo(6));
    }

    [Test]
    public void InputCorrectData_Perimeter_ShouldReturnCorrectArea()
    {
        //Arrange
        var triangle = new Triangle(3, 4, 5);

        //Act
        var perimeter = triangle.Perimeter();

        //Assert
        Assert.That(perimeter, Is.EqualTo(12));
    }

    [Test]
    [TestCase(3, 4, 5, true)]
    [TestCase(3, 3, 4, false)]
    public void InputCorrectData_RightTriangle_ShouldReturnCorrectAnswer(double sideA, double sideB, double sideC, bool expectedAnswer)
    {
        //Arrange
        var triangle = new Triangle(sideA, sideB, sideC);

        //Act
        var result = triangle.IsRightTriangle();

        //Assert
        Assert.That(result, Is.EqualTo(expectedAnswer));
    }

    [Test]
    [TestCase(3, 4, 5, false)]
    [TestCase(3, 3, 3, true)]
    public void InputCorrectData_EquilateralTriangle_ShouldReturnCorrectAnswer(double sideA, double sideB, double sideC, bool expectedAnswer)
    {
        //Arrange
        var triangle = new Triangle(sideA, sideB, sideC);

        //Act
        var result = triangle.IsEquilateralTriangle();

        //Assert
        Assert.That(result, Is.EqualTo(expectedAnswer));
    }
}
