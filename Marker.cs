using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    public class Marker
    {
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

        public string value
        {
            get;
            set;
        }
        public FormattedText Value
        {
            get;
            set;
        }

        public Point TextPoint
        {
            get;
            set;
        }

        public Point GridStartPoint
        {
            get;
            set;
        }


        public Point GridEndPoint
        {
            get;
            set;
        }
        //FormattedText formattedText = new FormattedText("测试",CultureInfo.CurrentCulture,FlowDirection.LeftToRight,new Typeface("Verdana"),12,
        //Brushes.Black);
    }
}
