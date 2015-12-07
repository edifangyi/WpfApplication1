using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();


            chart1.YMaxValue = 100;
            chart1.YMinValue = 0;
            chart1.XMaxValue = 200;
            chart1.XMinValue = 0;

            double x = Math.Sin(100);

          
           
         
            
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            List<DataItem> ds = new List<DataItem>(200);
            Random r = new Random();
            Thread thr = new Thread(
                ()=> {
                for (int i = 0; i < 200; i++)
                {
           
                    DataItem dataitem = new DataItem();
                    dataitem.Data = value;
                    ds.Add(dataitem);         int value = (int)Math.Round(Math.Sin(i) * 10) + 50;

                    
                    Console.Write(value);
                    Console.Write(" ,");
                        this.Dispatcher.Invoke(new Action(() => {
                            chart1.SetDataSource(ds);
                        }));
                        Thread.Sleep(200);
                }
            });
            thr.Start();
        }
    }
}
