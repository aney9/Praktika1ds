using praktika1ds.praktikaDataSetTableAdapters;
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
using System.Windows.Shapes;
using static praktika1ds.praktikaDataSet;

namespace praktika1ds
{
    /// <summary>
    /// Логика взаимодействия для tri.xaml
    /// </summary>
    public partial class tri : Window
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public tri()
        {
            InitializeComponent();
            dg3.ItemsSource = orders.GetData();
        }

        private void vyhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dobavl(object sender, RoutedEventArgs e)
        {
            decimal price1 = Convert.ToDecimal(price.Text);
            int ID11 = Convert.ToInt32(ID1.Text);
            int ID22 = Convert.ToInt32(ID2.Text);
            orders.dobavl(data.Text, price1, ID11, ID22);
            dg3.ItemsSource = orders.GetData();
            ochistka();
        }
        private void ochistka()
        {
            data.Text = null;
            price.Text = null;
            ID1.Text = null;
            ID2.Text = null;
        }

        private void udal(object sender, RoutedEventArgs e)
        {
            object id = (dg3.SelectedItem as DataRowView).Row[0];
            orders.udal(Convert.ToInt32(id));
            dg3.ItemsSource = orders.GetData();
            ochistka();
        }

        private void izmen(object sender, RoutedEventArgs e)
        {
            decimal price1 = Convert.ToDecimal(price.Text);
            int ID11 = Convert.ToInt32(ID1.Text);
            int ID22 = Convert.ToInt32(ID2.Text);
            object id = (dg3.SelectedItem as DataRowView).Row[0];
            orders.izmen(data.Text, price1, ID11, ID22, Convert.ToInt32(id));
            dg3.ItemsSource = orders.GetData();
            ochistka();
        }

        private void dg3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (dg3.SelectedItem as DataRowView);
            if (proverka != null)
            {
                data.Text = proverka.Row[1].ToString();
                price.Text = proverka.Row[2].ToString();
                ID1.Text = proverka.Row[3].ToString();
                ID2.Text = proverka.Row[4].ToString();
            }
        }
    }
}
