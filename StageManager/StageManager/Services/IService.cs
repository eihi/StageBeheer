using StageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public interface IService
    {
        IEnumerable<studentsets> Studenten { get; }

        IEnumerable<docentsets> Docenten { get; }

        IEnumerable<bedrijfsets> Bedrijven { get; }

        IEnumerable<bedrijfsbegeleidersets> Bedrijfsbegeleiders { get; }

        //void addStudent();

        //void addDocent();

        //void addBedrijf();

        //void addBedrijfsbegeleider();



    }
}
