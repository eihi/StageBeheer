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
    class StagesOverzichtViewModel : PropertyChanged
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
                        };
                        list.Remove(value);
                        list.Add(o, s);
                        List = list;
                    }
                }
            }
        }

        

        public StagesOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            List = new Dictionary<object, students>();
            List = new WStored().SearchStudentSet("", "").ToDictionary(t => (Object)new
            {

                /*
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
                  
                 <DataGrid.Columns>
                                    <DataGridTextColumn Binding="{Binding Stagetype}" Header="Stage type" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Eerstestudent}" Header="Student 1" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Tweedestudent}" Header="Student 2" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Stagebegeleider}" Header="Stagebegeleider" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Tweedelezer}" Header="Tweede lezer" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Bedrijf}" Header="Bedrijf" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Bedrijfsbegeleider}" Header="Bedrijfsbegeleider" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Begin}" Header="Begin Datum" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Eind}" Header="Eind Datum" Width="auto" IsReadOnly="True"/>
                                </DataGrid.Columns>
                 */

                Stagetype = t.studentnumber,
                Eerstestudent = t.users.name,
                Tweedestudent = t.users.surname,
                Stagebegeleider = t.users.students.education.name,
                Tweedelezer = t.users.phonenumber,
                Bedrijf = t.users.students.meets,
                Bedrijfsbegeleider = t.users.email,
                Begin = t.users.email,
                Eind = t.users.students.adresses.street,

            }, t => t);

        }
    }
}
