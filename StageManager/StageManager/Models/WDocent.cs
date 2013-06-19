using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Services;
using StageManager.Exceptions;

namespace StageManager.Models
{
    public class WDocent : WPersoon, ISetEntity<docentsets>
    {
        public int Leraar_Id
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
        public Double? DBU1
        {
            get
            {
                return getSet().DBU1;
            }
            set
            {
                getSet().DBU1 = value;
                save(getSet());
            }
        }
        public Double? DBU2
        {
            get
            {
                return getSet().DBU2;
            }
            set
            {
                getSet().DBU2 = value;
                save(getSet());
            }
        }
        public Double? DBU3
        {
            get
            {
                return getSet().DBU3;
            }
            set
            {
                getSet().DBU3 = value;
                save(getSet());
            }
        }
        public Double? DBU4
        {
            get
            {
                return getSet().DBU4;
            }
            set
            {
                getSet().DBU4 = value;
                save(getSet());
            }
        }

        public int algemeensetId
        {
            get
            {
                return getSet().algemeensetId;
            }
            set
            {
                getSet().algemeensetId = value;
                save(getSet());
            }
        }
        public int webkeysets_Id
        {
            get
            {
                return getSet().webkeysets_Id;
            }
            set
            {
                getSet().webkeysets_Id = value;
                save(getSet());
            }
        }
        public new int Id
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


        public virtual WAlgemeen algemeenset
        {
            get
            {
                if (getSet().algemeensets == null)
                {
                    return null;
                }
                return new WAlgemeen(getSet().algemeensets);
            }
            set
            {
                getSet().algemeensets = value.getSet();
                save(getSet());
            }
        }
        public virtual WPersoon persoonset
        {
            get
            {
                if (getSet().persoonsets == null)
                {
                    return null;
                }
                return new WPersoon(getSet().persoonsets);
            }
            set
            {
                getSet().persoonsets = value.getSet();
                save(getSet());
            }
        }

        public Double? Rest()
        {
            Double werkuren;
            Double.TryParse(algemeenset.Werk_Uren, out werkuren);

           int stageCount = (from stage in StageManagerEntities.stagesets.ToList()
                             where stage.docentsets != null && stage.docentsets.Id == this.Leraar_Id
                              select new WStage(stage)).ToList().Count;

            return DBU1 * (werkuren / 4) + DBU2 * (werkuren / 4) - (stageCount*16);
        }



        public virtual WAdres adressets
        {
            get
            {
                if (getSet().adressets == null)
                {
                    return null;
                }
                return new WAdres(getSet().adressets);
            }
            set
            {
                getSet().adressets = value.getSet();
                save(getSet());
            }
        }
        public virtual WWebkey webkeysets
        {
            get
            {
                if (getSet().webkeysets == null)
                {
                    return null;
                }
                return new WWebkey(getSet().webkeysets);
            }
            set
            {
                getSet().webkeysets = value.getSet();
                save(getSet());
            }
        }
    public virtual List<WOpleiding> Opleidingset
        {
            get
            {
                List<WOpleiding> oplSet = new List<WOpleiding>();
                for (int i = 0; i < getSet().opleidingsets.Count; i++)
                {
                    oplSet.Add(new WOpleiding(getSet().opleidingsets.ElementAt(i)));
                }
                return oplSet;
            }
            set
            {
                List<opleidingsets> list = new List<opleidingsets>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().opleidingsets = list;
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

        public WDocent(docentsets set)
            : base(set.persoonsets)
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public new docentsets getSet()
        {
            return set;
        }

        public new docentsets set { get; set; }
    }
}