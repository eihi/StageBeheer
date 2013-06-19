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
    public class GegevensOverzichtViewModel : PropertyChanged, IExcelAlgorithm
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

        private Object selectedStudent;
        public object SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                if (value != null)
                {
                    selectedStudent = value;
                    students s = null;
                    list.TryGetValue(value, out s);
                    Type t = value.GetType();
                    System.Reflection.PropertyInfo p = t.GetProperty("MailTo");
                    System.Reflection.MethodInfo m = p.GetMethod;
                    bool ob = !(bool)m.Invoke(value, null);
                    bool temp = !(bool)value.GetType().GetProperty("MailTo").GetMethod.Invoke(value, null);
                    if (s != null)
                    {
                        Object o = (Object)new
                        {
                            Studentnummer = (String)value.GetType().GetProperty("Studentnummer").GetMethod.Invoke(value, null),
                            Achternaam = (String)value.GetType().GetProperty("Achternaam").GetMethod.Invoke(value, null),
                            Voorvoegsels = (String)value.GetType().GetProperty("Voorvoegsels").GetMethod.Invoke(value, null),
                            Roepnaam = (String)value.GetType().GetProperty("Roepnaam").GetMethod.Invoke(value, null),
                            Email = (String)value.GetType().GetProperty("Email").GetMethod.Invoke(value, null),
                            EmailURL = (String)value.GetType().GetProperty("EmailURL").GetMethod.Invoke(value, null),
                            Straatnaam = (String)value.GetType().GetProperty("Straatnaam").GetMethod.Invoke(value, null),
                            Nummer = (String)value.GetType().GetProperty("Nummer").GetMethod.Invoke(value, null),
                            Toevoeging = (String)value.GetType().GetProperty("Toevoeging").GetMethod.Invoke(value, null),
                            Postcode = (String)value.GetType().GetProperty("Postcode").GetMethod.Invoke(value, null),
                            Plaats = (String)value.GetType().GetProperty("Plaats").GetMethod.Invoke(value, null),
                            Telefoonnummer = (String)value.GetType().GetProperty("Telefoonnummer").GetMethod.Invoke(value, null),
                            SLB61 = (String)value.GetType().GetProperty("SLB61").GetMethod.Invoke(value, null),
                            SLB62 = (String)value.GetType().GetProperty("SLB62").GetMethod.Invoke(value, null),
                            SLB63 = (String)value.GetType().GetProperty("SLB63").GetMethod.Invoke(value, null),
                            SLB6T = (String)value.GetType().GetProperty("SLB6T").GetMethod.Invoke(value, null),
                            SLB71 = (String)value.GetType().GetProperty("SLB71").GetMethod.Invoke(value, null),
                            SLB72 = (String)value.GetType().GetProperty("SLB72").GetMethod.Invoke(value, null),
                            SLB7T = (String)value.GetType().GetProperty("SLB7T").GetMethod.Invoke(value, null),
                            ECs = (String)value.GetType().GetProperty("ECs").GetMethod.Invoke(value, null),
                            P = (String)value.GetType().GetProperty("{").GetMethod.Invoke(value, null),
                            EPS = (String)value.GetType().GetProperty("EPS").GetMethod.Invoke(value, null),
                            Goedkeuring = (String)value.GetType().GetProperty("Goedkeuring").GetMethod.Invoke(value, null),
                            Toestemming = (String)value.GetType().GetProperty("Toestemming").GetMethod.Invoke(value, null),
                            Stagecontract = (String)value.GetType().GetProperty("Stagecontract").GetMethod.Invoke(value, null),
                            Docent = (String)value.GetType().GetProperty("Docent").GetMethod.Invoke(value, null),
                            Bijzonderheden = (String)value.GetType().GetProperty("Bijzonderheden").GetMethod.Invoke(value, null),
                        };
                        list.Remove(value);
                        list.Add(o, s);
                        List = list;
                    }
                }
            }
        }

        public GegevensOverzichtViewModel(MainViewModel main)
            :base(main)
        {
            selectedStudent = new Object();
            List = new Dictionary<object, students>();
            List = new WStored().SearchStudentSet("", "").ToDictionary(t => (Object)new
            {
                Studentnummer = t.Studentnummer,
                Achternaam = t.Achternaam,
                Voorvoegsels = "",
                Roepnaam = t.Voornaam,                
                Email = t.Email,
                EmailURL = t.Email,
                Straatnaam = "",
                Nummer = 0,
                Toevoeging = "",
                Postcode = "",
                Plaats = "",
                Telefoonnummer = t.Telefoonnummer,

                // Zoeken naar Extra info
                ECs = t.EC_norm_behaald,
            }, t => t);

            /*
Student
	Studentnummer
	Achternaam
	Voorvoegsels
	Roepnaam
	E-mail
	Straatnaam
	Nummer
	Toevoeging
	Postcode
	Plaats
	Telefoonnummer

Info + Docent
	SLB6-1
	SLB6-2
	SLB6-3
	SLB6-T
	SLB7-1
	SLB7-2
	SLB7-T
	EC's
	P
	EPS
	Form. Goedkeuring
	Toestemming Ex. Comm.
	Stagecontract
	Begeleidend Docent
	Bijzonderheden

Bedrijf + Bedrijfsbegeleider
	Bedrijf
	Branche
	Straat
	Nummer
	Toevoeging
	Postcode
	Plaats
	Land
	Bedrijfsbegeleider
	E-mail
	Tel. nr Bedrijf
	Tel. nr Bedrijfsbegeleider
	Website
             */
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            int i = 1;

            worksheet.Cells[i, 1] = "Studentnummer";
            worksheet.Cells[i, 2] = "Voornaam";
            worksheet.Cells[i, 3] = "Achternaam";
            worksheet.Cells[i, 4] = "E-mailadres";
            worksheet.Cells[i, 5] = "Telefoonnummer";

            foreach (KeyValuePair<Object, students> s in List)
            {
                i++;

                worksheet.Cells[i, 1] = s.Value.studentnumber;
                worksheet.Cells[i, 2] = s.Value.users.name;
                worksheet.Cells[i, 3] = s.Value.users.surname;
                worksheet.Cells[i, 4] = s.Value.users.email;
                worksheet.Cells[i, 5] = s.Value.users.phonenumber;
            }
        }
    }
}