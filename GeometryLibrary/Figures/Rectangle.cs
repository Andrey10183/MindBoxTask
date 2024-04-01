using GeometryLibrary.Exceptions;
using GeometryLibrary.Extensions;

namespace GeometryLibrary.Figures;

public class Rectangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;

    public double SideA { get { return _sideA; } }
    public double SideB { get { return _sideB; } }

    public Rectangle(double sideA, double sideB)
    {
        if (sideA <= 0 || sideB<=0 ) 
        {
            throw new ArgumentException("Side values should be greater then zero");
        }

        _sideA = sideA;
        _sideB = sideB;
    }

    public override double Area()
    {
        var result = _sideA * _sideB;

        if (result.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining rectangle area");
        }

        return result;
    }
        

    public override double Perimeter()
    {
        var result = 2 * _sideA + 2 * _sideB;

        if ( result.IsOverflow())
        {
            throw new CalculationOverflowException("Overflow occurred during defining rectangle perimeter");
        }

        return result;
    }
        

    public bool IsSquare() =>
        _sideA == _sideB;

    public override string ToString()
    {
        return $"Rectangle {_sideA}, {_sideB}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Rectangle)
            return false;
        else
            return 
                SideA == ((Rectangle)obj).SideA &&
                SideB == ((Rectangle)obj).SideB;
    }

    public override int GetHashCode()
    {
        // Combine hash codes of the fields
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + SideA.GetHashCode();
            hash = hash * 23 + SideB.GetHashCode();
            return hash;
        }
    }
}
