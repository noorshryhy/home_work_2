using System;
using System.Collections.Generic;
namespace home__work2
{
    class Program
    {
        class Searcher<T> where T : IComparable<T>
        {
           
            public int BinarySearchIterative(T[] array, T value)
            {
                Array.Sort(array); 
                int left = 0;
                int right = array.Length - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    int cmp = array[mid].CompareTo(value);

                    if (cmp == 0)
                    {
                        return mid;
                    }
                    if (cmp < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return -1;
            }

            
            public int BinarySearchRecursive(T[] array, T value)
            {
                Array.Sort(array);  
                return BinarySearchRecursiveHelper(array, value, 0, array.Length - 1);
            }

            private int BinarySearchRecursiveHelper(T[] array, T value, int left, int right)
            {
                if (left > right)
                {
                    return -1;
                }

                int mid = left + (right - left) / 2;
                int cmp = array[mid].CompareTo(value);

                if (cmp == 0)
                {
                    return mid;
                }
                if (cmp < 0)
                {
                    return BinarySearchRecursiveHelper(array, value, mid + 1, right);
                }
                else
                {
                    return BinarySearchRecursiveHelper(array, value, left, mid - 1);
                }
            }
        }


        static void Main(string[] args)
        {
            Searcher<int> searcher = new Searcher<int>();
            int[] array = { 5, 3, 2, 4, 1 };

            int value = 3;
            int binaryIterativeResult = searcher.BinarySearchIterative(array, value);
            int binaryRecursiveResult = searcher.BinarySearchRecursive(array, value);

            Console.WriteLine($"res: {binaryIterativeResult}");
            Console.WriteLine($"res :{binaryRecursiveResult}");
        }
    }
}
    