using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class NotifyObjectBase : INotifyPropertyChanged,INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanging(string propertyName)
        {
            if(PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                return;
            if(propertyExpression != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
            }
        }

        protected virtual void OnPropertyChanging<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                return;
            if (propertyExpression != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                PropertyChanging(this, new PropertyChangingEventArgs(body.Member.Name));
            }
        }
    }
}
