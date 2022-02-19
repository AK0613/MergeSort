using System;

namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 80, 13, 79, 46, 37, 89, 158 };
            Console.WriteLine("Unsorted Array: ");
            Print(arr);
            Console.WriteLine("\nNow sorted: ");
            arr = BubbleSort(arr);
            Print(arr);

        }

        public static void Print(int[] arr)
        {
            foreach (int i in arr)
                Console.Write(i + " ");

        }

        #region BubbleSort
        public static int[] BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        int temp = arr[i];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }
        #endregion

        #region SelectionSort
        public static int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }

        #endregion

        #region MergeSort
        public static int[] MergeSort(int[] array)
        {
            //creating new array to hold result
            int[] result = new int[array.Length];
            int[] left, right;

            //Base case for recursion
            if (array.Length <= 1)
                return array;
            
            //Find midpoint
            int midPoint = array.Length / 2;

            //Left array 
            left = new int[midPoint];

            //If the array has an even number of elements both arrays are the same size.
            if (array.Length %2 == 0)
                right = new int[midPoint];
            //Else the right array will have one more element
            else
                right = new int[midPoint + 1];

            //Populate arrays starting with the left from 0 to midpoint. 
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }
            //Secondary index for the right array
            int x = 0;

            //Iterate through and add values to the right array. Starting from the midpoint
            for(int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            result = Merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        public static int[] Merge(int[] left, int[] right)
        {
            //Find the size of the new array
            int resultSize = left.Length + right.Length;

            //Create a new array to hold the result
            int[] result = new int[resultSize];

            //Indeces to iterate through left right and result array in order to add items in order
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            //While either arrays has content
            while(leftIndex < left.Length || rightIndex < right.Length)
            {
                //Case for both arrays having content. Compare and then add them in order and increment index accordingly
                if(leftIndex<left.Length && rightIndex<right.Length)
                {
                    //If Left is smaller than right
                    if (left[leftIndex] <= right[rightIndex])
                    {
                        result[resultIndex]=left[leftIndex];
                        resultIndex++;
                        leftIndex++;
                    }
                    //else right is smaller than left
                    else
                    {
                        result[resultIndex]=right[rightIndex];
                        resultIndex++;
                        rightIndex++;
                    }
                }

                //Case for only left array having values

                else if(leftIndex<left.Length)
                {
                    result[resultIndex] = left[leftIndex];
                    resultIndex++;
                    leftIndex++;
                }

                //Case for only right array having values
                else if(rightIndex<right.Length)
                {
                    result[resultIndex] = right[rightIndex];
                    resultIndex++;
                    rightIndex++;
                }
            }
            return result;
        }

        #endregion
    }
}




