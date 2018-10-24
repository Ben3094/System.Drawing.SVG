using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Drawing.SVG
{
    public class Curve : INotifyPropertyChanged
    {
        public ObservableCollection<Point> Points = new PointCollection();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PointCollection : ObservableCollection<Point>
    {
        protected override void InsertItem(int index, Point item)
        {
            if (item is RelativePoint)
                if (index > 0)
                    if (((RelativePoint)item).RelativeTo != this[index - 1])
                        throw new ArgumentException("Points can only be relative to the previous point in the list");
            base.InsertItem(index, item);
        }
    }

    public class RelativePoint : Point
    {
        private Point relativeTo;
        public Point RelativeTo
        {
            get { return this.relativeTo; }
            set
            {
                this.relativeTo = value;
                OnPropertyChanged();
            }
        }

        private double dx;
        public double dX
        {
            get { return this.dx; }
            set
            {
                this.dx = value;
                OnPropertyChanged();
            }
        }
        public override double X
        {
            get { return this.dx + this.relativeTo.X; }
            set
            {
                this.dx = value - this.relativeTo.X;
                OnPropertyChanged();
                OnPropertyChanged(nameof(this.dX));
            }
        }

        private double dy;
        public double dY
        {
            get { return this.dy; }
            set
            {
                this.dy = value;
                OnPropertyChanged();
            }
        }
        public override double Y
        {
            get { return this.dy + this.relativeTo.Y; }
            set
            {
                this.dy = value - this.relativeTo.Y;
                OnPropertyChanged();
            }
        }
    }

    public class AbsolutePoint : Point
    {
        protected double x;
        public override double X
        {
            get { return this.x; }
            set
            {
                this.x = value;
                OnPropertyChanged();
            }
        }
        protected double y;
        public override double Y
        {
            get { return this.y; }
            set
            {
                this.y = value;
                OnPropertyChanged();
            }
        }
    }
    
    public abstract class Point : INotifyPropertyChanged
    {

        public abstract double X { get; set; }
        public abstract double Y { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
