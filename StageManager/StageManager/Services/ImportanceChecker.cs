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
        private DistanceCalculator dCalculator;

        public ImportanceChecker()
        {
            dCalculator = new DistanceCalculator();
        }

        public List<object> checkImportance(int internship)
        {
            List<object> teachers = new List<object>();

            //stage
            //get adres
            //get kennis

            //get docenten
            //check tijd (+ aantal stages gelinkt)
            //get kennisgebieden per docent
            //get locatie
            
            return teachers;
        }
    }
}
