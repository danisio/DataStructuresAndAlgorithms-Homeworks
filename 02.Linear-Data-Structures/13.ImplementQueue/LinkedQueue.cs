namespace ImplementQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> myQueue;

        public LinkedQueue()
        {
            this.myQueue = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.myQueue.AddLast(item);
        }

        public T Dequeue()
        {
            var item = this.myQueue.First;
            this.myQueue.RemoveFirst();
            return item.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currItem = this.myQueue.First;

            for (var i = 0; i < this.myQueue.Count; i++)
            {
                if (currItem != null)
                {
                    yield return currItem.Value;

                    currItem = currItem.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
