using StageManager.Exceptions;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    public class WAdres : Wrapper, ISetEntity<adressets>
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

        public String Plaats
        {
            get
            {
                return getSet().Plaats;
            }
            set
            {
                getSet().Plaats = value;
                save(getSet());
            }
        }

        public String Straat
        {
            get
            {
                return getSet().Straat;
            }
            set
            {
                getSet().Straat = value;
                save(getSet());
            }
        }
        
        public String Huisnummer
        {
            get
            {
                return getSet().Huisnummer;
            }
            set
            {
                getSet().Huisnummer = value;
                save(getSet());
            }
        }
        
        public String Postcode
        {
            get
            {
                return getSet().Postcode;
            }
            set
            {
                getSet().Postcode = value;
                save(getSet());
            }
        }      
        

        public WAdres(adressets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name + " is NULL");
            }
            this.set = set;
        }

        public adressets getSet()
        {
            return set;
        }

        public adressets set { get; set; }
    }
}