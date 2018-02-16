using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentCard
{
    public class Student
    {
        public string FIO { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public string Course { get; set; }
        public string Group { get; set; }
    }
}
