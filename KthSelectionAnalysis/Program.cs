namespace KthSelectionAnalysis
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        static void Main()
        {
            int[] arr = GenerateRandomArray(10000000); // Generate a random array
            int k = 10; // Find the 10th smallest element

            // Approach 1: Sort entire array
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            int kthElement1 = FindKthSmallestBySorting(arr, k);
            stopwatch1.Stop();
            Console.WriteLine($"(Full Sort) {k}th smallest element: {kthElement1}, Time: {stopwatch1.ElapsedMilliseconds} ms");

            // Approach 2: Sort only k elements and process rest using Insertion Sort
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            int kthElement2 = FindKthSmallestInsertionSort(arr, k);
            stopwatch2.Stop();
            Console.WriteLine($"(Partial Sort) {k}th smallest element: {kthElement2}, Time: {stopwatch2.ElapsedMilliseconds} ms");
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 10001); // Numbers between 1 and 10000
            }
            return arr;
        }

        static int FindKthSmallestBySorting(int[] arr, int k)
        {
            int[] arrCopy1 = (int[])arr.Clone();
            Array.Sort(arrCopy1);
            return arrCopy1[k - 1]; // k-th smallest element
        }

        static int FindKthSmallestInsertionSort(int[] arr, int k)
        {
            // Create a new array to store first k elements
            int[] kArr = new int[k];

            // Copy first k elements
            Array.Copy(arr, kArr, k);

            // Sort first k elements using Insertion Sort
            for (int i = 1; i < k; i++)
            {
                int key = kArr[i];
                int j = i - 1;

                while (j >= 0 && kArr[j] > key)
                {
                    kArr[j + 1] = kArr[j];
                    j--;
                }
                kArr[j + 1] = key;
            }

            // Process remaining elements in the original array
            for (int i = k; i < arr.Length; i++)
            {
                if (arr[i] < kArr[k - 1]) // If the element is smaller than the largest in kArr
                {
                    kArr[k - 1] = arr[i]; // Replace the largest element

                    // Re-sort using Insertion Sort
                    int key = kArr[k - 1];
                    int j = k - 2;
                    while (j >= 0 && kArr[j] > key)
                    {
                        kArr[j + 1] = kArr[j];
                        j--;
                    }
                    kArr[j + 1] = key;
                }
            }

            return kArr[k - 1]; // Return the k-th smallest element (last element in sorted kArr)
        }
    }

}
