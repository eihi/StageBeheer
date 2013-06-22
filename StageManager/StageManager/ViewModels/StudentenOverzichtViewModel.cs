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
    class StudentenOverzichtViewModel : PropertyChanged
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

        public StudentenOverzichtViewModel(MainViewModel main)
            : base(main)
        {
        List = new Dictionary<object, students>();
            List = new WStored().SearchStudentSet("", "").ToDictionary(t => (Object)new
            {
                Studentnummer = t.studentnumber,
                Voornaam = t.users.name,
                Achternaam = t.users.surname,
                Opleiding = t.users.students.education.name,
                Telefoonnummer = t.users.phonenumber,
                //Voldoet = t.users.students.meets, // TODO voldoet aan norm examencommissie
                Email = t.users.email,
                EmailURL = t.users.email,
                Straatnaam = t.users.students.adresses.street,
                Huisnummer = t.users.students.adresses.housenumber,
                Postcode = t.users.students.adresses.zipcode,
                Woonplaats = t.users.students.adresses.place,
            }, t => t);
        }
    }
}
