using System.Linq;
using ETL.Model;
using HtmlAgilityPack;

namespace ETL.Helpers
{
    public class CommentsMapper
    {
        public Comment MapFromHTMLNode(HtmlNode node)
        {
            var commentBuilder = new CommentBuilder();

            var rowNode = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("comment"));

            var userNodeOuter = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("only400"));
            var userNodeIner = userNodeOuter.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("display:inline-block;vertical-align:top;margin-left:10px;"));
            var user = userNodeIner.FirstChild.InnerHtml;

            var text = rowNode.InnerHtml.ToString();
            var startIndex = text.IndexOf("</div>");
            var endIndex = text.IndexOf("<div style='text-align:right;");
            var date = rowNode.FirstChild.InnerHtml;
            var rateNode = rowNode.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("text-align:right;"));
            string comment;

            if (endIndex != -1)
            { 
                //normal user
                comment = text.Substring(startIndex + 6, endIndex);
                var rating = rateNode.Descendants("div").FirstOrDefault().Descendants("font").FirstOrDefault().InnerText;
                return commentBuilder
                   .WithUsername(user)
                   .WithRating(int.Parse(rating))
                   .WithDate(date)
                   .WithOpinion(comment)
                   .Create();
            }

            else
            {
                //guest
                comment = text.Substring(startIndex + 6);
                return commentBuilder
                   .WithUsername(user)
                   .WithDate(date)
                   .WithOpinion(comment)
                   .Create();
            }

        }
    }
}
