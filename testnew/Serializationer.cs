using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace testnew
{
    public class Serializationer
    {
        public static void WriteXml(List<Student> student)
        {

            using (StreamWriter writer = new StreamWriter("Serialization001.xml"))
            {
                try
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    //XmlRootAttribute root = new XmlRootAttribute("List<Student>");
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>)/*, root*/);
                    serializer.Serialize(writer, student, ns);
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения");
                }
                finally
                {
                    writer.Close();
                }

            }

        }

        public void GetStudents()
        {
            //Student student = new Student { FIO = "ФиоСтудента", Facult = "Факультет", Spec = "Специальность", Course = "Курс", Group = "Группа" };
            MainWindow mw = new MainWindow();
            var xmlser = new XmlSerializer(typeof(List<Student>));
            string filename = "Serialization001.xml";
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    var newStudent = new List<Student>();
                    newStudent = (List<Student>)xmlser.Deserialize(fs);
                    ListViewItem lvi = new ListViewItem()
                    {
                        Content = newStudent
                    };
                    mw.theListView.Items.Add(lvi);
                }
            }

        }
    }
}
