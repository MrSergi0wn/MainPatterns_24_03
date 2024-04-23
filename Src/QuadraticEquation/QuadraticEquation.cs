namespace MainPatterns.QuadraticEquation;

public class QuadraticEquation : IQuadraticEquation
{
    /// <summary>
    /// Решение квадратного уравнения a^2*x + bx + c = 0, где x - переменная; a, b, c - любое число, где a != 0
    /// </summary>
    public double[] Solve(double a, double b, double c)
    {
        this.InvalidValuesHandler(a, b, c);

        var discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant < -double.Epsilon) return new double[] { };

        if (Math.Abs(discriminant) <= double.Epsilon) return new double[] { -b / 2 * a };

        return discriminant > double.Epsilon ? new double[] { (-b + Math.Sqrt(discriminant)) / 2 * a, (-b - Math.Sqrt(discriminant)) / 2 * a } : new double[] { };
    }

    private void InvalidValuesHandler(double a, double b, double c)
    {
        if (Math.Abs(a) < double.Epsilon) throw new Exception("Коэфициент 'a' не может быть эквивалентен нулю!");

        if (double.IsNaN(a) || double.IsInfinity(a)) throw new Exception();
        if (double.IsNaN(b) || double.IsInfinity(b)) throw new Exception();
        if (double.IsNaN(c) || double.IsInfinity(c)) throw new Exception();
    }
}
