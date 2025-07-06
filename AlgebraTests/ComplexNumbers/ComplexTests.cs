using Complex = Algebra.ComplexNumbers.Complex;

namespace AlgebraTests.ComplexNumbers;

public class ComplexTests
{
    [Theory]
    [MemberData(nameof(ComplexTestCases.AdditionTestCases), MemberType = typeof(ComplexTestCases))]
    public void AdditionOfComplexNumbersAddition_Success(Complex a, Complex b, Complex expected)
    {
        // Act
        var actual = a + b;

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ComplexTestCases.SubstractionTestCases), MemberType = typeof(ComplexTestCases))]
    public void SubstractionOfComplexNumbers_Success(Complex a, Complex b, Complex expected)
    {
        // Act
        var actual = a - b;

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ComplexTestCases.MultiplicationTestCases), MemberType = typeof(ComplexTestCases))]
    public void MultiplicationOfComplexNumbers_Success(Complex a, Complex b, Complex expected)
    {
        // Act
        var actual = a * b;

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ComplexTestCases.UnaryMinusOperatorTestCases), MemberType = typeof(ComplexTestCases))]
    public void UnaryMinusOperator_Success(Complex a, Complex expected)
    {
        // Act
        var actual = -a;

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ComplexTestCases.DivisionTestCases), MemberType = typeof(ComplexTestCases))]
    public void DivisionOfComplexNumbers_Success(Complex a, Complex b, Complex expected)
    {
        // Act
        var actual = a / b;

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ComplexTestCases.ModTestCases), MemberType = typeof(ComplexTestCases))]
    public void ModOfComplexNumber_Success(Complex a, double expected)
    {
        // Act
        var actual = a.Mod;

        // Assert
        Assert.Equal(expected, actual);
    }
}