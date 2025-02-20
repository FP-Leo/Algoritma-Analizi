using System.Diagnostics;

namespace BubbleSortAnalysis
{
    internal class Program
    {
        static void Main()
        {
            int[] sizeArray = [100, 500, 1000, 5000, 10000, 100000, 1000000]; // Array sizes to test

            foreach (int size in sizeArray)
            {
                int[] arr = GenerateRandomArray(size);
                Stopwatch stopwatch = Stopwatch.StartNew();

                OptimizedBubbleSort(arr);

                stopwatch.Stop();
                Console.WriteLine($"Sorted array of size {size} in {stopwatch.ElapsedMilliseconds} ms");
            }
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new();
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 1001); // 1 to 1000 (inclusive lower, exclusive upper)
            }

            return arr;
        }

        static void OptimizedBubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }

                // If no swaps occurred, the array is already sorted
                if (!swapped)
                    break;
            }
        }
    }
}
