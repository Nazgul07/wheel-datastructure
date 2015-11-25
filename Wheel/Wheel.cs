using System;
using System.Collections;
using System.Collections.Generic;

namespace Wheel
{
    public class Wheel<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		public int Count {
			get
			{
				return _position + 1;
			}
		}

		private T[] _items;

		private int _position;

		public Wheel() : this(10)
		{

		}

		public Wheel(int initialSize)
		{
			_items = new T[initialSize];
			_position = -1;
        }

		public T Push(T item)
		{
			if (_position + 1 == _items.Length)
			{
				Array.Resize(ref _items, _items.Length * 2);
			}
			if (_position + 1 < _items.Length)
			{
                _items[++_position] = item;
			}
			return item;
		}

		public T Peek()
		{
			if (_position == -1)
				throw new IndexOutOfRangeException();
			return _items[_position];
		}

		public T Pop()
		{
			if (_position == -1)
				throw new IndexOutOfRangeException();
			T item = _items[_position];
			_items[_position--] = default(T);
			return item;
		}

		public void Rotate(int positions)
		{
			int newPosition = _position;
			newPosition += positions;
			while(newPosition > _position)
			{
				newPosition -= _position;
				newPosition--;
			}
			if(newPosition < _position)
			{
				T[] leftArray = new T[newPosition + 1];
				Array.Copy(_items, leftArray, newPosition + 1);
				T[] rightArray = new T[_position - newPosition];
				Array.Copy(_items, newPosition + 1, rightArray, 0, rightArray.Length);
				T[] newArray = new T[_items.Length];
				Array.Copy(rightArray, 0, newArray, 0, rightArray.Length);
				Array.Copy(leftArray, 0, newArray, rightArray.Length, leftArray.Length);
				_items = newArray;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return _items.GetEnumerator();
		}
		
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			for(int i = 0; i <= _position; i++)
			{
				yield return _items[i];
			}
		}
	}
}
