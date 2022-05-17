using System;
using System.Drawing;

namespace PriorityQHeap
{
    //TODO: Document PriorityQ Class
    public class PriorityQ
    {
        private Heap Heap { get; set; }
        public PriorityQ ( int size ) => Heap = new( size );

        public void AddItem( int value ) => Heap.AddItem( value );

        public int GetItem( ) => Heap.GetItem( );
    }
}
