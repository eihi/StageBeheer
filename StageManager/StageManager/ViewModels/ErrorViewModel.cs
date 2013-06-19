using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageManager.ViewModels
{
    public class ErrorViewModel : PropertyChangedBase
    {
        private Visibility opacity;
        public Visibility Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                opacity = value;
                NotifyOfPropertyChange(() => Opacity);
            }
        }

        public ErrorViewModel()
        {
            Opacity = Visibility.Collapsed;
        }

        public void Sluit()
        {
            Opacity = Visibility.Collapsed;
        }

        public void Error()
        {
            Opacity = Visibility.Visible;
        }
    }
}