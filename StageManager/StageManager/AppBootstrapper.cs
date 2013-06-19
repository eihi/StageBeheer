namespace StageManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using Caliburn.Micro;
    using System.Diagnostics;
    using StageManager.Controllers;
    using StageManager.ViewModels;
    using System.Threading.Tasks;
    using System.Reflection;
    using StageManager.Services;
    using StageManager.Models;

    public class AppBootstrapper : Bootstrapper
    {
        private WindowManager windowManager;
        private ViewController viewController;
        private stagemanagerEntities smEntities;

        public AppBootstrapper()
            :base()
        {
            windowManager = new WindowManager();
            viewController = new ViewController();
            
            smEntities = new stagemanagerEntities();


            // Observer observable
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.SomethingHappened += viewController.HandleEvent;

            // Show Window
            windowManager.ShowWindow(mainViewModel);
        }
    }
}