// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode.Tests.SolutionTests;

public class ATMUnitTest
{
    [Fact]
    public void Test()
    {
        ATM atm = new();
        atm.Deposit([0, 0, 1, 2, 1]);
        Assert.Equal([0, 0, 1, 0, 1], atm.Withdraw(600));
        atm.Deposit([0, 1, 0, 1, 1]);
        Assert.Equal([-1], atm.Withdraw(600));
        Assert.Equal([0, 1, 0, 0, 1], atm.Withdraw(550));
    }
}
