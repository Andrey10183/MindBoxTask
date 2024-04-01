using GeometryLibrary.Figures;

namespace GeometryLibrary.Tests;

public class CommonTests
{
    [Test]
    public void CalculateAreaOfShapes()
    {
        var rectangle = new Rectangle(3, 4);
        var triangle = new Triangle(3, 4, 5);
        var circle = new Circle(10);

        var shapes = new List<Shape>() { rectangle, triangle, circle };

        var result = shapes
            .Select(x => new ShapeParams
            {
                Area = x.Area(),
                Perimeter = x.Perimeter(),
            } )
            .ToList();

        Assert.That(result[0].Area, Is.EqualTo(12));
        Assert.That(result[0].Perimeter, Is.EqualTo(14));
        Assert.That(result[1].Area, Is.EqualTo(6));
        Assert.That(result[1].Perimeter, Is.EqualTo(12));
        Assert.That(result[2].Area, Is.EqualTo(Math.PI * 100));
        Assert.That(result[2].Perimeter, Is.EqualTo(Math.PI * 20));
    }
}

public class ShapeParams
{
    public double Area { get; set; }
    public double Perimeter { get; set; }
}
