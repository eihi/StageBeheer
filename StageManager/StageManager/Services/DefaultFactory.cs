using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageManager.Models;

namespace StageManager.Services
{
    class DefaultFactory : IFactory
    {
        public studentsets CreateStudent()
        {
            return new studentsets
            {
                // Naam = naam,
                // Opleiding = opleiding
            };
        }
        public docentsets CreateDocent()
        {
            return new docentsets
            {
                // Naam = naam,
                // Opleiding = opleiding
            };
        }
    }
}
