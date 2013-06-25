using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class ImportanceChecker
    {

        public ImportanceChecker()
        {
            
        }

        public List<DocentValue> checkImportance(int internship)
        {
            List<DocentValue> returnlist = new List<DocentValue>();     
            //stage
            List<internships> stage = (from stages in new WStored().SearchStage("", "", false) where stages.id == internship select stages).ToList();  
            internships Internship = stage[0];
            //get adres
            String adres = Internship.supervisor.companies.adresses.zipcode;            
            //get kennis
            List<db_internship_knowledge> kennis = (from kennisgebied in new WStored().SearchDBInternshipKnowledge() where kennisgebied.internship_id == internship select kennisgebied).ToList();
            //get docenten
            List<teachers> teachers = (from teach in new WStored().SearchDocentSet("") select teach).ToList();
            for(int i = 0; i < teachers.Count; i++)
            {
                DocentValue teachervalue = new DocentValue(teachers[i]);                
                Boolean duo = false;

                List<students_internships> gekoppeldeStudenten = (from gs in new WStored().SearchStudents_internships() where gs.intership_id == internship select gs).ToList();
                if (gekoppeldeStudenten.Count > 1)
                    duo = true;
                 //check tijd (+ aantal stages gelinkt)
                teachervalue.checkTime(Internship.type, duo, Internship.start_date, Internship.end_date);
                 //get kennisgebieden per docent
                teachervalue.checkKnowledge(kennis);
                 //get locatie TODO pas aanroepen na sorteren en dan alleen de hoogste 10
                teachervalue.checkDistance(adres);
                //update
                teachervalue.updateValue();

                returnlist.Add(teachervalue);
            }
          
            //sorteer lijst als er meer dan 1 in zit.
            if (returnlist.Count > 1)
            {
                returnlist = SortList(returnlist);
            }

            for (int i = 0; i < returnlist.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(returnlist[i].value + " " + returnlist[i].TeacherInfo.users.name);
            }
            return returnlist;
        }

        /*
         *sorteerd een DocentValue lijst op bassis van de Docentvalue.value van hoog naar laag. 
         */
        private List<DocentValue> SortList(List<DocentValue> returnlist)
        {
            List<DocentValue> sortedList = returnlist;
            return sortedList.OrderByDescending(x => x.value).ToList();             
        }
    }
}
