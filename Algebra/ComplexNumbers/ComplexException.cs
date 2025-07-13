namespace Algebra.ComplexNumbers;

public class ComplexException : Exception
{
    public ComplexException(string message): base(message)
    {
    }

    public ComplexException(string message, Exception innerException) : base(message, innerException)
    {
    }
}