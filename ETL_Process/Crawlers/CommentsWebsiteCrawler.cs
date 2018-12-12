using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ETL.Helpers;
using ETL.Model;
using System.Data.SqlClient;

namespace ETL
{
    public class CommentsWebsiteCrawler
    {
        public CommentsWebsiteCrawler()
        {
        }

        public CommentsWebsiteCrawler(IList<Beer> beerList)
        {
            this.beerList = beerList;
        }

        private const string urlString = "https://ocen-piwo.pl/";
        private IList<GuestComment> guestComments = new List<GuestComment>();
        private IList<UserComment> userComments = new List<UserComment>();
        private IList<HtmlNode> nodes = null;
        public IList<Beer> beerList { get; set; }

        public async Task startCrawlerAsync()
        {
            foreach (var beer in beerList)
            {
                String url = urlString + beer.Url;
                await GetComments(url, beer.BeerHash);
            }
        }

        public CommentResult GetCommentResults()
        {
            return new CommentResult(guestComments, userComments);
        }

        public int GetCommentsCount()
        {
            return guestComments.Count() + userComments.Count();
        }

        private bool IsComment(HtmlNode node)
        {
            return node.FirstChild.HasChildNodes && node.FirstChild.FirstChild.Name.Equals("img");
        }

        private bool IsGuestComment(HtmlNode node)
        {
            var userNodeOuter = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("only400"));
            var userNodeIner = userNodeOuter.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("display:inline-block;vertical-align:top;margin-left:10px;"));
            var username = userNodeIner.FirstChild.InnerHtml;
            return username == "Gość";
        }

        private List<HtmlNode> GetCommentNodes(HtmlDocument htmlDocument)
        {
            return htmlDocument.GetElementbyId("komentarze_lista")
               .Descendants("table").FirstOrDefault()
               .Descendants("tr").ToList();
        }

        private async Task GetComments(string url, Int32 beerHash)
        {
            var httpClient = new HttpClient();
            var htmlDocument = new HtmlDocument();
            var html = await httpClient.GetStringAsync(url);
            htmlDocument.LoadHtml(html);
            this.nodes = GetCommentNodes(htmlDocument);

            var guestCommentMapper = new GuestCommentMapper();
            var userCommentMapper = new UserCommentMapper();

            foreach (var node in nodes)
            {
               
                if (IsComment(node))
                {
                    if (IsGuestComment(node))
                    {

                        var guestComment = guestCommentMapper.MapFromHTMLNode(node);
                        guestComment.BeerHash = beerHash;
                        guestComments.Add(guestComment);
                    }

                    else
                    {
                        var userComment = userCommentMapper.MapFromHTMLNode(node);
                        userComment.BeerHash = beerHash;
                        userComments.Add(userComment);

                    }
                }
            }

        }
             
    }
}
