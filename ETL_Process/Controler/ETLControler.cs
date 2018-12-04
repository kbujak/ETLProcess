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

        public ETLControler()
        {
            this.beerRankingCrawler = new BeerRankingWebsiteCrawler();
            this.commentWebsiteCrawler = new CommentsWebsiteCrawler();
        }

        public int Extract()
        {
            IList<Beer> beers = new List<Beer>();
            var beerBuilder = new BeerBuilder();
            beers.Add(beerBuilder
                .WithUrl("https://ocen-piwo.pl/pinta-imperator-baltycki-sherry-oloroso-barrel-aged-s1-n7239")
                .Create());
            return beers.Count();
        }



    }
}
