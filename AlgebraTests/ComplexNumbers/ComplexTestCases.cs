using Algebra.ComplexNumbers;

namespace AlgebraTests.ComplexNumbers;

public static class ComplexTestCases
{
    public static TheoryData<Complex, Complex, Complex> AdditionTestCases => new()
    {
        { Complex.FromCartesian(1, 2), Complex.FromCartesian(3, 4), Complex.FromCartesian(4, 6) },
        { Complex.FromCartesian(-1, -2), Complex.FromCartesian(3, 4), Complex.FromCartesian(2, 2) },
        { Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0) },
        { Complex.FromCartesian(5, 0), Complex.FromCartesian(0, 3), Complex.FromCartesian(5, 3) },
        
        { Complex.FromCartesian(-5.2, -3.5), Complex.FromCartesian(-2.3, -1.1), Complex.FromCartesian(-7.5, -4.6) },
        { Complex.FromCartesian(4.35, -2.25), Complex.FromCartesian(4.75, 12.59), Complex.FromCartesian(9.1, 10.34) },
        { Complex.FromCartesian(2.2, -3.5), Complex.FromCartesian(-2.2, 4.5), Complex.FromCartesian(0, 1) },
    };
    
    public static TheoryData<Complex, Complex, Complex> SubstractionTestCases => new()
    {
        { Complex.FromCartesian(1, 2), Complex.FromCartesian(3, 4), Complex.FromCartesian(-2, -2) },
        { Complex.FromCartesian(-1, -2), Complex.FromCartesian(3, 4), Complex.FromCartesian(-4, -6) },
        { Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0) },
        { Complex.FromCartesian(5, 0), Complex.FromCartesian(0, 3), Complex.FromCartesian(5, -3) },
        
        { Complex.FromCartesian(-5.2, -3.5), Complex.FromCartesian(-2.3, -1.1), Complex.FromCartesian(-2.9, -2.4) },
        { Complex.FromCartesian(4.35, -2.25), Complex.FromCartesian(4.75, 12.59), Complex.FromCartesian(-0.4, -14.84) },
        { Complex.FromCartesian(-2.2, -3.5), Complex.FromCartesian(-2.2, 4.5), Complex.FromCartesian(0, -8) },
    };
    
    public static TheoryData<Complex, Complex, Complex> MultiplicationTestCases => new()
    {
        { Complex.FromCartesian(1, 2), Complex.FromCartesian(3, 4), Complex.FromCartesian(-5, 10) },
        { Complex.FromCartesian(-1, -2), Complex.FromCartesian(3, 4), Complex.FromCartesian(5, -10) },
        { Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0) },
        { Complex.FromCartesian(5, 0), Complex.FromCartesian(0, 3), Complex.FromCartesian(0, 15) },
        
        { Complex.FromCartesian(-5.2, 3.5), Complex.FromCartesian(-2.3, -1.1), Complex.FromCartesian(15.81, -2.33) },
        { Complex.FromCartesian(4.35, -2.25), Complex.FromCartesian(4.75, 12.59), Complex.FromCartesian(48.99, 44.079) },
        { Complex.FromCartesian(2.2, -3.5), Complex.FromCartesian(-2.2, 4.5), Complex.FromCartesian(10.91, 17.6) },
    };
    
    public static TheoryData<Complex, Complex> UnaryMinusOperatorTestCases => new()
    {
        { Complex.FromCartesian(1, 2), Complex.FromCartesian(-1, -2) },
        { Complex.FromCartesian(-3, -4), Complex.FromCartesian(3, 4) },
        { Complex.FromCartesian(0, 0), Complex.FromCartesian(0, 0) },
        
        { Complex.FromCartesian(-5.2, 3.5), Complex.FromCartesian(5.2, -3.5) },
        { Complex.FromCartesian(4.35, -2.25), Complex.FromCartesian(-4.35, 2.25) },
    };
    
    public static TheoryData<Complex, Complex, Complex> DivisionTestCases => new()
    {
        { Complex.FromCartesian(1, 2), Complex.FromCartesian(3, 4), Complex.FromCartesian(0.44, 0.08) },
        { Complex.FromCartesian(-1, -2), Complex.FromCartesian(3, 4), Complex.FromCartesian(-0.44, -0.08) },
        { Complex.FromCartesian(5, 0), Complex.FromCartesian(0, 3), Complex.FromCartesian(0, -1.6666666667) },
        { Complex.FromCartesian(4, 0), Complex.FromCartesian(2, 0), Complex.FromCartesian(2, 0) },
        { Complex.FromCartesian(0, 5), Complex.FromCartesian(0, -10), Complex.FromCartesian(-0.5, 0) },
        
        { Complex.FromCartesian(-5.2, 3.5), Complex.FromCartesian(-2.3, -1.1), Complex.FromCartesian(1.2476923077,  - 2.1184615385) },
        { Complex.FromCartesian(4.35, -2.25), Complex.FromCartesian(4.75, 12.59), Complex.FromCartesian(-0.0423315547, -0.3614833109) },
        { Complex.FromCartesian(2.233, 33.5), Complex.FromCartesian(2.233, 33.5), Complex.FromCartesian(1, 0) },
    };
    
    public static TheoryData<Complex, double> ModTestCases => new()
    {
        { Complex.FromCartesian(3, 4), 5},
        { Complex.FromCartesian(-1, -2), 2.236068},
        { Complex.FromCartesian(0, 0), 0 },
        { Complex.FromCartesian(10, 0), 10 },
        { Complex.FromCartesian(0, -100), 100 },
        
        { Complex.FromCartesian(-5.2, 3.5), 6.268174 },
        { Complex.FromCartesian(0.6, 0.8), 1 },
        { Complex.FromCartesian(-5.381928, 0),  5.381928},
        { Complex.FromCartesian(0, 42.41),  42.41},
    };
    
    public static TheoryData<Complex, double> ArgumentTestCases => new()
    {
        // Boundary cases.
        { Complex.FromCartesian(0, 1), Math.PI / 2},
        { Complex.FromCartesian(0, -5), -Math.PI / 2 },
        { Complex.FromCartesian(1, 0), 0 },
        { Complex.FromCartesian(-5, 0), 0 },
        { Complex.FromCartesian(0, 1.125), Math.PI / 2},
        { Complex.FromCartesian(0, -5.75), -Math.PI / 2 },
        { Complex.FromCartesian(1.625, 0), 0 },
        { Complex.FromCartesian(-5.9281928, 0), 0 },
        
        // Cases when Re > 0.
        { Complex.FromCartesian(1, 1), Math.PI / 4},
        { Complex.FromCartesian(1, Math.Sqrt(3)), Math.PI / 3 },
        { Complex.FromCartesian(Math.Sqrt(3), 1), Math.PI / 6 },
        { Complex.FromCartesian(1, 2), 1.10714871779 },
        { Complex.FromCartesian(0.4, 0.3), 0.643501108793 },
        { Complex.FromCartesian(1, -1), -Math.PI / 4},
        { Complex.FromCartesian(1, -Math.Sqrt(3)), -Math.PI / 3 },
        { Complex.FromCartesian(Math.Sqrt(3), -1),-Math.PI / 6 },
        { Complex.FromCartesian(1, -2), -1.10714871779 },
        { Complex.FromCartesian(0.4, -0.3), -0.643501108793 },
        
        // Cases when Re < 0.
        { Complex.FromCartesian(-1, 1), 3 * Math.PI / 4},
        { Complex.FromCartesian(-1, Math.Sqrt(3)), 2 * Math.PI / 3 },
        { Complex.FromCartesian(-Math.Sqrt(3), 1), 5 * Math.PI / 6 },
        { Complex.FromCartesian(-1, 2), 2.0344439358 },
        { Complex.FromCartesian(-0.4, 0.3), 2.4980915448 },
        { Complex.FromCartesian(-1, -1), 5 * Math.PI / 4},
        { Complex.FromCartesian(-1, -Math.Sqrt(3)), 4 * Math.PI / 3 },
        { Complex.FromCartesian(-Math.Sqrt(3), -1), 7 * Math.PI / 6 },
        { Complex.FromCartesian(-1, -2), 4.24874137138 },
        { Complex.FromCartesian(-0.4, -0.3), 3.78509376238 },
    };
}