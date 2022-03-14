namespace Otus.Learning;

public class QuadraticEquation
{
    private readonly double _epsilon = 0.001;

    public QuadraticEquation()
    {
        
    }
    public QuadraticEquation(double epsilon)
    {
        _epsilon = epsilon;
    }

    /// <summary>
    /// Метод находит корни квадратного уравнения вида: a*x2 + b*x + c = 0
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns>Массив корней уравнения</returns>
    public double[] Solve(double a, double b, double c)
    {
        IfCoefficientsNotFiniteThenException(a, b, c);
        IfCoefficientANotEpsilonRangeThenException(a);

        var discriminant = Math.Pow(b, 2) - 4 * a * c;
        IfDiscriminantNotFiniteThenException(discriminant);
        if (Math.Abs(discriminant) < _epsilon)
        {
            var x = -b / (2 * a);
            return new[] { x };
        }

        if (discriminant > _epsilon)
        {
            var x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            var x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return new[] { x1, x2 };
        }
        
        return Array.Empty<double>();
    }

    /// <summary>
    /// Метод проверяет, являются ли коэффициенты уравнения вещественными числами 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <exception cref="ArgumentException"></exception>
    private void IfCoefficientsNotFiniteThenException(double a, double b, double c)
    {
        if (!double.IsFinite(a) || !double.IsFinite(b) || !double.IsFinite(c))
        {
            throw new ArgumentException("Коэффициенты уравнения должны быть вещестенным числом");
        }
    }

    /// <summary>
    /// Метод проверяет находится ли коэффициента 'а' в диапазоне точности
    /// </summary>
    /// <param name="a"></param>
    /// <exception cref="ArgumentException"></exception>
    private void IfCoefficientANotEpsilonRangeThenException(double a)
    {
        if (Math.Abs(a) < _epsilon)
        {
            throw new ArgumentException("В квадратном уравнение коэффициент 'a' не может быть равен 0");
        }
    }

    /// <summary>
    /// Метод проверяет, является ли дискриминант вещественным числом
    /// </summary>
    /// <param name="d"></param>
    /// <exception cref="ArithmeticException"></exception>
    private void IfDiscriminantNotFiniteThenException(double d)
    {
        if (!double.IsFinite(d))
        {
            throw new ArithmeticException("Дискриминант должен быть вещественным числом");
        }
    }
}