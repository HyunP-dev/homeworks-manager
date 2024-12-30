using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using application.DataModel;
using application.Model;
using CsvHelper.Configuration;
using Microsoft.Win32;

namespace application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StudentsView.MouseDoubleClick += (s, e) =>
            {
                StudentPerInfo info = (StudentPerInfo) StudentsView.SelectedItem;
                var paths = MainModel.Instance.GetHomeworkPaths(info.Student);

                var files = new LinkedList<FileInfo>();
                foreach(var path in paths)
                {
                    files.AddLast(new FileInfo(path));
                }
                FilesView.ItemsSource = files;

            };
        }

        private void OpenHomeworkDir(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                CurDirView.Content = $"현재 디렉토리: {dialog.FolderName}";
                MainModel.Instance.Dir = dialog.FolderName;
                StudentsView.ItemsSource = MainModel.Instance.StudentInfos;
            }
        }

        private void LoadStudents(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using var streamReader = new StreamReader(dialog.OpenFile());
                using var csvReader = new CsvHelper.CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ",", Encoding = Encoding.UTF8 });
                csvReader.Read();
                csvReader.ReadHeader();
                var students = csvReader.GetRecords<Student>().ToArray();

                MainModel.Instance.Students = students;
            }
        }

        private void CreateStudentDir(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "폴더들을 생성할 위치를 선택해주세요.";
            if (dialog.ShowDialog() == true)
            {
                // TODO: 폴더를 생성 후, 각 과제물들을 맞는 폴더 내로 옮기는 로직 작성.
            }
        }
    }
}