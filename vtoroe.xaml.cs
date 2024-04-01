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

namespace praktika1ds
{
    /// <summary>
    /// Логика взаимодействия для vtoroe.xaml
    /// </summary>
    public partial class vtoroe : Window
    {
        MestoTableAdapter mesto = new MestoTableAdapter();
        public vtoroe()
        {
            InitializeComponent();
            dg2.ItemsSource = mesto.GetData();
        }
        private void cl2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void cl1(object sender, RoutedEventArgs e)
        {
            mesto.dob(sekt.Text, ryad.Text, mestoo.Text);
            dg2.ItemsSource = mesto.GetData();
            ochistka();
        }
        private void ochistka()
        {
            sekt.Text = null;
            ryad.Text = null;
            mestoo.Text = null;
        }

        private void cl3(object sender, RoutedEventArgs e)
        {
            object id = (dg2.SelectedItem as DataRowView).Row[0];
            mesto.izm(sekt.Text, ryad.Text, mestoo.Text, Convert.ToInt32(id));
            dg2.ItemsSource = mesto.GetData();
            ochistka();
        }

        private void cl4(object sender, RoutedEventArgs e)
        {
            object id = (dg2.SelectedItem as DataRowView).Row[0];
            mesto.DeleteQuery(Convert.ToInt32(id));
            dg2.ItemsSource = mesto.GetData();
            ochistka();
        }

        private void dg2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (dg2.SelectedItem as DataRowView);
            if (proverka != null)
            {
                sekt.Text = proverka.Row[1].ToString();
                ryad.Text = proverka.Row[2].ToString();
                mestoo.Text = proverka.Row[3].ToString();
            }
        }
    }
}
