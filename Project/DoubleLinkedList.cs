using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DoubleList : IMyCollection
    {
        internal class Node
        {
            public Node? prev;
            public Node? next;
            public IObject? data;
        }
        public class DoubleListIterator : IMyiterator
        {
            public IObject? Current
            {
                get
                {
                    if (current is null) return default;
                    return current.data;
                }
                set
                {
                    if(current is not null)
                        current.data = value;
                }
            }
            private Node? current;
            private readonly bool reverse;
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
        private Node? head;
        private Node? tail;
        public DoubleList()
        {
            head = null;
            tail = null;
        }
        public void AddObject(IObject data)
        {
            Node el = new()
            {
                data = data
            };
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
        public bool RemoveObject(IObject obj)
        {
            Node? p = head;
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
}
