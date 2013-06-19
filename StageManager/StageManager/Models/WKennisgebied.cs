using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageManager.Models
{
    public class WKennisgebied : Wrapper, ISetEntity<kennisgebiedset>
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

        public virtual List<WDocent> docentsets {
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
        
        public virtual List<WStage> stagesets {
            get
            {
                List<WStage> oplSet = new List<WStage>();
                for (int i = 0; i < getSet().stagesets.Count; i++)
                {
                    oplSet.Add(new WStage(getSet().stagesets.ElementAt(i)));
                }
                return oplSet;
            }
            set
            {
                List<stagesets> list = new List<stagesets>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().stagesets = list;
                save(getSet());
            }
}

        public WKennisgebied(kennisgebiedset set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public kennisgebiedset getSet()
        {
            return set;
        }

        public kennisgebiedset set { get; set; }
    }
}
