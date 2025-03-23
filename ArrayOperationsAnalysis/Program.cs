using System;

class DynamicArray
{
    private int[] array;
    private int count;
    private int resizeCount;

    public DynamicArray(int initialSize = 10)
    {
        array = new int[initialSize];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.MinValue;
        }
        count = 0;
        resizeCount = 0;
    }

    public void Add(int value)
    {
        if (count == array.Length)
        {
            Resize();
        }
        array[count++] = value;
    }

    private void Resize()
    {
        int newSize = array.Length * 2;
        int[] newArray = new int[newSize];
        Array.Copy(array, newArray, array.Length);
        for (int i = array.Length; i < newSize; i++)
        {
            newArray[i] = int.MinValue;
        }
        array = newArray;
        resizeCount++;
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }
        if (index == count - 1)
        {
            array[index] = int.MinValue;
        }
        else
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[count - 1] = int.MinValue;
        }
        count--;
    }

    public void Delete()
    {
        if (count > 0)
        {
            array[count - 1] = int.MinValue;
            count--;
        }
        else
        {
            Console.WriteLine("Array is already empty.");
        }
    }
    public bool Search(int index, int value)
    {
        if (array[index] == value)
        {
            return true;
        }
        return false;
    }
    public int Search(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return int.MinValue; // Not found
    }

    public bool Contains(int value)
    {
        return Search(value) != -1;
    }

    public int GetResizeCount()
    {
        return resizeCount;
    }

    public void PrintArray()
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == int.MinValue)
            {
                Console.Write("_ ");
            }
            else
            {
                Console.Write(array[i] + " ");
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int n = 10; // Change n as needed
        int elementsToAdd = 15 * n;
        DynamicArray dynamicArray = new ();

        for (int i = 0; i < elementsToAdd; i++)
        {
            dynamicArray.Add(i);
        }

        Console.WriteLine($"Array resized {dynamicArray.GetResizeCount()} times.");

        // Deleting some elements
        dynamicArray.Delete(2);
        dynamicArray.Delete(5);
        dynamicArray.Delete(); // Deleting last element

        Console.WriteLine("Array after deletions:");
        dynamicArray.PrintArray();

        // Searching for an element
        int searchValue = 7;
        int index = dynamicArray.Search(searchValue);
        if (index != int.MinValue)
        {
            Console.WriteLine($"Value {searchValue} found at index {index}.");
        }
        else
        {
            Console.WriteLine($"Value {searchValue} not found.");
        }
    }
}
