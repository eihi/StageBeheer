using StageManager.Exceptions;
using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StageManager.Services
{
    public class Wrapper : IWrapper
    {
        static private DispatcherTimer timer;
        static private stagemanagerEntities stageManagerEntities;
        static private TimeSpan time;

        public static stagemanagerEntities StageManagerEntities
        {
            get { return Wrapper.stageManagerEntities; }
            set { Wrapper.stageManagerEntities = value; }
        }

        public Wrapper()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                time = new TimeSpan(0, 0, 1);
                timer.Interval = time;
                timer.Tick += timer_Tick;
            }
            if (stageManagerEntities == null)
            {
                stageManagerEntities = new stagemanagerEntities();
                stageManagerEntities.Configuration.LazyLoadingEnabled = false;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int i = stageManagerEntities.SaveChanges();
            timer.Stop();
        }

        public void forceSync()
        {
            timer_Tick(null, null);
        }


        public void save(Object o)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timer.Interval = time;
                timer.Start();
            }
            else
            {
                timer.Start();
            }
        }


        public void add(object o)
        {
            try
            {
                stageManagerEntities.Set(o.GetType()).Add(o);
                save(o);
            }
            catch (Exception)
            {

            }
        }
        public void delete(object o)
        {
            if (stageManagerEntities.Set(o.GetType()).Find(o) != null)
            {
                stageManagerEntities.Set(o.GetType()).Remove(o);
                save(o);
            }
        }
    }
}
