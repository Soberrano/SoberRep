using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentCard
{
    [Serializable]
    public class Student
    {
        [XmlAttribute("ФиоСтудента")]
        public string FIO { get; set; }
        [XmlAttribute("Факультет")]
        public string Faculty { get; set; }
        [XmlAttribute("Специальность")]
        public string Specialization { get; set; }
        [XmlAttribute("Курс")]
        public string Course { get; set; }
        [XmlAttribute("Группа")]
        public string Group { get; set; }
    }
}
