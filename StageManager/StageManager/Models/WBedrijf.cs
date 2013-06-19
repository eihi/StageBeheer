using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    public class WBedrijf : Wrapper, ISetEntity<bedrijfsets>
    {
        public int Id
        {
            get
            {
                return getSet().Bedrijfs_Id;
            }
            set
            {
                getSet().Bedrijfs_Id = value;
                save(getSet());
            }
        }

        public String Naam
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

        public String TelefoonNummer
        {
            get
            {
                return getSet().Telefoonnummer;
            }
            set{
                getSet().Telefoonnummer = value;
                save(getSet());
            }
        }

        public String Website
        {
            get
            {
                return getSet().Website;
            }
            set
            {
                getSet().Website = value;
                save(getSet());
            }
        }

        public WAdres AdresSets
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

        public List<WBedrijfsBegeleider> Bedrijfsbegeleidersets
        {
            get
            {
                List<WBedrijfsBegeleider> list = new List<WBedrijfsBegeleider>();
                for (int i = 0; i < getSet().bedrijfsbegeleidersets.Count; i++)
                {
                    list.Add(new WBedrijfsBegeleider(getSet().bedrijfsbegeleidersets.ElementAt(i)));
                }
                return list;
            }
            set
            {
                List<bedrijfsbegeleidersets> list = new List<bedrijfsbegeleidersets>();
                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i].getSet());
                }
                getSet().bedrijfsbegeleidersets = list;
                save(getSet());
            }
        }

        public WBedrijf(bedrijfsets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public bedrijfsets getSet()
        {
            return set;
        }

        public bedrijfsets set { get; set; }
    }
}
