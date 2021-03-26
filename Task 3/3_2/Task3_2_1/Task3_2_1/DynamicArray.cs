using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3_2_1
{
    public class DynamicArray<T>:IEnumerable<T>,IEnumerable,ICloneable
    {
        private T[] _myArr;
        private int _lastInd = -1;
        private const int MINCAPACITY = 8;
        public int Capacity
        {
            get
            {
                return _myArr.Length;
            }
            set
            {
                T[] tmp = new T[value];
                Array.Copy(_myArr, tmp, value);
                _myArr = tmp;
                _lastInd = --value;
            }
        }
        public int Length => _lastInd + 1;

        public DynamicArray()
        {
            _myArr = new T[MINCAPACITY];
        }
        public DynamicArray(int n)
        {
            if (n < 0)
                throw new ArgumentException("нельзя создать массив отрицательного размера");
            _myArr = new T[n];
        }
        public DynamicArray(IEnumerable<T> s)
        {
            if (s == null)
                throw new ArgumentException("Нужно передать коллекцию");
            
            IEnumerator ie = s.GetEnumerator();
            _myArr = new T[MINCAPACITY];
            while (ie.MoveNext())
            {
                if (Capacity == _lastInd + 1) Resize();
                _lastInd++;
                _myArr[_lastInd] = (T)ie.Current;
            }  
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
        public void AddRange(IEnumerable<T> s) // Нужно будет конечно реализовать метод, при условии, что 's' не коллекция(
        {
            if (s == null)
                throw new ArgumentException("Нужно передать коллекцию");
            
            if (s is ICollection<T> collection)
            {
                T[] tmp = new T[(int)(Math.Pow(2, Math.Ceiling(Math.Log2(collection.Count+Length))))];   
                _myArr.CopyTo(tmp, 0);
                collection.CopyTo(tmp, Length - 1);
                _myArr = tmp;
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException();
            Array.Copy(_myArr, index + 1, _myArr, index, Length - index);
            _lastInd--;
        }
        public bool Remove(T it)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_myArr[i].Equals(it))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
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
        public T[] ToArray()
        {
            T[] res = new T[Length];
            Array.Copy(_myArr, 0, res, 0, Length);
            return res;
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
                if (id > _lastInd || (Length+id) < 0) throw new ArgumentOutOfRangeException();
                if (id < 0)
                    return GetById(Length + id);
                return GetById(id);
            }
            set
            {
                if (id > _lastInd || (Length+id) < 0) throw new ArgumentOutOfRangeException();
                if (id < 0)
                    AddOrUpdate(Length + id,value);
                AddOrUpdate(id, value);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _myArr[i];
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _myArr[i];
            }
        }
        public object Clone() 
        {
            return MemberwiseClone();
        }
    }
}
