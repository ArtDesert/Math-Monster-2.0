using System.Globalization;

namespace Algebra.ComplexNumbers;

/// <summary>
/// A complex number.
/// </summary>
public class Complex
{
    private const double Epsilon = 1e-10;

    /// <summary>
    /// The real part. 
    /// </summary>
    public double Re { get; }

    /// <summary>
    /// The imaginary part. 
    /// </summary>
    public double Im { get; }

    /// <summary>
    /// Creates a complex number with a zero real and imaginary parts.
    /// </summary>
    public Complex() => Re = Im = 0.0;

    /// <summary>
    /// Creates a complex number with a zero real and imaginary parts.
    /// </summary>
    /// <param name="re">The real part.</param>
    /// <param name="im">The imaginary part.</param>
    public Complex(double re, double im)
    {
        Re = re;
        Im = im;
    }

    /// <summary>
    /// Returns the string representation of a complex number.
    /// </summary>
    public override string ToString() =>
        string.Format(
            CultureInfo.InvariantCulture,
            (Re, Im) switch
            {
                (_, 0) => "{0}",
                (0, _) => "{0}i",
                (_, < 0) => "{0}{1}i",
                _ => "{0}+{1}i"
            }, Re, Im);

    /// <summary>
    /// Возвращает модуль комплексного числа
    /// </summary>
    /// <returns></returns>
    public double Mod()
    {
        return Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
    }

    /// <summary>
    /// Returns the amount of two complex numbers.
    /// </summary>
    /// <param name="a">The first term.</param>
    /// <param name="b">The second term.</param>
    /// <returns>The amount.</returns>
    public static Complex operator +(Complex a, Complex b) =>
        new(a.Re + b.Re, a.Im + b.Im);

    /// <summary>
    /// The unary minus operator.
    /// </summary>
    /// <param name="a">A complex number.</param>
    /// <returns>A complex number with the opposite sign.</returns>
    public static Complex operator -(Complex a) => new(-a.Re, -a.Im);

    /// <summary>
    /// Returns the difference of two complex numbers.
    /// </summary>
    /// <param name="a">The reduced.</param>
    /// <param name="b">The deductible.</param>
    /// <returns>The difference.</returns>
    public static Complex operator -(Complex a, Complex b) => new(a.Re - b.Re, a.Im - b.Im);

    public static Complex operator *(Complex a, Complex b)
        => new(
            a.Re * b.Re - a.Im * b.Im,
            a.Re * b.Im + a.Im * b.Re);

    public static Complex operator /(Complex a, Complex b)
    {
        var denominator = b.Re * b.Re + b.Im * b.Im;
        return new Complex(
            (a.Re * b.Re + a.Im * b.Im) / denominator,
            (a.Im * b.Re - a.Re * b.Im) / denominator);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj == null || obj.GetType() != typeof(Complex))
        {
            return false;
        }

        var complex = obj as Complex;
        return Math.Abs(Re - complex.Re) < Epsilon && Math.Abs(Im - complex.Im) < Epsilon;
    }

    public override int GetHashCode() => HashCode.Combine(Re, Im);
}