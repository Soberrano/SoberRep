using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testnew
{
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
