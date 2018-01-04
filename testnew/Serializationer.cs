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
    public class Serializationer : MainWindow
    {
        public static void WriteXml(List<Student> student)
        {

            using (StreamWriter writer = new StreamWriter("Serialization001.xml"))
            {
                try
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
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
            var xmlser = new XmlSerializer(typeof(Student));
            string filename = "Serialization001.xml";
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    var newStudent = (Student)xmlser.Deserialize(fs);
                    ListViewItem lvi = new ListViewItem()
                    {
                        Content = newStudent
                    };
                    ListOfStudent.Add(newStudent);
                    theListView.Items.Add(lvi);

                }
            }
            //Student student = null;
            //string filename = "Serialization001.xml";
            //XmlSerializer xser = new XmlSerializer(typeof(Student));
            //if (File.Exists(filename))
            //{
            //    using (StreamReader fs = new StreamReader(filename))
            //    {
            //        student = (Student)xser.Deserialize(fs);
            //        fs.Close();
            //    }

            //}
        }
    }
}
