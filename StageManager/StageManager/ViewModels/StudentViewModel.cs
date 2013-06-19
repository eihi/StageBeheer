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
    class StudentViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private WStudent student;

        internal WStudent Student
        {
            get { return student; }
            set
            {
                student = value;
                NotifyOfPropertyChange(() => Voornaam);
                NotifyOfPropertyChange(() => Achternaam);
                NotifyOfPropertyChange(() => Studentnummer);
                NotifyOfPropertyChange(() => Opleiding);
                NotifyOfPropertyChange(() => Emailadres);
                NotifyOfPropertyChange(() => Telefoonnummer);
            }
        }

        public string Voornaam
        {
            get { return student.Voornaam; }
            set
            {
                student.Voornaam = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }

        public String Achternaam
        {
            get
            {
                return student.Achternaam;
            }
            set
            {
                student.Achternaam = value;
                NotifyOfPropertyChange(() => Achternaam);
            }
        }

        public int Studentnummer
        {
            get { return student.Studentnummer; }
            set
            {
                student.Studentnummer = value;
                NotifyOfPropertyChange(() => Studentnummer);
            }
        }
        public string Opleiding
        {
            get { return student.Opleidingset.Naam; }
            set
            {
                student.Opleidingset.Naam = value;
                NotifyOfPropertyChange(() => Opleiding);
            }
        }

        public string Emailadres
        {
            get { return student.Email; }
            set
            {
                student.Email = value;
                NotifyOfPropertyChange(() => Emailadres);
            }
        }
        public string Telefoonnummer
        {
            get { return student.Telefoonnummer; }
            set
            {
                student.Telefoonnummer = value;
                NotifyOfPropertyChange(() => Telefoonnummer);
            }
        }

        public StudentViewModel(MainViewModel main)
            : base(main)
        {
        }

        public StudentViewModel(MainViewModel main, WStudent student)
            : this(main)
        {
            Student = student;
        }

        public override void update(object[] o)
        {
            try
            {
                Student = (WStudent)o[1];
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
            worksheet.Cells[1, 3] = "Studentnummer";
            worksheet.Cells[2, 3] = Studentnummer;
            worksheet.Cells[1, 4] = "Opleiding";
            worksheet.Cells[2, 4] = Opleiding;
            worksheet.Cells[1, 5] = "E-mailadres";
            worksheet.Cells[2, 5] = Emailadres;
            worksheet.Cells[1, 6] = "Telefoonnummer";
            worksheet.Cells[2, 6] = Telefoonnummer;
        }
    }
}