using System;

public class HeapSort
{
    // Function to perform heap sort on an integer array.
    public static int[] Sort(int[] arr)
    {
        int n = arr.Length;

        // Build max heap.  This is a crucial step in heap sort.
        // We start from the last non-leaf node and heapify all preceding nodes.
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // One by one extract an element from the heap, and then
        //  re-heapify the remaining elements.
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (maximum element) with the last element.
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Reduce the heap size by 1 and heapify the root (index 0)
            //  to maintain the max heap property.
            Heapify(arr, i, 0);
        }
        return arr;
    }

    // Recursive function to heapify a subtree rooted at index i in the array arr.
    // n is the size of the heap.
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // left = 2*i + 1
        int right = 2 * i + 2; // right = 2*i + 2

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != i)
        {
            // Swap arr[i] and arr[largest]
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree.  This is important
            // to ensure the max-heap property is maintained after the swap.
            Heapify(arr, n, largest);
        }
    }

    // Main function - Entry point of the program
    public static void Main(string[] args)
    {
        // Example array to be sorted
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        int n = arr.Length;

        // Print the original array
        Console.WriteLine("Original array:");
        PrintArray(arr);

        // Call the HeapSort.Sort function to sort the array
        Sort(arr);

        // Print the sorted array
        Console.WriteLine("\nSorted array:");
        PrintArray(arr);
    }

    // Function to print the elements of an array
    static void PrintArray(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}