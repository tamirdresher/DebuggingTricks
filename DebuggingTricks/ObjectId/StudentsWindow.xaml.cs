using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OzCodeDemo.Annotations;

namespace OzCodeDemo.ObjectId
{
    /// <summary>
    /// Interaction logic for StudentsWindow.xaml
    /// </summary>
    public partial class StudentsWindow : Window, INotifyPropertyChanged
    {
        private IEnumerable<StudentViewModel> _students;

        public StudentsWindow()
        {
            InitializeComponent();
        }

        public IEnumerable<StudentViewModel> Students
        {
            get { return _students; }
            set
            {
                if (Equals(value, _students)) return;
                _students = value;
                OnPropertyChanged();
            }
        }

        private void OnLoadMore(object sender, RoutedEventArgs e)
        {
            var studentRepository = new StudentRepository();
            Students = studentRepository
                .GetStudents()
                .Select(s => new StudentViewModel(s));

            SetVip(Students);
        }

        private void SetVip(IEnumerable<StudentViewModel> students)
        {
            foreach (var student in students)
            {
                student.IsVip = student.Name.Contains("Bart");
            }
        }

        private void OnCalculateGrades(object sender, RoutedEventArgs e)
        {
            foreach (var student in Students)
            {
                student.Grade = student.IsVip ? 100 : 85;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
