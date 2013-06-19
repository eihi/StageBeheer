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
        private readonly List<studentsets> studenten;
        private readonly List<docentsets> docenten;
        private readonly List<bedrijfsets> bedrijven;
        private readonly List<bedrijfsbegeleidersets> bedrijfsbegeleiders;

        public Service(IFactory factory)
        {
            this.factory = factory;

            this.studenten = new List<studentsets>();
            this.docenten = new List<docentsets>();
            this.bedrijven = new List<bedrijfsets>();
            this.bedrijfsbegeleiders = new List<bedrijfsbegeleidersets>();
        }

        public IEnumerable<studentsets> Studenten
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

        public IEnumerable<docentsets> Docenten
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

        public IEnumerable<bedrijfsets> Bedrijven
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

        public IEnumerable<bedrijfsbegeleidersets> Bedrijfsbegeleiders
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
