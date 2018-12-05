using ETL;
using ETL.Helpers;
using ETL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Process.Controler
{
    public class ETLControler
    {
        private BeerRankingWebsiteCrawler beerRankingCrawler;
        private CommentsWebsiteCrawler commentWebsiteCrawler;

        private IList<Beer> Beers { get; set; }

        internal ETLControler()
        {
            this.beerRankingCrawler = new BeerRankingWebsiteCrawler();
            this.commentWebsiteCrawler = new CommentsWebsiteCrawler();
            this.Beers = new List<Beer>();
        }

        //extract raw data
        internal int Extract()
        {
            //IList<Beer> beers = new List<Beer>();
            var beerBuilder = new BeerBuilder();
            Beers.Add(beerBuilder
                .WithUrl("https://ocen-piwo.pl/pinta-imperator-baltycki-sherry-oloroso-barrel-aged-s1-n7239")
                .Create());
            return Beers.Count();
        }

        //transform data to objects 
        internal bool Transform()
        {
            
            return true;
        }

        //save data to DB
        internal bool Load()
        {
            return true;
        }

        //save data to csv file
        internal bool saveDataToCSVFile()
        {
            return true;
        }

        //clear database
        internal bool clearDatabase()
        {
            return true; 
        }

        //( ͡° ͜ʖ ͡°)
        internal IList<Beer> getAllBeers()  
        {
            return Beers;
        }
    }
}
