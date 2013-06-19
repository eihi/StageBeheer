using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    interface IWrapper
    {
        void save(Object o);
        void add(Object o);
        void delete(Object o);
    }
}
