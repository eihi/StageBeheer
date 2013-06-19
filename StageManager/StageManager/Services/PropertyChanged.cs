using Caliburn.Micro;
using StageManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class PropertyChanged : PropertyChangedBase, IUpdate
    {
        public MainViewModel Main { get; set; }

        public PropertyChanged(MainViewModel main)
        {
            Main = main;
        }

        public virtual void update(object[] o)
        {
        }

        public void Close()
        {
            Main.removeContent(this);
        }

        public void CloseAll()
        {
            Main.Contents.Clear();
        }
    }
}
