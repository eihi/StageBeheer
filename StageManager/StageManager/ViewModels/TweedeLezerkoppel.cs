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
    class TweedeLezerkoppel : PropertyChanged
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
                //NotifyOfPropertyChange(() => Koppel);
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




        public TweedeLezerkoppel(MainViewModel main, PropertyChanged last)
            : base(main, last)
        {
            Main = main;


           
        }

        public TweedeLezerkoppel(MainViewModel main, PropertyChanged last, String teacher)
            : base(main, last)
        {
            Main = main;


        }

        public TweedeLezerkoppel(MainViewModel main, PropertyChanged last, internships stage)
            : this(main, last)
        {

            list = new Dictionary<object, db_teacherhasinternship>();
            int ID = unchecked((int)stage.id);
            Stage = stage;

             List = new WStored().Searchteacherasinternship().ToDictionary(t => (Object)new
            {            
                naam = "zoiets",
                aantalkeertweedelezer = "iets",

            }, t => t);


            GridContents = list.Keys.ToList();
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
            /*  OLD CODE 
            Stage.teachers = KoppelDocent;            
            Wrapper myWrapper = new Wrapper();
            myWrapper.forceSync();
            Main.ChangeButton("Zoek", new List<Object>(), Services.Clear.All);
             */
            if (selectedDocent != null)
            {
                
             //   teachers henk = selectedDocent.TeacherInfo;
                List<internships> stages = (from myStage in new WStored().SearchStage("", "", true) where myStage.id == Stage.id select myStage).ToList();
                internships myinternship = stages[0];
             //   myinternship.teacher_user_id = selectedDocent.TeacherInfo.user_id;

                
                //pop up
                MessageBox.Show(selectedDocent.name + " " + selectedDocent.surname + " is aan deze stage gekoppelt als tweede lezer, en de persoon die aan deze al zat is zijn tweedelezer geworden. mits deze nog niet gekoppelt was", "succes!");
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
