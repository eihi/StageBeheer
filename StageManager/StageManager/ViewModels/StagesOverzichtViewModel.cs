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
    class StagesOverzichtViewModel : PropertyChanged
    {
        private Dictionary<Object, dbstageviewcomplete> list;
        Dictionary<Object, dbstageviewcomplete> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => List);
            }
        }

        private List<Object> gridContents;
        public List<object> GridContents
        {
            get
            {
                return gridContents;
            }
            set
            {
                gridContents = value;
                NotifyOfPropertyChange(() => GridContents);
            }
        }
        

        public StagesOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            
            List = new Dictionary<object, dbstageviewcomplete>();
            List = new WStored().SearchDBStageViewComplete().ToDictionary(t => (Object)new
            {
                
                Stagetype = t.type,
                Eerstestudent = t.name + " " + t.surname,
                Tweedestudent = " TODO ",
                Stagebegeleider = t.teacher_name + " " + t.teacher_surname,
                Tweedelezer = t.sr_name + " " + t.sr_surname,
                Bedrijf = t.company_name,
                Bedrijfsbegeleider = t.sv_name + " " + t.sv_surname,
                Begin = t.start_date.ToString().Substring(0, t.start_date.ToString().IndexOf(' ')),
                Eind = t.end_date.ToString().Substring(0, t.end_date.ToString().IndexOf(' ')),

            }, t => t);

        }
    }
}
