using StudentCard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace testnew
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public LambdaCommand AddButtonClick { get; set; }
        public LambdaCommand ChangeButtonClick { get; set; }
        public bool Check = false;
        public AddWindow()
        {
            InitializeComponent();
        }
        public void AddToList()
        {
            Student student = new Student { FIO = tbFIO.Text, Faculty = tbFaculty.Text, Specialization = tbSpecialty.Text, Course = Convert.ToInt32(tbCourse.Text), Group = tbGroup.Text, TelNum = Convert.ToDouble(tbTelNum.Text)};
            MainWindow.ListOfStudent.Add(student);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFIO.Text) && !string.IsNullOrEmpty(tbGroup.Text) && !string.IsNullOrEmpty(tbFaculty.Text) && !string.IsNullOrEmpty(tbSpecialty.Text) && !string.IsNullOrEmpty(tbCourse.Text) && !string.IsNullOrEmpty(tbTelNum.Text))
            {
                AddToList();
            }
        }
    }
}
