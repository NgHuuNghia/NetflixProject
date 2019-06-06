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
    public class AdminVideoViewModel : BaseViewModel
    {
        private ObservableCollection<string> _ListSort = new ObservableCollection<string>() { "VideoID", "Tên video", "Thời gian", "Quốc gia", "Thể loại", "Ngày ra mắt", "Giám đốc sản xuất", "Biên kịch", "Diễn viên","Điểm đánh giá" };
        public ObservableCollection<string> ListSort { get => _ListSort; set { _ListSort = value; OnPropertyChanged(); } }

        private ObservableCollection<video> _VideoList;
        public ObservableCollection<video> VideoList { get => _VideoList; set { _VideoList = value; OnPropertyChanged(); } }

        private string _SelectedTypeSort;
        public string SelectedTypeSort
        {
            get => _SelectedTypeSort;
            set
            {
                _SelectedTypeSort = value;
                OnPropertyChanged();
                if (SelectedTypeSort == "VideoID")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.video_id));
                }
                else if (SelectedTypeSort == "Tên video")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.video_name));
                }
                else if (SelectedTypeSort == "Thời gian")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.video_time));
                }
                else if (SelectedTypeSort == "Quốc gia")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.video_rel_country)); 
                }
                else if (SelectedTypeSort == "Thể loại")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.category.category_name)); 
                }
                else if (SelectedTypeSort == "Ngày ra mắt")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.release_date));
                }
                else if (SelectedTypeSort == "Giám đốc sản xuất")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.director));
                }
                else if (SelectedTypeSort == "Biên kịch")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.writers));
                }
                else if (SelectedTypeSort == "Diễn viên")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.stars));
                }
                else if (SelectedTypeSort == "Điểm đánh giá")
                {
                    VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos.OrderBy(s => s.rating));
                }

            }
        }

        private video _SelectedItem;
        public video SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    VideoID = SelectedItem.video_id;
                    VideoName = SelectedItem.video_name;
                    VideoTime = (int)SelectedItem.video_time;
                    RelCountry = SelectedItem.video_rel_country;
                    VideoType = SelectedItem.category.category_name;
                    VideoTypeCatID = SelectedItem.category.category_id;
                    RelDate = (DateTime)SelectedItem.release_date;
                    Director = SelectedItem.director;
                    Writer = SelectedItem.writers;
                    Stars = SelectedItem.stars;
                    Rating = (double)SelectedItem.rating;

                }
            }
        }

        private int _VideoTypeCatID;
        public int VideoTypeCatID { get => _VideoTypeCatID; set { _VideoTypeCatID = value; OnPropertyChanged(); } }


        private int _VideoID;
        public int VideoID { get => _VideoID; set { _VideoID = value; OnPropertyChanged(); } }

        private string _VideoName;
        public string VideoName { get => _VideoName; set { _VideoName = value; OnPropertyChanged(); } }

        private int _VideoTime;
        public int VideoTime { get => _VideoTime; set { _VideoTime = value; OnPropertyChanged(); } }

        private string _RelCountry;
        public string RelCountry { get => _RelCountry; set { _RelCountry = value; OnPropertyChanged(); } }

        private string _VideoType;
        public string VideoType { get => _VideoType; set { _VideoType = value; OnPropertyChanged(); } }

        private DateTime _RelDate;
        public DateTime RelDate { get => _RelDate; set { _RelDate = value; OnPropertyChanged(); } }

        private string _Director;
        public string Director { get => _Director; set { _Director = value; OnPropertyChanged(); } }

        private string _Writer;
        public string Writer { get => _Writer; set { _Writer = value; OnPropertyChanged(); } }
        
        private string _Stars;
        public string Stars { get => _Stars; set { _Stars = value; OnPropertyChanged(); } }

        private double _Rating;
        public double Rating { get => _Rating; set { _Rating = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public AdminVideoViewModel()
        {
            VideoList = new ObservableCollection<video>(DataProvider.Ins.DB.videos);
            AddCommand = new RelayCommand<video>((p) =>
            {
                // điều kiện add được
                if (string.IsNullOrEmpty(VideoName) || string.IsNullOrEmpty(VideoTime.ToString()) || string.IsNullOrEmpty(RelCountry) || string.IsNullOrEmpty(VideoType) || string.IsNullOrEmpty(Director) || string.IsNullOrEmpty(Writer) || string.IsNullOrEmpty(Stars) || string.IsNullOrEmpty(Rating.ToString()))
                {
                    return false;
                }
                if (VideoTime.GetType() != typeof(int) || Rating.GetType() != typeof(double))
                {
                    return false;
                }
                
                //check tồn tại loại phim hay ko
                var category = DataProvider.Ins.DB.categories.Where(x => x.category_name == VideoType);
                if (category == null || category.Count() == 0)
                {
                    return false;
                }

                if (Rating < 0 || Rating > 10)
                {
                    return false;
                }

                if (VideoTime < 0)
                {
                    return false;
                }

                //nhấn được
                return true;
            }, (p) =>
            {
                var video = new video() { video_name = VideoName, video_time = VideoTime, video_rel_country = RelCountry, category_id = VideoTypeCatID, release_date = RelDate,director = Director,writers = Writer, stars = Stars, rating = Rating  };
                DataProvider.Ins.DB.videos.Add(video);
                DataProvider.Ins.DB.SaveChanges();

                //load data
                VideoList.Add(video);
            });

            EditCommand = new RelayCommand<video>((p) =>
            {
                // điều kiện add được
                if (string.IsNullOrEmpty(VideoName) || string.IsNullOrEmpty(VideoTime.ToString()) || string.IsNullOrEmpty(RelCountry) || string.IsNullOrEmpty(VideoType) || string.IsNullOrEmpty(Director) || string.IsNullOrEmpty(Writer) || string.IsNullOrEmpty(Stars) || string.IsNullOrEmpty(Rating.ToString()))
                {
                    return false;
                }
                if (VideoTime.GetType() != typeof(int) || Rating.GetType() != typeof(double))
                {
                    return false;
                }
                
                var category = DataProvider.Ins.DB.categories.Where(x => x.category_name == VideoType);
                if (category == null || category.Count() == 0)
                {
                    return false;
                }

                if (Rating <0 || Rating > 10)
                {
                    return false;
                }
                if (VideoTime < 0)
                {
                    return false;
                }
                //nhấn được
                return true;
            }, (p) =>
            {
                var video = DataProvider.Ins.DB.videos.Where(x => x.video_id == VideoID).SingleOrDefault();
                var category = DataProvider.Ins.DB.categories.Where(x => x.category_name == VideoType).SingleOrDefault();
                video.video_name = VideoName;
                video.video_time = VideoTime;
                video.video_rel_country = RelCountry;
                video.category_id = category.category_id;
                video.release_date = RelDate;
                video.director = Director;
                video.writers = Writer;
                video.stars = Stars;
                video.rating = Rating;


                DataProvider.Ins.DB.SaveChanges();

                ///load data sửa trong user model khi tạo entity mới thì copy dán vô lại video.cs (https://www.youtube.com/watch?v=IaLDvfhoVWc&list=PL33lvabfss1zfGxCcTIYr5IjsyweWWtAO&index=14)

            //public int video_id { get; set; }

            //private string _video_name { get; set; }
            //public string video_name { get => _video_name; set { _video_name = value; OnPropertyChanged(); } }

            //private Nullable<int> _video_time { get; set; }
            //public Nullable<int> video_time { get => _video_time; set { _video_time = value; OnPropertyChanged(); } }

            //private string _video_rel_country { get; set; }
            //public string video_rel_country { get => _video_rel_country; set { _video_rel_country = value; OnPropertyChanged(); } }

            //private Nullable<int> _category_id { get; set; }
            //public Nullable<int> category_id { get => _category_id; set { _category_id = value; OnPropertyChanged(); } }

            //private Nullable<System.DateTime> _release_date { get; set; }
            //public Nullable<System.DateTime> release_date { get => _release_date; set { _release_date = value; OnPropertyChanged(); } }

            //private string _director { get; set; }
            //public string director { get => _director; set { _director = value; OnPropertyChanged(); } }

            //private string _writers { get; set; }
            //public string writers { get => _writers; set { _writers = value; OnPropertyChanged(); } }

            //private string _stars { get; set; }
            //public string stars { get => _stars; set { _stars = value; OnPropertyChanged(); } }

            //private Nullable<double> _rating { get; set; }
            //public Nullable<double> rating { get => _rating; set { _rating = value; OnPropertyChanged(); } }

            //public category _category;
            //public virtual category category { get => _category; set { _category = value; OnPropertyChanged(); } }
    });

            DeleteCommand = new RelayCommand<video>((p) =>
            {
                //check tồn tại hay chưa
                var video = DataProvider.Ins.DB.videos.Where(x => x.video_id == VideoID);
                if (video == null || video.Count() == 0)
                {
                    return false;
                }
                //nhấn được
                return true;
            }, (p) =>
            {
                var video = DataProvider.Ins.DB.videos.Where(x => x.video_id == VideoID).SingleOrDefault();
                DataProvider.Ins.DB.videos.Remove(video);
                DataProvider.Ins.DB.SaveChanges();

                //load lai data
                VideoList.Remove(video);

            });
        }
    }
}
