using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3_1_1
{
    class MySuperCollection<T> : ICollection<T>
    {
        private List<T> _myList;
        public MySuperCollection()
        {
            _myList = new List<T>();
        }
        public MySuperCollection(int start, int end)
        {
            _myList = new List<T>((IEnumerable<T>)Enumerable.Range(start, end));
        }

        public int Count => _myList.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _myList.Add(item);
        }

        public void Clear()
        {
            _myList.Clear();
        }

        public bool Contains(T item)
        {
            return _myList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _myList.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            return _myList.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MySuperCollectionEnumerator<T>(_myList);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MySuperCollectionEnumerator<T>(_myList);
        }
        private T GetById(int id)
        {
            return _myList[id];
        }
        private void AddOrUpdate(int id, T un)
        {
            _myList[id] = un;
        }
        public T this[int id]
        {
            get
            {
                return GetById(id);
            }
            set
            {
                AddOrUpdate(id, value);
            }
        }
    }
}
