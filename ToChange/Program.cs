using System;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using ETL.Model;

namespace ETL.Helpers
{
    class Program
    {    
        static void Main(string[] args)
        {
            /*
            var m = new BeerRankingWebsiteCrawler();
            m.startCrawlerAsync().Wait();
            Console.WriteLine(m.beerList.Count());
            */

            IList<Beer> beers = new List<Beer>();
            var beerBuilder = new BeerBuilder();
            beers.Add(beerBuilder
                .WithUrl("https://ocen-piwo.pl/pinta-imperator-baltycki-sherry-oloroso-barrel-aged-s1-n7239")
                .Create());


            var c = new CommentsWebsiteCrawler(beers);
            c.startCrawlerAsync().Wait();
            Console.WriteLine(c.comments.Count());


            Console.Read();
        }


    }
}
