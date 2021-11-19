using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator_Autopark.AllCollections
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;

        public int Count => GetCount();

        private T[] _queue;
        private int _endIndex;

        public MyQueue()
        {
            _queue = new T[DefaultCapacity];

            _endIndex = 0;
        }

        public MyQueue(IEnumerable<T> queue)
        {
            if (queue is null)
            {
                throw new ArgumentNullException(nameof(queue), "The transmitted data cannot be null");
            }

            _queue = new T[DefaultCapacity];
            foreach (var item in queue)
            {
                Enqueue(item);
            }
        }

        public MyQueue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Queue size cannot be less than zero", nameof(size));
            }

            _queue = new T[size];
            _endIndex = 0;
        }

        private int GetCount()
        {
            int count = 0;
            foreach (var item in _queue)
            {
                if (item != null)
                {
                    count++;
                }
            }

            return count;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Can't remove item, queue is empty ");

            var requiredItem = _queue[0];
            var newQueue = new T[Count];
            
            Array.Copy(_queue, 1, newQueue, 0, --_endIndex);
            _queue = newQueue;

            return requiredItem;
        }

        public void Enqueue(T item)
        {
            if (Count - 1 == _endIndex)
            {
                Resize();
            }

            _queue[_endIndex] = item;
            _endIndex++;
        }

        public void Clear()
        {
            Array.Clear(_queue, 0, Count);

            _endIndex = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _queue.Length; i++)
            {
                if (_queue[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void Resize()
        { 
            int resizeValue = 2;
            T[] resizeQueue = new T[_queue.Length * resizeValue];

            for (int i = 0; i < _queue.Length; i++)
                resizeQueue[i] = _queue[i];

            _queue = resizeQueue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _endIndex; i++)
            {
                yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}