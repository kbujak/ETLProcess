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
        }

        internal async
        Task ExtractComments()
        {
            commentWebsiteCrawler.beerList = Beers;
            await commentWebsiteCrawler.startCrawlerAsync();
            this.CommentResult = commentWebsiteCrawler.GetCommentResults();
        }

        //transform data to objects 
        internal async Task Transform()
        {
            foreach (var beer in Beers)
            {
                beer.BeerHash = HashGenerator.GetEncodedHash(beer.Name);
            }

            foreach (var userComment in CommentResult.UserComments)
            {
                userComment.UserId = HashGenerator.GetEncodedHash(userComment.Username +  userComment.Date);
            }

            foreach (var guestComment in CommentResult.GuestComments)
            {
                guestComment.GuestId = HashGenerator.GetEncodedHash(guestComment.Date);
            }


        }

        //save data to DB
        internal bool Load()
        {
            DatabaseHelper.saveBeersToDB(getAllBeers());
            DatabaseHelper.saveCommentsToDatabase(GetCommentResult());
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
