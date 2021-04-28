using System;

public class Program
{
    public static void Main()
    {
        int[] a = new[] { 4, 8, 42, 23, 16, 15 };
        Console.WriteLine(string.Join(",", a));
        MergeSort(a);
        Console.WriteLine(string.Join(",", a));

        string[] n = new[] { "Stacey", "Craig", "Keith", "car", "zeus", "Zoo" };
        Console.WriteLine(string.Join(",", n));
        MergeSort(n);
        Console.WriteLine(string.Join(",", n));
    }

    public static void MergeSort<T>(T[] arr)
        where T : IComparable<T> // generic constraint
    {
        MergeSort(arr, 0, arr.Length);
    }

    private static void MergeSort<T>(T[] arr, int start, int end)
        where T : IComparable<T> // generic constraint
    {
        Console.WriteLine(new { start, end });
        // Recursive "base case"
        if (end - start <= 1) return;

        var mid = start + (end - start) / 2;

        MergeSort(arr, start, mid);
        MergeSort(arr, mid, end);

        Merge(arr, start, mid, end);
    }

    // [left......right-1][right.....end-1]
    private static void Merge<T>(T[] arr, int left, int right, int end)
        where T : IComparable<T> // generic constraint
    {
        T[] sorted = new T[end - left];
        int il = left;
        int ir = right;
        int s = 0; // index in sorted

        while (il < right && ir < end)
        {
            if (arr[il].CompareTo(arr[ir]) < 0)
                sorted[s] = arr[il++];
            else
                sorted[s] = arr[ir++];

            s++;
        }

        if (il == right)
            while (ir < end)
                sorted[s++] = arr[ir++];
        else if (ir == end)
            while (il < right)
                sorted[s++] = arr[il++];

        // Copy back into arr from sorted
        for (int i = 0; i < sorted.Length; i++)
            arr[left + i] = sorted[i];
    }
}
