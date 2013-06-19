using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class KoppelViewModel : PropertyChanged
    {
        private internships stage;

        public internships Stage
        {
            get { return stage; }
            set { stage = value;
            //KoppelStudentNaam = stage.studentset.Voornaam + " " + stage.studentset.Achternaam;        TODO!!!!!!!!!!
            NotifyOfPropertyChange(()=>CanTweedeLezer);
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

        private teachers selectedDocent;
        public Object SelectedDocent
        {

            get { return selectedDocent; }
            set
            {
                selectedDocent = new WStored().SearchDocentSet(value.GetType().GetProperty("Voornaam").GetMethod.Invoke(value, null).ToString()).First();
                KoppelDocent = selectedDocent;
                NotifyOfPropertyChange(() => SelectedDocent);
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

        private Dictionary<Object, teachers> list;
        public Dictionary<Object, teachers> List
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



        public void TweedeLezer()
        {
            Main.ChangeButton("");//TODO!!
        }

        public KoppelViewModel(MainViewModel main)
            : base(main)
        {
            Main = main;
            list = new Dictionary<object, teachers>();
            list = (new WStored().SearchDocentSet("").ToDictionary(t => (Object)new
                    {
                        Voornaam = t.users.name,
                        Achternaam = t.users.surname,
                        Uren = 10, // TODO: uren rest
                        Kennisgebied = t.knowledge.First().name,
                        Afstand = 500
                    }, t => t));


            GridContents = list.Keys.ToList();
        }

        public KoppelViewModel(MainViewModel main, internships stage)
            :this(main)
        {
            Stage = stage;
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
            Stage.teachers = KoppelDocent;            
            Wrapper myWrapper = new Wrapper();
            myWrapper.forceSync();
            Main.ChangeButton("Zoek", new List<Object>(), Services.Clear.All);
        }

    }
}
