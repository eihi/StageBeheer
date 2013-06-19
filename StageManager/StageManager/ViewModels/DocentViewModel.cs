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
    class DocentViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private WDocent docent = new WStored().SearchDocentSet(null)[random.Next(new WStored().SearchDocentSet(null).Count)];

        internal WDocent Docent
        {
            get { return docent; }
            set
            {
                docent = value;
                NotifyOfPropertyChange(() => Voornaam);
                NotifyOfPropertyChange(() => Achternaam);
                NotifyOfPropertyChange(() => Straat);
                NotifyOfPropertyChange(() => Huisnummer);
                NotifyOfPropertyChange(() => Postcode);
                NotifyOfPropertyChange(() => Woonplaats);
                NotifyOfPropertyChange(() => Telefoon);
                NotifyOfPropertyChange(() => EMail);
            }
        }

        public String Voornaam
        {
            get
            {
                return docent.Voornaam;
            }
            set
            {
                docent.Voornaam = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }
        public String Achternaam
        {
            get
            {
                return docent.Achternaam;
            }
            set
            {
                docent.Achternaam = value;
                NotifyOfPropertyChange(() => Achternaam);
            }
        }
        public String Straat
        {
            get
            {
                return docent.adressets.Straat;
            }
            set
            {
                docent.adressets.Straat = value;
                NotifyOfPropertyChange(() => Straat);
            }
        }
        public String Huisnummer
        {
            get
            {
                return docent.adressets.Huisnummer;
            }
            set
            {
                docent.adressets.Huisnummer = value;
                NotifyOfPropertyChange(() => Huisnummer);
            }
        }

        public String Postcode
        {
            get
            {
                return docent.adressets.Postcode;
            }
            set
            {
                docent.adressets.Postcode = value;
                NotifyOfPropertyChange(() => Postcode);
            }
        }
        public String Woonplaats
        {
            get
            {
                return docent.adressets.Plaats;
            }
            set
            {
                docent.adressets.Plaats = value;
                NotifyOfPropertyChange(() => Woonplaats);
            }
        }
        public String Telefoon
        {
            get
            {
                return docent.Telefoonnummer;
            }
            set
            {
                docent.Telefoonnummer = value;
                NotifyOfPropertyChange(() => Telefoon);
            }
        }
        public String EMail
        {
            get
            {
                return docent.Email;
            }
            set
            {
                docent.Email = value;
                NotifyOfPropertyChange(() => EMail);
            }
        }

        public DocentViewModel(MainViewModel main)
            : base(main)
        { }
        public DocentViewModel(MainViewModel main, WDocent docent)
            : this(main)
        {
            Docent = docent;
        }

        public override void update(object[] o)
        {
            try
            {
                Docent = (WDocent)o[1];
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
            worksheet.Cells[2, 1] = Voornaam;
            worksheet.Cells[1, 2] = "Achternaam";
            worksheet.Cells[2, 2] = Achternaam;
            worksheet.Cells[1, 3] = "Huisnummer";
            worksheet.Cells[2, 3] = Huisnummer;
            worksheet.Cells[1, 4] = "Postcode";
            worksheet.Cells[2, 4] = Postcode;
            worksheet.Cells[1, 5] = "Woonplaats";
            worksheet.Cells[2, 5] = Woonplaats;
            worksheet.Cells[1, 6] = "Telefoon";
            worksheet.Cells[2, 6] = Telefoon;
            worksheet.Cells[1, 7] = "E-mail";
            worksheet.Cells[2, 7] = EMail;
        }
    }
}