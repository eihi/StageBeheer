using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace StageManager.Models
{
    class WStored : Wrapper
    {
        private Random r = new Random();

        public static void PushToDB()
        {
            int i = WStored.StageManagerEntities.SaveChanges();
        }

        public List<students> SearchStudentSet(String searchString, String searchOpleiding)
        {
            if (searchString == null && searchOpleiding == null)
            {

                return (from student
                        in StageManagerEntities.students.ToList()
                        select student).ToList();
            }
            if (searchString != null && searchOpleiding == null)
            {
                return (from student
                       in StageManagerEntities.students.ToList()
                        where student.users.name.ToLower().Contains(searchString.ToLower()) ||
                        student.users.surname.ToLower().Contains(searchString.ToLower()) ||
                        student.studentnumber.ToString().ToLower().Contains(searchString.ToLower())
                        select student).ToList();
            }
            else if (searchOpleiding != null && searchString == null)
            {
                return (from student
                        in StageManagerEntities.students.ToList()
                        where student.education.name.ToLower().Contains(searchOpleiding.ToLower())
                        select student).ToList();

            }
            else
            {
                return (from student
                        in StageManagerEntities.students.ToList()
                        where (student.users.name.ToLower().Contains(searchString.ToLower()) ||
                        student.users.surname.ToLower().Contains(searchString.ToLower()) ||
                        student.studentnumber.ToString().ToLower().Contains(searchString.ToLower())) &&
                        student.education.name.ToLower().Contains(searchOpleiding.ToLower())
                        select student).ToList();
            }
        }

        public List<students> SearchStudentSetWithStage(String searchString, String searchOpleiding)
        {

            if (searchString == null && searchOpleiding == null)
            {
                searchString = "";
            }
            if (searchString != null && searchOpleiding == null)
            {
                return (from student
                        in StageManagerEntities.students.ToList()
                        where student.users.name.ToLower().Contains(searchString.ToLower()) ||
                        student.users.surname.ToLower().Contains(searchString.ToLower()) ||
                        student.studentnumber.ToString().ToLower().Contains(searchString.ToLower())// && (
                        //student.st.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select student).ToList();//TODO
            }
            else if (searchOpleiding != null && searchString == null)
            {
                return (from student
                        in StageManagerEntities.students.ToList()
                        where (student.education.name.ToLower().Contains(searchOpleiding.ToLower()))// && (
                        //student.stagesets.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select student).ToList();//TODO
            }
            else
            {
                return (from student
                        in StageManagerEntities.students.ToList()
                        where (student.users.name.ToLower().Contains(searchString.ToLower()) ||
                        student.users.surname.ToLower().Contains(searchString.ToLower()) ||
                        student.studentnumber.ToString().ToLower().Contains(searchString.ToLower())) &&
                        (student.education.name.ToLower().Contains(searchOpleiding.ToLower())) //&& (
                        //student.stagesets.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select student).ToList();//TODO
            }
        }

        public List<internships> SearchStage(String searchString, String searchOpleiding, bool All)
        {
            List<internships> listStage = StageManagerEntities.internships.ToList();
            List<internships> returnList = new List<internships>();

            for (int i = 0; i < listStage.Count; i++)
            {
                internships stage = listStage[i];

                bool contains = false;
                for (int j = 0; j < returnList.Count; j++)
                {
                    if (returnList[j] == stage)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    returnList.Add(stage);
                }
            }

            return returnList;
        }

        public List<teachers> SearchDocentSet(String searchString)
        {
            if (searchString == null)
            {
                return (from docent in StageManagerEntities.teachers.ToList() select docent).ToList();
            }
            else
            {
                return (from docent
                            in StageManagerEntities.teachers.ToList()
                        where (docent.users.name.ToLower().Contains(searchString.ToLower()) ||
                        docent.users.surname.ToLower().Contains(searchString.ToLower()))
                        select docent).ToList();
            }
        }

        public List<teachers> SearchDocentSet(String voornaam, String achternaam)
        {
            if (voornaam == null || achternaam == null)
            {
                return (from docent in StageManagerEntities.teachers.ToList() select docent).ToList();
            }
            else
            {
                return (from docent
                            in StageManagerEntities.teachers.ToList()
                        where (docent.users.name.ToLower().Contains(voornaam.ToLower()) ||
                        docent.users.surname.ToLower().Contains(achternaam.ToLower()))
                        select docent).ToList();
            }
        }

        public List<dbstageview> SearchDBStageView()
        {
            return (from viewstage in StageManagerEntities.dbstageview.ToList() select viewstage).ToList();
        }

        public List<students_internships> SearchStudents_internships()
        {
            return (from student_internships in StageManagerEntities.students_internships.ToList() select student_internships).ToList();
        }

        public List<db_teacherhasinternship> Searchteacherhasinternship()
        {
            return (from zoek in StageManagerEntities.db_teacherhasinternship.ToList() select zoek).ToList();
        }

        public List<db_internship_knowledge> SearchDBInternshipKnowledge()
        {
            return (from viewstagekennis in StageManagerEntities.db_internship_knowledge.ToList() select viewstagekennis).ToList();
        }

        public List<db_teacher_knowledge> SearchDBTeacherKnowledge()
        {
            return (from viewleraarkennis in StageManagerEntities.db_teacher_knowledge.ToList() select viewleraarkennis).ToList();
        }

        public List<dbstageviewcomplete> SearchDBStageViewComplete()
        {
            return (from viewstage in StageManagerEntities.dbstageviewcomplete.ToList() select viewstage).ToList();
        }

        public List<supervisor> SearchBedrijfsBegeleiderSet()
        {
            return (from begeleider in StageManagerEntities.supervisor.ToList() select begeleider).ToList();
        }

        public List<education> SearchOpleidingSet()
        {
            return (from opleiding in StageManagerEntities.education.ToList().OrderBy(o => o.name) select opleiding).ToList();
        }

        public List<volumehours> SearchVolumehours()
        {
            return (from hours in StageManagerEntities.volumehours.ToList() select hours).ToList();
        }

        public List<companies> SearchBedrijfSet()
        {
            return (from bedrijf in StageManagerEntities.companies.ToList() select bedrijf).ToList();
        }

        public List<internships> SearchStageSet()
        {
            return (from stage in StageManagerEntities.internships.ToList() select stage).ToList();
        }

        public List<internships> SearchKoppelingSet()
        {
            return (from stage in StageManagerEntities.internships.ToList()
                    //where stage.docentsets != null && stage.Student2 != null
                    select stage).ToList();//TODO
        }

        public List<internships> SearchKoppelingSet2()
        {
            return (from stage in StageManagerEntities.internships.ToList()
                    //where stage.docentsets != null && stage.Student2 == null
                    select stage).ToList();//TODO
        }


        public internships SearchStageSet(int StudentId)
        {
            return (from stage in StageManagerEntities.internships.ToList()
                    //where stage.Student1 == StudentId
                    select stage).First();//TODO
        }

        public bool containsMail(String mailadres)
        {
            return (from user in StageManagerEntities.users.ToList()
                    where user.email == mailadres
                    select user).Count() != 0;
        }

        public webkeys mailWebkey(String mailadres)
        {
            List<users> list = StageManagerEntities.users.ToList();
            users user = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].email == mailadres)
                {
                    user = list[i];
                    break;
                }
            }

            if (user != null)
            {
                List<webkeys> keyList = StageManagerEntities.webkeys.ToList();
                for (int i = 0; i < keyList.Count; i++)
                {
                    if (keyList[i].users == user)
                    {
                        return keyList[i];
                    }
                }
            }

            return null;//TODO: CHECK!!
        }

        public string NewWebkey(string to)
        {
            String key = "";
            List<webkeys> list = new List<webkeys>();
            do
            {
                key = randomSting(10);
                list = (from webkey in StageManagerEntities.webkeys.ToList() where webkey.webkey == key select webkey).ToList();
            }
            while (list.Count > 0);
            return key;
        }

        private string randomSting(int p)
        {
            if (p <= 0)
            {
                return null;
            }
            String key = "";
            char[] list = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                              'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                              'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
                              'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            for (int i = 0; i < p; i++)
            {
                key += list[r.Next(list.Length)];
            }
            return key;
        }

        internal List<webkeys> SearchWebkeys()
        {
            return StageManagerEntities.webkeys.ToList();
        }
    }
}