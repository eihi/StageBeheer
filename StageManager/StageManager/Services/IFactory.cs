using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;

namespace StageManager.Services
{
    public interface IFactory
    {
        studentsets CreateStudent();

        docentsets CreateDocent();
    }
}
