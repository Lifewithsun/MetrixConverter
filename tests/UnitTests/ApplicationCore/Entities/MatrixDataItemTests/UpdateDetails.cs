using System;
using ApplicationCore.Entities;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.MatrixDataItemTests;

public class UpdateDetails
{
    private MatrixDataItem _testItem;
    private string _validFrom = "test description";
    private string _validTo = "test name";
    private string _validMultiplyBy = "/123";
    private bool _validIsDecimal = true;

    public UpdateDetails()
    {
        _testItem = new MatrixDataItem(_validFrom, _validTo, _validMultiplyBy, _validIsDecimal);
    }

    [Fact]
    public void ThrowsArgumentExceptionGivenEmptyName()
    {
        string newValue = "";
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(newValue, _validTo, _validMultiplyBy));
    }

    [Fact]
    public void ThrowsArgumentExceptionGivenEmptyDescription()
    {
        string newValue = "";
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validFrom, newValue, _validMultiplyBy));
    }

    [Fact]
    public void ThrowsArgumentNullExceptionGivenNullName()
    {
        Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(null, _validTo, _validMultiplyBy));
    }

    [Fact]
    public void ThrowsArgumentNullExceptionGivenNullDescription()
    {
        Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(_validFrom, null, _validMultiplyBy));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ThrowsArgumentExceptionGivenNonPositivePrice(string newPrice)
    {
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validFrom, _validTo, newPrice));
    }
}
