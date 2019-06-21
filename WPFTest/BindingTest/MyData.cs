using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BindingTest
{
    public class MyData : INotifyPropertyChanged
    {
        private DateTime now;

        public MyData()
        {
            now = DateTime.Now;
        }
        public DateTime Now
        {
            get
            {
                return now;
            }
            set
            {
                now = value;
                OnPropertyChanged("DateTime");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
