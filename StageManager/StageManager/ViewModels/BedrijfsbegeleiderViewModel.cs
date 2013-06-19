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
                begeleider = value;
                NotifyOfPropertyChange(() => Functie);
                NotifyOfPropertyChange(() => Opleiding);
                NotifyOfPropertyChange(() => BegeleidingUren);
                /*NotifyOfPropertyChange(()=>Voornaam);
                NotifyOfPropertyChange(()=>Achternaam);
                NotifyOfPropertyChange(()=>EMail);*/
            }
        }

        /*public String Voornaam
        {
            get
            {
                return begeleider.Voornaam;
            }
            set
            {
                begeleider.Voornaam = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }

        public String Achternaam
        {
            get
            {
                return begeleider.Achternaam;
            }
            set
            {
                begeleider.Achternaam = value;
                NotifyOfPropertyChange(() => Achternaam);
            }
        }
        */
        public String Functie
        {
            get
            {
                return begeleider.function;
            }
        }

        /* public String EMail
         {
             get
             {
                 return begeleider.Email;
             }
             set
             {
                 begeleider.Email = value;
                 NotifyOfPropertyChange(() => EMail);
             }
         }*/

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

        public bool? BegeleidingUren
        {
            get
            {
                return true;//TODO!!!!!
            }
            set
            {
                //begeleider.Minimale_begeleidingstijd_gegarandeerd = value;
                NotifyOfPropertyChange(() => BegeleidingUren);
            }
        }

        public BedrijfsbegeleiderViewModel(MainViewModel main)
            : base(main)
        { }
        public BedrijfsbegeleiderViewModel(MainViewModel main, supervisor bedrijfsbegeleider)
            : this(main)
        {
            Begeleider = bedrijfsbegeleider;
        }

        public override void update(object[] o)
        {
            try
            {
                Begeleider = (supervisor)o[1];
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
            worksheet.Cells[1, 1] = "Voornaam";
            //worksheet.Cells[2, 1] = Voornaam;
            worksheet.Cells[1, 2] = "Achternaam";
            //worksheet.Cells[2, 2] = Achternaam;
            worksheet.Cells[1, 3] = "Functie";
            worksheet.Cells[2, 3] = Functie;
            worksheet.Cells[1, 4] = "Opleiding";
            worksheet.Cells[2, 4] = Opleiding;
            worksheet.Cells[1, 5] = "BegeleidingUren";
            worksheet.Cells[2, 5] = BegeleidingUren;
            worksheet.Cells[1, 6] = "E-mailadres";
            //worksheet.Cells[2, 6] = EMail;
        }
    }
}