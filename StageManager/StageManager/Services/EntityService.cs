using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class EntityService : IService
    {
        private readonly IFactory factory;
        private readonly stagemanagerEntities entities;

        public EntityService(
            IFactory factory,
            stagemanagerEntities entities)
        {
            this.factory = factory;
            this.entities = entities;
        }
        public IEnumerable<students> Studenten
        {
            get { return entities.students; }
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
            get { return entities.teachers; }
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
            get { return entities.companies; }
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
            get { return entities.supervisor; }
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
