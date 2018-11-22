using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ETL.Helpers;
using ETL.Model;

namespace ETL
{
    public class CommentsWebsiteCrawler
    {
        public CommentsWebsiteCrawler(IList<Beer> beerList)
        {
            this.beerList = beerList;
        }


        private const string urlString = "https://ocen-piwo.pl/";
        private const int beersNumber = 10;
        private IReadOnlyList<string> urls;
        public IList<Beer> beerList;
        public IList<Comment> comments = new List<Comment>();

        public async Task startCrawlerAsync()
        {

            foreach (var beer in beerList)
            { 
                await GetComments(beer.Url);
            }

        }

        private async Task GetComments(string url)
        {
            var httpClient = new HttpClient();
            var htmlDocument = new HtmlDocument();
            var html = await httpClient.GetStringAsync(url);
            htmlDocument.LoadHtml(html);

            var x = htmlDocument.GetElementbyId("komentarze_lista")
                .Descendants("table").FirstOrDefault();

            var a = htmlDocument.DocumentNode.Descendants("div")
                                .Where(n => n.GetAttributeValue("id", "").Equals("komentarze_lista")).FirstOrDefault();

            var b = x.Descendants("tr").FirstOrDefault();

            var c = x.Descendants("tr").Where(n => n.Descendants().Count() == 2);




            var nodes = htmlDocument.GetElementbyId("komentarze_lista")
                .Descendants("table").FirstOrDefault()
                .Descendants("tr").ToList();

            IList<HtmlNode> goodNodes = new List<HtmlNode>(); 
            var commentsMapper = new CommentsMapper();

            foreach (var node in nodes)
            {
                if (node.FirstChild.HasChildNodes && node.FirstChild.FirstChild.Name.Equals("img"))
                {
                    goodNodes.Add(node);
                }
                
            }


            foreach(var n in goodNodes)
            {
                var co = commentsMapper.MapFromHTMLNode(n);
                comments.Add(co);
            }
         
        }
    }
}
