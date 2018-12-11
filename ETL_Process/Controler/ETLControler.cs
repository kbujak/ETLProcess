using ETL;
using ETL.Helpers;
using ETL.Model;
using ETL_Process.Csv;
using ETL_Process.Helpers.Database;
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
        private BeerCsvWriter beerCsvWriter;

        private IList<Beer> Beers { get; set; }
        private CommentResult CommentResult { get; set; }

        internal ETLControler()
        {
            this.beerRankingCrawler = new BeerRankingWebsiteCrawler();
            this.commentWebsiteCrawler = new CommentsWebsiteCrawler();
            this.beerCsvWriter = new BeerCsvWriter();
            this.Beers = new List<Beer>();
        }

        //extract raw data
        internal async 
        Task ExtractBeers()
        { 
            var m = new BeerRankingWebsiteCrawler();
            await m.startCrawlerAsync();
            this.Beers = m.beerList;
            DatabaseHelper.saveBeersToDB(this.Beers);
        }

        internal async
        Task ExtractComments()
        {
            //something breaks on later beers
            //TO DO fix it xd
            commentWebsiteCrawler.beerList = Beers; //commentWebsiteCrawler.beerList = Beers; - to check if it is working
            await commentWebsiteCrawler.startCrawlerAsync();
            DatabaseHelper.saveCommentsToDatabase(commentWebsiteCrawler.GetCommentResults());
            this.CommentResult = commentWebsiteCrawler.GetCommentResults(); //this should be in transform/loads
        }

        //transform data to objects 
        internal async Task Transform()
        {
            //Console.WriteLine(commentWebsiteCrawler.GetCommentResults().GuestComments.Count); //moved to Load
        }

        //save data to DB
        internal bool Load()
        {
            Console.WriteLine(commentWebsiteCrawler.GetCommentResults().GuestComments.Count); 
            return true;
        }

        //save data to csv file
        internal bool saveDataToCSVFile()
        {
            beerCsvWriter.WriteBeersToCsv(getAllBeers());
            beerCsvWriter.WriteGuestCommentsToCsv(GetCommentResult().GuestComments);
            beerCsvWriter.WriteUserCommentsToCsv(GetCommentResult().UserComments);

            return true;
        }

        //clear database
        internal bool clearDatabase()
        {
            try
            {
                DatabaseHelper.ClearDB();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        //( ͡° ͜ʖ ͡°)
        internal IList<Beer> getAllBeers()  
        {
            return Beers;
        }

        internal CommentResult GetCommentResult()
        {
            return CommentResult;
        }

        internal int GetCommentsCount()
        {
            return commentWebsiteCrawler.GetCommentsCount();
        }
    }
}
