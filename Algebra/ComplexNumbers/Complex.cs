using System.Diagnostics;
using System.Globalization;

namespace Algebra.ComplexNumbers;

/// <summary>
/// A complex number.
/// </summary>
public class Complex
{
    /// <summary>
    /// Accuracy for comparing doubles for equality.
    /// </summary>
    private const double Epsilon = 1e-6;
    
    private Complex(double re, double im, double mod, double arg)
    {
        Re = re;
        Im = im;
        Mod = mod;
        Arg = arg;
    }

    /// <summary>
    /// Returns the real part. 
    /// </summary>
    public double Re { get; }

    /// <summary>
    /// Returns the imaginary part. 
    /// </summary>
    public double Im { get; }

    /// <summary>
    /// Returns the modulus.
    /// </summary>
    public double Mod { get; }

    /// <summary>
    /// Returns the argument.
    /// </summary>
    public double Arg { get; }

    /// <summary>
    /// The factory method of creating a complex number from Cartesian form.
    /// </summary>
    /// <param name="re">The real part.</param>
    /// <param name="im">The imagine part.</param>
    /// <returns>New complex number.</returns>
    public static Complex FromCartesian(double re, double im)
    {
        var mod = Math.Sqrt(re * re + im * im);
        var arg = (re, im) switch
        {
            (0, 0) => double.NaN,
            (_, 0) => 0,
            (0, _) => Math.PI / 2 * Math.Sign(im),
            (> 0, _) => Math.Atan(im / re),
            (< 0, _) => Math.Atan(im / re) + Math.PI,
            _ => throw new UnreachableException("All cases are covered.")
        };
        return new Complex(re, im, mod, arg);
    }
    
    /// <summary>
    /// The factory method of creating a complex number from polar form.
    /// </summary>
    /// <param name="mod">Modulus.</param>
    /// <param name="arg">Argument.</param>
    /// <returns>New complex number.</returns>
    /// <exception cref="ComplexException">The modulus is equal to zero.</exception>
    public static Complex FromPolar(double mod, double arg)
    {
        if (mod == 0)
        {
            throw new ComplexException("There is no polar form for a zero complex number.");
        }

        var re = mod * Math.Cos(arg);
        var im = mod * Math.Sin(arg);
        return new Complex(re, im, mod, arg);
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
                (0, 1) => "i",
                (0, _) => "{1}i",
                (_, < 0) => "{0}{1}i",
                _ => "{0}+{1}i"
            }, Re, Im);

    /// <summary>
    /// Returns the amount of two complex numbers.
    /// </summary>
    /// <param name="a">The first term.</param>
    /// <param name="b">The second term.</param>
    /// <returns>The amount.</returns>
    public static Complex operator +(Complex a, Complex b) =>
        FromCartesian(a.Re + b.Re, a.Im + b.Im);

    /// <summary>
    /// The unary minus operator.
    /// </summary>
    /// <param name="a">A complex number.</param>
    /// <returns>A complex number with the opposite sign.</returns>
    public static Complex operator -(Complex a) => FromCartesian(-a.Re, -a.Im);

    /// <summary>
    /// Returns the difference of two complex numbers.
    /// </summary>
    /// <param name="a">The reduced.</param>
    /// <param name="b">The deductible.</param>
    /// <returns>The difference.</returns>
    public static Complex operator -(Complex a, Complex b) => FromCartesian(a.Re - b.Re, a.Im - b.Im);

    /// <summary>
    /// Returns the product of two complex numbers.
    /// </summary>
    /// <param name="a">The first multiplier.</param>
    /// <param name="b">The second multiplier.</param>
    public static Complex operator *(Complex a, Complex b)
        => FromCartesian(
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
        return FromCartesian(
            (a.Re * b.Re + a.Im * b.Im) / denominator,
            (a.Im * b.Re - a.Re * b.Im) / denominator);
    }

    /// <summary>
    /// Raises a complex number to a given degree.
    /// </summary>
    /// <param name="a">The basis of the degree.</param>
    /// <param name="degree">Degree.</param>
    public static Complex operator ^(Complex a, int degree)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the roots of a complex number of a given degree.
    /// </summary>
    /// <param name="degree">De</param>
    /// <returns></returns>
    public static Complex[] FindRoots(int degree)
    {
        throw new NotImplementedException();
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