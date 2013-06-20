using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class DistanceCalculator
    {

        public DistanceCalculator()
        {
        }

        /*
         *Voer de postcode strings in, deze worden naar een website gestuurd en daar word de afstand berekend in kilometers.
         *syntax: 1342AA aan elkaar
         *Returnt een double met de kilometer waarde.
         */
        public double getDistance(string p1, string p2)
        {
            //TODO : error handling bij error returnt die nu null
            using (WebClient client = new WebClient())
            {
                string first = p1;
                string second = p2;
                String downloadedString = client.DownloadString("http://www.geenenict.nl/afstand.php?zip1=" + first + "&zip2=" + second);
                System.Diagnostics.Debug.WriteLine(downloadedString);
                double value;
                double.TryParse(downloadedString, out value);
                return value;

            }
        }

    }
}
