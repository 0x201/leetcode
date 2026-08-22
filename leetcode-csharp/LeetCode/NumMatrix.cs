// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class NumMatrix
{
    private int[,] Sum { get; }

    public NumMatrix(int[][] matrix)
    {
        int m = matrix.Length;
        if (m <= 0) return;
        int n = matrix[0].Length;
        Sum = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Sum[i + 1, j + 1] = Sum[i, j + 1] + Sum[i + 1, j] - Sum[i, j] + matrix[i][j];
            }
        }
    }
    public int SumRange(int row1, int col1, int row2, int col2)
    {
        return Sum[row2 + 1, col2 + 1] - Sum[row1, col2 + 1] - Sum[row2 + 1, col1] + Sum[row1, col1];
    }
}
