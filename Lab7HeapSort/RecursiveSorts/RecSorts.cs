using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PriorityQHeap;

namespace RecursiveSorts
{
    public static class RecSorts
    {
        static void Main( string [ ] args ) { }
        public static void HeapSort( int[] arr, int size )
        {
            Heap heap = new ( arr );
            while ( heap.NumItems > 1 )
            {
                heap.Swap( --heap.NumItems, 0 );
                heap.TrickleDown( 0 );
            }
            // TODO: Find out how to reverse output.
        }

        public static void MergeSort( int [ ] arr, int size )
        {
            throw new NotImplementedException( );
        }
        public static void QuickSort( int [ ] arr, int size )
        {
            throw new NotImplementedException( );
        }
        public static int FindNth( int [ ] arr, int size, int value )
        {
            throw new NotImplementedException( );
        }
    }
}
