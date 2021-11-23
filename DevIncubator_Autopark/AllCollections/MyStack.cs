using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator_Autopark.AllCollections
{
    public class MyStack<T> : IEnumerable<T>
    {
        public int Count => _headItemIndex + 1;

        private T[] _stack;
        private int _headItemIndex = 0;

        public MyStack()
        {
            int defaultCapacity = 10;
            _stack = new T[defaultCapacity];
        }

        public MyStack(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Stack size cannot be less than zero", nameof(size));
            }

            _stack = new T[size];
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

            _stack[_headItemIndex++] = item;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Can't pop item, stack is empty ");
            }

            --_headItemIndex;
            T popItem = _stack[_headItemIndex];
            _stack[_headItemIndex] = default;

            return popItem;
        }

        public T Peek() => Count != 0 ? _stack[_headItemIndex] : throw new InvalidOperationException("Can't peek item, stack is empty ");

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}