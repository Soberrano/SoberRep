using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentCard
{
    public class Student
    {//так и не получилось адекватно разбить студента на составляющие :(
        public string FIO { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public double TelNum { get; set; }
    }
}
