using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    public class DoubleList : IMyCollection
    {
        internal class node
        {
            public node? prev;
            public node? next;
            public IRepresentation? data;
        }
        public class DoubleListIterator : IMyiterator
        {
            public IRepresentation? Current
            {
                get
                {
                    if (current is null) return default;
                    return current.data;
                }
            }
            private node? current;
            private bool reverse;
            public DoubleListIterator(DoubleList L, bool reverse)
            {
                this.reverse = reverse;
                if (reverse)
                {
                    current = L.tail;
                }
                else
                {
                    current = L.head;
                }
            }
            public bool MoveNext()
            {
                if (reverse)
                {
                    if (current is not null && current.prev is not null)
                    {
                        current = current.prev;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (current is not null && current.next is not null)
                    {
                        current = current.next;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        private node? head;
        private node? tail;
        public DoubleList()
        {
            head = null;
            tail = null;
        }
        public void AddObject(IRepresentation data)
        {
            node el = new node();
            el.data = data;
            if (tail is null)
            {
                el.next = null;
                el.prev = null;
                head = el;
            }
            else
            {
                el.prev = tail;
                el.next = null;
                tail.next = el;
            }
            tail = el;
        }
        public bool RemoveObject(IRepresentation obj)
        {
            node? p = head;
            while (p is not null)
            {
                if (p.data is not null && !p.data.Equals(obj))
                    p = p.next;
                else
                {
                    if (p == head)
                    {
                        head = head.next;

                    }
                    else if (p == tail)
                    {
                        tail = tail.prev;
                    }
                    else
                    {
                        if (p.prev is not null)
                            p.prev.next = p.next;
                    }
                    p.next = null;
                    p.prev = null;
                    return true;
                }
            }
            return false;
        }
        public IMyiterator GetForwardIterator()
        {
            return new DoubleListIterator(this, false);
        }
        public IMyiterator GetBackwardIterator()
        {
            return new DoubleListIterator(this, true);
        }
    }
    public class Vector : IMyCollection
    {
        public class VectorIterator : IMyiterator
        {
            public IRepresentation? Current
            {
                get
                {
                    return v.At(index);
                }
            }
            private bool reverse;
            private int index;
            private int size;
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
        private List<IRepresentation> values;
        private int size;
        public Vector()
        {
            values = new List<IRepresentation>();
            size = 0;
        }
        private IRepresentation At(int index)
        {
            return values[index];
        }
        public void AddObject(IRepresentation data)
        {
            values.Add(data);
            size++;
        }
        public bool RemoveObject(IRepresentation obj)
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
    public class SortedArray
    {
        public class SortedArrayIterator : IMyiterator
        {
            public IRepresentation? Current
            {
                get
                {
                    return values[index];
                }
            }
            private int index;
            private int size;
            private bool reverse;
            private List<IRepresentation> values;
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

        private List<IRepresentation> values;
        private Func<IRepresentation, IRepresentation, int> comparator;
        public void Insert(IRepresentation data)
        {
            values.Insert(0, data);
            for (int i = 1; i < values.Count; i++)
            {
               if (comparator(values[i], values[i - 1]) != 1)
               {
                    IRepresentation tmp = values[i - 1];
                    values[i] = data;
                    values[i - 1] = tmp;
               }
            }
        }
        public void Delete(SortedArrayIterator iter)
        {
            if (iter is not null && iter.Current is not null)
            {
                IRepresentation todel = iter.Current;
                int i = 0;
                while (!Equals(todel, values[i]))
                {
                    i++;
                }
                while (i < values.Count - 2)
                {
                    IRepresentation tmp = values[i + 1];
                    values[i + 1] = values[i];
                    values[i] = tmp;
                }
                values.RemoveAt(values.Count - 1);
            }
        }
        public SortedArray(Func<IRepresentation, IRepresentation, int> comparator)
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
