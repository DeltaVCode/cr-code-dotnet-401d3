using System.Collections;
using System.Collections.Generic;

namespace LendingLibrary.Collections
{
    public class Backpack<T> : IBag<T>
    {
        public void Pack(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Unpack(int index)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
