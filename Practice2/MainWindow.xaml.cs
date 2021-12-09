using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
using System.IO;
using LibMas;
using Lib_7;

namespace Practice2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        private string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");
        public int[] processedArray;
        private DataTable res = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработал Шестаков Артём ИСП-31 \nВариант №7 \nВвести n целых чисел. Вычислить для чисел < 0 функцию x2.Результат обработки каждого числа вывести на экран");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ResultOutputButtonClick(object sender, RoutedEventArgs e)
        {
            res = new DataTable();
            resultGrid.ItemsSource = null;
            resultGrid.Items.Clear();
            resultGrid.Columns.Clear();
            try
            {
                processedArray = FillMass.Fill(Convert.ToInt32(inputBox.Text));
            }
            catch
            {
                MessageBox.Show("В качестве размера матрицы указано некорректное значение.");
            }
            DataRow row = res.NewRow();

            for (int i = 0; i < processedArray.Length; i++)
            {
                res.Columns.Add("column " + i.ToString(), typeof(string));
            }
            for (int i = 0; i < processedArray.Length; i++)
            {
                row[i] = processedArray[i];
            }
            res.Rows.Add(row);
            resultGrid.ItemsSource = res.DefaultView;
        }
        public void SaveButton_click(object sender, RoutedEventArgs e)
        {
           
            FillMass.SaveMatrix(path, processedArray);
        }
        public void OpenButton_click(object sender, RoutedEventArgs e)
        {
            FillMass.OpenArray(path, out int[] savedArray);
            res = new DataTable();
            resultGrid.ItemsSource = null;
            resultGrid.Items.Clear();
            resultGrid.Columns.Clear();
            DataRow row = res.NewRow();

            for (int i = 0; i < savedArray.Length; i++)
            {
                res.Columns.Add("column " + i.ToString(), typeof(string));
            }
            for (int i = 0; i < savedArray.Length; i++)
            {
                row[i] = savedArray[i];
            }
            res.Rows.Add(row);
            resultGrid.ItemsSource = res.DefaultView;
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            res = new DataTable();
            resultGrid.ItemsSource = null;
            resultGrid.Items.Clear();
            resultGrid.Columns.Clear();
            processedArray = ProgrammModules.NumbersBelowZeroToPower(processedArray);

            DataRow row = res.NewRow();

            for (int i = 0; i < processedArray.Length; i++)
            {
                res.Columns.Add("column " + i.ToString(), typeof(string));
            }
            for (int i = 0; i < processedArray.Length; i++)
            {
                row[i] = processedArray[i];
            }
            res.Rows.Add(row);
            resultGrid.ItemsSource = res.DefaultView;
        }
    }
}
