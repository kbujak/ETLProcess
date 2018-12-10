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
        public CommentsWebsiteCrawler()
        {
        }

        public CommentsWebsiteCrawler(IList<Beer> beerList)
        {
            this.beerList = beerList;
        }


        private const string urlString = "https://ocen-piwo.pl/";
        private IList<Beer> beerList;
        private IList<GuestComment> guestComments = new List<GuestComment>();
        private IList<UserComment> userComments = new List<UserComment>();

        public async Task startCrawlerAsync()
        {
            foreach (var beer in beerList)
            {
                String url = urlString + beer.Url;
                await GetComments(url);
            }
        }

        public CommentResult GetCommentResults()
        {
            return new CommentResult(guestComments, userComments);
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

        private async Task GetComments(string url)
        {
            var httpClient = new HttpClient();
            var htmlDocument = new HtmlDocument();
            var html = await httpClient.GetStringAsync(url);
            htmlDocument.LoadHtml(html);

            var guestCommentMapper = new GuestCommentMapper();
            var userCommentMapper = new UserCommentMapper();

            var nodes = GetCommentNodes(htmlDocument);

            foreach (var node in nodes)
            {
               
                if (IsComment(node))
                {
                    if (IsGuestComment(node))
                    {

                        var guestComment = guestCommentMapper.MapFromHTMLNode(node);
                        guestComments.Add(guestComment);
                    }

                    else
                    {
                        var userComment = userCommentMapper.MapFromHTMLNode(node);
                        userComments.Add(userComment);

                    }
                }
                
            }
         
        }

    }
}
