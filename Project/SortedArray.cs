using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SortedArray
    {
        public class SortedArrayIterator : IMyiterator
        {
            public IObject? Current
            {
                get
                {
                    return values[index];
                }
                set
                {
                    if(value is not null) 
                        values[index] = value;
                }
            }
            private int index;
            private readonly int size;
            private readonly bool reverse;
            private readonly List<IObject> values;
            public SortedArrayIterator(SortedArray sArr, bool reverse)
            {
                this.reverse = reverse;
                this.values = sArr.values;
                this.size = values.Count;
                if (reverse)
                {
                    index = this.size - 1;
                }
                else
                {
                    index = 0;
                }
            }
            public bool MoveNext()
            {
                if (reverse)
                {
                    if (index < 1) return false;
                    index--;
                }
                else
                {
                    if (index >= size - 1) return false;
                    index++;
                }
                return true;
            }
        }

        private readonly List<IObject> values;
        private readonly Func<IObject, IObject, int> comparator;
        public void Insert(IObject data)
        {
            values.Insert(0, data);
            for (int i = 1; i < values.Count; i++)
            {
               if (comparator(values[i], values[i - 1]) != 1)
               {
                    IObject tmp = values[i - 1];
                    values[i] = data;
                    values[i - 1] = tmp;
               }
            }
        }
        public void Delete(SortedArrayIterator iter)
        {
            if (iter is not null && iter.Current is not null)
            {
                IObject todel = iter.Current;
                int i = 0;
                while (!Equals(todel, values[i]))
                {
                    i++;
                }
                while (i < values.Count - 2)
                {
                    IObject tmp = values[i + 1];
                    values[i + 1] = values[i];
                    values[i] = tmp;
                }
                values.RemoveAt(values.Count - 1);
            }
        }
        public SortedArray(Func<IObject, IObject, int> comparator)
        {
            values = new();
            this.comparator = comparator;
        }
        public IMyiterator GetForwardIterator()
        {
            return new SortedArrayIterator(this,false);
        }
        public IMyiterator GetBackwardIterator()
        {
            return new SortedArrayIterator(this, true);
        }
    }
}
