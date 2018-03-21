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
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Student> ListOfStudent { get; set; } = new ObservableCollection<Student>();
        Serializationer ser = new Serializationer();
        testnew.AddWindow aw = new testnew.AddWindow();
        public MainWindow()
        {
            InitializeComponent();
            ReadStudents();
            DataContext = this;
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
        void ReadStudents()
        {
            foreach (var i in ser.Load())
            {
               ListOfStudent.Add(i);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)//Открывает окно добавления нового студента
        {
            
            aw.Show();
        }
    }





}
