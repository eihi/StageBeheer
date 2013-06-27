using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;
using Caliburn.Micro;
using StageManager.Services;

namespace StageManager.ViewModels
{
    class BedrijfsbegeleiderViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private supervisor begeleider = new WStored().SearchBedrijfsBegeleiderSet()[random.Next(new WStored().SearchBedrijfsBegeleiderSet().Count)];//temp

        internal supervisor Begeleider
        {
            get { return begeleider; }
            set
            {
                begeleider = WStored.StageManagerEntities.supervisor.Find(value.user_id);
                NotifyOfPropertyChange(() => Functie);
                NotifyOfPropertyChange(() => Opleiding);
                NotifyOfPropertyChange(() => BegeleidingUren);
                NotifyOfPropertyChange(() => Voornaam);
                NotifyOfPropertyChange(() => Achternaam);
                NotifyOfPropertyChange(() => EMail);
                NotifyOfPropertyChange(() => Telefoon);
            }
        }

        public void btnSave()
        {
            WStored.PushToDB();
        }

        public String Voornaam
        {
            get
            {
                return begeleider.users.name;
            }
            set
            {
                begeleider.users.name = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }

        public String Telefoon
        {
            get
            {
                return begeleider.users.phonenumber;
            }
            set
            {
                begeleider.users.phonenumber = value;
                NotifyOfPropertyChange(() => Telefoon);
            }
        }

        public String Achternaam
        {
            get
            {
                return begeleider.users.surname;
            }
            set
            {
                begeleider.users.surname = value;
                NotifyOfPropertyChange(() => Achternaam);
            }
        }
        
        public String Functie
        {
            get
            {
                return begeleider.function;
            }
        }

        public String EMail
         {
             get
             {
                 return begeleider.users.email;
             }
             set
             {
                 begeleider.users.email = value;
                 NotifyOfPropertyChange(() => EMail);
             }
         }

        public String Opleiding
        {
            get
            {
                return begeleider.education;
            }
            set
            {
                begeleider.education = value;
                NotifyOfPropertyChange(() => Opleiding);
            }
        }

        public int BegeleidingUren
        {
            get
            {
                return begeleider.minimal_time;
            }
            set
            {
                begeleider.minimal_time = value;
                NotifyOfPropertyChange(() => BegeleidingUren);
            }
        }

        public BedrijfsbegeleiderViewModel(MainViewModel main, PropertyChanged last)
            : base(main,last)
        { }

        public BedrijfsbegeleiderViewModel(MainViewModel main,PropertyChanged last, supervisor bedrijfsbegeleider)
            : this(main,last)
        {
            Begeleider = bedrijfsbegeleider;
        }

        public override void update(object[] o)
        {
            try
            {
                Begeleider = (supervisor)o[2];
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
            LinkedList<object[]> rows = new LinkedList<object[]>();

            string[] columns = { 
                "Voornaam", 
                "Achternaam",
                "Functie",
                "Opleiding",
                "BegeleidingUren",
                "E-mailadres"
            };

            object[] row = {
                    Voornaam,
                    Achternaam,
                    Functie,
                    Opleiding,
                    BegeleidingUren,
                    EMail
            };

            rows.AddLast(row);
            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }
    }
}