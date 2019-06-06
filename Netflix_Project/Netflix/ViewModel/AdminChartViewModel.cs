using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Netflix.Model;

namespace Netflix.ViewModel
{
    class AdminChartViewModel : BaseViewModel
    {
        // thống kê dựa theo điểm đánh giá
        private ObservableCollection<string> _ListStatist = new ObservableCollection<string>() { "Quốc gia", "Thể loại","Giám đốc sản xuất", "Biên kịch", "Diễn viên"};
        public ObservableCollection<string> ListStatist { get => _ListStatist; set { _ListStatist = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ListChart = new ObservableCollection<string>() { "Biểu đồ cột cụm","Biểu đồ thanh cụm", "Biểu đồ đường" };
        public ObservableCollection<string> ListChart { get => _ListChart; set { _ListChart = value; OnPropertyChanged(); } }
        

        public AdminChartViewModel()
        {

        }
    }
}
