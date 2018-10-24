using System;

namespace System.Drawing.SVG
{
    public class Group : Container
    {
        public override string XML_NODE_NAME { get { return "g"; } }
    }
    
    public class Title : Element
    {
        public override string XML_NODE_NAME { get { return "title"; } }

        private string content;
        public string Content
        {
            get { return this.content; }
            set
            {
                this.content = value;
                OnPropertyChanged();
            }
        }
    }

    public class Rectangle : Element
    {
        public override string XML_NODE_NAME { get { return "rect"; } }

    }
    public class Square : Element
    {
        public override string XML_NODE_NAME { get { return "rect"; } }
    }

    public class Ellipse : Element
    {
        public override string XML_NODE_NAME { get { return "ellipse"; } }
    }
    public class Circle : Ellipse
    {
        public override string XML_NODE_NAME { get { return "circle"; } }
    }

    public class Line : Element
    {
        public override string XML_NODE_NAME { get { return "line"; } }
    }

    public class Polyline : Element
    {
        public override string XML_NODE_NAME { get { return "polyline"; } }
    }

    public class Polygon : Element
    {
        public override string XML_NODE_NAME { get { return "polygon"; } }
    }

    public class Path : Element
    {
        public override string XML_NODE_NAME { get { return "ellipse"; } }

        
    }
}
