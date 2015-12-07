using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    public abstract class Axis: ICalculate, IRender
    {

        protected List<Marker> _Markers;

        public int MaxValue
        {
            get;
            set;
        }

        public int MinValue
        {
            get;
            set;
        }

        public Point StartPoint
        {
            get;
            set;
        }

        public Point EndPoint
        {
            get;
            set;
        }

        public Axis()
        {
            _Markers = new List<Marker>();
        }

        public virtual void Caculate(Size size)
        {
        }

        public virtual void Render(DrawingContext dc)
        {
        }
    }
}
