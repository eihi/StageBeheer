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
    class StageopdrachtViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private internships stage = new WStored().SearchStageSet()[random.Next(new WStored().SearchStageSet().Count)];

        internal internships Stage
        {
            get { return stage; }
            set
            {
                stage = value;
                NotifyOfPropertyChange(() => StartDatum);
                NotifyOfPropertyChange(() => Bedrijfsbegeleider);
                NotifyOfPropertyChange(() => Docent);
                NotifyOfPropertyChange(() => EersteStudent);
                NotifyOfPropertyChange(() => EindDatum);
                NotifyOfPropertyChange(() => Omschrijving);
                NotifyOfPropertyChange(() => TweedeStudent);
            }
        }

        public void btnSave()
        {
            WStored.PushToDB();
        }

        public DateTime StartDatum
        {
            get { return stage.start_date; }
            set
            {
                stage.start_date = value;
                NotifyOfPropertyChange(() => StartDatum);
            }
        }

        public DateTime EindDatum
        {
            get { return stage.end_date; }
            set
            {
                stage.end_date = value;
                NotifyOfPropertyChange(() => EindDatum);
            }
        }

        public string Omschrijving
        {
            get {  return stage.description; }
            set
            {
                stage.description = value;
                NotifyOfPropertyChange(() => Omschrijving);
            }
        }

        public string EersteStudent
        {
            get 
            {
                try
                {
                    return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string TweedeStudent
        {
            get 
            {
                try
                {
                    return null;//stage.studentset.Voornaam + " " + stage.studentset.Achternaam; TODO!!!!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string Bedrijfsbegeleider
        {
            get
            {
                try
                {
                    //return stage.bedrijfsbegeleiderset.Voornaam + " " + stage.bedrijfsbegeleiderset.Achternaam;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
                return "Geen BedrijfsBegeleider gekoppeld";
            }
            set { }
        }

        public string Docent
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

        public StageopdrachtViewModel(MainViewModel main,PropertyChanged last)
            :base(main,last)
        {
        }

        public StageopdrachtViewModel(MainViewModel main,PropertyChanged last, internships stage)
            : this(main,last)
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
                
                throw;
            }
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            worksheet.Cells[1, 1] = "StartDatum";
            worksheet.Cells[2, 1] = StartDatum;
            worksheet.Cells[1, 2] = "Bedrijfsbegeleider";
            worksheet.Cells[2, 2] = Bedrijfsbegeleider;
            worksheet.Cells[1, 3] = "Docent";
            worksheet.Cells[2, 3] = Docent;
            worksheet.Cells[1, 4] = "Eerste Student";
            worksheet.Cells[2, 4] = EersteStudent;
            worksheet.Cells[1, 5] = "Tweede Student";
            worksheet.Cells[2, 5] = TweedeStudent;
            worksheet.Cells[1, 6] = "Eind Datum";
            worksheet.Cells[2, 6] = EindDatum;
            worksheet.Cells[1, 7] = "Omschrijving";
            worksheet.Cells[2, 7] = Omschrijving;
        }
    }
}