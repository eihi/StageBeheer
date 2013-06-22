using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StageManager.ViewModels
{
    class BedrijfViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private companies bedrijf = new WStored().SearchBedrijfSet()[random.Next(new WStored().SearchBedrijfSet().Count)];//temp

        internal companies Bedrijf
        {
            get { return bedrijf; }
            set
            {
                bedrijf = value;
                NotifyOfPropertyChange(() => Naam);
                NotifyOfPropertyChange(() => Straat);
                NotifyOfPropertyChange(() => Huisnummer);
                NotifyOfPropertyChange(() => Postcode);
                NotifyOfPropertyChange(() => Plaats);
                NotifyOfPropertyChange(() => Telefoon);
                NotifyOfPropertyChange(() => Website);
            }
        }
        public String Naam
        {
            get
            {
                return bedrijf.name;
            }
            set
            {
                bedrijf.name = value;
                NotifyOfPropertyChange(() => Naam);
            }
        }
        public String Telefoon
        {
            get
            {
                return bedrijf.phonenumber;
            }
            set
            {
                bedrijf.phonenumber = value;
                NotifyOfPropertyChange(() => Telefoon);
            }
        }
        public String Website
        {
            get
            {
                return bedrijf.website;
            }
            set
            {
                bedrijf.website = value;
                NotifyOfPropertyChange(() => Website);
            }
        }

        public String Straat
        {
            get
            {
                return bedrijf.adresses.street;
            }
            set
            {
                bedrijf.adresses.street = value;
                NotifyOfPropertyChange(() => Straat);
            }
        }

        public String Huisnummer
        {
            get
            {
                return bedrijf.adresses.housenumber;
            }
            set
            {
                bedrijf.adresses.housenumber = value;
                NotifyOfPropertyChange(() => Huisnummer);
            }
        }

        public String Postcode
        {
            get
            {
                return bedrijf.adresses.zipcode;
            }
            set
            {
                bedrijf.adresses.zipcode = value;
                NotifyOfPropertyChange(() => Postcode);
            }
        }

        public String Plaats
        {
            get
            {
                return bedrijf.adresses.place;
            }
            set
            {
                bedrijf.adresses.place = value;
                NotifyOfPropertyChange(() => Plaats);
            }
        }

        public BedrijfViewModel(MainViewModel main)
            :base(main)
        {
        }

        public BedrijfViewModel(MainViewModel main, companies bedrijf)
            : this(main)
        {
            Bedrijf = bedrijf;
        }

        public override void update(object[] o)
        {
            try
            {
                Bedrijf = (companies)o[1];
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
            worksheet.Cells[1, 1] = "Naam";
            worksheet.Cells[2, 1] = Naam;
            worksheet.Cells[1, 2] = "Straat";
            worksheet.Cells[2, 2] = Straat;
            worksheet.Cells[1, 3] = "Huisnummer";
            worksheet.Cells[2, 3] = Huisnummer;
            worksheet.Cells[1, 4] = "Postcode";
            worksheet.Cells[2, 4] = Postcode;
            worksheet.Cells[1, 5] = "Plaats";
            worksheet.Cells[2, 5] = Plaats;
        }
    }
}
