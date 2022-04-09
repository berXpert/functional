using Xunit;
using static functional.Validation;
using System;

namespace functional.tests;

public class UnitTest1
{
    [Fact]
    public void WhenTransferDateIsFuture_ThenValidationPasses()
    {
        var validate = DateNotPast( () => new DateTime(2022,4,12));

        var transfer = MakeTransfer.Dummy with
        {
            Date = new System.DateTime(2022,5,12)
        };

        var actual = validate(transfer);

        Assert.True(actual.IsValid);
    }

     [Fact]
    public void WhenTransferDateIsPast_ThenValidationFails()
    {
        var validate = DateNotPast( () => new DateTime(2022,5,12));

        var transfer = MakeTransfer.Dummy with
        {
            Date = new System.DateTime(2022,4,12)
        };

        var actual = validate(transfer);

        Assert.False(actual.IsValid);
    }
}