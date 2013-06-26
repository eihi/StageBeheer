using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using StageManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageManager.ViewModels
{
    class StageViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private internships stage;
        public enum Search { TweedeStudent, TweedeLezer };
        
        private Search _searchFor;
        public Search SearchFor 
        {
            get
            {
                return _searchFor;
            }
            set
            {
                _searchFor = value;
            }
        }

        internal internships Stage
        {
            get { return stage; }
            set
            {
                stage = value;
                NotifyOfPropertyChange(() => EersteStudent);
                NotifyOfPropertyChange(() => TweedeStudent);
                NotifyOfPropertyChange(() => Stagebegeleider);
                NotifyOfPropertyChange(() => TweedeLezer);
                NotifyOfPropertyChange(() => Bedrijf);
                NotifyOfPropertyChange(() => Bedrijfsbegeleider);
                NotifyOfPropertyChange(() => AddBedrijfsbegeleiderVisibility);
                NotifyOfPropertyChange(() => AddBedrijfVisibility);
                NotifyOfPropertyChange(() => AddStagebegeleiderVisibility);
                NotifyOfPropertyChange(() => AddStudentVisibility);
                NotifyOfPropertyChange(() => AddTweedeLezerVisibility);
                NotifyOfPropertyChange(() => TweedeLezerVisibility);
                NotifyOfPropertyChange(() => TweedeStudentVisibility);
                NotifyOfPropertyChange(() => BedrijfsbegeleiderVisibility);
                NotifyOfPropertyChange(() => BedrijfVisibility);
                NotifyOfPropertyChange(() => EersteStudentVisibility);
                NotifyOfPropertyChange(() => EindDatum);
                NotifyOfPropertyChange(() => StagebegeleiderVisibility);
                NotifyOfPropertyChange(() => StartDatum);
            }
        }

        public StageViewModel(MainViewModel main, PropertyChanged last)
            :base(main, last)
        {
        }

        public StageViewModel(MainViewModel main, PropertyChanged last, internships stage)
            : this(main, last)
        {
            Stage = stage;
        }

        private string afstudeerstageVisibility;
        public string AfstudeerstageVisibility
        {
            get
            {
                switch(stage.type){
                    case "1":
                        return "Visible";
                    default:
                        return "Collapsed";
                }
                    
            }
            set {
                afstudeerstageVisibility = value;
                NotifyOfPropertyChange(() => AfstudeerstageVisibility);
            }
        }

        private string _eersteStudent;
        public string EersteStudent
        {
            get
            {
                return stage.students_internships.First().students.users.name + " " + stage.students_internships.First().students.users.surname;
            }
            set
            {
                _eersteStudent = value;
                NotifyOfPropertyChange(() => EersteStudent);
            }
        }

        private string eersteStudentVisibility;
        public string EersteStudentVisibility
        {
            get
            {
                // als eerste student niet leeg is laat eerste student zien, anders verbergen
                if (EersteStudent != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                eersteStudentVisibility = value;
                NotifyOfPropertyChange(() => EersteStudentVisibility);
            }
        }

        private string _tweedeStudent;
        public string TweedeStudent
        {
            get
            {
                String temp = "";
                try{
                    temp = stage.students_internships.ElementAtOrDefault(1).students.users.name + " " + stage.students_internships.ElementAtOrDefault(1).students.users.surname; 
                }
                catch (Exception e) 
               {
                    System.Diagnostics.Debug.WriteLine("error geen tweedestudent");
                }
                return temp;   
            }
            set
            {
                _tweedeStudent = value;
                NotifyOfPropertyChange(() => TweedeStudent);
            }
        }

        private string tweedeStudentVisibility;
        public string TweedeStudentVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (TweedeStudent != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                tweedeStudentVisibility = value;
                NotifyOfPropertyChange(() => tweedeStudentVisibility);
            }
        }

        private string addStudentVisibility;
        public string AddStudentVisibility
        {
            get
            {
                if (EersteStudent != "" && TweedeStudent != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
            set
            {
                addStudentVisibility = value;
                NotifyOfPropertyChange(() => AddStudentVisibility);
            }
        }

        private string stagebegeleider;
        public string Stagebegeleider
        {
            get
            {
                String teruggave = "";
                try
                {
                    teruggave = stage.teachers1.users.name + " " + stage.teachers1.users.surname;
                }
                catch (Exception e)
                {
                    teruggave = "";
                }
                return teruggave;
            }
            set {
                stagebegeleider = value;
                NotifyOfPropertyChange(() => Stagebegeleider);
            }
        }

        private string stagebegeleiderVisibility;
        public string StagebegeleiderVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Stagebegeleider != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                stagebegeleiderVisibility = value;
                NotifyOfPropertyChange(() => StagebegeleiderVisibility);
            }
        }

        private string addStagebegeleiderVisibility;
        public string AddStagebegeleiderVisibility
        {
            get
            {
                if (Stagebegeleider != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
            set
            {
                addStudentVisibility = value;
                NotifyOfPropertyChange(() => addStudentVisibility);
            }
        }

        private string bedrijf;
        public string Bedrijf
        {
            get
            {
                try
                {
                    return stage.supervisor.companies.name;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set 
            {
                bedrijf = value;
                NotifyOfPropertyChange(() => Bedrijf);
            }
        }

        private string bedrijfVisibility;
        public string BedrijfVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Bedrijf != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                bedrijfVisibility = value;
                NotifyOfPropertyChange(() => BedrijfVisibility);
            }
        }

        private string addBedrijfVisibility;
        public string AddBedrijfVisibility
        {
            get
            {
                if (Bedrijf != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
            set
            {
                addBedrijfVisibility = value;
                NotifyOfPropertyChange(() => AddBedrijfVisibility);
            }
        }

        private string tweedeLezer;
        public string TweedeLezer
        {
            get
            {
                try
                {
                    //(WStored.StageManagerEntities.teachers Where stage.secondReader == stage.teacher_user_id select );
                    teachers teacher = null;
                    List<teachers> teacherlist = (from zoek in new WStored().SearchDocentSet("") where zoek.user_id == stage.secondReader select zoek).ToList();
                    if(teacherlist.Count > 0)
                    {
                    teacher = teacherlist[0];
                    }
                    return teacher.users.name + " " + teacher.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
                // TODO return WStored.StageManagerEntities.teachers.Where<WStored.StageManagerEntities.
            }
            set 
            {
                tweedeLezer = value;
                NotifyOfPropertyChange(() => TweedeLezer);
            }
        }

        private string tweedeLezerVisibility;
        public string TweedeLezerVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (TweedeLezer != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                tweedeLezerVisibility = value;
                NotifyOfPropertyChange(() => TweedeLezerVisibility);
            }
        }

        private string addTweedelezerVisibility;
        public string AddTweedeLezerVisibility
        {
            get
            {
                if (TweedeLezer != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
            set
            {
                addTweedelezerVisibility = value;
                NotifyOfPropertyChange(() => AddTweedeLezerVisibility);
            }
        }

        public void btnSave()
        {
            WStored.PushToDB();
        }

        private string bedrijfsbegeleider;
        public string Bedrijfsbegeleider
        {
            get
            {
                try
                {
                    return stage.supervisor.users.name + " " + stage.supervisor.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set 
            {
                bedrijfsbegeleider = value;
                NotifyOfPropertyChange(() => Bedrijfsbegeleider);
            }
        }

        private string stageType;
        public string StageType
        {
            get
            {
                switch (stage.type)
                {
                    case "0":
                        return "Stage";
                    case "1":
                        return "Afstudeerstage";
                    default:
                        return "";
                }
            }
            set
            {
                stageType = value;
                NotifyOfPropertyChange(() => StageType);
            }
        }

        private string bedrijfsbegeleiderVisibility;
        public string BedrijfsbegeleiderVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Bedrijfsbegeleider != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set
            {
                bedrijfsbegeleiderVisibility = value;
                NotifyOfPropertyChange(() => BedrijfsbegeleiderVisibility);
            }
        }

        private string addBedrijfsbegeleiderVisibility;
        public string AddBedrijfsbegeleiderVisibility
        {
            get
            {
                if (Bedrijfsbegeleider != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
            set
            {
                addBedrijfsbegeleiderVisibility = value;
                NotifyOfPropertyChange(() => AddBedrijfsbegeleiderVisibility);
            }
        }
        
        // TODO public string StageType
        private string startDatum;
        public string StartDatum
        {
            get
            {
                try
                {
                    return stage.start_date.ToShortDateString();
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set
            {
                startDatum = value;
                NotifyOfPropertyChange(() => StartDatum);
            }
        }

        private string eindDatum;
        public string EindDatum
        {
            get
            {
                try
                {
                    return stage.end_date.ToShortDateString();
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set
            {
                eindDatum = value;
                NotifyOfPropertyChange(() => EindDatum);
            }
        }

        public void btnEersteStudent()
        {
            try
            {
                Main.ChangeButton("Student", this, new List<object>() { stage.students_internships.First().students }, Clear.No);
            }
            catch (Exception)
            { }
        }

        public void btnTweedeStudent()
        {
            try
            {
                Main.ChangeButton("Student", this, new List<object>() { stage.students_internships.ElementAt(1).students }, Clear.No);
            }
            catch (Exception)
            { }
        }

        public void btnAddTweedeStudent()
        {
            SearchFor = Search.TweedeStudent;
            Main.ChangeButton("Zoek", this, new List<object>() { "", ZoekViewModel.SearchType.Studenten }, Clear.No);
        }

        public void btnAddStagebegeleider()
        {
            Main.ChangeButton("Koppel",this, new List<object> {Stage}, Clear.No);
        }

        public void btnTweedeLezer()
        {
            teachers teacher = null;
            List<teachers> teacherlist = (from zoek in new WStored().SearchDocentSet("") where zoek.user_id == stage.secondReader select zoek).ToList();
            if (teacherlist.Count > 0)
            {
                teacher = teacherlist[0];
            }
            Main.ChangeButton("Docent", this, new List<object>() { teacher }, Clear.No);
        }

        public void btnAddTweedeLezer()
        {
            SearchFor = Search.TweedeLezer;
            Main.ChangeButton("Zoek",this, new List<object>() { "", ZoekViewModel.SearchType.Docenten }, Clear.No);
        }

        public void btnStageopdracht()
        {
            Main.ChangeButton("Stageopdracht", this, new List<object>() { stage}, Clear.No );
        }

        public void btnStagebegeleider()
        {
            Main.ChangeButton("Docent", this, new List<object>() { stage.teachers1 }, Clear.No);
        }

        public void btnRemoveStagebegeleider()
        {
            // TODO
        }

        public void btnRemoveTweedeLezer()
        {
            // TODO
        }

        public void btnRemoveTweedeStudent()
        {
            // TODO
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void btnBedrijf()
        {
            Main.ChangeButton("Bedrijf", this, new List<object>() {Stage.supervisor.companies }, Clear.No);
        }

        public void btnBedrijfsbegeleider()
        {
            Main.ChangeButton("Bedrijfsbegeleider", this, new List<object>() { Stage.supervisor}, Clear.No);
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            LinkedList<object[]> rows = new LinkedList<object[]>();

            string[] columns = { 
                "EersteStudent", 
                "TweedeStudent",
                "Stagebegeleider",
                "TweedeLezer",
                "Bedrijf",
                "Bedrijfsbegeleider",
                "Start datum",
                "Eind datum"
            };

            object[] row = {
                EersteStudent,
                TweedeStudent,
                Stagebegeleider,
                TweedeLezer,
                Bedrijf,
                Bedrijfsbegeleider,
                StartDatum,
                EindDatum
            };

            rows.AddLast(row);

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }

        public override void update(object[] o)
        {
            try
            {
                Stage = (internships)o[2];
            }
            catch (Exception)
            { }
        }
    }
}