namespace PriorityQHeap
{
    /// <summary> A simple Priority Queue (abstract class) implemented on a heap. In this case, the heap is implemented on an array. </summary>
    public class PriorityQ
    {
            private Heap Heap { get; set; }

            public PriorityQ ( int size = -1 ) => Heap = new( size );

            public void AddItem( int value ) => Heap.AddItem( value );

            public int GetItem( ) => Heap.GetItem( );
        }

    class Program { static void Main( string [ ] args ) { } }
    }
