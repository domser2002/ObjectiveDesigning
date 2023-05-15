using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Vector : IMyCollection
    {
        public class VectorIterator : IMyiterator
        {
            public IObject? Current
            {
                get
                {
                    return v.At(index);
                }
                set
                {
                    if(value is not null)
                        v.values[index] = value;
                }
            }
            private readonly bool reverse;
            private int index;
            private readonly int size;
            private readonly Vector v;
            public VectorIterator(Vector v, bool reverse)
            {
                this.v = v;
                this.reverse = reverse;
                if (reverse)
                {
                    index = v.size - 1;
                }
                else
                {
                    index = 0;
                }
                size = v.size;
            }
            public bool MoveNext()
            {
                if (reverse)
                {
                    index--;
                    if (index < 0) return false;
                }
                else
                {
                    index++;
                    if (index >= size) return false;
                }
                return true;
            }
        }
        private readonly List<IObject> values;
        private int size;
        public Vector()
        {
            values = new List<IObject>();
            size = 0;
        }
        private IObject At(int index)
        {
            return values[index];
        }
        public void AddObject(IObject data)
        {
            values.Add(data);
            size++;
        }
        public bool RemoveObject(IObject obj)
        {
            if (values.Remove(obj))
            {
                size--;
                return true;
            }
            return false;
        }
        public IMyiterator GetForwardIterator()
        {
            return new VectorIterator(this, false);
        }
        public IMyiterator GetBackwardIterator()
        {
            return new VectorIterator(this, true);
        }
    }
}
