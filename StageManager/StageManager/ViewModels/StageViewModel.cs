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
    class StageViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private internships stage;

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
                
            }
        }

        public StageViewModel(MainViewModel main)
            :base(main)
        {
        }

        public StageViewModel(MainViewModel main, internships stage)
            : this(main)
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
                if (isAfstudeerstage)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
            set { }
        }
        
        public string EersteStudent
        {
            get
            {
                try
                {
                    return stage.students_internships.First().students.users.name + " " + stage.students_internships.First().students.users.surname; //TODO juiste student
                }
                catch (Exception)
                {              
                    return "";
                }
                
            }
            set 
            {
                
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

        public string TweedeStudent
        {
            get
            {
                try
                {
                    return stage.students_internships.ElementAtOrDefault(1).students.users.name + " " + stage.students_internships.ElementAtOrDefault(1).students.users.surname; //TODO juiste student?
                }
                catch (NullReferenceException)
                {
                    return "";
                }

            }
            set { }
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
                if (EersteStudent != "" & TweedeStudent != "")
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

        public string TweedeLezer
        {
            get
            {
                try
                {
                    //return stage.teachers.users.name + " " + stage.teachers.users.surname;
                    return "";
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
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



        public void showStageopdracht()
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
    }
}