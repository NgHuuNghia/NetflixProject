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

namespace Netflix
{
    /// <summary>
    /// Interaction logic for AdminQLTKWindow.xaml
    /// </summary>
    public partial class AdminQLTKWindow : Window
    {
        public AdminQLTKWindow()
        {
            InitializeComponent();
        }
        private void BtnExit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}
