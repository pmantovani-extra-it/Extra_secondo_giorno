using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using App2.ViewModels;
using Foundation;
using UIKit;

namespace Extra.iOS.Native
{
    public class DataSource<T>: UITableViewDataSource
    {
        private IEnumerable<T> _dataSource;
        private UITableView _tableView;
        private string _cellName;
        public DataSource(IEnumerable<T> dataSource, UITableView tableView, string cellName)
        {
            _dataSource = dataSource;
            _tableView = tableView;
            _cellName = cellName;
            if (dataSource is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)dataSource).CollectionChanged += DataSource_CollectionChanged;
            }
        }

        private void DataSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                _tableView.ReloadData();
            }
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _dataSource.Count();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(_cellName, indexPath);
            if (cell is ICellBinding<T>)
            {
                ((ICellBinding<T>)(cell)).BindCell(_dataSource.ToList()[indexPath.Row]);
            }
            return cell;
        }
    }
  
}