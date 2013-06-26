using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;
using StageManager.Services;
using StageManager.Controllers;
using System.Windows;

namespace StageManager.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {

        private String username = "k.janssen2@avans.nl";
        public String Username
        {
            get { return username; }
            set
            {
                if (value.Equals(""))
                {
                    username = null;
                }
                else
                {
                    username = value;
                }
                NotifyOfPropertyChange(() => Username);
            }
        }

        private Visibility Wvisible;
        public Visibility WVisible
        {
            get { return Wvisible; }
            set
            {
                Wvisible = value;
                NotifyOfPropertyChange(() => WVisible);
            }
        }

        private String password;
        public String Password
        {
            get { return password; }
            set
            {
                if (value.Equals(""))
                {
                    password = null;
                }
                else
                {

                    password = value;
                }
                NotifyOfPropertyChange(() => Password);
            }
        }

        private bool visible;
        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                NotifyOfPropertyChange(() => Visible);
            }
        }

        public void Connect()
        {
            Login myLogin = new Login();
            administrators user = myLogin.Connect(username, password);

            if (user != null)
            {
                // Observer observable
                ViewController viewController = new ViewController();
                MainViewModel mainViewModel = new MainViewModel(user);
                mainViewModel.SomethingHappened += viewController.HandleEvent;
                WindowManager windowManager = new WindowManager();
                mainViewModel.ChangeButton(decideWindowState());
                windowManager.ShowWindow(mainViewModel);
                WVisible = Visibility.Hidden;
            }
            else
            {
                Visible =true;
            }
        }

        public void Quit()
        {
            Environment.Exit(1);
        }

        private String decideWindowState()
        {
            String windowToOpen = "Mail";

            stagemanagerEntities smE = new stagemanagerEntities();
            List<students> students = smE.students.ToList();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].students_internships.ToList().Count == 0 || students[i].students_internships.First().internships == null || students[i].students_internships.First().internships.teachers == null)
                {
                    windowToOpen = "ProcesOverzicht";
                }
            }

            return windowToOpen;
        }
    }
}
