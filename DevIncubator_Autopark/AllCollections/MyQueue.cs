using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator_Autopark.AllCollections
{
    class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;
        private const int ResizeValue = 2;

        public int Count { get => _endIndex; }

        private T[] _queue;
        private int _endIndex;

        public MyQueue()
        {
            _queue = new T[DefaultCapacity];

            _endIndex = 0;
        }

        public MyQueue(T[] queue)
        {
            if (queue != null)
            {
                throw new ArgumentNullException(nameof(queue), "The transmitted data cannot be null");
            }

            _queue = queue;

            _endIndex = _queue.Length - 1;
        }

        public MyQueue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Queue size cannot be less than zero", nameof(size));
            }

            _queue = new T[size];

            _endIndex = 0;
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
            for (int i = 0; i < _queue.Length; i++)
                _queue[i] = default;

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

        private T[] Resize()
        {
            T[] resizeQueue = new T[_queue.Length * ResizeValue];

            for (int i = 0; i < _queue.Length; i++)
                resizeQueue[i] = _queue[i];

            return resizeQueue;
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
