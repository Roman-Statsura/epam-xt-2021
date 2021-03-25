using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3_1_1
{
    public class MySuperCollectionEnumerator<T> : IEnumerator<T>
    {
        private List<T> _collection;
        private int curIndex;
        public MySuperCollectionEnumerator(List<T> collection)
        {
            _collection = collection;
            curIndex = -1;
        }
        public T Current
        {
            get
            {
                if (curIndex == -1 || curIndex >= _collection.Count)
                    throw new InvalidOperationException();
                return _collection[curIndex];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                if (curIndex == -1 || curIndex >= _collection.Count)
                    throw new InvalidOperationException();
                return _collection[curIndex];
            }
        }
        void IDisposable.Dispose() { }
        public bool MoveNext()
        {
            if (curIndex >= _collection.Count - 1)
            {
                curIndex = 0;
                return true;
            }
            else if (curIndex < _collection.Count - 1)
            {
                curIndex++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            curIndex = -1;
        }
    }
}
