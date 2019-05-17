using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using Xamarin.Forms;

namespace DungeonsAndDragonsAppS.ViewModel.Abstract
{
    class ViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Volá událost PropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
