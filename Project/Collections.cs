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
                if(reverse)
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
                    if(index >= size) return false;
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
}
