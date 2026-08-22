// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.Tests.InterviewSolutionTests;
public class CheckPermutationUnitTest
{
    [Theory]
    [InlineData("abc", "bca", true)]
    [InlineData("abc", "bad", false)]
    public void MultipleDataTest(string s1, string s2, bool expected)
    {
        bool actual = InterviewSolution.CheckPermutation(s1, s2);
        Assert.Equal(expected, actual);
    }
}

