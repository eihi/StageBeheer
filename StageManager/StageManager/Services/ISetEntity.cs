using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    interface ISetEntity<T> where T: class
    {
        T getSet();
    }
}
