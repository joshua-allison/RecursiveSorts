namespace RecursiveSorts
{
    public static class RecSorts
    {
        static void Main( string [ ] args ) { }

        public static void HeapSort( int [ ] arr, int size ) => RecursiveHeapSort( arr, size );

        /// <summary> "Heap sort is a comparison-based sorting technique based on Binary Heap data structure. It is similar to selection sort where we first find the minimum element and place the minimum element at the beginning. We repeat the same process for the remaining elements." </summary>
        /// <param name="theArray"> The array to be heap-sorted. </param>
        /// <param name="size"> The size of the array to be heap-sorted. </param>
        /// <accreditation> This method and the algorithm within is from "Heap Sort" found at https://www.geeksforgeeks.org/heap-sort/ </accreditation>
        private static void RecursiveHeapSort( int [ ] theArray, int size )
        {
            // Build heap (rearrange array)
            for ( int i = size / 2 - 1 ; i >= 0 ; i-- )
                Heapify( theArray, size, i );

            // One by one extract an element from heap
            for ( int i = size - 1 ; i > 0 ; i-- )
            {
                Swap( theArray, 0, i ); // Move current root to end
                Heapify( theArray, i, 0 ); // call max heapify on the reduced heap
            }
        }

        /// <summary> "Heapify a subtree rooted with (...) index in theArray." </summary>
        /// <accreditation> This method and the algorithm within is from "Heap Sort" found at https://www.geeksforgeeks.org/heap-sort/ </accreditation>
        private static void Heapify( int [ ] theArray, int size, int index )
        {
            int largest = index; // Initialize largest as root
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            // If left child is larger than root
            if ( leftChildIndex < size && theArray [ leftChildIndex ] > theArray [ largest ] )
                largest = leftChildIndex;

            // If right child is larger than largest so far
            if ( rightChildIndex < size && theArray [ rightChildIndex ] > theArray [ largest ] )
                largest = rightChildIndex;

            // If largest is not root
            if ( largest != index )
            {
                int swap = theArray [ index ];
                theArray [ index ] = theArray [ largest ];
                theArray [ largest ] = swap;

                // Recursively heapify the affected sub-tree
                Heapify( theArray, size, largest );
            }
        }

        // Merge Sort
        public static void MergeSort( int [ ] theArray, int size ) => RecursiveMergeSort( theArray, 0, size - 1);

        /// <summary> "Like QuickSort, Merge Sort is a Divide and Conquer algorithm. It divides the input array into two halves, calls itself for the two halves, and then it merges the two sorted halves. " </summary>
        /// <param name="theArray"> The array to be recursively sorted. </param>
        /// <param name="left"> The left-most index to operate on. </param>
        /// <param name="right">  The right-most index to operate on.  </param>
        /// <accreditation> This method and the algorithm within is from "Merge Sort" found at https://www.geeksforgeeks.org/merge-sort/ </accreditation>
        private static void RecursiveMergeSort( int [ ] theArray, int left, int right )
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

        private static void Merge(int [] theArray, int left, int middle, int right )
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


        // Quick Sort
        public static void QuickSort( int [ ] theArray, int size ) => RecurisveQuickSort( theArray, 0, size - 1 );

        /// <summary> "Recursive Program that does quicksort. " </summary>
        /// <param name="arr"> The array to be quicksorted. </param>
        /// <param name="size"> The size of the array to be quicksorted. </param>
        /// <accreditation> The algorithm for this method is based on "CS260 - QuickSort" by Jim Bailey </accreditation>
        private static void RecurisveQuickSort( int [ ] theArray, int first, int last )
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

        /// <summary> Swap the values of two given indeces. </summary>
        /// <param name="index1"> The first index to swap. </param>
        /// <param name="index2"> The second index to swap. </param>
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


        // Thinking Problem
        public static int? FindNth( int [ ] theArray, int size, int index ) => ModifiedRecurisveQuickSort( theArray, 0, size - 1, index);

        /// <summary> "Recursive Program that does quicksort. " </summary>
        /// <param name="theArray"> The array to be quicksorted. </param>
        /// <param name="size"> The size of the array to be quicksorted. </param>
        /// <accreditation> The algorithm for this method is based on "CS260 - QuickSort" by Jim Bailey </accreditation>
        private static int? ModifiedRecurisveQuickSort( int [ ] theArray, int first, int last, int index, int? value = null)
        {
            /// This modified quick sort returns a nullable int, and since it's recursive, we need to have a way to return the value recursively once we've found it.
            /// One way to do that is to have the return value also be a parameter that defaults to null.

            // if the array length is greater than 1
            // partition it, then QuickSort each sub-array
            if ( first < last && value is null)
            {
                // partition, returns index of properly placed pivot
                int pivot = Partition( theArray, first, last );

                /// We know that when we find a pivot, the value at the index of the pivot itself has already been sorted.
                /// So, stop the recursion, and return the value found at the index of the pivot.
                if ( pivot == index )
                    value = theArray [ pivot ];

                /// then, we assign the value equal to the return value of the recursive sort.
                /// We do this because if we were to leave it as is, the very first recursive call to the quick sort function would return null, as that is what 'value' was when it was first called.
                /// By setting value equal to the result of the modified Quick Sort, we preserve the value found at the innermost call of quick sort, and pass it all the way up the stack to the end, where it can be returned to the original calling find Nth function.
                value = ModifiedRecurisveQuickSort( theArray, first, pivot - 1, index, value );
            }
            return value;
        }
    }
}
