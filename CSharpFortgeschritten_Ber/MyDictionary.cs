/*using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpFortgeschritten_Ber
{

    class MyDictionary<TKey, TValue> : IEnumerable<Element<TKey, TValue>>
    {
     /*   Element<TKey, TValue> root;

        public void Add(TKey key, TValue value)
        {
            if (root == null)
                root = new Element<TKey, TValue>(key, value);
            else
            {
                var newElement = new Element<TKey, TValue>(key, value);
                newElement.nextElement = root;
                root = newElement;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return Find(key).value;
            }
            set
            {

                Find(key).value = value;
            }
        }

        private Element<TKey, TValue> Find(TKey key)
        {
            if (root == null)
                throw new Exception("Collection is empty");

            var curElement = root;
            while (!curElement.key.Equals(key))
            {
                curElement = curElement.nextElement;
                if (curElement == null)
                    throw new Exception("Key not found");
            }

            return curElement;
        }

        public void Remove(TKey key)
        {
            if (root == null)
                throw new Exception("Collection is empty");

            if (root.key.Equals(key))
            {
                root = root.nextElement;
                return;
            }

            var curElement = root;
            var nextElement = root.nextElement;
            if (nextElement == null)
                throw new Exception("Key not found");

            while (!nextElement.key.Equals(key))
            {
                curElement = nextElement;
                nextElement = nextElement.nextElement;

                if (nextElement == null)
                    throw new Exception("Key not found");
            }

            curElement.nextElement = nextElement.nextElement;
        }

        public IEnumerator<Element<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class ABC<Element<TKey, TValue>
    {

    }
    public struct Element<TKey, TValue>
    {
        public Element(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public TKey key;
        public TValue value;
        public Element<TKey, TValue> nextElement;
    }


    public class Enumerator<Element<TKey, TValue>> : IEnumerator<Element<TKey, TValue>>
    {
        public Element<TKey, TValue> Current { get; set; }

    object IEnumerator.Current { get; }

    Element<TKey, Tvalue> IEnumerator<Element<TKey, Tvalue>>.Current => throw new NotImplementedException();

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (Current.nextElement == null)
            return false;

        Current = Current.nextElement;
        return true;
    }

    public void Reset()
    {
        Current = null;
    }
}
}*/