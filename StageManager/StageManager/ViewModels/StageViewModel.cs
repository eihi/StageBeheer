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
    class StageViewModel : PropertyChanged
    {
        private static Random random = new Random();
        private internships stage = new WStored().SearchStageSet()[random.Next(new WStored().SearchStageSet().Count)];

        internal internships Stage
        {
            get { return stage; }
            set
            {
                stage = value;
                NotifyOfPropertyChange(() => EersteStudent);
                NotifyOfPropertyChange(() => TweedeStudent);
                NotifyOfPropertyChange(() => Stagebegeleider);
                NotifyOfPropertyChange(() => TweedeLezer);
                NotifyOfPropertyChange(() => Bedrijf);
                NotifyOfPropertyChange(() => Bedrijfsbegeleider);
            }
        }

        public StageViewModel(MainViewModel main)
            :base(main)
        {
        }

        public StageViewModel(MainViewModel main, internships stage)
            : this(main)
        {
            Stage = stage;
        }

        public string EersteStudent
        {
            get
            {
                try
                {
                    return "Sjors Boom";
                    //return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {              
                    return "";
                }
                
            }
            set 
            {
                
            }
        }

        public string EersteStudentVisibility
        {
            get
            {
                // als eerste student niet leeg is laat eerste student zien, anders verbergen
                if (EersteStudent != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string TweedeStudent
        {
            get
            {
                try
                {
                    return "Leon van Tuyl"; // stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }

            }
            set { }
        }

        public string TweedeStudentVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (TweedeStudent != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string AddStudentVisibility
        {
            get
            {
                if (EersteStudent != "" & TweedeStudent != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public string Stagebegeleider
        {
            get
            {
                try
                {
                    return "Bob Polis";
                    //return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string StageBegeleiderVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Stagebegeleider != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string AddStagebegeleiderVisibility
        {
            get
            {
                if (Stagebegeleider != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public string Bedrijf
        {
            get
            {
                try
                {
                    return "Microsoft";
                    //return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string BedrijfVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Bedrijf != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string AddBedrijfVisibility
        {
            get
            {
                if (Bedrijf != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public string TweedeLezer
        {
            get
            {
                try
                {
                    return "";
                    //return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string TweedeLezerVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (TweedeLezer != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string AddTweedeLezerVisibility
        {
            get
            {
                if (TweedeLezer != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public string Bedrijfsbegeleider
        {
            get
            {
                try
                {
                    return "Bill Gates";
                    //return null;// stage.studentset2.Voornaam + " " + stage.studentset2.Achternaam; TODO!
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string BedrijfsbegeleidererVisibility
        {
            get
            {
                // als tweede student niet leeg is laat tweede student zien, anders verbergen
                if (Bedrijfsbegeleider != "")
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

        public string AddBedrijfsbegeleiderVisibility
        {
            get
            {
                if (Bedrijfsbegeleider != "")
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public void showStageopdracht()
        {
            Main.ChangeButton("Stage");
        }
    }
}
