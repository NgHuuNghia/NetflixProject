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
        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get => _AccountList; set { _AccountList = value; OnPropertyChanged(); } }

        public AdminViewModel()
        {
            loadDSTK();
        }
        void loadDSTK()
        {
            AccountList = new ObservableCollection<Account>();

            var userList = DataProvider.Ins.DB.users;
            foreach (var item in userList)
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
