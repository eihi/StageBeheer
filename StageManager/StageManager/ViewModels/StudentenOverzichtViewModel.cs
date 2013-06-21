using Caliburn.Micro;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class StudentenOverzichtViewModel : PropertyChanged
    {
        public StudentenOverzichtViewModel(MainViewModel main)
            : base(main)
        {
        }

        //public studentenoverzichtviewmodel(mainviewmodel main, students student)
        //    : this(main)
        //{
        //    // todo
        //}
    }
}
