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
    class DemoNieuwKoppelViewModel : PropertyChanged
    {
        private List<Object> studentGridContents;
        public List<Object> StudentGridContents
        {
            get { return studentGridContents; }
            set
            {
                studentGridContents = value;
                NotifyOfPropertyChange(() => StudentGridContents);
            }
        }

        private List<teachers> docentGridContents;
        public List<teachers> DocentGridContents
        {
            get { return docentGridContents; }
            set
            {
                docentGridContents = value;
                NotifyOfPropertyChange(() => DocentGridContents);
            }
        }

        private List<teachers> lezerGridContents;
        public List<teachers> LezerGridContents
        {
            get { return lezerGridContents; }
            set
            {
                lezerGridContents = value;
                NotifyOfPropertyChange(() => LezerGridContents);
            }
        }

        private String searchString;
        public String SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                searchStudent();
                NotifyOfPropertyChange(() => SearchString);
            }
        }

        private String searchOpleiding;
        public String SearchOpleiding
        {
            get { return searchOpleiding; }
            set
            {
                searchOpleiding = value;
                searchStudent();
                NotifyOfPropertyChange(() => SearchOpleiding);
            }
        }

        private List<String> opleidingStack;
        public List<String> OpleidingStack
        {
            get { return opleidingStack; }
            set
            {
                opleidingStack = value;
                NotifyOfPropertyChange(() => OpleidingStack);
            }
        }

        private students selectedStudent;
        public Object SelectedStudent
        {

            get { return selectedStudent; }
            set
            {
                try
                {
                    selectedStudent = new WStored().SearchStudentSetWithStage(value.GetType().GetProperty("Studentnummer").GetMethod.Invoke(value, null).ToString(), "").First();
                    KoppelStudent = selectedStudent;
                    NotifyOfPropertyChange(() => SelectedStudent);
                }
                catch
                {

                }
            }
        }

        private students koppelStudent;
        public students KoppelStudent
        {

            get { return koppelStudent; }
            set
            {
                koppelStudent = value;
                KoppelStudentNaam = koppelStudent.users.surname + ", " + koppelStudent.users.name;
                NotifyOfPropertyChange(() => KoppelStudent);
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


        public DemoNieuwKoppelViewModel(MainViewModel main)
            :base(main)
        {
            SearchString = "";
            SearchOpleiding = "";
            FillView();
            OpleidingStack = (from opleiding in new WStored().SearchOpleidingSet() select opleiding.Naam).ToList();
        }

        //Vul grid
        public void FillView()
        {
            DocentGridContents = new WStored().SearchDocentSet(null);
            LezerGridContents = new WStored().SearchDocentSet(null);
        }

        public void searchStudent()
        {
            StudentGridContents = (from student in new WStored().SearchStudentSetWithStage(SearchString, SearchOpleiding)
                                   select (object)new { Studentnummer = student.Studentnummer, Voornaam = student.Voornaam, Achternaam = student.Achternaam, EC_norm_behaald = student.EC_norm_behaald }).ToList();
        }

        public void Koppelen()
        {
            internships myStage = new WStored().SearchStageSet(KoppelStudent.Id);
            myStage.teachers = KoppelDocent;

            SearchString = "";
            SearchOpleiding = "";
            searchStudent();
        }
    }
}
