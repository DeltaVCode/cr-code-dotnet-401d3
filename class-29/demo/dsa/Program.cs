using System;
using System.Collections.Generic;
using System.Globalization;

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

        MergeSort(n, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(string.Join(",", n));
        MergeSort(n, StringComparer.Ordinal); // literally ascii order
        Console.WriteLine(string.Join(",", n));

        MergeSort(n, StringComparer.CurrentCulture);
        Console.WriteLine(string.Join(",", n));
        MergeSort(n, StringComparer.CurrentCultureIgnoreCase);
        Console.WriteLine(string.Join(",", n));

        Console.WriteLine(CultureInfo.CurrentCulture.Name);
    }

    public static void MergeSort<T>(T[] arr, IComparer<T> comparer = null)
        where T : IComparable<T> // generic constraint
    {
        MergeSort(arr, 0, arr.Length, comparer ?? Comparer<T>.Default);
    }

    private static void MergeSort<T>(T[] arr, int start, int end, IComparer<T> comparer)
        where T : IComparable<T> // generic constraint
    {
        Console.WriteLine(new { start, end });
        // Recursive "base case"
        if (end - start <= 1) return;

        var mid = start + (end - start) / 2;

        MergeSort(arr, start, mid, comparer);
        MergeSort(arr, mid, end, comparer);

        Merge(arr, start, mid, end, comparer);
    }

    // [left......right-1][right.....end-1]
    private static void Merge<T>(T[] arr, int left, int right, int end, IComparer<T> comparer)
        where T : IComparable<T> // generic constraint
    {
        T[] sorted = new T[end - left];
        int il = left;
        int ir = right;
        int s = 0; // index in sorted

        while (il < right && ir < end)
        {
            if (comparer.Compare(arr[il], arr[ir]) < 0)
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
