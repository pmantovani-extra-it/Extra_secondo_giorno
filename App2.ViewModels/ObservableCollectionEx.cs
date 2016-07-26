using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {

        private bool defer;
        private System.Threading.SynchronizationContext context;

        public ObservableCollectionEx()
        {
            this.context = System.Threading.SynchronizationContext.Current;
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
		protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!defer)
                context.Post(s => base.OnPropertyChanged(e), null);
        }

        /// <summary>
        /// Raises the <see cref="E:CollectionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
		protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!defer)
                context.Post(s => base.OnCollectionChanged(e), null);
        }

        /// <summary>
        /// Clear all actual items and add the items from source
        /// </summary>
        /// <param name="source">The source.</param>
		public void Reset(IEnumerable<T> source)
        {
            this.defer = true;
            this.Clear();
            foreach (var s in source)
            {
                this.Add(s);
            }
            this.defer = false;

            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Adds a range of items to the end
        /// </summary>
        /// <param name="source">The source.</param>
		public void AddRange(IEnumerable<T> source)
        {
            this.defer = true;
            var list = source.ToList();
            foreach (var s in list)
            {
                this.Add(s);
            }
            this.defer = false;
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, this.Count - list.Count));
        }
    }
}
