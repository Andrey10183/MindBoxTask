namespace GeometryLibrary.Extensions;

public static class DoubleExtensions
{
    public static bool IsOverflow(this double input)
    {
        return (double.IsInfinity(input));
    }
}
