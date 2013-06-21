using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;
using StageManager.Services;
using StageManager.Controllers;

namespace StageManager.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {

        private String username = "remcovanderheijden@hotmail.com";
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
                windowManager.ShowWindow(mainViewModel);
            }
            else
            {
                Visible =true;
            }
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}
