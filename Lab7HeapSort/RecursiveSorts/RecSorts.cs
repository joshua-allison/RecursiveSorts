using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using PriorityQHeap;

namespace RecursiveSorts
{
    public static class RecSorts
    {
        static void Main( string [ ] args ) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        /// <accreditation> This class and the methods within are based on "CS260 - Heaps", & "CS260 Trees on Arrays" by Jim Bailey </accreditation>
        public static void HeapSort( int[] arr, int size )
        {
            throw new NotImplementedException( );
        }

        public static void MergeSort( int [ ] theArray, int size ) => RecursiveMergeSort( theArray, 0, size - 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theArray"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <accreditation> This method and the algorithm within is based on "Merge Sort" from https://www.geeksforgeeks.org/merge-sort/ </accreditation>
        public static void RecursiveMergeSort( int [ ] theArray, int left, int right )
        {
            if ( left < right )
            {
                int middle = left + ( right - left ) / 2; // find the middle

                RecursiveMergeSort( theArray, left, middle ); // Sort first half
                RecursiveMergeSort( theArray, middle + 1, right ); // Sort second half

                // Merge the sorted halves
                Merge( theArray, left, middle, right );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <accreditation> This method and the algorithm within is based on "Merge Sort" from https://www.geeksforgeeks.org/merge-sort/ </accreditation>
        public static void Merge(int [] theArray, int left, int middle, int right )
        {
            // Find sizes of two subarrays to be merged
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            // Create temp arrays
            int [ ] leftArray = new int [ leftSize ];
            int [ ] rightArray = new int [ rightSize ];
            int leftIndex, rightIndex;

            // Copy data to temp arrays
            for ( leftIndex = 0 ; leftIndex < leftSize ; ++leftIndex )
                leftArray [ leftIndex ] = theArray [ left + leftIndex ];
            for ( rightIndex = 0 ; rightIndex < rightSize ; ++rightIndex )
                rightArray [ rightIndex ] = theArray [ middle + 1 + rightIndex ];

            // Merge the temp arrays
            leftIndex = 0; // initial index of the first array
            rightIndex = 0; // initial index of the first array

            // Initial index of merged subarray array
            int mergedIndex = left;

            while ( leftIndex < leftSize && rightIndex < rightSize )
            {
                if ( leftArray [ leftIndex ] <= rightArray [ rightIndex ] )
                {
                    theArray [ mergedIndex ] = leftArray [ leftIndex ];
                    leftIndex++;
                } else {
                    theArray [ mergedIndex ] = rightArray [ rightIndex ];
                    rightIndex++;
                }
                mergedIndex++;
            }

            // Copy remaining elements of leftArray[], if any
            while ( leftIndex < leftSize )
            {
                theArray [ mergedIndex ] = leftArray [ leftIndex ];
                leftIndex++;
                mergedIndex++;
            }

            // Copy remaining elements of rightArray[], if any
            while ( rightIndex < rightSize )
            {
                theArray [ mergedIndex ] = rightArray [ rightIndex ];
                rightIndex++;
                mergedIndex++;
            }
        }

        public static void QuickSort( int [ ] theArray, int size ) => RecurisveQuickSort( theArray, 0, size - 1 );

        /// <summary> "Recursive Program that does quicksort. " </summary>
        /// <param name="arr"> The array to be quicksorted. </param>
        /// <param name="size"> The size of the array to be quicksorted. </param>
        /// <accreditation> The algorithm for this method is based on "CS260 - QuickSort" by Jim Bailey </accreditation>
        public static void RecurisveQuickSort( int [ ] theArray, int first, int last )
        {
            // if the array length is greater than 1
            // partition it, then QuickSort each sub-array
            if ( first < last)
            {
                // partition, returns index of properly placed pivot
                int pivot = Partition( theArray, first, last );

                //now recursively sort each sub-array
                RecurisveQuickSort( theArray, first, pivot - 1 );
                RecurisveQuickSort( theArray, pivot + 1, last );
            }
        }

        /// <summary>
        /// Swap the values of two given indeces
        /// </summary>
        /// <param name="index1"> The first index to swap </param>
        /// <param name="index2"> The second index to swap </param>
        /// <accreditation> https://stackoverflow.com/a/43759284 </accreditation>
        public static void Swap( int [ ] theArray, int index1, int index2 )
        {
            // check for out of range
            if ( theArray.Length > index2 && theArray.Length > index1 )
            {
                // swap index x and y
                var temp = theArray [ index1 ];
                theArray [ index1 ] = theArray [ index2 ];
                theArray [ index2 ] = temp;
            }
        }

        /// <summary> "Simple Partition. Use the first location for pivot." </summary>
        /// <param name="theArray"> The array to partition. </param>
        /// <returns> The index of a placed pivot. </returns>
        /// <accreditation> This methods is based on "CS260 - QuickSort" by Jim Bailey </accreditation>
        public static int Partition( int [ ] theArray, int first, int last )
        {
            int pivotIndex = first;
            int pivotElement = theArray [ first ];

            int index = first + 1;

            // Move items less than pivot to lower indices
            while ( index <= last )
            {
                if ( theArray [ index ] <= pivotElement )
                {
                    pivotIndex += 1;
                    Swap( theArray, index, pivotIndex );
                }
                index += 1;
            }

            // Place pivot in the proper place
            Swap( theArray, pivotIndex, first );

            return pivotIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <accreditation> This class and the methods within are based on "CS260 - Heaps", & "CS260 Trees on Arrays" by Jim Bailey </accreditation>
        public static int FindNth( int [ ] arr, int size, int value )
        {
            throw new NotImplementedException( );
        }

    }
}
