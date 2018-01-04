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

namespace testnew
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Student> ListOfStudent = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
            AddButtonClick = new LambdaCommand((param) =>
            {
                return EmptyLi();
            },
                (param) =>
                {
                    AddToList();
                });

            ChangeButtonClick = new LambdaCommand((param) => { return true; }, (param) => { Reload(); });
            DataContext = this;
        }
        bool EmptyLi()
        {
            if (!string.IsNullOrEmpty(TBfio) && !string.IsNullOrEmpty(TBgroup) && !string.IsNullOrEmpty(TBfacult) && !string.IsNullOrEmpty(TBspec) && !string.IsNullOrEmpty(TBcourse))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Добавление нового студента в ListView
        /// </summary>
        public void AddToList()
        {
            Student student = new Student { FIO = TBfio, Facult = TBfacult, Spec = TBspec, Course = TBcourse, Group = TBgroup };
            ListViewItem lvi = new ListViewItem()
            {
                Content = student
            };
            ListOfStudent.Add(student);
            theListView.Items.Add(lvi);
            Serializationer.WriteXml(ListOfStudent);
        }
        public void Reload()
        {

        }

       
        #region Рабочие лошадки

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



        public LambdaCommand AddButtonClick { get; set; }
        public LambdaCommand ChangeButtonClick { get; set; }

        Serializationer ser = new Serializationer();

        public class LambdaCommand : ICommand
        {
            delegate bool CanExecutedelegate(object nekoeOpisanieCanExec);
            delegate void Executedelegate(object nekoeOpisanieExec);

            CanExecutedelegate _CanExecuteDelegate;
            Executedelegate _ExecuteDelegate;


            public LambdaCommand(Func<object, bool> konkretnoeOpisanieCanExec, Action<object> konkretnoeOpisanieExec)
            {

                _CanExecuteDelegate = new CanExecutedelegate(konkretnoeOpisanieCanExec);
                _ExecuteDelegate = new Executedelegate(konkretnoeOpisanieExec);
            }


            public bool CanExecute(object exemplarDelegata)
            {
                return _CanExecuteDelegate(exemplarDelegata);
            }
            public void Execute(object exemplarDelegata)
            {
                _ExecuteDelegate(exemplarDelegata);
            }
            public void CanExeсChanged()
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged.Invoke(this, new EventArgs());
            }
            public event EventHandler CanExecuteChanged;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in ser.GetStudents())
            {
                theListView.Items.Add(i);
            }
        }
    }
    #endregion
    [Serializable]
    public class Student
    {
        [XmlAttribute("ФиоСтудента")]
        public string FIO { get; set; }
        [XmlAttribute("Факультет")]
        public string Facult { get; set; }
        [XmlAttribute("Специальность")]
        public string Spec { get; set; }
        [XmlAttribute("Курс")]
        public string Course { get; set; }
        [XmlAttribute("Группа")]
        public string Group { get; set; }
    }


}
