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
                (0, _) => "{1}i",
                (_, < 0) => "{0}{1}i",
                _ => "{0}+{1}i"
            }, Re, Im);

    /// <summary>
    /// Returns the modulus of a complex number.
    /// </summary>
    public double Mod => Math.Sqrt(Re * Re + Im * Im);

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

    /// <summary>
    /// Returns the product of two complex numbers.
    /// </summary>
    /// <param name="a">The first multiplier.</param>
    /// <param name="b">The second multiplier.</param>
    public static Complex operator *(Complex a, Complex b)
        => new(
            a.Re * b.Re - a.Im * b.Im,
            a.Re * b.Im + a.Im * b.Re);

    /// <summary>
    /// Returns the quotient of two complex numbers.
    /// </summary>
    /// <param name="a">The numerator.</param>
    /// <param name="b">The denominator.</param>
    /// <exception cref="DivideByZeroException">The denominator is equal to zero.</exception>
    public static Complex operator /(Complex a, Complex b)
    {
        if (b is { Re: 0, Im: 0 })
        {
            throw new DivideByZeroException();
        }

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

        return obj is Complex complex
               && Math.Abs(Re - complex.Re) < Epsilon
               && Math.Abs(Im - complex.Im) < Epsilon;
    }

    public override int GetHashCode() => HashCode.Combine(Re, Im);
}