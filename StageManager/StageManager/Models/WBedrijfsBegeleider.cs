using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    public class WBedrijfsBegeleider :Wrapper, ISetEntity<bedrijfsbegeleidersets>
    {
        public string Functie
        {
            get
            {
                return getSet().Functie;
            }
            set
            {
                getSet().Functie = value;
                save(getSet());
            }
        }
        public string Opleidingsniveau
        {
            get
            {
                return getSet().Opleidingsniveau;
            }
            set
            {
                getSet().Opleidingsniveau = value;
                save(getSet());
            }
        }
        public bool? Minimale_begeleidingstijd_gegarandeerd
        {
            get
            {
                return getSet().Minimale_begeleidingstijd_gegarandeerd;
            }
            set
            {
                getSet().Minimale_begeleidingstijd_gegarandeerd = value;
                save(getSet());
            }
        }
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

        public virtual WBedrijf bedrijfset
        {
            get
            {
                if (getSet().bedrijfsets == null)
                {
                    return null;
                }
                return new WBedrijf(getSet().bedrijfsets);
            }
            set
            {
                getSet().bedrijfsets = value.getSet();
                save(getSet());
            }
        }

        public WBedrijfsBegeleider(bedrijfsbegeleidersets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public bedrijfsbegeleidersets getSet()
        {
            return set;
        }

        public bedrijfsbegeleidersets set { get; set; }
    }
}
