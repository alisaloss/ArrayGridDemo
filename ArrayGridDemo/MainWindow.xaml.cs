using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArrayGridDemo
{
    public partial class MainWindow : Window
    {
        private const double Threshold = 300.0; // You'll be taking the threshold as user input not hardcoding

        public MainWindow()
        {
            InitializeComponent();

            // Load data
            var data = ArrayBuilder.BuildSampleArray(6, 8);
            Grid.ItemsSource = DataTableHelper.ToDataTable(data).DefaultView;
        }

        private void Grid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Use dispatcher to ensure cells are generated before coloring
            e.Row.Dispatcher.InvokeAsync(() =>
            {
                foreach (var cell in FindVisualChildren<DataGridCell>(e.Row))
                {
                    if (cell.Content is TextBlock tb &&
                        double.TryParse(tb.Text, out var value))
                    {
                        cell.Background = value > Threshold ? Brushes.Red : Brushes.White;
                    }
                }
            });
        }

        private static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            //if (depObj == null) yield break;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                if (child is T t)
                    yield return t;

                foreach (var childOfChild in FindVisualChildren<T>(child))
                    yield return childOfChild;
            }
        }
    }
}
