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
        public students CreateStudent()
        {
            return new students
            {
                // Naam = naam,
                // Opleiding = opleiding
            };
        }
        public teachers CreateDocent()
        {
            return new teachers
            {
                // Naam = naam,
                // Opleiding = opleiding
            };
        }
    }
}
