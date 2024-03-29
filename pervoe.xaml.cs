using System;
using System.Collections.Generic;
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
using praktika1ds.praktikaDataSetTableAdapters;

namespace praktika1ds
{
    /// <summary>
    /// Логика взаимодействия для pervoe.xaml
    /// </summary>
    public partial class pervoe : Window
    {
        ClientsTableAdapter clients = new ClientsTableAdapter();
        public pervoe()
        {
            InitializeComponent();
            dg1.ItemsSource = clients.GetData();
        }

        private void cl1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
