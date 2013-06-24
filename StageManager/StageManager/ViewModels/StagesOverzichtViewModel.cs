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
            List<dbstageviewcomplete> tempList = (from stage in new WStored().SearchDBStageViewComplete() select stage).ToList();

            for (int i = 0; i < tempList.Count; i++)
            {
                String tweedeStudent = "";
                if (i < tempList.Count - 1 && tempList[i].internshipID == tempList[i + 1].internshipID)
                {
                    tweedeStudent = tempList[i + 1].name + " " + tempList[i + 1].surname;
                }
                object o = (Object)new
                {
                    Stagetype = tempList[i].type,
                    Eerstestudent = tempList[i].name + " " + tempList[i].surname,
                    Tweedestudent = " TODO ",
                    Stagebegeleider = tempList[i].teacher_name + " " + tempList[i].teacher_surname,
                    Tweedelezer = tempList[i].sr_name + " " + tempList[i].sr_surname,
                    Bedrijf = tempList[i].company_name,
                    Bedrijfsbegeleider = tempList[i].sv_name + " " + tempList[i].sv_surname,
                    Begin = tempList[i].start_date.ToString().Substring(0, tempList[i].start_date.ToString().IndexOf(' ')),
                    Eind = tempList[i].end_date.ToString().Substring(0, tempList[i].end_date.ToString().IndexOf(' ')),
                };
                List.Add(o, tempList[i]);
                NotifyOfPropertyChange(() => List);
            }
        }
    }
}
