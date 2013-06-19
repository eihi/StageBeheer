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
        IEnumerable<students> Studenten { get; }

        IEnumerable<teachers> Docenten { get; }

        IEnumerable<companies> Bedrijven { get; }

        IEnumerable<supervisor> Bedrijfsbegeleiders { get; }

        //void addStudent();

        //void addDocent();

        //void addBedrijf();

        //void addBedrijfsbegeleider();



    }
}
