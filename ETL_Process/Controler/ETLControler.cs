﻿using ETL;
using ETL.Helpers;
using ETL.Model;
using ETL_Process.Csv;
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
            var m = new CommentsWebsiteCrawler(Beers);
            await m.startCrawlerAsync();
            this.CommentResult = m.GetCommentResults();
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
            beerCsvWriter.WriteBeersToCsv(getAllBeers());
            beerCsvWriter.WriteGuestCommentsToCsv(GetCommentResult().GuestComments);
            beerCsvWriter.WriteUserCommentsToCsv(GetCommentResult().UserComments);

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

        internal CommentResult GetCommentResult()
        {
            return CommentResult;
        }
    }
}
