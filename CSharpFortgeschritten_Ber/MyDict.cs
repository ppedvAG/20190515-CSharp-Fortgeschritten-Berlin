using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFortgeschritten_Ber
{
    class MyDict<TKey, TValue>: IEnumerable<InternalArrayType<TKey, TValue>>
    {
        public TKey[] Keys
        {
            get
            {
                var keyArray = new TKey[_internalArray.Length];
                for (int i = 0; i < _internalArray.Length; i++)
                {
                    keyArray[i] = _internalArray[i].key;
                }
                return keyArray;
            }
        }
        public TValue[] Values
        {
            get
            {
                var valueArray = new TValue[_internalArray.Length];
                for (int i = 0; i < _internalArray.Length; i++)
                {
                   valueArray[i] = _internalArray[i].value;
                }
                return valueArray;
            }
        }

        private InternalArrayType<TKey, TValue>[] _internalArray;

        public void Add(TKey key, TValue value)
        {
            if(_internalArray == null)
            {
                _internalArray = new InternalArrayType<TKey, TValue>[1];
                _internalArray[0].key = key;
                _internalArray[0].value = value;
            } else
            {
                var _internalArrayCopy = new InternalArrayType<TKey, TValue>[_internalArray.Length + 1];
                for (int i = 0; i < _internalArray.Length; i++)
                {
                    _internalArrayCopy[i].key = _internalArray[i].key;
                    _internalArrayCopy[i].value = _internalArray[i].value;
                }
                _internalArrayCopy[_internalArray.Length].key = key;
                _internalArrayCopy[_internalArray.Length].value = value;
                _internalArray = _internalArrayCopy;
            }
        }
        public void Remove(TKey key)
        {
            var _internalArrayCopy = new InternalArrayType<TKey, TValue>[_internalArray.Length - 1];
            int j = 0;
            for (int i = 0; i < _internalArray.Length; i++)
            {
                if (_internalArray[i].key.Equals(key))
                {
                    continue;
                }
                _internalArrayCopy[j++] = _internalArray[i];
            }
            _internalArray = _internalArrayCopy;
        }

        public IEnumerator<InternalArrayType<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in _internalArray)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public struct InternalArrayType<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}
