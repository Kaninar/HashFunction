using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3
{
    internal class ObservableDictionary<TKey, TValue> : Dictionary<TKey,TValue>, INotifyCollectionChanged /*, IEnumerable<TKey, TValue>*/
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableDictionary() :base() { }

        public ObservableDictionary(int capacity, TValue defaulValue = default(TValue)) : base(capacity) {}

        public TValue defaultValue;

        public new bool TryAdd(TKey key, TValue value) 
        {
            bool isEmpty = EqualityComparer<TValue>.Default.Equals(base[key], defaultValue) ? true : false;

            if (isEmpty) 
            {
                base[key] = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, key));
            }
            return isEmpty;
        }
    }
}
