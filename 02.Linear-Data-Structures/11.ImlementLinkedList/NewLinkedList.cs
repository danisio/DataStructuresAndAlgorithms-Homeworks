namespace ImlementLinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList2<T> : IEnumerable<T>
    {
        private ListItem<T> Head { get; set; }

        private ListItem<T> Tail { get; set; }

        public void AddFirst(T value)
        {
            var newNode = new ListItem<T>()
            {
                Value = value
            };

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Head.Previous = newNode;
                newNode.Next = this.Head;
                this.Head = newNode;
            }
        }

        public void AddLast(T value)
        {
            var newNode = new ListItem<T>()
            {
                Value = value
            };

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                newNode.Previous = this.Tail;
                this.Tail = newNode;
            }
        }

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var item = this.Head;
            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
