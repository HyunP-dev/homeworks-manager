using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DataModel
{
    public class StudentPerInfo
    {
        private readonly Student _student;
        public Student Student { get => _student; }
        public string Name { get => _student.Name; }
        public int Number { get => _student.Number; }
        public int NFile { get; set; }
        public StudentPerInfo (Student student)
        {
            _student = student;
            NFile = 0;
        }
    }
}
