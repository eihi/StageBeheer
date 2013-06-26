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
    public class ProcesOverzichtViewModel : PropertyChanged, IExcelAlgorithm
    {
        private int amountselected = 0;
        public int Amountselected
        {
            get { return amountselected; }
            set
            {
                amountselected = value;
                NotifyOfPropertyChange(() => CanStageVerwerken);
            }
        }

        public bool CanStageVerwerken
        {
            get
            {
                return Amountselected == 1;
            }
        }
        public bool CanStageVerwerken2
        {
            get
            {
                return SelectedStudent == null;
            }
        }

        public bool CanMailStageSelectie
        {
            get
            {
                return SelectedStudent == null;
            }
        }



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
                    bool student = list.TryGetValue(value, out selectedStudent);
                    if (student)
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
                        if ((bool)o.GetType().GetProperty("MailTo").GetMethod.Invoke(o, null))
                        {
                            Amountselected++;
                        }
                        else
                        {
                            Amountselected--;
                        }

                        list.Remove(value);
                        list.Add(o, selectedStudent);
                        List = list;
                    }
                }
                NotifyOfPropertyChange(() => CanStageVerwerken2);
                NotifyOfPropertyChange(() => CanMailStageSelectie);
                
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
                    if (s == null)
                    {
                         mails.Add((String)List.Keys.ElementAt(i).GetType().GetProperty("Email").GetMethod.Invoke(List.Keys.ElementAt(i), null));
                    }
                    else
                        mails.Add(s.users.email);
                }
            }
            Main.ChangeButton("Mail", new List<object>() { mails, MailViewModel.mailType.nieuw }, Clear.No);
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

                    foreach (students st in students)
                    {
                        if (s.users.email == st.users.email)
                        {
                            if (st.students_internships.Count > 0)
                            {
                                st.students_internships.First().internships.approved = "2";
                            }
                        }
                    }
                    smE.SaveChanges();
                }
            }
            Main.ChangeButton("Mail", new List<object>() { mails, MailViewModel.mailType.beoordeling, stageData }, Clear.No);
        }

        public ProcesOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            refresh();
        }

        private void refresh(){
            stagemanagerEntities smE = new stagemanagerEntities();
            List<students> students = smE.students.ToList();
            List = new Dictionary<object, students>();
            List = students.ToDictionary(t => (Object)new
            {
                MailTo = false,
                Email = t.users != null ? t.users.email : "student heeft geen gebruiker",
                Student = t.users != null ? t.users.name + " " + t.users.surname : "student heeft geen gebruiker",
                Gegevens = t.users != null || t.students_internships != null || t.students_internships.Count > 0 ? "Compleet" : "Niet compleet",
                Stageopdracht = t.students_internships != null && t.students_internships.Count > 0 ? t.students_internships.First().internships.description : "niet ingeleverd",
                Goedgekeurd = t.students_internships != null && t.students_internships.Count > 0 ?
                    (t.students_internships.First().internships.approved == "0" ?
                        "In afwachting" :
                        (t.students_internships.First().internships.approved == "1" ?
                            "Goedgekeurd" :
                            (t.students_internships.First().internships.approved == "2" ?
                                "Wordt nagekeken" :
                                (t.students_internships.First().internships.approved == "3" ?
                                    "Niet goedgekeurd" :
                                    "fout in db"
                                )
                            )
                        )
                    ) :
                    "niet van toepassing"
            }, t => t);

            // Haal ook alle lege webkeys mee
            foreach (webkeys w in new WStored().SearchWebkeys())
            {
                if (w.user_id == null)
                {
                    Object o = (Object)new
                    {
                        MailTo = false,
                        Email = w.email != null ? w.email : "student heeft geen gebruiker",
                        Student = "Nog niet ingevuld",
                        Stageopdracht = "niet van toepassing",
                        Gegevens = "niet van toepassing",
                        Goedgekeurd = "niet van toepassing"
                    };
                    list.Add(o, null);
                }
            }
            List = List;

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
                        case "0":
                            s.students_internships.First().internships.approved = "1";
                            break;

                        case "1":
                            s.students_internships.First().internships.approved = "2";
                            break;

                        case "2":
                            s.students_internships.First().internships.approved = "3";
                            break;

                        case "3":
                            s.students_internships.First().internships.approved = "0";
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
            refresh();
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
            int i = 0;
            foreach (KeyValuePair<Object, students> s in List)
            {

                if (s.Value == null)
                {
                    

                    object[] row = {
                    "Niet bekend",
                    (String)List.Keys.ElementAt(i).GetType().GetProperty("Email").GetMethod.Invoke(List.Keys.ElementAt(i), null),
                    "Geen stageopdracht",
                    "NVT"
                    };

                    rows.AddLast(row);

                }
                else if (s.Value.students_internships.Count > 0)
                {
                    string approved = "";
                    switch (int.Parse(s.Value.students_internships.First().internships.approved))
                    {
                        case 1:
                            approved = "Goedgekeurd";
                            break;
                        case 2:
                            approved = "Wordt nagekeken";
                            break;
                        case 3:
                            approved = "goedgekeurd";
                            break;
                        default:
                            approved = "In afwachting";
                            break;
                    }


                    object[] row = {
                    s.Value.users.name + " " + s.Value.users.surname,
                    s.Value.users.email,
                    s.Value.students_internships.First().internships.description,
                    approved
                    };

                    rows.AddLast(row);
                }
                else
                {
                    object[] row = {
                    s.Value.users.name + " " + s.Value.users.surname,
                    s.Value.users.email,
                    "Nog geen stage",
                    "Niet van toepassing"
                    };

                    rows.AddLast(row);
                }
                i++;        
            }

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }

        public void StageVerwerken()
        {
            students student = null;
            for (int i = 0; i < List.Keys.Count; i++)
            {
                if ((bool)List.Keys.ElementAt(i).GetType().GetProperty("MailTo").GetMethod.Invoke(List.Keys.ElementAt(i), null))
                {
                    if (List.TryGetValue(List.Keys.ElementAt(i), out student))
                    {
                        break;
                    }
                }
            }

            if (list.Count > 0 && selectedStudent.students_internships.First() != null)
            {
                Main.ChangeButton("Stage", new List<object>() { student.students_internships.First().internships }, Clear.After);
            }
        }
    }
}