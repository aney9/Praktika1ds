using praktika1ds.praktikaDataSetTableAdapters;
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
    }
}
