namespace ImplementStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class NewStack<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;

        private T[] array;
        private int index;

        public NewStack()
        {
            this.array = new T[InitialSize];
            this.index = 0;
        }

        public int Count
        {
            get { return this.index; }
        }

        public int Capacity
        {
            get { return this.array.Length; }
        }

        public T Peek()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.array[this.index - 1];
        }

        public void Push(T item)
        {
            if (this.index == this.Capacity)
            {
                this.array = this.ResizeArray();
            }

            this.array[this.index] = item;

            this.index++;
        }

        public T Pop()
        {
            if (this.index <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            this.index--;

            var item = this.array[this.index];

            this.array[this.index] = default(T);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < this.index)
            {
                yield return this.array[i];
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T[] ResizeArray()
        {
            var result = new T[this.Capacity * 2];

            for (int i = 0; i < this.Capacity; i++)
            {
                result[i] = this.array[i];
            }

            return result;
        }
    }
}
