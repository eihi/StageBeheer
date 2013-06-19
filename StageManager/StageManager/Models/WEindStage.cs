using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Models
{
    class WEindStage : WStage, ISetEntity<eindstagesets>
    {
        public WDocent TweedeLezer
        {
            get
            {
                if (getSet().TweedeLezer == null)
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

        public WEindStage(eindstagesets set)
            : base(set.stagesets)
        {
            Set = set;
        }

        public new eindstagesets getSet()
        {
            return Set;
        }

        public eindstagesets Set { get; set; }
    }
}
