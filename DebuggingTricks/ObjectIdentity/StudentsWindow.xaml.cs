using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Common.Students;

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
            foreach (var studentVM in students)
            {
                studentVM.IsVip = studentVM.Student.Name.Contains("Bart");
            }
        }

        private void OnCalculateGrades(object sender, RoutedEventArgs e)
        {
            foreach (var studentVM in Students)
            {
                studentVM.Student.Grade = studentVM.IsVip ? 100 : 85;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
