using Caliburn.Micro;
using StageManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class PropertyChanged : PropertyChangedBase, IUpdate
    {
        public MainViewModel Main { get; set; }
        public Services.PropertyChanged Last { get; set; }

        public PropertyChanged(MainViewModel main, PropertyChanged last)
        {
            Main = main;
            Last = last;
        }

        public virtual void update(object[] o)
        {
        }

        public virtual void update()
        {
            PropertyInfo[] propperties = this.GetType().GetProperties();
            for (int i = 0; i < propperties.Length; i++)
            {
                NotifyOfPropertyChange(propperties[i].Name);
            }
            if (Last != null)
            {
                Last.update();
            }
        }

        public void Close()
        {
            Main.removeContentAfter(this);
            Main.removeContent(this);
        }

        public void CloseAll()
        {
            Main.Contents.Clear();
        }
    }
}