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
        private stagemanagerEntities smEntities;

        public AppBootstrapper()
            :base()
        {
            windowManager = new WindowManager();
            
            smEntities = new stagemanagerEntities();

            LoginViewModel loginViewModel = new LoginViewModel();


            // Show Window
            windowManager.ShowWindow(loginViewModel);
        }
    }
}