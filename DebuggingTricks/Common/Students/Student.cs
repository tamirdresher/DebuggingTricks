using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Annotations;

namespace Common.Students
{
    public class Student:INotifyPropertyChanged
    {
        private double _grade;
        private string _email;
        private string _name;
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        public double Grade
        {
            get { return _grade; }
            set
            {
                if (value.Equals(_grade)) return;
                _grade = value;
                OnPropertyChanged();
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
