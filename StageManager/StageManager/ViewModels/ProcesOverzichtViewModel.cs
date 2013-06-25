﻿using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    public class ProcesOverzichtViewModel : PropertyChanged, IExcelAlgorithm
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

        private internships selectedStage;
        public internships SelectedStage
        {
            get { return selectedStage; }
            set { selectedStage = value; }
        }

        public object SelectedObject
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                //List.TryGetValue(value, out selectedStudent);
                Main.ChangeButton("Stage", new List<Object>() { selectedStudent }, Services.Clear.No);

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
                            Student = (String)value.GetType().GetProperty("Student").GetMethod.Invoke(value, null),
                            Gegevens = (String)value.GetType().GetProperty("Gegevens").GetMethod.Invoke(value, null),
                            Stageopdracht = (String)value.GetType().GetProperty("Stageopdracht").GetMethod.Invoke(value, null),
                            Goedgekeurd = (String)value.GetType().GetProperty("Goedgekeurd").GetMethod.Invoke(value, null)
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

        public void MailStageSelectie()
        {
            String stageData = "";
            List<String> mails = new List<string>();
            for (int i = 0; i < List.Keys.Count; i++)
            {
                if ((bool)List.Keys.ElementAt(i).GetType().GetProperty("MailTo").GetMethod.Invoke(List.Keys.ElementAt(i), null))
                {
                    students s;
                    List.TryGetValue(List.Keys.ElementAt(i), out s);
                    stageData = s.students_internships.First().internships.description + "\n Van" + s.students_internships.First().internships.start_date + " Tot " + s.students_internships.First().internships.end_date;

                    stagemanagerEntities smE = new stagemanagerEntities();
                    List<students> students = smE.students.ToList();

                    foreach(students st in students){
                        if(s.users.email == st.users.email){
                            if (st.students_internships.Count > 0)
                            {
                                st.students_internships.First().internships.approved = "2";
                            }
                        }
                    }
                    smE.SaveChanges();
                }
            }
            Main.ChangeButton("Mail", new List<object>() { mails , MailViewModel.mailType.beoordeling, stageData}, Clear.No);
        }

        public ProcesOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            stagemanagerEntities smE = new stagemanagerEntities();
            List<students> students = smE.students.ToList();
            List = new Dictionary<object, students>();
            List<students> studenten = new List<students>();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].students_internships.ToList().Count == 0)
                {
                    List<students_internships> myList = new List<students_internships>();
                    myList.Add(new students_internships
                    {
                        internships = new internships
                                       {
                                        description = "Geen stage",
                                        approved = "Nee"
                                        }
                    });

                    studenten.Add(new students
                    {
                        users = students[i].users,
                        students_internships = myList
                    });
                }
                else if (students[i].students_internships.First().internships.approved == "3")
                {
                    List<students_internships> myList = new List<students_internships>();
                    myList.Add(new students_internships
                    {
                        internships = new internships
                        {
                            description = "Aanwezig",
                            approved = "Nee"
                        }
                    });

                    studenten.Add(new students
                    {
                        users = students[i].users,
                        students_internships = myList
                    });
                }
                else if (students[i].students_internships.First().internships.approved == "1")
                {
                    List<students_internships> myList = new List<students_internships>();
                    myList.Add(new students_internships
                    {
                        internships = new internships
                        {
                            description = "Aanwezig",
                            approved = "Ja"
                        }
                    });

                    studenten.Add(new students
                    {
                        users = students[i].users,
                        students_internships = myList
                    });
                }
                else if (students[i].students_internships.First().internships.approved == "2")
                {
                    List<students_internships> myList = new List<students_internships>();
                    myList.Add(new students_internships
                    {
                        internships = new internships
                        {
                            description = "Aanwezig",
                            approved = "Word Behandeld"
                        }
                    });

                    studenten.Add(new students
                    {
                        users = students[i].users,
                        students_internships = myList
                    });
                }
            }

            List = studenten.ToDictionary(t => (Object)new
            {
                MailTo = false,
                Email = t.users.email,
                Student = t.users.name + " " + t.users.surname,
                Gegevens = "Compleet",
                Stageopdracht = t.students_internships.First().internships.description,
                Goedgekeurd = t.students_internships.First().internships.approved
            }, t => t);
        }
    
        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void updateStageStatus()
        {
            stagemanagerEntities smE = new stagemanagerEntities();
            List<students> students = smE.students.ToList();

            for (int i = 0; i < List.Keys.Count; i++)
            {

                if ((bool)List.Keys.ElementAt(i).GetType().GetProperty("MailTo").GetMethod.Invoke(List.Keys.ElementAt(i), null))
                {
                    students s;
                    List.TryGetValue(List.Keys.ElementAt(i), out s);
                    switch (s.students_internships.First().internships.approved)
                    {
                        case "Nee" :
                            s.students_internships.First().internships.approved = "1";
                            
                            System.Diagnostics.Debug.WriteLine("Ja");
                            break;

                        case "Ja":

                            s.students_internships.First().internships.approved = "2";

                            System.Diagnostics.Debug.WriteLine("Bewerkt");
                            break;

                        case "Word Behandeld":
                            s.students_internships.First().internships.approved = "3";

                            System.Diagnostics.Debug.WriteLine("Nee");
                            break;
                    }

                    foreach (students st in students)
                    {
                        if (s.users.email == st.users.email)
                        {
                            if (st.students_internships.Count > 0)
                            {
                                st.students_internships.First().internships.approved = s.students_internships.First().internships.approved;
                            }
                        }
                    }
                }
            }
            smE.SaveChanges();
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            LinkedList<object[]> rows = new LinkedList<object[]>();

            string[] columns = { 
                "Student",
                "E-mailadres",
                "Stageopdracht",
                "Goedgekeurd"
            };

            foreach (KeyValuePair<Object, students> s in List)
            {
                object[] row = {
                    s.Value.users.name + " " + s.Value.users.surname,
                    s.Value.users.email,
                    s.Value.students_internships.First().internships.description,
                    s.Value.students_internships.First().internships.approved
                };

                rows.AddLast(row); 
            }

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }
    }
}