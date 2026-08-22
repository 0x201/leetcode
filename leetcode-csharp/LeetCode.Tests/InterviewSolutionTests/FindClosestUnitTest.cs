// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.Tests.InterviewSolutionTests;

public class FindClosestUnitTest
{
    public static TheoryData<string[], string, string, int> Data => new()
    {
        { ["I", "am", "a", "student", "from", "a", "university", "in", "a", "city"], "a", "student", 1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string[] words, string word1, string word2, int expected)
    {
        int actual = InterviewSolution.FindClosest(words, word1, word2);
        Assert.Equal(expected, actual);
    }
}
