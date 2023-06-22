

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
        int maxArea = 0;
        int i = 0;
        int j = height.Length - 1;

        while (i < j)
        {
            int area;

            if (height[i] > height[j])
            {
                area = height[j] * (j - i);
                j--;
            }
            else
            {
                area = height[i] * (j - i);
                i++;
            }

            if (area > maxArea)
            {
                maxArea = area;
            }
        }

        return maxArea;
    }
}