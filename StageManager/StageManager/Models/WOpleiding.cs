using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageManager.Models
{
     public class WOpleiding : Wrapper, ISetEntity<opleidingsets>
    {
        public int Id
        {
            get
            {
                return getSet().Id;
            }
            set
            {
                getSet().Id = value;
                save(getSet());
            }
        }

        public string Naam
        {
            get
            {
                return getSet().Naam;
            }
            set
            {
                getSet().Naam = value;
                save(getSet());
            }
        }

        public int acedemieId
        {
            get
            {
                return getSet().acedemieId;
            }
            set
            {
                getSet().acedemieId = value;
                save(getSet());
            }
        }

        public virtual WAcademie acedemieset
        {
            get
            {
                if (getSet().academiesets == null)
                {
                    return null;
                }
                return new WAcademie(getSet().academiesets);
            }
            set
            {
                getSet().academiesets = value.getSet();
                save(getSet());
            }
        }
        
        public virtual List<WStudent> studentsets
        {
            get
            {
                List<WStudent> oplSet = new List<WStudent>();
                for (int i = 0; i < getSet().studentsets.Count; i++)
                {
                    oplSet.Add(new WStudent(getSet().studentsets.ElementAt(i)));
                }
                return oplSet;
            }
            set
            {
                List<studentsets> list = new List<studentsets>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().studentsets = list;
                save(getSet());
            }
        }
        
        public virtual List<WDocent> docentsets
        {
            get
            {
                List<WDocent> oplSet = new List<WDocent>();
                for (int i = 0; i < getSet().docentsets.Count; i++)
                {
                    oplSet.Add(new WDocent(getSet().docentsets.ElementAt(i)));
                }
                return oplSet;
            }
            set
            {
                List<docentsets> list = new List<docentsets>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().docentsets = list;
                save(getSet());
            }
        }

        public WOpleiding(opleidingsets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }


        public opleidingsets getSet()
        {
            return set;
        }

        public opleidingsets set { get; set; }
    }
}