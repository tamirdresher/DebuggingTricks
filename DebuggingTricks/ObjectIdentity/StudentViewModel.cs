using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Students;


namespace OzCodeDemo.ObjectId
{
    public class StudentViewModel:INotifyPropertyChanged
    {
        private DateTime _lastUpdate;
        private bool _isVip;

        public StudentViewModel(Student student)
        {
            Student = student;
            LastUpdate = DateTime.Now;
        }
        public Student Student { get; set; }

      

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