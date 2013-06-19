using StageManager.Exceptions;
using StageManager.Services;
using System;

namespace StageManager.Models
{
    public class WPersoon : Wrapper, ISetEntity<persoonsets>
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
        
        public string Email
        {
            get
            {
                return getSet().Email;
            }
            set
            {
                getSet().Email = value;
                save(getSet());
            }
        }
        
        public String Telefoonnummer
        {
            get
            {
                return getSet().Telefoonnummer;
            }
            set
            {
                getSet().Telefoonnummer = value;
                save(getSet());
            }
        }

        public virtual String Voornaam
        {
            get
            {
                return getSet().Voornaam;
            }
            set
            {
                getSet().Voornaam = value;
                save(getSet());
            }
        }

        public virtual String Achternaam
        {
            get
            {
                return getSet().Achternaam;
            }
            set
            {
                getSet().Achternaam = value; 
                save(getSet());
            }
        }

        public WPersoon(persoonsets set)
            : base()
        {
            if (set == null)
            {
                throw new CantBeNullException(set.GetType().Name+ " is NULL");
            }
            this.set = set;
        }

        public persoonsets getSet()
        {
            return set;
        }

        public persoonsets set { get; set; }
    }
}