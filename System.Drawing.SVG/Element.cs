using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Drawing.SVG
{
    public abstract class Element : INotifyPropertyChanged
    {
        private Container parent;
        public Container Parent
        {
            get { return this.parent; }
            set
            {
                if (this.parent != null)
                    if (this.parent.InnerElements.Contains(this))
                        this.parent.InnerElements.Remove(this);
                this.parent = value;
                this.parent?.InnerElements.Add(this);
                OnPropertyChanged();
            }
        }

        public abstract string XML_NODE_NAME { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public abstract class Container : Element
    {
        public Container()
        {
            this.InnerElements.CollectionChanged += InnerElements_CollectionChanged;
        }

        private void InnerElements_CollectionChanged(object sender, Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (Element element in e.NewItems)
                        element.Parent = this;
                    break;
                case Collections.Specialized.NotifyCollectionChangedAction.Remove:
                case Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    foreach (Element element in e.OldItems)
                        element.Parent = null;
                    break;
                case Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (Element element in e.NewItems)
                        element.Parent = this;
                    foreach (Element element in e.OldItems)
                        element.Parent = null;
                    break;
            }
        }

        public readonly ObservableCollection<Element> InnerElements = new ObservableCollection<Element>();
    }

}
