namespace LargestSubsum
{
    internal class Program
    {
        static int stepCounter = 0;  // Static counter to track the number of steps

        static void Main()
        {
            // Test case: Array with positive and negative numbers
            int[] testArray = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
            int largestSum = FindLargestSubsum(testArray);
            Console.WriteLine("The largest subarray sum is: " + largestSum);
            Console.WriteLine("Number of steps: " + stepCounter);

            // Reset counter and test case 2
            stepCounter = 0;  // Reset the step counter
            int[] testArray2 = [2, 3, 5, 1, 6];
            int largestSum2 = FindLargestSubsum(testArray2);
            Console.WriteLine("The largest subarray sum is: " + largestSum2);
            Console.WriteLine("Number of steps: " + stepCounter);

            // Reset counter and test case 3
            stepCounter = 0;  // Reset the step counter
            int[] testArray3 = [-1, -2, -3, -4];
            int largestSum3 = FindLargestSubsum(testArray3);
            Console.WriteLine("The largest subarray sum is: " + largestSum3);
            Console.WriteLine("Number of steps: " + stepCounter);

            // Reset counter and test case 4
            stepCounter = 0;  // Reset the step counter
            int[] testArray4 = [5];
            int largestSum4 = FindLargestSubsum(testArray4);
            Console.WriteLine("The largest subarray sum is: " + largestSum4);
            Console.WriteLine("Number of steps: " + stepCounter);
        }

        public static int FindLargestSubsum(int[] s)
        {
            int n = s.Length;
            int maxSum = int.MinValue;  // Initialize maxSum to a very small value

            // Brute-force approach with O(n^3) complexity
            for (int start = 0; start < n; start++)  // First loop to select starting index
            {
                stepCounter++;  // Increment the counter each time the outer loop runs

                for (int end = start; end < n; end++)  // Second loop to select ending index
                {
                    stepCounter++;  // Increment the counter each time the second loop runs

                    int sum = 0;
                    for (int k = start; k <= end; k++)  // Third loop to calculate the sum of subarray
                    {
                        sum += s[k];
                        stepCounter++;  // Increment for each addition operation in the innermost loop
                    }
                    maxSum = Math.Max(maxSum, sum);  // Update maxSum if a larger sum is found
                }
            }

            return maxSum;  // Return the largest subarray sum
        }
    }
}
