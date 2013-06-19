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
    public class ProcesOverzichtViewModel : PropertyChanged
    {
        /*
         * ("", "m.aydin4@student.avans.nl", "Aydin, Murat", "Hyacinthenstraat 15", "Ingeleverd", "In orde", "Bob Bus"))
         */

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
                            MailTo = !(bool)value.GetType().GetProperty("MailTo").GetMethod.Invoke(value, null),
                            Email = (String)value.GetType().GetProperty("Email").GetMethod.Invoke(value, null),
                            EmailURL = (String)value.GetType().GetProperty("EmailURL").GetMethod.Invoke(value, null),
                            StudentNaam = (String)value.GetType().GetProperty("StudentNaam").GetMethod.Invoke(value, null),
                            Gegevens = (String)value.GetType().GetProperty("Gegevens").GetMethod.Invoke(value, null),
                            Stageopdracht = (bool)value.GetType().GetProperty("Stageopdracht").GetMethod.Invoke(value, null),
                            Feedback = (String)value.GetType().GetProperty("Feedback").GetMethod.Invoke(value, null),
                            Docent = (String)value.GetType().GetProperty("Docent").GetMethod.Invoke(value, null)
                        };
                        list.Remove(value);
                        list.Add(o, s);
                        List = list;
                    }
                }
            }
        }

        public void MailSelectie()
        {
            List<String> mails = new List<string>();
            for (int i = 0; i < List.Keys.Count; i++)
            {
                if ((bool)List.Keys.ElementAt(i).GetType().GetProperty("MailTo").GetMethod.Invoke(List.Keys.ElementAt(i), null))
                {
                    students s;
                    List.TryGetValue(List.Keys.ElementAt(i), out s);
                    mails.Add(s.users.email);
                }
            }
            Main.ChangeButton("Mail", new List<object>() { mails }, Clear.No);

        }

        public ProcesOverzichtViewModel(MainViewModel main)
            : base(main)
        {/*
            selectedStudent = new Object();
            List = new Dictionary<object, students>();
            List<students> stages = new WStored().SearchStage("", "", false);

            List<students> studenten = new List<students>();

            for (int i = 0; i < stages.Count; i++)
            {
                if (stages[i].studentset != null)
                {
                    bool contains = false;
                    for (int j = 0; j < studenten.Count; j++)
                    {
                        if (stages[i].studentset.getSet() == studenten[j].getSet())
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (!contains)
                    {
                        studenten.Add(stages[i].studentset);
                    }
                }
                if (stages[i].studentset2 != null)
                {
                    bool contains = false;
                    for (int j = 0; j < studenten.Count; j++)
                    {
                        if (stages[i].studentset2.getSet() == studenten[j].getSet())
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (!contains)
                    {
                        //studenten.Add(stages[i].studentset2); TODO!!!!!!
                    }
                }
            }


            List = studenten.ToDictionary(t => (Object)new
                          {
                              MailTo = false,
                              Email = t.users.email,
                              EmailURL = "mailto:" + t.users.email,
                              StudentNaam = t.users.surname+ ", " + t.users.name,
                              Gegevens = "Adres komt hier",
                              Stageopdracht = true,
                              Feedback = "Geen",
                              Docent = "Docent"
                          }, t => t);
          */
        }
    }
}

