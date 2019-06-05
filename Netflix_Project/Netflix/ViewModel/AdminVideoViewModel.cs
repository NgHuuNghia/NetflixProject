using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netflix.Model;

namespace Netflix.ViewModel
{
    public class AdminVideoViewModel : BaseViewModel
    {
        private ObservableCollection<string> _ListSort = new ObservableCollection<string>() { "VideoID", "Tên video", "Thời gian", "Quốc gia", "Thể loại", "ngày ra mắt", "Giám đốc sản xuất", "Biên kịch", "Diễn viên","Điểm đánh giá" };
        public ObservableCollection<string> ListSort { get => _ListSort; set { _ListSort = value; OnPropertyChanged(); } }

        public AdminVideoViewModel()
        {

        }
    }
}
