using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_2_1
{
    public class DynamicArray<T>
    {
        private T[] _myArr;
        private int _lastInd = -1;
        private const int MINCAPACITY = 8;
        public int Capacity => _myArr.Length;
        public int Length => _lastInd + 1;

        public DynamicArray()
        {
            _myArr = new T[MINCAPACITY];
        }
        public DynamicArray(int n)
        {
            _myArr = new T[n];
        }
        public DynamicArray(IEnumerable<T> s)
        {
            if (s is ICollection<T> collection)
            {
                _myArr = new T[collection.Count];
                collection.CopyTo(_myArr, 0);
            }
            else throw new NotImplementedException("Не пихай что попало сюда");
        }
        public void Resize()
        {
            T[] tmp = new T[Capacity * 2];
            _myArr.CopyTo(tmp, 0);
            _myArr = tmp;
        }
        public void Add(T el)
        {
            if (Length == Capacity) Resize();
            _lastInd++;
            _myArr[_lastInd] = el;
        }
        public void AddRange(IEnumerable<T> s)
        {
            if (s is ICollection<T> collection)
            {
                T[] tmp = new T[(int)(Math.Pow(2, Math.Ceiling(Math.Log2(collection.Count+Length))))];   
                _myArr.CopyTo(tmp, 0);
                collection.CopyTo(tmp, Length - 1);
                _myArr = tmp;
            }
        }
        private void Trim()
        {
            if (_lastInd > -1)
            {
                T[] tmp = new T[Capacity];
                Array.Copy(_myArr, tmp, Length);
                _myArr = tmp;
            }

        }
        public bool Remove(int index)
        {
            if (index < 0 || index >= Length) return false; 
            for (int i = index; i < _lastInd; i++)
            {
                _myArr[i] = _myArr[i+1];
            }
            _myArr[_lastInd] = default;
            _lastInd--;
            return true;
        }
        public bool Insert(int index,T value)
        {
            if (index < 0 || index >= Length) throw new ArgumentOutOfRangeException();
            if (Length == Capacity) Resize();
            for (int i = _lastInd; i >= index; i--)
            {
                _myArr[i + 1] = _myArr[i];
            }
            _lastInd++;
            _myArr[index] = value;
            return true;
        }
        private T GetById(int id)
        {
            return _myArr[id];
        }
        private void AddOrUpdate(int id, T un)
        {
            _myArr[id] = un;
        }
        public T this[int id]
        {
            get
            {
                if (id > _lastInd) throw new ArgumentOutOfRangeException();
                return GetById(id);
            }
            set
            {
                if (id > _lastInd) throw new ArgumentOutOfRangeException();
                AddOrUpdate(id, value);
            }
        }
    }
}
