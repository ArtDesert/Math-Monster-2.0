using Algebra.ComplexNumbers;

namespace AlgebraTests.ComplexNumbers;

public static class ComplexTestCases
{
    public static TheoryData<Complex, Complex, Complex> AdditionTestCases => new()
    {
        { new Complex(1, 2), new Complex(3, 4), new Complex(4, 6) },
        { new Complex(-1, -2), new Complex(3, 4), new Complex(2, 2) },
        { new Complex(0, 0), new Complex(0, 0), new Complex(0, 0) },
        { new Complex(5, 0), new Complex(0, 3), new Complex(5, 3) },
        
        { new Complex(-5.2, -3.5), new Complex(-2.3, -1.1), new Complex(-7.5, -4.6) },
        { new Complex(4.35, -2.25), new Complex(4.75, 12.59), new Complex(9.1, 10.34) },
        { new Complex(2.2, -3.5), new Complex(-2.2, 4.5), new Complex(0, 1) },
    };
    
    public static TheoryData<Complex, Complex, Complex> SubstractionTestCases => new()
    {
        { new Complex(1, 2), new Complex(3, 4), new Complex(-2, -2) },
        { new Complex(-1, -2), new Complex(3, 4), new Complex(-4, -6) },
        { new Complex(0, 0), new Complex(0, 0), new Complex(0, 0) },
        { new Complex(5, 0), new Complex(0, 3), new Complex(5, -3) },
        
        { new Complex(-5.2, -3.5), new Complex(-2.3, -1.1), new Complex(-2.9, -2.4) },
        { new Complex(4.35, -2.25), new Complex(4.75, 12.59), new Complex(-0.4, -14.84) },
        { new Complex(-2.2, -3.5), new Complex(-2.2, 4.5), new Complex(0, -8) },
    };
    
    public static TheoryData<Complex, Complex, Complex> MultiplicationTestCases => new()
    {
        { new Complex(1, 2), new Complex(3, 4), new Complex(-5, 10) },
        { new Complex(-1, -2), new Complex(3, 4), new Complex(5, -10) },
        { new Complex(0, 0), new Complex(0, 0), new Complex(0, 0) },
        { new Complex(5, 0), new Complex(0, 3), new Complex(0, 15) },
        
        { new Complex(-5.2, 3.5), new Complex(-2.3, -1.1), new Complex(15.81, -2.33) },
        { new Complex(4.35, -2.25), new Complex(4.75, 12.59), new Complex(48.99, 44.079) },
        { new Complex(2.2, -3.5), new Complex(-2.2, 4.5), new Complex(10.91, 17.6) },
    };
    
    public static TheoryData<Complex, Complex> UnaryMinusOperatorTestCases => new()
    {
        { new Complex(1, 2), new Complex(-1, -2) },
        { new Complex(-3, -4), new Complex(3, 4) },
        { new Complex(0, 0), new Complex(0, 0) },
        
        { new Complex(-5.2, 3.5), new Complex(5.2, -3.5) },
        { new Complex(4.35, -2.25), new Complex(-4.35, 2.25) },
    };
}