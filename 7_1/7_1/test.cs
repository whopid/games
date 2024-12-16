using NUnit.Framework;

[TestFixture]
public class NumberValidatorTests
{
    private NumberValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new NumberValidator();
    }

    [Test]
    public void ValidateInput_ValidNumber_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => _validator.ValidateInput("100"));
    }

    [Test]
    public void ValidateInput_TooLargeNumber_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _validator.ValidateInput("2147483648"));
    }

    [Test]
    public void ValidateInput_TooSmallNumber_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _validator.ValidateInput("-2147483649"));
    }

    [Test]
    public void ValidateInput_NonNumericInput_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(() => _validator.ValidateInput("abc"));
    }

    [Test]
    public void ValidateInput_EmptyInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _validator.ValidateInput(""));
    }

    [Test]
    public void ValidateInput_WhitespaceInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _validator.ValidateInput("   "));
    }
}
