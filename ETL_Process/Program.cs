using ETL;
using ETL.Helpers;
using ETL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETL_Process
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ETLUserForm());


         /*
     var m = new BeerRankingWebsiteCrawler();
     m.startCrawlerAsync().Wait();
     Console.WriteLine(m.beerList.Count());
     */
     /*
            IList<Beer> beers = new List<Beer>();
            var beerBuilder = new BeerBuilder();
            beers.Add(beerBuilder
                .WithUrl("https://ocen-piwo.pl/pinta-imperator-baltycki-sherry-oloroso-barrel-aged-s1-n7239")
                .Create());


            var c = new CommentsWebsiteCrawler(beers);
            c.startCrawlerAsync().Wait();
            Console.WriteLine(c.GetCommentResults().GuestComments.Count);*/






            Console.Read();
        }
    }
}
