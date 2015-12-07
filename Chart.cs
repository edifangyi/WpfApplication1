using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    public class Chart:Canvas
    {
        XAxis _xAxis;
        YAxis _yAxis;
        Content _Content;
        CommentText _CommentText;

        public int XMaxValue
        {
            get
            {
                return _xAxis.MaxValue;
            }
            set
            {
                _xAxis.MaxValue = value;
                _Content.XMaxValue = value;
            }
        }

        public int YMaxValue
        {
            get
            {
                return _yAxis.MaxValue;
            }
            set
            {
                _yAxis.MaxValue = value;
                _Content.YMaxValue = value;
            }
        }

        public int XMinValue
        {
            get
            {
                return _xAxis.MinValue;

            }
            set
            {
                _xAxis.MinValue = value;
                _Content.XMinValue = value;
            }
        }

        public int YMinValue
        {
            get
            {
                return _yAxis.MinValue;
            }
            set
            {
                _yAxis.MinValue = value;
                _Content.YMinValue = value;
            }
        }

        public void SetDataSource(List<DataItem> data)
        {
            _Content.DataSource(data);
            this.InvalidateMeasure();
            this.InvalidateVisual();
        }

        public Chart()
        {
            _xAxis = new XAxis();
            _yAxis = new YAxis();
            _Content = new Content();
            _CommentText = new CommentText();
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Debug.WriteLine("[Chart] [MeasureOverride] size width:{0} height:{1}",constraint.Width,constraint.Height);
            _xAxis.Caculate(constraint);
            _yAxis.Caculate(constraint);
            _Content.Caculate(constraint);
            return base.MeasureOverride(constraint);

        }

        protected override void OnRender(DrawingContext dc)
        {
            Debug.WriteLine("[Chart] [OnRender] ");
            base.OnRender(dc);
            _yAxis.Render(dc);
            _xAxis.Render(dc);
            _Content.Render(dc);
            //FormattedText formattedText = new FormattedText("测试",CultureInfo.CurrentCulture,FlowDirection.LeftToRight,new Typeface("Verdana"),12,
            //Brushes.Black);
            //dc.DrawText(formattedText, new Point(0.0, 0.0));
        }

    }
}
