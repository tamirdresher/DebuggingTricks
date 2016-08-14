using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Students;


namespace OzCodeDemo.ObjectId
{
    public class StudentViewModel:INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _email;
        private double _grade;
        private DateTime _lastUpdate;
        private bool _isVip;

        public StudentViewModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Email = student.Email;
            Grade = student.Grade;
            LastUpdate = DateTime.Now;
        }
        
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

        public bool IsVip
        {
            get { return _isVip; }
            set
            {
                if (value == _isVip) return;
                _isVip = value;
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

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                if (value.Equals(_lastUpdate)) return;
                _lastUpdate = value;
                OnPropertyChanged();
            }
        }
        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}