using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    public class Content : ICalculate, IRender
    {
        List<Point> _poilist;

        List<DataItem> _datasource;

        PathFigure _figure;

        PathGeometry _geo;

        public int XMaxValue
        {
            get;
            set;
        }

        public int XMinValue
        {
            get;
            set;
        }

        public int YMaxValue
        {
            get;
            set;
        }

        public int YMinValue
        {
            get;
            set;
        }

        public Content()
        {
            _poilist = new List<Point>();
        }

        public void Caculate(Size size)
        {
            CaculatePoints(size);
        }

        public void DataSource(List<DataItem> data)
        {
            _datasource = data;
        }

        public void Render(DrawingContext dc)
        {
            if (_datasource != null && _datasource.Count > 0)
            {
                dc.DrawGeometry(null, new Pen(Brushes.White, 2), _geo);
            }
            
        }

        private void CaculatePoints(Size size)
        {
            if(_datasource==null)
            {
                return;
            }

            if(_datasource.Count<2)
            {
                return;
            }

            Point Startp = new Point();
            _figure = new PathFigure();
            Startp.X =size.Width-(ChartPropery.AxisLineMargin + 1)+ChartPropery.RightMargin+1;

            double xAxisLen = size.Width - ChartPropery.RightMargin - ChartPropery.AxisLineMargin;
            double yAxisLen = size.Height - ChartPropery.AxisLineMargin - ChartPropery.TopMargin - 1;

            Startp.Y= size.Height - ChartPropery.AxisLineMargin - Math.Round(_datasource[0].Data * yAxisLen / YMaxValue);
            _figure.StartPoint = Startp;

            PolyLineSegment segment = new PolyLineSegment();
            _figure.Segments.Add(segment);

            for (int i=0;i< _datasource.Count;i++)
            {
                Point p = new Point();
                p.X = size.Width-(Math.Round((i+1) *  xAxisLen / XMaxValue) + ChartPropery.AxisLineMargin+1)+ChartPropery.RightMargin+1;
                p.Y = size.Height - ChartPropery.AxisLineMargin -  Math.Round(_datasource[i].Data * yAxisLen / YMaxValue);
             
                segment.Points.Add(p);
            }

            _geo = new PathGeometry();
            _geo.Figures.Add(_figure);
        }
    }
}
