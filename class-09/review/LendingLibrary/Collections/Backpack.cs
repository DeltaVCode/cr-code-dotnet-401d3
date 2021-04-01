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
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
