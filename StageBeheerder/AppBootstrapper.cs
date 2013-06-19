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
        private WindowManager _windowManager = new WindowManager();
        private ViewController _viewController = new ViewController();
        private StageBeheerderEntities _smEntities = new StageBeheerderEntities();

        public AppBootstrapper()
            : base()
        {
            // Observer observable
            MainViewModel mainViewModel = new MainViewModel();
            // TODO mainViewModel.SomethingHappened += viewController.HandleEvent;

            // Show Window
            _windowManager.ShowWindow(mainViewModel);
        }
    }
}
