using CsvHelper;
using ETL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETL_Process.Csv
{
    class BeerCsvWriter
    {

        public bool WriteBeersToCsv(IList<Beer> beers)
        {
            WriteToCsvFile(beers, "beers.csv");

            return true;
        }

        public bool WriteGuestCommentsToCsv(IList<GuestComment> guestComments)
        {
            WriteToCsvFile(guestComments, "guestComments.csv");

            return true;
        }

        public bool WriteUserCommentsToCsv(IList<UserComment> userComments)
        {
            WriteToCsvFile(userComments, "userComments.csv");

            return true;
        }

        private bool WriteToCsvFile<T>(IEnumerable<T> objects, String fileName)
        {
            var path = @"./" + fileName;
            using (TextWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.WriteRecords(objects);

            }
            return true;
        }
        
    }
}
