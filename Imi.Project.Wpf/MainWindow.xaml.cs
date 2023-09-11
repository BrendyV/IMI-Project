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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grdLogin.Visibility = Visibility.Visible;
            grdAnimal.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            grdAnimal.Visibility=Visibility.Visible;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbContinent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbBreeding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbDiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbSocial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
