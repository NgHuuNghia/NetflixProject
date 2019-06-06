using Netflix.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Netflix.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //model
       

        //command
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        //public ICommand UnitCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                //if (p == null)
                //    return;
                //p.Hide();
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.ShowDialog();

                //load adminQTLKWindown

                AdminQLTKWindow adminQLTKWindow = new AdminQLTKWindow();
                adminQLTKWindow.ShowDialog();


            }
              );
        }

        
    }
}
