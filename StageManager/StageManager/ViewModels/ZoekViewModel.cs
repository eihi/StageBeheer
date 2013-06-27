using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;

namespace StageManager.ViewModels
{
    public class ZoekViewModel : PropertyChanged
    {
        private String searchString;
        public enum SearchType { Docenten, Studenten }
        private SearchType stype = SearchType.Studenten;

        public String SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                //searchStage();

                switch (stype)
                {
                    case SearchType.Docenten:
                        searchDocent();
                        break;
                    case SearchType.Studenten:
                        searchStudent();
                        break;
                }

                NotifyOfPropertyChange(() => SearchString);
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

        private String searchOpleiding;
        public String SearchOpleiding
        {
            get { return searchOpleiding; }
            set
            {
                searchOpleiding = value;
                searchStage();
                NotifyOfPropertyChange(() => SearchOpleiding);
            }
        }

        private Dictionary<Object,internships> stageList;
        public Dictionary<Object, internships> StageList
        {
            get
            {
                return stageList;
            }
            set
            {
                stageList = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => StageList);
            }
        }

        private Dictionary<Object, teachers> docentList;
        public Dictionary<Object, teachers> DocentList
        {
            get
            {
                return docentList;
            }
            set
            {
                docentList = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => DocentList);
            }
        }

        private Dictionary<Object, students> studentList;
        public Dictionary<Object, students> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                studentList = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => StudentList);
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

        private internships selectedStage;
        public internships SelectedStage
        {
            get { return selectedStage; }
            set { selectedStage = value; }
        }

        private object _selectedObject;
        public object SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;

                StageViewModel svm = (StageViewModel)Last;

                if (svm == null)
                {
                    return;
                }

                List<internships> internships = (from myStage in new WStored().SearchStage("", "", true)
                                                 where myStage.id == svm.StageId()
                                                 select myStage).ToList();
                internships internship = internships[0];
                students student = null;
                switch (svm.SearchFor)
                {
                    case StageViewModel.Search.TweedeStudent:
                        var studentnummer = _selectedObject.GetType().GetProperty("Studentnummer");
                        student = new WStored().SearchStudentSet(studentnummer.GetValue(_selectedObject, null).ToString(), "")[0];
                        //internship.students_internships.ElementAtOrDefault(1).students.user_id = student.user_id;
                        break;

                        //Deze case is niet meer relevant. wordt al gedaan met een tweedelezerkoppelview + viewmodel.
                    case StageViewModel.Search.TweedeLezer:
                        var voornaam = _selectedObject.GetType().GetProperty("Voornaam");
                        var achternaam = _selectedObject.GetType().GetProperty("Achternaam");
                        teachers teacher = new WStored().SearchDocentSet(voornaam.GetValue(_selectedObject, null).ToString(), achternaam.GetValue(_selectedObject, null).ToString())[0];
                        internship.teacher_user_id = teacher.user_id;
                        break;
                }
                
                
                students_internships insert = new students_internships();
                insert.intership_id = internship.id;
                insert.student_user_id = student.user_id;
                insert.achieved = "0";

                /*
                 * TODO <_----------- stageview iets updaten 
                 */
                WStored.StageManagerEntities.students_internships.Add(insert);
                
                WStored.PushToDB();
                Last.update();                
                MessageBox.Show(student.users.name + " " + student.users.surname + " is aan deze stage gekoppeld", "succes!");
                this.Close();
            }
        }

        public void Test(students student)
        {
            Main.ChangeButton("Student",this, new List<object>() { student }, Clear.After);
        }

        public ZoekViewModel(MainViewModel main,PropertyChanged last)
            :base(main,last)
        {
            OpleidingStack = (from opleiding in new WStored().SearchOpleidingSet() select opleiding.name).ToList();
            switch(stype)
            {
                case SearchType.Docenten:
                    searchDocent();
                    break;
                case SearchType.Studenten:
                    searchStudent();
                    break;
            }
        }

        public ZoekViewModel(MainViewModel main,PropertyChanged last, String zoekString, SearchType type)
            : this(main, last)
        {
            stype = type;
            SearchString = zoekString;
        }

        public void searchStage()
        {
            //list = new Dictionary<object, internships>();
            //list = (new WStored().SearchStage(searchString, searchOpleiding,false).ToDictionary(t=>(Object)new
            //        {
            //                Stage = t.description,
            //                Studentnummer = t.student.Studentnummer,
            //                Voornaam = t.studentset.Voornaam,
            //                Achternaam = t.studentset.Achternaam,
            //                Opleiding = t.studentset.Opleidingset.Naam,
            //                EC_Norm_Behaald = t.studentset.EC_norm_behaald
            //        },t=>t));
            //if (list.Count == 0)
            //{
            //    list.Add((Object)new
            //    {
            //        Error = "No occurrences found!"
            //    },null);

            //}
            //    GridContents = list.Keys.ToList();
        }

        public void searchDocent()
        {
            docentList = new Dictionary<object, teachers>();
            docentList = (new WStored().SearchDocentSet(searchString).ToDictionary(t => (Object)new
            {
                Voornaam = t.users.name,
                Achternaam = t.users.surname

            }, t => t));
            if (docentList.Count == 0)
            {
                docentList.Add((Object)new
                {
                    Error = "No occurrences found!"
                }, null);

            }
                GridContents = docentList.Keys.ToList();
        }

        public void searchStudent()
        {
            studentList = new Dictionary<object, students>();
            studentList = (new WStored().SearchStudentSet(searchString, searchOpleiding).ToDictionary(t => (Object)new
            {
                Studentnummer = t.users.students.studentnumber,
                Voornaam = t.users.name,
                Achternaam = t.users.surname
            }, t => t));
            if (studentList.Count == 0)
            {
                studentList.Add((Object)new
                {
                    Error = "No occurrences found!"
                }, null);

            }
            GridContents = studentList.Keys.ToList();
        }

        public override void update(object[] o)
        {
            try
            {
                SearchString = (String)o[2];
            }
            catch (Exception)
            {
            }
        }
    }
}
