using StageManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StageManager.Services
{
    public class Mailer
    {
        private static LinkedList<MailMessage> mails;
        private static WStored stored;
        private static SmtpClient smtp = new SmtpClient();
        private static bool _init;
        private static bool isSending;

        public static bool IsSending
        {
            get { return Mailer.isSending; }
            set { Mailer.isSending = value; }
        }

        private static void init()
        {
            if (!_init)
            {
                mails = new LinkedList<MailMessage>();
                smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.SendCompleted += next;
                smtp.Credentials = new NetworkCredential("stagemanager.min08sog@gmail.com", "stagemanager");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                stored = new WStored();

                smtp.EnableSsl = true;
                isSending = false;
                _init = true;
            }
        }

        private static void next(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (mails.Count > 0)
                {
                    smtp.SendAsync(mails.Last.Value, null);
                    isSending = true;
                    mails.RemoveLast();
                }
                else
                {
                    isSending = false;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public static void Send(String to, String body, String Subject, IDictionary replacements = null)
        {
            init();
            char[] c = { ',', ';', ':' };
            String[] To = to.Split(c);
            for (int i = 0; i < To.Length; i++)
            {
                MailDefinition m = new MailDefinition();
                if (!replacements.Contains("\n"))
                {
                    replacements.Add("\n", "<br/>");
                }
                m.IsBodyHtml = true;
                m.Subject = Subject;
                m.From = "min08.stagemanager@gmail.com";
                try
                {
                    mails.AddLast(m.CreateMailMessage(To[i], replacements, body, new System.Web.UI.Control()));
                }
                catch (Exception)//TODO
                { };
            }
            if (!isSending)
            {
                next(null, null);
            }
        }

        public static void SendNew(String to, String body, String Subject, String hetType, IDictionary replacements = null)
        {
            init();
            if (replacements.Contains("%webkey%"))
            {
                replacements.Remove("%webkey%");
            }

            // Webkey aanmaken
            String key;
            key = stored.NewWebkey(to);

            // In database is het leraar, in de webview docent (freakytime aanpassing)
            String webkeyType = "student";
            if (hetType.Equals("docent"))
            {
                webkeyType = "leraar";
            }

            webkeys webkey = new webkeys() { webkey = key, type = webkeyType, email = to };

            // Webkey opslaan in database
            WStored.StageManagerEntities.webkeys.Add(webkey);
            WStored.PushToDB();

            // construct URL
            key = "http://stagemanager.modupro.nl/" + hetType + "/" + webkey.webkey;
            replacements.Add("%webkey%", "<a href='" + key + "'>" + key + "</a>");

            // Send
            Send(to, body, Subject, replacements);
        }

        public static void SendBeoordeling(String to, String body, String Subject, IDictionary replacements = null)
        {
            init();
            Send(to, body, Subject, replacements);
        }
    }
}