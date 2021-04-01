using System.Collections;
using System.Collections.Generic;

namespace LendingLibrary.Collections
{
    public class Backpack<T> : IBag<T>
    {
        private readonly List<T> storage = new List<T>();

        public void Pack(T item)
        {
            if (item != null)
            {
                storage.Add(item);
            }
        }

        public T Unpack(int index)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in storage)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
