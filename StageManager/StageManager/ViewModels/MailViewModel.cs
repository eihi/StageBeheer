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
        private String to;
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
                if (message.Contains("%webkey%"))
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

        public MailViewModel(MainViewModel main)
            :base(main)
        {
            To = "";
            Message = "Beste student,\n\n" +
                "Met deze mail vragen wij vriendelijk om je gegevens in te vullen in dit web formulier\n" +
                "%webkey%\n\n\n" +
                "Met vriendelijke groeten,\n" +
                "Katinka Janssen\n" +
                "Stagecoördinator AI&I\n" +
                "Avans Hogeschool 's-Hertogenbosch";
        }

        public MailViewModel(MainViewModel main, List<String> emails)
            :this(main)
        {
            if (emails != null)
            {
                for (int i = 0; i < emails.Count; i++)
                {
                    To += emails[i]+" ";
                }
            }
        }
        public void Send()
        {
            char[] c = { ',', ';', ' ', ':' };
            String[] to = To.Split(c);
            for (int i = 0; i < to.Length; i++)
            {
                Mailer.SendNew(to[i].Trim(), Message, Subject, new ListDictionary());
            }
        }

        public override void update(object[] o)
        {
            try
            {
                To="";
                List<String> emails = (List<String>)o[1];
                for (int i = 0; i < emails.Count; i++)
                {
                    To += emails[i] + " ";
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
