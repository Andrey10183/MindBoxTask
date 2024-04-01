using GeometryLibrary.Exceptions;
using GeometryLibrary.Extensions;

namespace GeometryLibrary.Figures;

public class Triangle : Shape
{
    private readonly double[] _sides = new double[3];

    public double SideA { get { return _sides[0]; } }
    public double SideB { get { return _sides[1]; } }
    public double SideC { get { return _sides[2]; } }

    public Triangle(
        double sideA,
        double sideB,
        double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Input values should be greater then zero");
        }

        _sides[0] = sideA;
        _sides[1] = sideB;
        _sides[2] = sideC;

        _sides = [.. _sides.OrderBy(x => x)];
    }

    public override double Area()
    {
        var p = Perimeter() / 2;

        var area = Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2]));

        if (area.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining area");
        }

        return area;
    }

    public override double Perimeter()
    {
        var result = _sides.Sum();

        if (result.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining perimeter");
        }

        return result;
    }
        
    public bool IsRightTriangle()
    {
        var sumOfLegs = _sides[0] * _sides[0] + _sides[1] * _sides[1];
        var hypotenuse = _sides[2] * _sides[2];

        if (double.IsInfinity(sumOfLegs) || double.IsInfinity(hypotenuse))
        {
            throw new CalculationOverflowException("Overflow occurred during defining right triangle");
        }

        var result = _sides[0] * _sides[0] + _sides[1] * _sides[1] == _sides[2] * _sides[2];

        return result;
    }
        
    public bool IsEquilateralTriangle() =>
        _sides[0] == _sides[1] && _sides[0] == _sides[2];

    public override string ToString()
    {
        return $"Triangle {_sides[0]}, {_sides[1]}, {_sides[2]}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Triangle)
            return false;
        else
            return
                SideA == ((Triangle)obj).SideA &&
                SideB == ((Triangle)obj).SideB &&
                SideC == ((Triangle)obj).SideC;
    }

    public override int GetHashCode()
    {
        // Combine hash codes of the fields
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + SideA.GetHashCode();
            hash = hash * 23 + SideB.GetHashCode();
            hash = hash * 23 + SideC.GetHashCode();
            return hash;
        }
    }
}
