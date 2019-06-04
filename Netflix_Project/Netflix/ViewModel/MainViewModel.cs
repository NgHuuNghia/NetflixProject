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
        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get => _AccountList; set { _AccountList = value; OnPropertyChanged(); } }

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
                loadDSTK();
                AdminQLTKWindow adminQLTKWindow = new AdminQLTKWindow();
                adminQLTKWindow.ShowDialog();
                

            }
              );

            //UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UnitWindow wd = new UnitWindow(); wd.ShowDialog(); });
            //if (!Isloaded)
            //{
            //    Isloaded = true;
            //    AdminQLTKWindow adminQLTKWindow = new AdminQLTKWindow();
            //    adminQLTKWindow.ShowDialog();
            //    loadDSTK();
            //}
            //MessageBox.Show(DataProvider.Ins.DB.users.First().name);
        }

        void loadDSTK()
        {
            AccountList = new ObservableCollection<Account>();
             
            var userList = DataProvider.Ins.DB.users;
            foreach(var item in userList)
            {
                //var birthdayFormat = DateTime.Now;
                //item.birthday = birthdayFormat;
                Account account = new Account();
                account.user = item;
                AccountList.Add(account);
            }

        }
    }
}
