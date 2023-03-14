using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimpleBank.Model
{
    public class ObjectObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var eventArgs = new PropertyChangedEventArgs(propertyName);
                handler(this, eventArgs);
            }
        }
    }
}
