using Caliburn.Micro;
using StageManager.Controllers;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private administrators user;

        private String userName;
        public String UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
        public event EventHandler SomethingHappened;
        public string currentButton { get; set; }

        public MainViewModel(administrators user)
        {
            this.user = user;

            UserName = "Ingelogd als, " + user.users.name + " " + user.users.surname;
            content = new ObservableCollection<PropertyChanged>();
            Error = new ErrorViewModel();
        }

        public ErrorViewModel Error { get; set; }

        private String search;
        public String Search
        {
            get
            {
                return search;
            }
            set
            {
                search = value;
                NotifyOfPropertyChange(() => Search);
                ChangeButton("Zoek", new List<object>() { value }, Clear.All);
            }
        }

        private ObservableCollection<PropertyChanged> content;
        public ObservableCollection<PropertyChanged> Contents
        {
            get { return content; }
            set
            {
                content = value;
                NotifyOfPropertyChange(() => Contents);
            }
        }

        public void addContent(PropertyChanged o)
        {
            Contents.Add(o);
            NotifyOfPropertyChange(() => Contents);
        }

        public void removeContent(PropertyChanged o)
        {
            if (Contents.Contains(o))
            {
                Contents.Remove(o);
            }
        }

        public void removeContentAfter(PropertyChanged o)
        {
            if (Contents.Contains(o))
            {
                int i = 0;
                for (i = 0; i < Contents.Count; i++)
                {
                    if (Contents[i] == o)
                    {
                        break;
                    }
                }
                while (Contents.Count > i + 1)
                {
                    Contents.RemoveAt(Contents.Count - 1);
                }
            }
        }

        public void CloseAll()
        {
            Contents.Clear();
        }

        public void ChangeButton(string name)
        {
            ChangeButton(name, new List<Object>());
        }

        public void ChangeButton(string name, List<Object> o)
        {
            ChangeButton(name, o, Clear.No);
        }

        public void ChangeButton(string name, List<Object> o, Clear c)
        {
            ChangeButton(name, o, c, null);
        }

        public void ChangeButton(string name, List<Object> o, Clear c, PropertyChanged p)
        {
            currentButton = name;
            Clear clear = c;
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, new MainArgs(o, clear, p));
            }
        }
    }
}
