// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.Tests.InterviewSolutionTests;
public class IsFlippedStringUnitTest
{
    [Theory]
    [InlineData("waterbottle", "erbottlewat", true)]
    [InlineData("aa", "aba", false)]
    public void MultipleDataTest(string s1, string s2, bool expected)
    {
        bool actual = InterviewSolution.IsFlippedString(s1, s2);
        Assert.Equal(expected, actual);
    }
}

