using System;
using System.Linq;
using System.Net.Http;

namespace ETL
{
    class Program
    {    
        static void Main(string[] args)
        {
            var m = new BeerRankingWebsiteCrawler();
            m.startCrawlerAsync().Wait();
            Console.WriteLine(m.beerList.Count());
            Console.Read();
        }


    }
}
