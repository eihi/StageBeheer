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
        private students student;

        internal students Student
        {
            get { return student; }
            set
            {
                student = WStored.StageManagerEntities.students.Find(value.user_id);
                NotifyOfPropertyChange(() => Voornaam);
                NotifyOfPropertyChange(() => Achternaam);
                NotifyOfPropertyChange(() => Studentnummer);
                NotifyOfPropertyChange(() => Opleiding);
                NotifyOfPropertyChange(() => Postcode);
                NotifyOfPropertyChange(() => Plaats);
                NotifyOfPropertyChange(() => Voldoet);
                NotifyOfPropertyChange(() => Emailadres);
                NotifyOfPropertyChange(() => Telefoonnummer);
            }
        }

        public string Voornaam
        {
            get { return student.users.name; }
            set
            {
                student.users.name = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }

        public string Postcode
        {
            get { return student.adresses.zipcode; }
            set
            {
                student.adresses.zipcode = value;
                NotifyOfPropertyChange(() => Postcode);
            }
        }

        public string Plaats
        {
            get { return student.adresses.place; }
            set
            {
                //student.adresses = WStored.StageManagerEntities.adresses.Find(student.addresss_id);
                student.adresses.place = value;
                NotifyOfPropertyChange(() => Plaats);
            }
        }

        public string Voldoet
        {
            get { return student.users.name; }
            set
            {
                student.users.name = value;
                NotifyOfPropertyChange(() => Voornaam);
            }
        }

        public String Achternaam
        {
            get
            {
                return student.users.surname;
            }
            set
            {
                student.users.surname = value;
                NotifyOfPropertyChange(() => Achternaam);
            }
        }

        public int Studentnummer
        {
            get { return student.studentnumber; }
            set
            {
                student.studentnumber = value;
                NotifyOfPropertyChange(() => Studentnummer);
            }
        }
        public string Opleiding
        {
            get { return student.education.name; }
            set
            {
                NotifyOfPropertyChange(() => Opleiding);
            }
        }

        public string Emailadres
        {
            get { return student.users.email; }
            set
            {
                student.users.email = value;
                NotifyOfPropertyChange(() => Emailadres);
            }
        }
        public string Telefoonnummer
        {
            get { return student.users.phonenumber; }
            set
            {
                student.users.phonenumber = value;
                NotifyOfPropertyChange(() => Telefoonnummer);
            }
        }

        public StudentViewModel(MainViewModel main, PropertyChanged last)
            : base(main, last)
        {
        }

        public StudentViewModel(MainViewModel main, PropertyChanged last, students student)
            : this(main, last)
        {
            Student = student;
        }

        public override void update(object[] o)
        {
            try
            {
                Student = (students)o[2];
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void btnSave()
        {
           WStored.PushToDB();
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
                "Studentnummer", 
                "Voornaam",
                "Achternaam",
                "Opleiding",
                "E-mailadres",
                "Telefoonnummer"
            };

            object[] row = {
                Studentnummer,
                Voornaam,
                Achternaam,
                Opleiding,
                Emailadres,
                Telefoonnummer
            };

            rows.AddLast(row);

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }
    }
}