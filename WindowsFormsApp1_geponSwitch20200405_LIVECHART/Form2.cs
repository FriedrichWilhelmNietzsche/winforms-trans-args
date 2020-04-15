using System;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace WindowsFormsApp1_geponSwitch20200405
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //osCount f1Count   g1rCount    g1wCount    e1rCount e1wCount f2Count g2rCount g2wCount e2rCount e2wCount
        double osCount = 1;

        double f1Count = 0;
        double g1rCount = 0;
        double g1wCount = 0;
        double e1rCount = 0;
        double e1wCount = 0;

        double f2Count = 0;
        double g2rCount = 0;
        double g2wCount = 0;
        double e2rCount = 0;
        double e2wCount = 0;


        private void Labels_Load(object sender, EventArgs e)
        {
             cartesianChart1.Series.Add(new ColumnSeries
            {
                 Title = "Count: ",
                 Values = new ChartValues<ObservableValue>
                {
                    new ObservableValue(osCount),
                    new ObservableValue(f1Count),
                    new ObservableValue(g1rCount),
                    new ObservableValue(g1wCount),
                    new ObservableValue(e1rCount),
                    new ObservableValue(e1wCount),
                    new ObservableValue(f2Count),
                    new ObservableValue(g2rCount),
                    new ObservableValue(g2wCount),
                    new ObservableValue(e2rCount),
                    new ObservableValue(e2wCount),
                },
                DataLabels = true,
                LabelPoint = point => point.Y + " "
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = new[]
                {
                    "Optical Switch",
                    "FOH-100 No.1",
                    "1GPON Right",
                    "1GPON Wrong",
                    "1EPON Right",
                    "1EPON Wrong",

                    "FOH-100 No.2",
                    "2GPON Right",
                    "2GPON Wrong",
                    "2EPON Right",
                    "2EPON Wrong"
                },
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 15
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value + ".00 items",
                Separator = new Separator()
            });        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            { osCount++; }


            cartesianChart1.Series.Clear();// Values.Clear();

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "Count: ",

                Values = new ChartValues<ObservableValue>
                {
                    new ObservableValue(osCount),
                    new ObservableValue(f1Count),
                    new ObservableValue(g1rCount),
                    new ObservableValue(g1wCount),
                    new ObservableValue(e1rCount),
                    new ObservableValue(e1wCount),
                    new ObservableValue(f2Count),
                    new ObservableValue(g2rCount),
                    new ObservableValue(g2wCount),
                    new ObservableValue(e2rCount),
                    new ObservableValue(e2wCount),
                },
                DataLabels = true,
                LabelPoint = point => point.Y + " "
            });
        }

        private void refresh()
        {

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { osCount, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;
            //更改数据集合会触发动画并更新图表
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { osCount, 3, 2, 4, 5 },
                LineSmoothness = 0, //直线, 1 表示平滑曲线
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });
            //更改任何series都会触发动画并更新图表
            cartesianChart1.Series[2].Values.Add(5d);
            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }
    }
}
