using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator_Autopark.AllCollections
{
    class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;
        private const int ResizeValue = 2;

        public int Count { get => _endIndex - _startIndex; }

        private readonly T[] _queue;
        private int _startIndex;
        private int _endIndex;

        public MyQueue()
        {
            _queue = new T[DefaultCapacity];
        }

        public MyQueue(T[] queue)
        {
            if (queue != null)
            {
                throw new ArgumentNullException(nameof(queue), "The transmitted data cannot be null");
            }

            _queue = queue;

            _startIndex = 0;
            _endIndex = _queue.Length - 1;
        }

        public MyQueue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Queue size cannot be less than zero", nameof(size));
            }

            _queue = new T[size];

            _startIndex = 0;
            _endIndex = 0;
        }

        public T Dequeue()
        {
            if (_startIndex == _endIndex)
                return default;

            var requiredItem = _queue[_startIndex];
            _startIndex++;

            return requiredItem;
        }

        public void Enqueue(T item)
        {
            if (_queue.Length - 1 == _endIndex)
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
            int endIndex = _endIndex;

            while (_startIndex != endIndex)
            {
                yield return _queue[endIndex++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
