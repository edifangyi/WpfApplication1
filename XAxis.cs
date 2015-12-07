using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    public class XAxis :Axis
    {
        public override void Caculate(Size size)
        {
            _Markers.Clear();
            CalcuateMarker(size);
            CalcuateLine(size);
        }

        public override void Render(DrawingContext dc)
        {
            RenderLine(dc);
            RenderMarker(dc);
            RenderGridLine(dc);
        }

        private void CalcuateMarker(Size size)
        {
            double value=MaxValue / 5;
            double xAxisLen = size.Width - ChartPropery.RightMargin - ChartPropery.AxisLineMargin;
            CaculateFirstMarker(size);
            for (int i=1;i<=5; i++)
            {
                Marker mk = new Marker();

                Point startp = new Point();
                startp.X = Math.Round(i * value * xAxisLen / MaxValue)+ChartPropery.AxisLineMargin+1;
                startp.Y = size.Height - ChartPropery.AxisLineMargin;
                mk.StartPoint = startp;

                Point endp = new Point();
                endp.X = startp.X;
                endp.Y = size.Height - ChartPropery.AxisLineMargin + ChartPropery.MarkerHeight;
                mk.EndPoint = endp;

                Point gridstartp = new Point();
                gridstartp.X = startp.X;
                gridstartp.Y = size.Height - ChartPropery.AxisLineMargin-1;
                mk.GridStartPoint = gridstartp;

                Point gridendp = new Point();
                gridendp.X = startp.X;
                gridendp.Y = ChartPropery.TopMargin;
                mk.GridEndPoint = gridendp;

                FormattedText formattedText = new FormattedText((MaxValue- i * value).ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 10,Brushes.White);
                mk.Value = formattedText;

                Point tpoint = new Point();
                tpoint.X = Math.Round(startp.X - formattedText.Width / 2);
                tpoint.Y = size.Height - ChartPropery.AxisLineMargin + ChartPropery.MarkerHeight;
                mk.TextPoint = tpoint;
                _Markers.Add(mk);
            }
        }

        private void CaculateFirstMarker(Size size)
        {
            Marker mk = new Marker();
            Point startp = new Point();
            startp.X = ChartPropery.AxisLineMargin;
            startp.Y = size.Height - ChartPropery.AxisLineMargin;
            mk.StartPoint = startp;

            Point endp = new Point();
            endp.X = startp.X;
            endp.Y = size.Height - ChartPropery.AxisLineMargin + ChartPropery.MarkerHeight;
            mk.EndPoint = endp;

            FormattedText formattedText = new FormattedText(MaxValue.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.White);
            mk.Value = formattedText;


            Point tpoint = new Point();
            tpoint.X = startp.X ;
            tpoint.Y = size.Height - ChartPropery.AxisLineMargin + ChartPropery.MarkerHeight;
            mk.TextPoint = tpoint;
            _Markers.Add(mk);
        }

        private void RenderMarker(DrawingContext dc)
        {
            dc.PushGuidelineSet(new GuidelineSet(new double[] { 0.5},new double[] { }));
            foreach(var m in _Markers)
            {
                dc.DrawLine(new Pen(Brushes.White,1),m.StartPoint,m.EndPoint);
                dc.DrawText(m.Value, m.TextPoint);
            }
            dc.Pop();
        }

        private void RenderGridLine(DrawingContext dc)
        {
            SolidColorBrush solidbrush = new SolidColorBrush(Color.FromArgb(0xff, 0xb0, 0xb0, 0xb0)); //#FFB0B0B0
            Pen p = new Pen(solidbrush, 1);
            p.DashStyle = DashStyles.Dash;

            dc.PushGuidelineSet(new GuidelineSet(new double[] { 0.5 }, new double[] { 0.5 }));
            foreach (var m in _Markers)
            {
                dc.DrawLine(p, m.GridStartPoint, m.GridEndPoint);
            }
            dc.Pop();

        }

        private void CalcuateLine(Size size)
        {
            Point startp = new Point();
            startp.X = ChartPropery.AxisLineMargin;
            startp.Y = size.Height - ChartPropery.AxisLineMargin-1;
            Point endp = new Point();
            endp.X = size.Width - ChartPropery.RightMargin+11;
            endp.Y = startp.Y;
            StartPoint = startp;
            EndPoint = endp;
        }

        private void RenderLine(DrawingContext dc)
        {
            dc.PushGuidelineSet(new GuidelineSet(new double[] {0 }, new double[] {-0.5 }));
            dc.DrawLine(new Pen(Brushes.White, 1), StartPoint, EndPoint);
            dc.Pop();
        }
    }
}
