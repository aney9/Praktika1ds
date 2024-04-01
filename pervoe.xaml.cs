using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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

        private void cl2(object sender, RoutedEventArgs e)
        {
            clients.cldobav(imya.Text, fam.Text, otch.Text, fanid.Text, tel.Text, email.Text);
            dg1.ItemsSource = clients.GetData();
            ochist();
        }

        private void cl3(object sender, RoutedEventArgs e)
        {

            object id = (dg1.SelectedItem as DataRowView).Row[0];
            clients.UpdateQuery(imya.Text, fam.Text, otch.Text, fanid.Text, tel.Text, email.Text, Convert.ToInt32(id));
            dg1.ItemsSource = clients.GetData();
            ochist();
        }
        private void cl4(object sender, RoutedEventArgs e)
        {
            object id = (dg1.SelectedItem as DataRowView).Row[0];
            clients.udal(Convert.ToInt32(id));
            dg1.ItemsSource = clients.GetData();
            ochist();
        }


        private void ochist()
        {
            imya.Text = null;
            fam.Text = null;
            otch.Text = null;
            fanid.Text = null;
            tel.Text = null;
            email.Text = null;
        }
        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (dg1.SelectedItem as DataRowView);
            if (proverka != null)
            {
                imya.Text = proverka.Row[1].ToString();
                fam.Text = proverka.Row[2].ToString();
                otch.Text = proverka.Row[3].ToString();
                fanid.Text = proverka.Row[4].ToString();
                tel.Text = proverka.Row[5].ToString();
                email.Text = proverka.Row[6].ToString();
            }
        }
    }
}
