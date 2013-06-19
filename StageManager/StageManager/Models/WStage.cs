using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    public class WStage : Wrapper, ISetEntity<stagesets>
    {
        public int Stage_Id
        {
            get
            {
                return getSet().Stage_Id;
            }
            set
            {
                getSet().Stage_Id = value;
                save(getSet());
            }
        }
        
        public System.DateTime? Start_datum
        {
            get
            {
                return getSet().Start_datum;
            }
            set
            {
                getSet().Start_datum = value;
                save(getSet());
            }
        }
        
        public System.DateTime? Eind_datum
        {
            get
            {
                return getSet().Eind_datum;
            }
            set
            {
                getSet().Eind_datum = value;
                save(getSet());
            }
        }
        
        public string Stageopdracht_omschijving
        {
            get
            {
                return getSet().Stageopdracht_omschijving;
            }
            set
            {
                getSet().Stageopdracht_omschijving = value;
                save(getSet());
            }
        }

        public int? studentset1_Id
        {
            get
            {
                return getSet().Student1;
            }
            set
            {
                getSet().Student1 = value;
                save(getSet());
            }
        }
        public int? studentset2_Id
        {
            get
            {
                return getSet().Student2;
            }
            set
            {
                getSet().Student2 = value;
                save(getSet());
            }
        }

        public virtual WDocent docentsets
        {
            get
            {
                if(getSet().docentsets==null)
                {
                    return null;
                }
                return new WDocent(getSet().docentsets);
            }
            set
            {
                getSet().docentsets = value.getSet();
                save(getSet());
            }
        }
        
        public virtual WStudent studentset
        {
            get
            {
                if (getSet().studentsets == null)
                {
                    return null;
                }
                return new WStudent(getSet().studentsets);
            }
            set
            {
                getSet().studentsets = value.getSet();
                save(getSet());
            }
        }

        public virtual WStudent studentset2
        {   
            get
            {
                if (getSet().studentsets1 == null)
                {
                    return null;
                }
                return new WStudent(getSet().studentsets1);
            }
            set
            {
                getSet().studentsets1 = value.getSet();
                save(getSet());
            }
        }

        
        public virtual List<WKennisgebied> tool_vaardigheidset
        {
            get
            {
                List<WKennisgebied> oplSet = new List<WKennisgebied>();
                for (int i = 0; i < getSet().kennisgebiedset.Count; i++)
                {
                    oplSet.Add(new WKennisgebied(getSet().kennisgebiedset.ElementAt(i)));
                }
                return oplSet;
            }
            set
            {
                List<kennisgebiedset> list = new List<kennisgebiedset>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().kennisgebiedset = list;
                save(getSet());
            }
        }
        
        public virtual WBedrijfsBegeleider bedrijfsbegeleiderset
        {
            get
            {
                if (getSet().bedrijfsbegeleidersets == null)
                {
                    return null;
                }
                return new WBedrijfsBegeleider(getSet().bedrijfsbegeleidersets);
            }
            set
            {
                getSet().bedrijfsbegeleidersets = value.getSet();
                save(getSet());
            }
        }

        public WStage(stagesets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public stagesets getSet()
        {
            return set;
        }

        public stagesets set { get; set; }
    }
}