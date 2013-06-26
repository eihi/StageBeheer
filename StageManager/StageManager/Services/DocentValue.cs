using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class DocentValue
    {
        public teachers TeacherInfo { get; set; }
        public int value { get; set; }
        public int timeleftafter { get; set; }
        // public int numberOfInternships { get; set; } niet uitgewerkt.
        public double distance { get; set; }
        public int numberOfKnowledge { get; set; }
        public List<String> sameKnowledge { get; set; }
        public String sameKnowledgeString { get; set; }

        static int stage = 7;
        static int duoStage = 14;
        static int eindstage = 18;
        static int duoEindstage = 26;

        static int hasTime = 50;
        static int hasKnowledge = 5;
        static int hasDistance = -1;
        static double RelevantDistance = 50;

        private int year;

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                blok1 = new DateTime(Year, 7, 29);
                blok2 = new DateTime(Year, 11, 1);
                blok3 = new DateTime(Year + 1, 1, 20);
                blok4 = new DateTime(Year + 1, 4, 1);
            }
        }

        public DateTime blok1 { get; set; }
        public DateTime blok2 { get; set; }
        public DateTime blok3 { get; set; }
        public DateTime blok4 { get; set; }

       

        public DocentValue(teachers teachers)
        {
            sameKnowledge = new List<String>();
            TeacherInfo = teachers;
            value = 0;
            timeleftafter = 0;            
            distance = 0;
            numberOfKnowledge = 0;
            Year = DateTime.Now.Year;
        }

        

        /*
         * vergelijkt een lijst met stage kennis en deze docent kennis.
         * per hit verhoogt hij een counter en voegt hij de naam van de kennis toe aan een list.
         */
        internal void checkKnowledge(List<db_internship_knowledge> kennis)
        {
            List<db_teacher_knowledge> docentKennis = (from DKennis in new WStored().SearchDBTeacherKnowledge() where DKennis.teacher_user_id == TeacherInfo.user_id select DKennis).ToList();
            for (int o = 0; o < docentKennis.Count; o++)
            {
                String currentKennis = docentKennis[o].name;
                for (int i = 0; i < kennis.Count; i++)
                {
                    if(kennis[i].name.Equals(currentKennis))
                    {
                        i = kennis.Count;
                        sameKnowledge.Add(currentKennis);
                        numberOfKnowledge++;
                    }
                }
            }

            for (int i = 0; i < sameKnowledge.Count; i++)
            {
                if (i > 0)
                {
                    sameKnowledgeString += ", ";
                }
                sameKnowledgeString += sameKnowledge[i];

            }
        }

        internal void checkDistance(string adres)
        {
            DistanceCalculator calc = new DistanceCalculator();
            distance = calc.getDistance(adres, TeacherInfo.adresses.zipcode);
        }

        internal void checkTime(string stagetype, Boolean duo, DateTime start, DateTime end)
        {
            int timeNeeded = 0;
            int timeLeft = 0;

            //kijk hoeveel tijd het kost om deze stage te doen.
            if (!duo)
            {
                if (stagetype.Equals("0"))
                    timeNeeded = stage;
                else if (stagetype.Equals("1"))
                    timeNeeded = eindstage;
            }
            else
            {
                if (stagetype.Equals("0"))
                    timeNeeded = duoStage;
                else if (stagetype.Equals("1"))
                    timeNeeded = duoEindstage;
            }

            //kijk de tijd die beschikbaar is.
            Boolean processed = false;
            String blokken = "";
            while (!processed) //kijk welk jaar en welke blokken deze stage zich afspeeld.
            {
                if (start > blok1)
                {
                    if (start > blok2)
                    {
                        if (start > blok3)
                        {
                            if (start > blok4)
                            {
                                Year += 1;
                                if (start < blok1)
                                {
                                    blokken = "41";
                                    processed = true;
                                }
                            }
                            else
                            { blokken = ("34"); processed = true; }
                        }
                        else
                        { blokken = ("23"); processed = true; }
                    }
                    else
                    { blokken = ("12"); processed = true; }
                }
                else
                {
                    Year -= 1;
                }
            }

            volumehours jaaruren = null;
            List<volumehours> jarenUren = (from uren in new WStored().SearchVolumehours() where uren.teacher_user_id == TeacherInfo.user_id select uren).ToList();
            if (jarenUren.Count > 0)
            {
                jaaruren = jarenUren[0];
            }

            if (jaaruren != null)
            {
                switch (blokken)
                {
                    case "12":
                        timeLeft = (jaaruren.remaining_hours1.Value + jaaruren.remaining_hours2.Value);
                        break;

                    case "23":
                        timeLeft = (jaaruren.remaining_hours2.Value + jaaruren.remaining_hours3.Value);
                        break;

                    case "34":
                        timeLeft = (jaaruren.remaining_hours3.Value + jaaruren.remaining_hours4.Value);
                        break;

                    case "41":
                        System.Diagnostics.Debug.WriteLine("blok 4 en 1 is niet toegestaan");
                        break;
                }
            }

            if (timeLeft >= timeNeeded)
            {
                timeleftafter = (timeLeft - timeNeeded);
            }

        }


        public void updateValue()
        {
            value = 0;
            if (timeleftafter > 0) // geen tijd dan flink aantal punten eraf.
            {
                value += hasTime;
            }

            for (int i = 0; i < numberOfKnowledge; i++)
            {
                value += hasKnowledge;
            }

            double distanceCalc = 5;
            while (distanceCalc < distance)
            {
                distanceCalc += RelevantDistance;
                value += hasDistance;
            }

        }

        internal void removeTime()
        {
            throw new NotImplementedException();
        }
    }
}
