using System.IO;
using application.DataModel;

namespace application.Model
{
    public class MainModel
    {
        private MainModel()
        {
        }

        private static readonly Lazy<MainModel> _instance =
            new Lazy<MainModel>(() => new MainModel());
        public static MainModel Instance { get => _instance.Value; }

        public IEnumerable<Student> Students { get; set; }
        public string Dir { get; set; }
        public IEnumerable<StudentPerInfo> StudentInfos
        {
            get
            {
                var files = Directory.GetFiles(Dir);
                var result = new HashSet<StudentPerInfo>();
                foreach (var student in Students)
                {
                    var studentInfo = new StudentPerInfo(student);
                    foreach (var file in files)
                    {
                        if (file.Contains(student.Number.ToString()) || file.Contains(student.Name.ToString()))
                        {
                            studentInfo.NFile++;
                            continue;
                        }
                    }
                    result.Add(studentInfo);
                }
                return result;
            }
        }

        public IEnumerable<string> GetHomeworkPaths(Student student)
        {
            var files = Directory.GetFiles(Instance.Dir);

            var result = new HashSet<string>();
            foreach (var file in files)
            {
                if (file.Contains(student.Number.ToString()) || file.Contains(student.Name.ToString()))
                {
                    result.Add(file);
                    continue;
                }
            }
            return result;
        }
    }
}
