using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using StageBeheerder.ViewModels;
using StageBeheerder.Views;
using StageBeheerder.Models;
using StageBeheerder.Controllers;

namespace StageBeheerder
{
    public class AppBootstrapper : Bootstrapper
    {
        private WindowManager windowManager = new WindowManager();
        private ViewController viewController = new ViewController();
        // TODO private StageBeheerderEntities smEntities = new stagemanagerEntities();

        public AppBootstrapper()
            : base()
        {
            // Observer observable
            MainViewModel mainViewModel = new MainViewModel();
            // TODO mainViewModel.SomethingHappened += viewController.HandleEvent;

            // Show Window
            windowManager.ShowWindow(mainViewModel);
        }
    }
}
