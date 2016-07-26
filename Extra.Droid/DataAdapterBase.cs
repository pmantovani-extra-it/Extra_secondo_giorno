using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace Extra.Droid { 

    public class DataAdapterBase<T> : BaseAdapter<T>
    {
        private IList<T> _items;
        private ActivityBase _activity;
        private Action<T, View> _bindView;
        private int _viewID;

        public DataAdapterBase(IList<T> items, ActivityBase activity, Action<T,View> bindView, int viewID)
        {
            _items = items;
            _bindView = bindView;
            _viewID = viewID;
            _activity = activity;
            if (items is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)_items).CollectionChanged += OnCollectionChanged;
            }

        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyDataSetChanged();
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = _activity.LayoutInflater.Inflate(_viewID, null);
                _bindView(_items[position], convertView);
            }
            return convertView;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override T this[int position]
        {
            get { return _items[position]; }
        }
    }
}