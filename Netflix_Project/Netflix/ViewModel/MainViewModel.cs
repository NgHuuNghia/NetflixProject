using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Netflix.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public MainViewModel()
        {
            if (!Isloaded)
            {
                Isloaded = true;
                AdminMainWindow adminMainWindow = new AdminMainWindow();
                adminMainWindow.ShowDialog();
            }   
        }
    }
}
