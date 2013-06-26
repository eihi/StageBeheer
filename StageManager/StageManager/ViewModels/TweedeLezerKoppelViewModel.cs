using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageManager.ViewModels
{
    class TweedeLezerKoppelViewModel : PropertyChanged
    {
        private internships stage;

        public internships Stage
        {
            get { return stage; }
            set
            {
                stage = value;
                NotifyOfPropertyChange(() => CanTweedeLezer);
                NotifyOfPropertyChange(() => KoppelStudentNaam);
            }
        }

        public String Koppel
        {
            get
            {
                if (selectedDocent != null)
                {
                    return "Koppel student aan " + selectedDocent.name + " " + selectedDocent.surname;
                }
                return "Koppel student aan _____";
            }
        }

        private String koppelStudentNaam = "<geselecteerde student>";
        public String KoppelStudentNaam
        {

            get { return koppelStudentNaam; }
            set
            {
                koppelStudentNaam = value;
                NotifyOfPropertyChange(() => KoppelStudentNaam);
            }
        }

        private db_teacherhasinternship selectedDocent;
        public Object SelectedDocent
        {

            get { return selectedDocent; }
            set
            {
                List.TryGetValue(value, out selectedDocent);
                KoppelDocent = selectedDocent;
                NotifyOfPropertyChange(() => SelectedDocent);
                NotifyOfPropertyChange(() => Koppel);
            }
        }

        private db_teacherhasinternship koppelDocent;
        public db_teacherhasinternship KoppelDocent
        {

            get { return koppelDocent; }
            set
            {
                koppelDocent = value;
                KoppelDocentNaam = koppelDocent.surname + ", " + koppelDocent.name;
                NotifyOfPropertyChange(() => KoppelDocent);
            }
        }

        private String koppelDocentNaam = "<geselecteerde docent>";
        public String KoppelDocentNaam
        {

            get { return koppelDocentNaam; }
            set
            {
                koppelDocentNaam = value;
                NotifyOfPropertyChange(() => KoppelDocentNaam);
            }
        }

        public Boolean CanTweedeLezer
        {
            get
            {
                return Stage != null ? Stage.GetType() == typeof(internships) : false;
            }
        }

        private Dictionary<Object, db_teacherhasinternship> list;
        public Dictionary<Object, db_teacherhasinternship> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
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




        public TweedeLezerKoppelViewModel(MainViewModel main, PropertyChanged last)
            : base(main, last)
        {
            Main = main;


           
        }

        public TweedeLezerKoppelViewModel(MainViewModel main, PropertyChanged last, String teacher)
            : base(main, last)
        {
            Main = main;


        }

        public TweedeLezerKoppelViewModel(MainViewModel main, PropertyChanged last, internships stage)
            : this(main, last)
        {

            list = new Dictionary<object, db_teacherhasinternship>();            
            Stage = stage;

             List = new WStored().Searchteacherhasinternship().ToDictionary(t => (Object)new
            {            
                naam = t.name + " " + t.surname,
                aantalkeertweedelezer = getStageCount(t.teacher_user_id.Value),
            }, t => t);

            GridContents = list.Keys.ToList();
        }


        public int getStageCount(int teacher)
        {
            int count = 0;
            List<internships> countlist = (from aantal in new WStored().SearchStageSet() where aantal.secondReader != null && aantal.secondReader == teacher select aantal).ToList();
            count = countlist.Count;
            return count;
        }


        public override void update(object[] o)
        {
            try
            {
                Stage = (internships)o[2];
            }
            catch (Exception)
            {
            }
        }

        public void Koppelen()
        {
     
            if (selectedDocent != null)
            {
                List<internships> stages = (from myStage in new WStored().SearchStage("", "", true) where myStage.id == Stage.id select myStage).ToList();
                internships myinternship = stages[0];
                int selected = selectedDocent.teacher_user_id.Value;
                myinternship.secondReader = selected;                
                //pop up
                MessageBox.Show(selectedDocent.name + " " + selectedDocent.surname + " is aan deze stage gekkoppelt als tweede lezer", "succes!");
                //update vorig scherm

                WStored.PushToDB();
                Last.update();
                //sluit scherm
                this.Close();
                //update stage scherm
            }
            else
                MessageBox.Show("Geen docent geselecteerd", "error");

        }

    }
}
