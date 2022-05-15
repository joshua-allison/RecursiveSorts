using System;
using System.Drawing;

namespace PriorityQHeap
{
    public class PriorityQ
    {
        private Heap Heap { get; set; }

        private const int DEFAULT_SIZE = 10;

        public PriorityQ ( int size = DEFAULT_SIZE )
        {
            int Size = ( size < 1 ) ? DEFAULT_SIZE : size;
            Heap = new( Size );
        }

        public void AddItem( int value ) => Heap.AddItem( value );

        public int GetItem( ) => Heap.GetItem( );
    }
}
