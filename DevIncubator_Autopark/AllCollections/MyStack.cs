using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator_Autopark.AllCollections
{
    public class MyStack<T> : IEnumerable<T>
    {
        public int Count => GetCount();

        private T[] _stack;
        private int _headItemIndex;

        public MyStack()
        {
            int defaultCapacity = 10;
            _stack = new T[defaultCapacity];

            _headItemIndex = -1;
        }

        public MyStack(IEnumerable<T> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack), "The transmitted data cannot be null");
            }

            foreach (var item in stack)
            {
                Push(item);
            }
        }

        public void Push(T item)
        {
            int resizeValue = 2;

            if (Count == _stack.Length - 1)
            {
                var resizeStack = new T[_stack.Length * resizeValue];
                Array.Copy(_stack, resizeStack, _stack.Length);
                _stack = resizeStack;
            }

            _stack[++_headItemIndex] = item;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Can't pop item, stack is empty ");
            }

            T popItem = _stack[_headItemIndex];
            _stack[_headItemIndex] = default;
            --_headItemIndex;

            return popItem;
        }

        private int GetCount()
        {
            int count = 0;
            foreach (var item in _stack)
            {
                if (item == null)
                {
                    return count;
                }

                count++;
            }

            return 0;
        }

        public T Peek() => Count != 0 ? _stack[_headItemIndex] : throw new InvalidOperationException("Can't peek item, stack is empty ");

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _stack.Length; i++)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}