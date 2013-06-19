using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class Service : IService
    {
        private readonly IFactory factory;
        private readonly List<students> studenten;
        private readonly List<teachers> docenten;
        private readonly List<companies> bedrijven;
        private readonly List<supervisor> bedrijfsbegeleiders;

        public Service(IFactory factory)
        {
            this.factory = factory;

            this.studenten = new List<students>();
            this.docenten = new List<teachers>();
            this.bedrijven = new List<companies>();
            this.bedrijfsbegeleiders = new List<supervisor>();
        }

        public IEnumerable<students> Studenten
        {
            get { return studenten; }
        }

        public event EventHandler StudentenChanged;
        protected void OnStudentenChanged()
        {
            var handler = StudentenChanged;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, e);
            }
        }

        public IEnumerable<teachers> Docenten
        {
            get { return docenten; }
        }

        public event EventHandler DocentenChanged;

        protected void OnDocentenChanged()
        {
            var handler = DocentenChanged;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, e);
            }
        }

        public IEnumerable<companies> Bedrijven
        {
            get { return bedrijven; }
        }

        public event EventHandler BedrijvenChanged;

        protected void OnBedrijvenChanged()
        {
            var handler = BedrijvenChanged;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, e);
            }
        }

        public IEnumerable<supervisor> Bedrijfsbegeleiders
        {
            get { return bedrijfsbegeleiders; }
        }

        public event EventHandler BedrijfsbegeleidersChanged;

        protected void OnBedrijfsbegeleidersChanged()
        {
            var handler = BedrijfsbegeleidersChanged;
            if (handler != null)
            {
                var e = EventArgs.Empty;
                handler(this, e);
            }
        }
    }
}
