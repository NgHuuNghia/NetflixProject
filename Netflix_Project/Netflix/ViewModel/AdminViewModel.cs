using Netflix.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        private ObservableCollection<user> _UserList;
        public ObservableCollection<user> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(); } }

        private user _SelectedItem;
        public user SelectedItem {
            get => _SelectedItem;
            set {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    UserID = SelectedItem.user_id;
                    Name = SelectedItem.name;
                    Birthday = SelectedItem.birthday;
                    Account = SelectedItem.account_id;
                    Password = SelectedItem.password;
                    Type = SelectedItem.account_type;
                    Gmail = SelectedItem.payment_gmail;

                }
            }
        }

        private int _UserID;
        public int UserID { get => _UserID; set { _UserID = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private DateTime _Birthday;
        public DateTime Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }

        private string _Account;
        public string Account { get => _Account; set { _Account = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged(); } }

        private string _Gmail;
        public string Gmail { get => _Gmail; set { _Gmail = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ListSort= new ObservableCollection<string>() { "UserID", "Họ tên", "Ngày sinh", "Tài khoản", "Loại tài khoản", "Gmail" };
        public ObservableCollection<string> ListSort { get => _ListSort; set {_ListSort = value; OnPropertyChanged(); } }

        private string _SelectedTypeSort;
        public string SelectedTypeSort {
            get => _SelectedTypeSort;
            set {
                _SelectedTypeSort = value;
                OnPropertyChanged();
                if(SelectedTypeSort == "UserID")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.user_id));
                }
                else if (SelectedTypeSort == "Họ tên")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.name));
                }
                else if (SelectedTypeSort == "Ngày sinh")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.birthday));
                }
                else if (SelectedTypeSort == "Tài khoản")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.account_id));
                }
                else if (SelectedTypeSort == "Loại tài khoản")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.account_type));
                }
                else if (SelectedTypeSort == "Gmail")
                {
                    UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users.OrderBy(s => s.payment_gmail));
                }

            }
        }
        

        public AdminViewModel()
        {
            UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users);
        }

    }
}
