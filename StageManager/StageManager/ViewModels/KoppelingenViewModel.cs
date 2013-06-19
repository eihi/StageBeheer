using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;
using StageManager.Views;
using StageManager.Controllers;
using Caliburn.Micro;
using StageManager.Services;

namespace StageManager.ViewModels
{
    class KoppelingenViewModel : PropertyChanged
    {
        private List<Object> koppelGridContents;
        public List<Object> KoppelGridContents
        {
            get { return koppelGridContents; }
            set
            {
                foreach (object c in value)
                {
                    koppelGridContents.Add(c);
                }
                NotifyOfPropertyChange(() => KoppelGridContents);
            }
        }

        public KoppelingenViewModel(MainViewModel main)
            :base(main)
        {
            koppelGridContents = new List<object>();
            searchKoppelingen();
        }

        public void searchKoppelingen()
        {
            //KoppelGridContents = (from stage in new WStored().SearchKoppelingSet()
            //                      select (object)new { Student1 = stage.students.users.name + " " + stage.studentset.Achternaam, Student2 = stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam, Stageopdracht = stage.description, Docent = stage.teachers.users.name + " " + stage.teachers.users.surname }).ToList();
           
            //KoppelGridContents = (from stage in new WStored().SearchKoppelingSet2()
            //                      select (object)new { Student1 = stage.studentset.Voornaam + " " + stage.studentset.Achternaam, Student2 = "", Stageopdracht = stage.Stageopdracht_omschijving, Docent = stage.docentsets.Voornaam + " " + stage.docentsets.Achternaam }).ToList();


        }
    }
}