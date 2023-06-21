
int[] test = { 1, 7, 6, 2, 5, 4, 2, 3, 6 };
Solution.MaxArea(test);

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
                Console.WriteLine($"Comparing line {highestLines.First()} to line {j}");
                // get the shorter of the two lines
                // multiply that value by the difference in the indexes of the two lines
                //      this is the area
                // if (area > maxArea)
                //      maxArea = area;
            }
            highestLines.Dequeue();
        }

        return maxArea;
    }
}