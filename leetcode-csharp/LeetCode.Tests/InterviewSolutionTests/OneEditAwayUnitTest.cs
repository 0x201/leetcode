// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.Tests.InterviewSolutionTests;

public class OneEditAwayUnitTest
{
    [Theory]
    [InlineData("pale", "ple", true)]
    [InlineData("pales", "pal", false)]
    public void MultipleDataTest(string first, string second, bool expected)
    {
        bool actual = InterviewSolution.OneEditAway(first, second);
        Assert.Equal(expected, actual);
    }
}