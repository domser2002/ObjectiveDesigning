using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    static class Extensions
    {
        public static void AddOrIgnore(this Dictionary<int, string> dictionary, int key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
        public static IRepresentation? Find(this IMyCollection collection,Func<IRepresentation,
            bool> pred,bool frombeginning)
        {
            IMyiterator iter;
            if(frombeginning)
                iter=collection.GetForwardIterator();
            else
                iter=collection.GetBackwardIterator();
            while(iter is not null && iter.Current is not null)
            {
                if(pred(iter.Current)) return iter.Current;
                if (!iter.MoveNext()) break;
            }
            return null;
        }
        public static void Print(this IMyCollection collection, Func<IRepresentation,
            bool> pred, bool frombeginning)
        {
            IMyiterator iter;
            if (frombeginning)
                iter = collection.GetForwardIterator();
            else
                iter = collection.GetBackwardIterator();
            while (iter is not null && iter.Current is not null)
            {
                if (pred(iter.Current))
                    iter.Current.Display();
                if (!iter.MoveNext()) break;
            }
        }

    }
}
