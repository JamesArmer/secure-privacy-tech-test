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
    public void IsBinaryValid_InputIs001_ReturnFalse()
    {
        var binaryStringService = new BinaryStringService();
        bool result = binaryStringService.Evaluate("001");

        Assert.False(result, "001 is invalid");
    }
}
