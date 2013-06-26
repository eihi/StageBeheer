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
    class DocentenOverzichtViewModel : PropertyChanged, IExcelAlgorithm
    {
        private Dictionary<object, teachers> _teacherList;
        Dictionary<object, teachers> TeacherList
        {
            get
            {
                return _teacherList;
            }
            set
            {
                _teacherList = value;
                TeacherGridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => TeacherList);
            }
        }

        private List<object> _teacherGridContents;
        public List<object> TeacherGridContents
        {
            get
            {
                return _teacherGridContents;
            }
            set
            {
                _teacherGridContents = value;
                NotifyOfPropertyChange(() => TeacherGridContents);
            }
        }

        private teachers _selectedTeacher;
        public object SelectedTeacher
        {
            get
            {
                return _selectedTeacher;
            }
            set
            {
                _selectedTeacher = null;
                if (value != null)
                {
                    _teacherList.TryGetValue(value, out _selectedTeacher);
                }
            }
        }

        public DocentenOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            TeacherList = new Dictionary<object, teachers>();
            TeacherList = new WStored().SearchDocentSet("").ToDictionary(t => (Object)new
            {
                Voornaam = t.users.name,
                Achternaam = t.users.surname,
                Straatnaam = t.adresses.street,
                Huisnummer = t.adresses.housenumber,
                Woonplaats = t.adresses.place,
                Telefoonnummer = t.users.phonenumber,
                Email = t.users.email,
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
                "Voornaam", 
                "Achternaam",
                "Straatnaam",
                "Huisnummer",
                "Woonplaats",
                "Telefoonnummer",
                "Email"
            };

            foreach (KeyValuePair<Object, teachers> t in TeacherList)
            {
                object[] row = {
                    t.Value.users.name,
                    t.Value.users.surname,
                    t.Value.adresses.street,
                    t.Value.adresses.housenumber,
                    t.Value.adresses.place,
                    t.Value.users.phonenumber,
                    t.Value.users.email,
                };

                rows.AddLast(row);
            }

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }

        public void editDocent()
        {
            Main.ChangeButton("Docent", new List<object>() { _selectedTeacher }, Clear.After, this);
        }
    }
}