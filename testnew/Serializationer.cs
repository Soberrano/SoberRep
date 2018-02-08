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
using Newtonsoft.Json;

namespace StudentCard
{
    public class Serializationer
    {
        //    ObservableCollection<Student> _history = new ObservableCollection<Student>();
        public static void Save(ObservableCollection<Student> _history)
        {
            try
            {
                string jsonstr = JsonConvert.SerializeObject(_history);
                var file = File.CreateText("history.json");// создает или открывает файл
                file.Write(jsonstr);// записать в созданный файл серелезованную историю
                file.Close();
            }
            catch
            {
                MessageBox.Show(" не удалось серелизовать");
            }
        }
        public ObservableCollection<Student> Load()
        {
            
            if (File.Exists("history.json"))
            {
                string jsonstr = File.ReadAllText("history.json");
                var _history = JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonstr);
                return _history;
            }
            return null;
        }
      
    }
}
