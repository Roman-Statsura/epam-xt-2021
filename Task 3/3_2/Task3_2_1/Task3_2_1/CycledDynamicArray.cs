using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3_2_1
{
    public class CycledDynamicArray<T>:DynamicArray<T>
    {
        private DynamicArray<T> _array;
        public new int Length => _array.Length;
        public CycledDynamicArray(DynamicArray<T> arr)
        {
            _array = arr;
        }
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; ; i++)
            {
                yield return _array[i % _array.Length];
            }
        }
    }
}
