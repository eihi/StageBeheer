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
                NotifyOfPropertyChange(() => isAfstudeerstage);
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

        public bool isAfstudeerstage
        {
            get;
            set;
        }

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
            set { }
        }

        private string _eersteStudent;
        public string EersteStudent
        {
            get
            {
                return _eersteStudent;
            }
            set
            {
                _eersteStudent = value;
                NotifyOfPropertyChange(() => EersteStudent);
            }
        }

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
        }

        private string _tweedeStudent;
        public string TweedeStudent
        {
            get
            {
                return _tweedeStudent;
            }
            set
            {
                _tweedeStudent = value;
                NotifyOfPropertyChange(() => TweedeStudent);
            }
        }

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
        }

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
        }

        public string Stagebegeleider
        {
            get
            {
                try
                {
                    return stage.teachers.users.name + " " + stage.teachers.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

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
        }

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
        }

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
            set { }
        }

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
        }

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
        }

        private string _tweedeLezer;
        public string TweedeLezer
        {
            get
            {
                return _tweedeLezer;
            }
            set 
            {
                _tweedeLezer = value;
                NotifyOfPropertyChange(() => TweedeLezer);
            }
        }

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
        }

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
        }

        public void btnSave()
        {
            WStored.PushToDB();
        }

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
            set { }
        }

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
        }

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
        }

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
        }
        
        // TODO public string StageType
        
        public string StartDatum
        {
            get
            {
                try
                {
                    return stage.start_date.ToString();
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
        }
        public string EindDatum
        {
            get
            {
                try
                {
                    return stage.end_date.ToString();
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
        }

        public void btnTweedeStudent_Click()
        {
            SearchFor = Search.TweedeStudent;
            Main.ChangeButton("Zoek", this, new List<object>() { "", ZoekViewModel.SearchType.Studenten }, Clear.No);
        }

        public void btnStagebegeleider_Click()
        {
            Main.ChangeButton("Koppel",this, new List<object> {Stage}, Clear.No);
        }

        public void btnTweedeLezer_Click()
        {
            SearchFor = Search.TweedeLezer;
            Main.ChangeButton("Zoek",this, new List<object>() { "", ZoekViewModel.SearchType.Docenten }, Clear.No);
        }

        public void btnStageopdracht_Click()
        {
            Main.ChangeButton("Stageopdracht");
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
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
                Stage = (internships)o[1];
            }
            catch (Exception)
            { }
        }
    }
}