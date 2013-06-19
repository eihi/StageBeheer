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
        //private DefaultFactory defaultFactory;
        //private EntityService entityService;
        private stagemanagerEntities smEntities;

        public AppBootstrapper()
            :base()
        {
            windowManager = new WindowManager();
            //defaultFactory = new DefaultFactory();
            smEntities = new stagemanagerEntities();

            //entityService = new EntityService(defaultFactory, smEntities);
            viewController = new ViewController();

            // Observer observable
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.SomethingHappened += viewController.HandleEvent;

            // Show Window
            windowManager.ShowWindow(mainViewModel);
        }
    }
}