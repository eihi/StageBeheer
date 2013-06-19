using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    class WStored : Wrapper
    {
        private Random r = new Random();

        public List<WStudent> SearchStudentSet(String searchString, String searchOpleiding)
        {
            if (searchString == null && searchOpleiding == null)
            {

                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        select new WStudent(student)).ToList();
            }
            if (searchString != null && searchOpleiding == null)
            {
                return (from student
                       in StageManagerEntities.studentsets.ToList()
                        where student.persoonsets.Voornaam.ToLower().Contains(searchString.ToLower()) ||
                        student.persoonsets.Achternaam.ToLower().Contains(searchString.ToLower()) ||
                        student.Studentnummer.ToString().ToLower().Contains(searchString.ToLower())
                        select new WStudent(student)).ToList();
            }
            else if (searchOpleiding != null && searchString == null)
            {
                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        where student.opleidingsets.Naam.ToLower().Contains(searchOpleiding.ToLower())
                        select new WStudent(student)).ToList();

            }
            else
            {
                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        where (student.persoonsets.Voornaam.ToLower().Contains(searchString.ToLower()) ||
                        student.persoonsets.Achternaam.ToLower().Contains(searchString.ToLower()) ||
                        student.Studentnummer.ToString().ToLower().Contains(searchString.ToLower())) &&
                        student.opleidingsets.Naam.ToLower().Contains(searchOpleiding.ToLower())
                        select new WStudent(student)).ToList();
            }
        }

        public List<WStudent> SearchStudentSetWithStage(String searchString, String searchOpleiding)
        {

            if (searchString == null && searchOpleiding == null)
            {
                searchString = "";
            }
            if (searchString != null && searchOpleiding == null)
            {
                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        where student.persoonsets.Voornaam.ToLower().Contains(searchString.ToLower()) ||
                        student.persoonsets.Achternaam.ToLower().Contains(searchString.ToLower()) ||
                        student.Studentnummer.ToString().ToLower().Contains(searchString.ToLower()) && (
                        student.stagesets.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select new WStudent(student)).ToList();
            }
            else if (searchOpleiding != null && searchString == null)
            {
                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        where (student.opleidingsets.Naam.ToLower().Contains(searchOpleiding.ToLower())) && (
                        student.stagesets.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select new WStudent(student)).ToList();
            }
            else
            {
                return (from student
                        in StageManagerEntities.studentsets.ToList()
                        where (student.persoonsets.Voornaam.ToLower().Contains(searchString.ToLower()) ||
                        student.persoonsets.Achternaam.ToLower().Contains(searchString.ToLower()) ||
                        student.Studentnummer.ToString().ToLower().Contains(searchString.ToLower())) &&
                        (student.opleidingsets.Naam.ToLower().Contains(searchOpleiding.ToLower())) && (
                        student.stagesets.First().docentset_Id == null || student.stagesets1.First().docentset_Id == null)
                        select new WStudent(student)).ToList();
            }
        }

        public List<WStage> SearchStage(String searchString, String searchOpleiding, bool All)
        {
            List<stagesets> listStage = StageManagerEntities.stagesets.ToList();
            List<eindstagesets> listEindStage = StageManagerEntities.eindstagesets.ToList();
            List<WStage> returnList = new List<WStage>();

            for (int i = 0; i < listEindStage.Count; i++)
            {
                WEindStage stage = new WEindStage(listEindStage[i]);
                if (stage.docentsets == null || stage.TweedeLezer == null || All)
                {
                    bool contains = false;
                    for (int j = 0; j < returnList.Count; j++)
                    {
                        if (returnList[j].getSet() == stage.set)
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
            }

            for (int i = 0; i < listStage.Count; i++)
            {
                WStage stage = new WStage(listStage[i]);

                bool contains = false;
                for (int j = 0; j < returnList.Count; j++)
                {
                    if (returnList[j].getSet() == stage.set)
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

        public List<WDocent> SearchDocentSet(String searchString)
        {
            if (searchString == null)
            {
                return (from docent in StageManagerEntities.docentsets.ToList() select new WDocent(docent)).ToList();
            }
            else
            {
                return (from docent
                            in StageManagerEntities.docentsets.ToList()
                        where (docent.persoonsets.Voornaam.ToLower().Contains(searchString.ToLower()) ||
                        docent.persoonsets.Achternaam.ToLower().Contains(searchString.ToLower()))
                        select new WDocent(docent)).ToList();
            }
        }

        public List<WBedrijfsBegeleider> SearchBedrijfsBegeleiderSet()
        {
            return (from begeleider in StageManagerEntities.bedrijfsbegeleidersets.ToList() select new WBedrijfsBegeleider(begeleider)).ToList();
        }

        public List<WOpleiding> SearchOpleidingSet()
        {
            return (from opleiding in StageManagerEntities.opleidingsets.ToList().OrderBy(o => o.Naam) select new WOpleiding(opleiding)).ToList();
        }

        public List<WBedrijf> SearchBedrijfSet()
        {
            return (from bedrijf in StageManagerEntities.bedrijfsets.ToList() select new WBedrijf(bedrijf)).ToList();
        }

        public List<WStage> SearchStageSet()
        {
            return (from stage in StageManagerEntities.stagesets.ToList() select new WStage(stage)).ToList();
        }

        public List<WStage> SearchKoppelingSet()
        {
            return (from stage in StageManagerEntities.stagesets.ToList()
                    where stage.docentsets != null && stage.Student2 != null
                    select new WStage(stage)).ToList();
        }

        public List<WStage> SearchKoppelingSet2()
        {
            return (from stage in StageManagerEntities.stagesets.ToList()
                    where stage.docentsets != null && stage.Student2 == null
                    select new WStage(stage)).ToList();
        }


        public WStage SearchStageSet(int StudentId)
        {
            return (from stage in StageManagerEntities.stagesets.ToList()
                    where stage.Student1 == StudentId
                    select new WStage(stage)).First();
        }

        public bool containsMail(String mailadres)
        {
            return (from mail in StageManagerEntities.tempemailsets.ToList()
                    where mail.Email == mailadres
                    select new WTempmail(mail)).Count() != 0;
        }

        public WWebkey mailWebkey(String mailadres)
        {
            return (from mail in StageManagerEntities.tempemailsets.ToList()
                    where mail.Email == mailadres
                    select new WWebkey(mail.webkeysets)).First();
        }

        public string NewWebkey(string to)
        {
            String key = "";
            List<WWebkey> list = new List<WWebkey>();
            do
            {
                key = randomSting(10);
                list = (from webkey in StageManagerEntities.webkeysets.ToList() where webkey.ConnectionKey == key select new WWebkey(webkey)).ToList();
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
    }
}