using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int m = matrix.Count;
        int n = matrix[0].Count;
        int layers = Math.Min(m, n) / 2;
        
        // Process each layer
        for (int layer = 0; layer < layers; layer++)
        {
            List<int> elements = new List<int>();
            
            // Extract top row (left to right)
            for (int j = layer; j < n - layer; j++)
                elements.Add(matrix[layer][j]);
            
            // Extract right column (top to bottom)
            for (int i = layer + 1; i < m - layer; i++)
                elements.Add(matrix[i][n - 1 - layer]);
            
            // Extract bottom row (right to left)
            for (int j = n - 2 - layer; j >= layer; j--)
                elements.Add(matrix[m - 1 - layer][j]);
            
            // Extract left column (bottom to top)
            for (int i = m - 2 - layer; i > layer; i--)
                elements.Add(matrix[i][layer]);
            
            // Calculate effective rotations for this layer
            int effectiveRotations = r % elements.Count;
            
            // Rotate the elements
            List<int> rotated = new List<int>();
            for (int i = effectiveRotations; i < elements.Count; i++)
                rotated.Add(elements[i]);
            for (int i = 0; i < effectiveRotations; i++)
                rotated.Add(elements[i]);
            
            // Put rotated elements back into matrix
            int index = 0;
            
            // Top row (left to right)
            for (int j = layer; j < n - layer; j++)
                matrix[layer][j] = rotated[index++];
            
            // Right column (top to bottom)
            for (int i = layer + 1; i < m - layer; i++)
                matrix[i][n - 1 - layer] = rotated[index++];
            
            // Bottom row (right to left)
            for (int j = n - 2 - layer; j >= layer; j--)
                matrix[m - 1 - layer][j] = rotated[index++];
            
            // Left column (bottom to top)
            for (int i = m - 2 - layer; i > layer; i--)
                matrix[i][layer] = rotated[index++];
        }
        
        // Print the rotated matrix
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}
