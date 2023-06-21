

// PROBLEMS

// While it is often the case, the answer does not always depend on the highest line in the array.
// This means that lines 16 - 32 are unnecessary.
// An example of this is { 1, 2, 1 } where the expected output is 2 because of the first and third elements.

// The double for-loop approach technically works, but is incredibly inefficient.
// It also exceeds that alloted time-limit on Leetcode.

int[] test = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
Console.WriteLine($"Max area = {Solution.MaxArea(test)}");

public class Solution
{
    static public int MaxArea(int[] height)
    {
        Queue<int> highestLines = new Queue<int>(); // stores the indexes of all the highest lines
        highestLines.Enqueue(0); // start with the first line
        for (int i = 1; i < height.Length; i++)
        // for each line after the first
        {
            if (height[i] > height[highestLines.First()])
            // if this is the highest line so far
            {
                highestLines.Clear();
                highestLines.Enqueue(i);
            }
            else if (height[i] == height[highestLines.First()])
            // if this is a duplicate highest line
            {
                highestLines.Enqueue(i);
            }
        }

        int maxArea = 0;
        int numberOfHighestLines = highestLines.Count;
        for (int i = 0; i < numberOfHighestLines; i++)
        // for each of the highest lines starting from the left
        {
            for (int j = 0; j < height.Length; j++)
            // for every other line
            {
                int area = Math.Min(height[highestLines.First()], height[j]) * (Math.Max(highestLines.First(), j) - Math.Min(highestLines.First(), j));
                Console.WriteLine($"area = {Math.Min(height[highestLines.First()], height[j])} * ({Math.Max(highestLines.First(), j)} - {Math.Min(highestLines.First(), j)}) = {area}");
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
            highestLines.Dequeue();
        }

        return maxArea;
    }
}