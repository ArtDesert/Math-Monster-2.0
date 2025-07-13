using Algebra.ComplexNumbers;

namespace AlgebraTests.ComplexNumbers;

public class ComplexTests
{
    #region CreatingTests

    [Fact]
    public void CreatingZeroComplexNumberFromCartesian_Success()
    {
        // Arrange
        var a = Complex.FromCartesian(0, 0);

        // Act & Assert
        Assert.Equal(0, a.Re, 6);
        Assert.Equal(0, a.Im, 6);
        Assert.Equal(0, a.Mod, 6);
        Assert.Equal(double.NaN, a.Arg);
    }

    [Fact]
    public void CreatingComplexNumberFromCartesian_Success()
    {
        // Arrange
        var a = Complex.FromCartesian(1, 1);

        // Act & Assert
        Assert.Equal(1, a.Re, 6);
        Assert.Equal(1, a.Im, 6);
        Assert.Equal(Math.Sqrt(2), a.Mod, 6);
        Assert.Equal(Math.PI / 4, a.Arg, 6);
    }

    [Fact]
    public void CreatingZeroComplexNumberFromPolar_ThrowsComplexException()
    {
        // Act & Assert
        Assert.Throws<ComplexException>(() => Complex.FromPolar(0, 0));
    }

    [Fact]
    public void CreatingComplexNumberFromPolar_Success()
    {
        // Arrange
        var a = Complex.FromPolar(1, Math.PI);

        // Act & Assert
        Assert.Equal(-1, a.Re, 6);
        Assert.Equal(0, a.Im, 6);
        Assert.Equal(1, a.Mod, 6);
        Assert.Equal(Math.PI, a.Arg, 6);
    }

    #endregion

    #region ArithmeticOperationsTests

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

    [Fact]
    public void DivisionOfComplexNumbers_ThrowsDivideByZeroException()
    {
        //Arrange
        var a = Complex.FromCartesian(1, 1);
        var b = Complex.FromCartesian(0, 0);

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => a / b);
    }

    [Theory]
    [MemberData(nameof(ComplexTestCases.ModTestCases), MemberType = typeof(ComplexTestCases))]
    public void ModOfComplexNumber_Success(Complex a, double expected)
    {
        // Act
        var actual = a.Mod;

        // Assert
        Assert.Equal(expected, actual, 6);
    }

    [Theory]
    [MemberData(nameof(ComplexTestCases.ArgumentTestCases), MemberType = typeof(ComplexTestCases))]
    public void ArgumentOfComplexNumber_Success(Complex a, double expected)
    {
        // Act
        var actual = a.Arg;

        // Assert
        Assert.Equal(expected, actual, 6);
    }

    #endregion
}