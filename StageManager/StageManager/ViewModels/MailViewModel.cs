using Caliburn.Micro;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageManager.ViewModels
{
    class MailViewModel :PropertyChanged
    {
        private String error;
        public String Error
        {
            get
            {
                return "In het bericht moet " + error + " voorkomen";
            }
            set
            {
                error = value;
            }
        }
        public enum mailType { leeg, beoordeling, herinnering, docent, student };
        private String to;
        private mailType type;
        public String To
        {
            get
            {
                return to;
            }
            set
            {
                char[] c = value.ToCharArray();
                String s="";
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == '\n' || c[i] == ' ')
                    {
                        c[i] = ',';
                    }
                    if (c[i] != '\r')
                    {
                        s += c[i];
                    }
                }
                to = s;
                NotifyOfPropertyChange(() => To);
            }
        }
        private String message;
        public String Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                if (message.Contains(error))
                {
                    Visible = false;
                }
                else
                {
                    Visible = true;
                }
                NotifyOfPropertyChange(()=>Message);
            }
        }

        public String Subject { get; set; }
        public String StageData { get; set; }
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

        public MailViewModel(MainViewModel main, PropertyChanged last)
            : this(main, last, mailType.student)
        {

        }

        public MailViewModel(MainViewModel main, PropertyChanged last, mailType optie)
            :base(main,last)
        {
            type = optie;

            To = "";
            SetMessage();

        }

        private void SetMessage()
        {
            switch (type)
            {
                case mailType.beoordeling:
                    Error = "%stageData%";
                    Subject = "Kijk deze stageopdracht na s.v.p.";
                    Message = "Beste docent,\n\n" +
                    "Met deze mail verplichten wij u vriendelijk om de stage geleverd via deze mail na te kijken.\n" +
                    "%stageData%\n\n\n" +
                    "Met vriendelijke groeten,\n" +
                    "Katinka Janssen\n" +
                    "Stagecoördinator AI&I\n" +
                    "Avans Hogeschool 's-Hertogenbosch";
                    break;
                case mailType.student:
                    Error = "%webkey%";
                    Subject = "Uitnodiging voor in het systeem";
                    Message = "Beste student,\n\n" +
                    "Met deze mail vragen wij vriendelijk om je gegevens in te vullen in dit web formulier\n" +
                    "%webkey%\n\n\n" +
                    "Met vriendelijke groeten,\n" +
                    "Katinka Janssen\n" +
                    "Stagecoördinator AI&I\n" +
                    "Avans Hogeschool 's-Hertogenbosch";
                    break;
                case mailType.docent:
                    Error = "%webkey%";
                    Subject = "Uitnodiging voor in het systeem";
                    Message = "Beste docent,\n\n" +
                    "Met deze mail vragen wij vriendelijk om je gegevens in te vullen in dit web formulier\n" +
                    "%webkey%\n\n\n" +
                    "Met vriendelijke groeten,\n" +
                    "Katinka Janssen\n" +
                    "Stagecoördinator AI&I\n" +
                    "Avans Hogeschool 's-Hertogenbosch";
                    break;
            }
        }

        public MailViewModel(MainViewModel main, PropertyChanged last, List<String> emails, mailType optie)
            : this(main, last, optie)
        {
            if (emails != null)
            {
                for (int i = 0; i < emails.Count; i++)
                {
                    To += emails[i] + " ";
                }
            }
        }

        public void Send()
        {
            char[] c = { ',', ';', ' ', ':' };
            String[] to = To.Split(c);
            for (int i = 0; i < to.Length; i++)
            {
                switch (type)
                {
                    case mailType.beoordeling:
                        Mailer.SendBeoordeling(to[i].Trim(), Message, Subject, StageData,  new ListDictionary());
                        break;
                    case mailType.student:
                        Mailer.SendNew(to[i].Trim(), Message, Subject, "student", new ListDictionary());
                        break;
                    case mailType.docent:
                        Mailer.SendNew(to[i].Trim(), Message, Subject, "docent", new ListDictionary());
                        break;
                }
            }

            MessageBoxResult result = MessageBox.Show("Verstuurd!", "Confirmation");
        }

        public override void update(object[] o)
        {
            try
            {
                To="";
                List<String> emails = (List<String>)o[2];
                for (int i = 0; i < emails.Count; i++)
                {
                    To += emails[i] + " ";
                }
                type = (mailType)o[3];
                SetMessage();
            }
            catch (Exception)
            {
            }
        }
    }
}
