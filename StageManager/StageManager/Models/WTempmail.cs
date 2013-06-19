using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    class WTempmail:Wrapper, ISetEntity<tempemailsets>
    {
        public string Email
        {
            get
            {
                return set.Email;
            }
            set
            {
                set.Email = value;
                save(set);
            }
        }

        public Nullable<int> Web_id
        {
            get
            {
                return set.Web_id;
            }
            set
            {
                set.Web_id = value;
                save(set);
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
                return new WWebkey(set.webkeysets);
            }
            set
            {
                set.webkeysets = value.getSet();
                save(set);
            }
        }

        public WTempmail(tempemailsets set)
        {
            this.set = set;
        }

        public tempemailsets getSet()
        {
            return set;
        }

        private tempemailsets set { get; set; }
    }
}
