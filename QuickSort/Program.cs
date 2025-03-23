namespace QuickSort2
{
    internal class Program
    {
        static void Main()
        {
            for (int i = 0; i < 20; i++)
            {
                int[] arr = GenerateRandomArray(6);
                QuickSort(arr, 0, arr.Length - 1);
                PrintArray(arr);
            }
        }
        // Lomuto's
        static int Partition_two(int[] arr, int low, int high)
        {
            int pivot = arr[high];


            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++; 
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }
        // Hoare's
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (arr[i] < pivot);

                do
                {
                    j--;
                } while (arr[j] > pivot);

                if (i >= j)
                    return j;

                Swap(arr, i, j);
            }
        }

        static void Swap(int[] arr, int i, int j)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int j = Partition(arr, low, high);
                QuickSort(arr, low, j - 1);
                QuickSort(arr, j + 1, high);
            }
        }

        static int[] GenerateRandomArray(int length)
        {
            Random random = new();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(100);
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
