using GeometryLibrary.Exceptions;
using GeometryLibrary.Extensions;

namespace GeometryLibrary.Figures;

/// <summary>
/// Provide methods for calculating geometric parameters of a Circle
/// </summary>
public class Circle : Shape
{
    private readonly double _radius;

    public double Radius { get { return _radius; } }
    public double Diameter { get { return 2 * _radius; } }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("radius value should be greater then zero");
        }

        _radius = radius;
    }

    public override double Area()
    {
        var area = Math.PI * _radius * _radius;

        if (area.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining circle area");
        }

        return Math.PI * _radius * _radius;
    }

    public override double Perimeter()
    {
        var perimeter = 2 * Math.PI * _radius;

        if ( perimeter.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining circle perimeter");
        }

        return  perimeter;
    }

    public override string ToString()
    {
        return $"Circle {_radius}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Circle)
         return false;
      else
        return Radius == ((Circle)obj).Radius;
    }

    public override int GetHashCode()
    {
        return _radius.GetHashCode();
    }
}
