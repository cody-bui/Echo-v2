using System;
using System.Collections.Generic;

namespace EchoCore
{
    /// <summary>
    /// pretty much a very fancy 2d array
    /// </summary>
    /// <typeparam name="TKey">key</typeparam>
    /// <typeparam name="PType">data type</typeparam>
    public class DataPool<TKey, PType>
    {
        public List<Tuple<TKey, List<PType>>> Pool { get; }

        public bool ContainsKey(in TKey key)
        {
            for (int i = 0; i < Pool.Count; i++)
                if (Pool[i].Item1.Equals(key))
                    return true;
            return false;
        }

        public void Add(in TKey t, in List<PType> p)
        {
            Pool.Add(new Tuple<TKey, List<PType>>(t,p));
        }
    }
}
