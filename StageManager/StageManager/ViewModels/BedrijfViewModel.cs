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
        private WBedrijf bedrijf = new WStored().SearchBedrijfSet()[random.Next(new WStored().SearchBedrijfSet().Count)];//temp

        internal WBedrijf Bedrijf
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
            }
        }
        public String Naam
        {
            get
            {
                return bedrijf.Naam;
            }
            set
            {
                bedrijf.Naam = value;
                NotifyOfPropertyChange(() => Naam);
            }
        }

        public String Straat
        {
            get
            {
                return bedrijf.AdresSets.Straat;
            }
            set
            {
                bedrijf.AdresSets.Straat = value;
                NotifyOfPropertyChange(() => Straat);
            }
        }

        public String Huisnummer
        {
            get
            {
                return bedrijf.AdresSets.Huisnummer;
            }
            set
            {
                bedrijf.AdresSets.Huisnummer = value;
                NotifyOfPropertyChange(() => Huisnummer);
            }
        }

        public String Postcode
        {
            get
            {
                return bedrijf.AdresSets.Postcode;
            }
            set
            {
                bedrijf.AdresSets.Postcode = value;
                NotifyOfPropertyChange(() => Postcode);
            }
        }

        public String Plaats
        {
            get
            {
                return bedrijf.AdresSets.Plaats;
            }
            set
            {
                bedrijf.AdresSets.Plaats = value;
                NotifyOfPropertyChange(() => Plaats);
            }
        }

        public BedrijfViewModel(MainViewModel main)
            :base(main)
        {
        }

        public BedrijfViewModel(MainViewModel main, WBedrijf bedrijf)
            : this(main)
        {
            Bedrijf = bedrijf;
        }

        public override void update(object[] o)
        {
            try
            {
                Bedrijf = (WBedrijf)o[1];
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
