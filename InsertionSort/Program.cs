namespace InsertionSort
{
    internal class Program
    {
        static void Main()
        {
            int[] sortedArray = [1, 2, 3, 4, 5]; // best case O(n)
            int[] unsortedArray = [5, 4, 3, 2, 1]; // worst case O(n^2)

            int iterations = InsertionSort(sortedArray); 
            Console.WriteLine($"Best case: {iterations} iterations");
            iterations = InsertionSort(unsortedArray);
            Console.WriteLine($"Worst case: {iterations} iterations");
        }

        static int InsertionSort(int[] arr)
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                count++;
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    count++;
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
            return count;
        }
    }
}
