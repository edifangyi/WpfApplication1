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
    public class YAxis : Axis
    {
        public  override void Caculate(Size size)
        {
            _Markers.Clear();
            CalcuateLine(size);
            CalcuateMarker(size);
        }

        public override  void Render(DrawingContext dc)
        {
            RenderLine(dc);
            RenderMarker(dc);
            RenderGridLine(dc);
        }

        private void RenderLine(DrawingContext dc)
        {
            dc.PushGuidelineSet(new GuidelineSet(new double[] { 0.5 }, new double[] { 0 }));
            dc.DrawLine(new Pen(Brushes.White, 1), StartPoint, EndPoint);
            dc.Pop();
        }

        private void RenderMarker(DrawingContext dc)
        {
            dc.PushGuidelineSet(new GuidelineSet(new double[] { 0 }, new double[] { 0.5 }));
            foreach(var m in _Markers)
            {
                dc.DrawLine(new Pen(Brushes.White, 1), m.StartPoint, m.EndPoint);
                dc.DrawText(m.Value, m.TextPoint);
            }
            dc.Pop();
        }

        private void RenderGridLine(DrawingContext dc)
        {
            
            SolidColorBrush solidbrush = new SolidColorBrush(Color.FromArgb(0xff, 0xb0, 0xb0, 0xb0)); //#FFB0B0B0
            Pen p = new Pen(solidbrush, 1);
            p.DashStyle = DashStyles.Dash;

            dc.PushGuidelineSet(new GuidelineSet(new double[] {0.5 },new double[] { 0.5}));
            foreach (var m in _Markers)
            {
                dc.DrawLine(p,m.GridStartPoint, m.GridEndPoint);
            }
            dc.Pop();
        }

        private void CaculateFirstMaker(Size size)
        {
            Marker mk = new Marker();
            Point startp = new Point();

            startp.X = ChartPropery.AxisLineMargin - ChartPropery.MarkerHeight;
            startp.Y = size.Height - ChartPropery.AxisLineMargin-1;

            Point endp = new Point();
            endp.X = ChartPropery.AxisLineMargin;
            endp.Y = startp.Y;

            mk.StartPoint = startp;
            mk.EndPoint = endp;

            FormattedText formattedText = new FormattedText(MinValue.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 10,
            Brushes.White);
            mk.Value = formattedText;

            Point tpoint = new Point();
            tpoint.X = ChartPropery.AxisLineMargin - formattedText.Width - ChartPropery.MarkerHeight;
            tpoint.Y = endp.Y - formattedText.Height;
            mk.TextPoint = tpoint;
            _Markers.Add(mk);
        }

        private void CalcuateMarker(Size size)
        {
            CaculateFirstMaker(size);
            double value = MaxValue / 5;
            double yAxisLen = size.Height - ChartPropery.AxisLineMargin - ChartPropery.TopMargin-1;
            for (int i=1;i<=5;i++)
            {
                Marker mk = new Marker();
                Point startp = new Point();

                startp.X = ChartPropery.AxisLineMargin - ChartPropery.MarkerHeight;
                startp.Y = size.Height- ChartPropery.AxisLineMargin-Math.Round(i * value * yAxisLen / MaxValue);

                Point endp = new Point();
                endp.X = ChartPropery.AxisLineMargin;
                endp.Y = startp.Y;

                mk.StartPoint = startp;
                mk.EndPoint = endp;

                FormattedText formattedText = new FormattedText((i * value).ToString(),CultureInfo.CurrentCulture,FlowDirection.LeftToRight,new Typeface("Verdana"),10,
                Brushes.White);
                mk.Value = formattedText;

                Point tpoint = new Point();
                tpoint.X = ChartPropery.AxisLineMargin - formattedText.Width- ChartPropery.MarkerHeight;
                tpoint.Y = endp.Y - formattedText.Height / 2;
                mk.TextPoint = tpoint;

                Point gridsp = new Point();
                gridsp.X = ChartPropery.AxisLineMargin;
                gridsp.Y = startp.Y;
                mk.GridStartPoint = gridsp;

                Point gridep = new Point();
                gridep.X = size.Width - ChartPropery.RightMargin;
                gridep.Y = gridsp.Y;
                mk.GridEndPoint = gridep;

                _Markers.Add(mk);
            }
        }

        private void CalcuateLine(Size size)
        {
            Point startp = new Point();
            startp.X = ChartPropery.AxisLineMargin;
            startp.Y = size.Height - ChartPropery.AxisLineMargin;
            StartPoint = startp;

            Point endp = new Point();
            endp.X = startp.X;
            endp.Y =ChartPropery.TopMargin-10;
            EndPoint = endp;
        }
    }
}
