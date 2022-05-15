using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PriorityQHeap
{
    /// <summary>
    /// A heap is a weakly ordered, complete binary tree. The largest value of a heap is the root.
    /// This Heap class is implemented on an array
    /// </summary>
    /// <accreditation> This class and the methods within are based on "CS260 - Heaps", & "CS260 Trees on Arrays" by Jim Bailey </accreditation>
    public class Heap
    {
        private int[] HeapArray { get; set; } // the array that the heap is implemented on

        private int Size; // the current size of the heap 

        private const int DEFAULT_SIZE = 10;

        private int NumItems; // the current number of items stored in the heap

        private int Parent( int index ) => ( index - 1 ) / 2; // find the index of the parent of the index argument

        private int Left( int index ) => index * 2;  // find the index of the left child of the index argument

        private int Right( int index ) => ( index * 2 ) + 1;  // find the index of the right child of the index argument

        /// <summary>
        /// Sorts the Binary Heap Array after insertion
        /// </summary>
        /// <param name="i"></param>
        /// <accreditation> Algorithm from "Open Data Structures" by Pat Morin, Chapter 10: "Heaps", page 213 </accreditation>
        private void BubbleUp( int index )
        {
            int parent = Parent( index );
            while ( index > 0 && HeapArray [ index ] > HeapArray [ parent ] ) 
            {
                Swap( index, parent );
                index = parent;
                parent = Parent( index );
            }
        }

        /// <summary>
        /// Sorts the Binary Heap Array after the removal of the last element on the last level
        /// </summary>
        /// <param name="index"></param>
        /// <accreditation> Algorithm from "Open Data Structures" by Pat Morin, Chapter 10: "Heaps", page 215 </accreditation>
        void TrickleDown( int index )
        {
            do
            {
                int i = -1;
                int right = Right( index );
                if ( right < NumItems && HeapArray [ right ] < HeapArray [ index ] )
                {
                    int left = Left( index );
                    i = HeapArray [ left ] < HeapArray [ right ] ? left : right;
                }
                else
                {
                    int left = Left( index );
                    if ( left < NumItems && HeapArray [ left ] < HeapArray [ index ] )  i = left;
                }
                if ( i >= 0 ) Swap( index, i );
                index = i;
            } while ( index >= 0 );
        }

        // prevent the array from overflowing by doubling it's size
        private void Resize( )  
        {
            int [ ] temp = HeapArray[0..Size];
            HeapArray = new int [ Size * 2 ];
            Size *= 2;
            for ( int i = 0 ; i < temp.Length ; i++ )
                HeapArray [ i ] = temp [ i ];
        }

        /// <summary>
        /// Swap the values of two given indeces
        /// </summary>
        /// <param name="x"> The first index to swap </param>
        /// <param name="y"> The second index to swap </param>
        /// <param name="array"> The array to perform the swap on </param>
        /// <accreditation> https://stackoverflow.com/a/43759284 </accreditation>
        public void Swap( int index1, int index2)
        {
            // check for out of range
            if ( HeapArray.Length > index2 && HeapArray.Length > index1 )
            {
                // swap index x and y
                var temp = HeapArray [ index1 ];
                HeapArray [ index1 ] = HeapArray [ index2 ];
                HeapArray [ index2 ] = temp;
            }
        }

        public Heap( int size = DEFAULT_SIZE)
        {
            Size = ( size < 1 ) ? DEFAULT_SIZE : size ;
            HeapArray = new int[Size];
            NumItems = 0;
        }

        /// <summary>
        /// Inserts a value into the heap.
        /// After the insertion, the heap is sorted so that the root (index 0) contains the greatest value.
        /// Resizes if necessary.
        /// </summary>
        /// <param name="value"> The value to be added to the heap. </param>
        /// <accreditation> Algorithm from "Open Data Structures" by Pat Morin, Chapter 10: "Heaps", page 213 </accreditation>
        public bool AddItem( int value )
        {
            // if the array is full, double the size of the array
            if ( NumItems + 1 > HeapArray.Length ) Resize( );
            
            // add the value argument to the last index of the array, and increment the number of items in the array
            HeapArray [ NumItems++ ] = value;
            
            // sort the array so that the root (index 0) contains the greatest value
            BubbleUp( NumItems - 1 );
            
            return true;
        }

        /// <summary>
        /// Removes and returns a value from the heap.
        /// </summary>
        /// <accreditation> Algorithm from "Open Data Structures" by Pat Morin, Chapter 10: "Heaps", page 213-215 </accreditation>
        public int GetItem( )
        {
            if ( NumItems <= -0 ) throw new IndexOutOfRangeException( );

            int x = HeapArray [ 0 ];
            HeapArray [ 0 ] = HeapArray [ --NumItems ];
            TrickleDown( 0 );
            if ( 3 * NumItems < HeapArray.Length ) Resize( );
            return x;
        }

        public override string ToString( )
        {
            // declare locals
            string heapString = "";
            int row = 0, numInRow = 1, numPrintedInRow = 0;

            // find out how many rows there will be
            int numRows = 0, i = 0, runningTotal;
            bool found = false;
            while ( found == false )
            {
                runningTotal = (int)Math.Pow( 2, i );
                if ( runningTotal < NumItems )
                    found = true;
                i++;
            }

            // construct the output
            heapString += "Number of rows: " + numRows + "\n";
            for ( int j = 0 ; j < NumItems ; j++ )
            {
                heapString += HeapArray [ j ] + " ";
                numPrintedInRow++;

                // printed the last element in the row
                if (numPrintedInRow == numInRow )
                {
                    // go to the next row;
                    row++;
                    heapString += "\n";
                    numPrintedInRow = 0;

                    // the next row will have 2^row number of items.
                    numInRow = ( int ) Math.Pow( 2, row );
                }
            }
            return heapString;
        }
    }
}
