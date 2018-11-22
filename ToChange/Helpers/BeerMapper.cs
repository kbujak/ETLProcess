using System.Linq;
using ETL.Model;
using HtmlAgilityPack;

namespace ETL.Helpers
{
    public class BeerMapper
    {
        public Beer MapFromHTMLNode(HtmlNode node)
        {
            var beerBuilder = new BeerBuilder();
            var tagDivs = node.Descendants("div")
                                .Where(n => n.GetAttributeValue("class", "").Equals("tag"))
                                .ToList();
            var ratingDiv = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("news_com"));
            

            return beerBuilder.WithName(node.Descendants("a").FirstOrDefault().InnerText)
                       .WithType(tagDivs.SingleOrDefault(d => d.GetAttributeValue("style", "").Contains("pliki/styleIcon.png"))?.ChildNodes.FirstOrDefault()?.InnerText)
                       //.WithPercentages(tagDivs.SingleOrDefault(d => d.GetAttributeValue("style", "").Contains("padding:6px;padding-top:7px;"))?.InnerText)
                       //.WithBlg(tagDivs.SingleOrDefault(d => d.ChildNodes.FirstOrDefault().InnerText == "Blg")?.InnerText)
                       .WithCountry(tagDivs.SingleOrDefault(d => d.GetAttributeValue("style", "").Contains("pliki/world.png"))?.ChildNodes.FirstOrDefault().InnerText)
                       .WithRating(ratingDiv.Descendants("font").FirstOrDefault()?.InnerText)
                       .WithUrl(ratingDiv.Descendants("a").FirstOrDefault()?.Attributes["href"].Value)
                       .Create();                      
        }
    }
}
