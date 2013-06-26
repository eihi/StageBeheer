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
    class StudentenOverzichtViewModel : PropertyChanged, IExcelAlgorithm
    {
        private Dictionary<Object, students> list;
        Dictionary<Object, students> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => List);
            }
        }

        private List<Object> gridContents;
        public List<object> GridContents
        {
            get
            {
                return gridContents;
            }
            set
            {
                gridContents = value;
                NotifyOfPropertyChange(() => GridContents);
            }
        }

        private students selectedStudent;
        public object SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = null;
                if (value != null)
                {
                    list.TryGetValue(value, out selectedStudent);
                }
            }
        }

        public StudentenOverzichtViewModel(MainViewModel main, PropertyChanged last)
            : base(main,last)
        {
            List = new Dictionary<object, students>();
            List = new WStored().SearchStudentSet("", "").ToDictionary(t => (Object)new
            {
                Studentnummer = t.studentnumber,
                Voornaam = t.users.name,
                Achternaam = t.users.surname,
                Opleiding = t.users.students.education.name,
                Telefoonnummer = t.users.phonenumber,
                Voldoet = t.users.students.meets,
                Email = t.users.email,
                EmailURL = t.users.email,
                Straatnaam = t.users.students.adresses.street,
                Huisnummer = t.users.students.adresses.housenumber,
                Postcode = t.users.students.adresses.zipcode,
                Woonplaats = t.users.students.adresses.place,
            }, t => t);
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
                "Telefoonnummer",
                "Toestemming. Ex. Comm.",
                "Email",
                "Straatnaam",
                "Huisnummer",
                "Postcode",
                "Woonplaats"
            };

            foreach (KeyValuePair<Object, students> t in List)
            {
                object[] row = {
                    t.Value.studentnumber,
                    t.Value.users.name,
                    t.Value.users.surname,
                    t.Value.users.students.education.name,
                    t.Value.users.phonenumber,
                    t.Value.users.students.meets,
                    t.Value.users.email,
                    t.Value.adresses.street,
                    t.Value.adresses.housenumber,
                    t.Value.users.students.adresses.zipcode,
                    t.Value.adresses.place
                };

                rows.AddLast(row);
            }

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }

        public void editStudent()
        {
            Main.ChangeButton("Student", this, new List<object>() { SelectedStudent }, Clear.After);
        }
    }
}