using Netflix.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Netflix.ViewModel
{
    public class AdminQLTKViewModel : BaseViewModel
    {
        private ObservableCollection<user> _UserList;
        public ObservableCollection<user> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ListTypeAccount = new ObservableCollection<string>() { "basic","premium" };
        public ObservableCollection<string> ListTypeAccount { get => _ListTypeAccount; set { _ListTypeAccount = value; OnPropertyChanged(); } }

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
                    SelectedType = SelectedItem.account_type;
                }
            }
        }

        private string _SelectedType;
        public string SelectedType
        {
            get => _SelectedType;
            set
            {
                _SelectedType = value;
                OnPropertyChanged();
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
        
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        


        public AdminQLTKViewModel()
        {
            UserList = new ObservableCollection<user>(DataProvider.Ins.DB.users);

            AddCommand = new RelayCommand<user>((p) => 
            {
                // điều kiện add được
                if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Gmail))
                {
                    return false;
                }
                //check tồn tại hay chưa
                var user = DataProvider.Ins.DB.users.Where(x => x.account_id == Account);
                if(user == null || user.Count() != 0)
                {
                    return false;
                }
                //nhấn được
                return true;
            }, (p) => 
            {
                var user =  new user() { name = Name, birthday = Birthday, account_id = Account,password = Password, account_type = SelectedType, payment_gmail = Gmail };
                DataProvider.Ins.DB.users.Add(user);
                DataProvider.Ins.DB.SaveChanges();

                //load data
                UserList.Add(user);
            });

            EditCommand = new RelayCommand<user>((p) =>
            {
                // điều kiện edit được
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Gmail))
                {
                    return false;
                }
                // check tồn tại hay chưa
                var user = DataProvider.Ins.DB.users.Where(x => x.user_id == UserID);
                if (user == null || user.Count() == 0)
                {
                    return false;
                }
                //nhấn được
                return true;
            }, (p) =>
            {
                var user = DataProvider.Ins.DB.users.Where(x => x.user_id == UserID).SingleOrDefault();

                user.name = Name;
                user.birthday = Birthday;
                user.account_id = Account;
                user.password = Password;
                user.account_type = SelectedType;
                user.payment_gmail = Gmail;

                DataProvider.Ins.DB.SaveChanges();

                ///load data sửa trong user model khi tạo entity mới thì copy dán vô lại user.cs (https://www.youtube.com/watch?v=IaLDvfhoVWc&list=PL33lvabfss1zfGxCcTIYr5IjsyweWWtAO&index=14)

                //public int user_id { get; set; }

                //private string _name;
                //public string name { get => _name; set { _name = value; OnPropertyChanged(); } }

                //private string _account_id;
                //public string account_id { get => _account_id; set { _account_id = value; OnPropertyChanged(); } }

                //private string _password;
                //public string password { get => _password; set { _password = value; OnPropertyChanged(); } }

                //private string _account_type;
                //public string account_type { get => _account_type; set { _account_type = value; OnPropertyChanged(); } }

                //private string _payment_gmail;
                //public string payment_gmail { get => _payment_gmail; set { _payment_gmail = value; OnPropertyChanged(); } }

                //private System.DateTime _birthday;
                //public System.DateTime birthday { get => _birthday; set { _birthday = value; OnPropertyChanged(); } }
            });

            DeleteCommand = new RelayCommand<user>((p) =>
            {
                //check tồn tại hay chưa
                var user = DataProvider.Ins.DB.users.Where(x => x.user_id == UserID);
                if (user == null || user.Count() == 0)
                {
                    return false;
                }
                //nhấn được
                return true;
            }, (p) =>
            {
                var user = DataProvider.Ins.DB.users.Where(x => x.user_id == UserID).SingleOrDefault();
                DataProvider.Ins.DB.users.Remove(user);
                DataProvider.Ins.DB.SaveChanges();

                //load lai data
                UserList.Remove(user);

            });


        }

    }
}
