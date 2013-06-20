using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class StageViewModel : PropertyChangedBase
    {
        public StageViewModel(MainViewModel main)
            //:base(main)
        {
        }

        public StageViewModel(MainViewModel main, internships stage)
            : this(main)
        {
            //Stage = stage;
        }
    }
}
