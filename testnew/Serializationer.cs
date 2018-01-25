using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace testnew
{
    public class Serializationer
    {
        public static void WriteXml(ObservableCollection<Student> student)
        {

            using (StreamWriter writer = new StreamWriter("Serialization001.xml"))
            {
                try
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Student>));
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

        public ObservableCollection<Student> GetStudents()
        {
            MainWindow mw = new MainWindow();
            var xmlser = new XmlSerializer(typeof(ObservableCollection<Student>));
            string filename = "Serialization001.xml";

            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    var newStudent = new ObservableCollection<Student>();
                    newStudent = (ObservableCollection<Student>)xmlser.Deserialize(fs);
                    return newStudent;
                }
            }
            return null;

        }
    }
}
