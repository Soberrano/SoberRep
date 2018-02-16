using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace StudentCard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Student> ListOfStudent { get; set; } = new ObservableCollection<Student>();
        public LambdaCommand AddButtonClick { get; set; }
        public LambdaCommand ChangeButtonClick { get; set; }
        Serializationer ser = new Serializationer();
        public bool Check = false;
        public MainWindow()
        {
            InitializeComponent();
            ReadStudents();
            AddButtonClick = new LambdaCommand((param) =>
            {
                return EmptyTest();
            },
                (param) =>
                {
                    AddToList();
                });
            DataContext = this;
            
        }
        /// <summary>
        /// Добавление нового студента в ListOfStudent
        /// </summary>
        public void AddToList()
        {
            Student student = new Student { FIO = TBfio, Faculty = TBfacult, Specialization = TBspec, Course = TBcourse, Group = TBgroup };
            ListOfStudent.Add(student);

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Закрытие приложения", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                //Если "Нет", просто выйди
            }
            else
            {
                Serializationer.Save(ListOfStudent);//Если "Да", то сохрани и выйди
            }
        }

        #region Рабочие лошадки
        bool EmptyTest()
        {
            if (!string.IsNullOrEmpty(TBfio) && !string.IsNullOrEmpty(TBgroup) && !string.IsNullOrEmpty(TBfacult) && !string.IsNullOrEmpty(TBspec) && !string.IsNullOrEmpty(TBcourse))
            {
                return true;
            }
            else return false;

        }
        string _tbfio;
        public string TBfio
        {
            get
            {
                return _tbfio;
            }
            set
            {
                _tbfio = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TBfio"));
                AddButtonClick.CanExeсChanged();

            }
        }
        string _tbgroup;
        public string TBgroup
        {
            get
            {
                return _tbgroup;
            }
            set
            {
                _tbgroup = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TBgroup"));

                AddButtonClick.CanExeсChanged();

            }
        }
        string _tbfacult;
        public string TBfacult
        {
            get
            {
                return _tbfacult;
            }
            set
            {
                _tbfacult = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TBfacult"));

                AddButtonClick.CanExeсChanged();

            }
        }
        string _tbspec;
        public string TBspec
        {
            get
            {
                return _tbspec;
            }
            set
            {
                _tbspec = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TBspec"));

                AddButtonClick.CanExeсChanged();

            }
        }
        string _tbcourse;
        public string TBcourse
        {
            get
            {
                return _tbcourse;
            }
            set
            {
                _tbcourse = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TBcourse"));

                AddButtonClick.CanExeсChanged();

            }
        }

        void ReadStudents()
        {
            foreach (var i in ser.Load())
            {
                ListOfStudent.Add(i);
            }
        }

        
    }

    #endregion




}
