using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using System.ComponentModel;

namespace PushBoxSDKExample
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private PropertyChangedEventHandler propertyChangedHandlers;
        private ObservableCollection<LogItem> items;

        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                items = new ObservableCollection<LogItem>() {
                     new LogItem("Første"),
                     new LogItem("Anden"),
                     new LogItem("Trejde")
                };
            } else
            {
                items = new ObservableCollection<LogItem>();
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                propertyChangedHandlers += value;
            }

            remove
            {
                propertyChangedHandlers -= value;
            }
        }

        public string Title { get { return "PushBox SDK demo"; } }

        public ObservableCollection<LogItem> Items { get { return items; }
            set
            {
                items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public ObservableCollection<LogItem> EmptyItems { get; } = new ObservableCollection<LogItem>();

        private void NotifyPropertyChanged(string name)
        {
            propertyChangedHandlers?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void addItems(LogItem[] logItems)
        {
            foreach (var item in logItems)
            {
                Items.Add(item);
            }
        }

        internal void SetItems(IEnumerable<LogItem> items)
        {
            this.Items = new ObservableCollection<LogItem>(items);
        }

        public void NoItems()
        {
            this.Items = EmptyItems;
        }
    }
}
