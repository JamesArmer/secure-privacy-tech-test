using backend.Services;

namespace backend.Tests;

public class BinaryStringEvaluationTests
{
    [Fact]
    public void IsBinaryValid_InputIs10_ReturnTrue()
    {
        var binaryStringService = new BinaryStringService();
        bool result = binaryStringService.Evaluate("10");

        Assert.True(result, "10 is valid");
    }

    [Fact]
    public void IsBinaryValid_InputIs0011_ReturnFalse()
    {
        var binaryStringService = new BinaryStringService();
        bool result = binaryStringService.Evaluate("0011");

        Assert.False(result, "0011 is invalid");
    }
}
