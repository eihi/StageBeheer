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
    class KoppelViewModel : PropertyChanged
    {
        private internships stage;

        

        public String Koppel
        {
            get
            {
                if (selectedDocent != null)
                {
                    return "Koppel student aan " + selectedDocent.TeacherInfo.users.name + " " + selectedDocent.TeacherInfo.users.surname;
                }
                return "Koppel student aan _____";
            }
        }

        public String Info
        {
            get
            {
                return "STAGE INFO \n Kennis nodig voor deze stage " + list.First().Value.stageKnowledge +
                     "\n Benodigde tijd: " + list.First().Value.timeNeeded +
                     "\n School jaar: " + list.First().Value.Year +  "-" + (list.First().Value.Year + 1) +
                     "\n Blokken: " + list.First().Value.blokken.Substring(0, 1) + "," + list.First().Value.blokken.Substring(1, 1) +
                     "\n Locatie: " + Stage.supervisor.companies.adresses.place + ", " + Stage.supervisor.companies.adresses.street + " " + Stage.supervisor.companies.adresses.housenumber; 
            }
        }

        public internships Stage
        {
            get { return stage; }
            set { stage = value;            
            NotifyOfPropertyChange(()=>  CanTweedeLezer);
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

        private DocentValue selectedDocent;
        public Object SelectedDocent
        {

            get { return selectedDocent; }
            set
            {
                List.TryGetValue(value, out selectedDocent);
                KoppelDocent = selectedDocent.TeacherInfo;
                NotifyOfPropertyChange(() => SelectedDocent);
                NotifyOfPropertyChange(() => Koppel);
            }
        }

        private teachers koppelDocent;
        public teachers KoppelDocent
        {

            get { return koppelDocent; }
            set
            {
                koppelDocent = value;
                KoppelDocentNaam = koppelDocent.users.surname + ", " + koppelDocent.users.name;
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
            get { return Stage!=null? Stage.GetType()== typeof(internships):false;
            }
        }

        private Dictionary<Object, DocentValue> list;
        public Dictionary<Object, DocentValue> List
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




        public KoppelViewModel(MainViewModel main)
            : base(main)
        {
            Main = main;
            

            list = new Dictionary<object, DocentValue>();        

            List = (new ImportanceChecker().checkImportance(2).ToDictionary(t => (Object)new
                    {
                        waarde = t.value,
                        naam = t.TeacherInfo.users.name + " " + t.TeacherInfo.users.surname, 
                        aantalkennis = t.numberOfKnowledge,
                        kennis = t.sameKnowledgeString,
                        afstand = t.distance,
                        tijdover = t.timeleftafter,                        

                    }, t => t));


            GridContents = list.Keys.ToList();
        }

        public KoppelViewModel(MainViewModel main, String teacher)
            : base(main)
        {
            Main = main;


            list = new Dictionary<object, DocentValue>();

            list = (new ImportanceChecker().checkImportance(2).ToDictionary(t => (Object)new
            {
                waarde = t.value,
                naam = t.TeacherInfo.users.name + " " + t.TeacherInfo.users.surname,
                aantalkennis = t.numberOfKnowledge,
                kennis = t.sameKnowledgeString,
                afstand = t.distance,
                tijdover = t.timeleftafter,
                vervoer = t.TeacherInfo.transport.name,

            }, t => t));


            GridContents = list.Keys.ToList();
        }

        public KoppelViewModel(MainViewModel main, internships stage)
            :this(main)
        {
            
            list = new Dictionary<object, DocentValue>();
            int ID = unchecked((int)stage.id);
            Stage = stage;
            list = (new ImportanceChecker().checkImportance(ID).ToDictionary(t => (Object)new
            {
                waarde = t.value,
                naam = t.TeacherInfo.users.name + " " + t.TeacherInfo.users.surname,
                aantalkennis = t.numberOfKnowledge,
                kennis = t.sameKnowledgeString,
                afstand = t.distance,
                tijdover = t.timeleftafter,

            }, t => t));


            GridContents = list.Keys.ToList();
        }

        public override void update(object[] o)
        {
            try
            {
                Stage = (internships)o[1];
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
                //stage.begeleider = selected
            //  Stage.teachers = selectedDocent.TeacherInfo;
                //selected.volumehours.juisteblokken - tijd
           //   selectedDocent.removeTime();
                //pop up
                MessageBox.Show(selectedDocent.TeacherInfo.users.name + " " + selectedDocent.TeacherInfo.users.surname + " is aan deze stage gekoppeld", "succes!");
                //sluit scherm
                this.Close();
                //update stage scherm
            }
            else
                MessageBox.Show("Geen docent geselecteerd", "error");
  
        }

    }
}
