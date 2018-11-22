using System.Linq;
using ETL.Model;
using HtmlAgilityPack;

namespace ETL.Helpers
{
    public class UserCommentMapper: CommentsMapper
    {

        private bool IsGuestUser(string username)
        {
            return username == "Gość";
        }


        private string ParseUserOpinion(HtmlNode node)
        {
            var rowNode = GetRowNode(node);
            var text = rowNode.InnerHtml.ToString();
            var startIndex = text.IndexOf("</div>");
            var endIndex = text.IndexOf("<div style='text-align:right;");
            var rateNode = rowNode.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("text-align:right;"));
            return text.Substring(startIndex + 6, endIndex);
        }

        private string ParseUserRating(HtmlNode node)
        {
            var rateNode = GetRowNode(node).Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("text-align:right;"));
            return rateNode.Descendants("div").FirstOrDefault().Descendants("font").FirstOrDefault().InnerText;
        }

        private string ParseUserName(HtmlNode node)
        {
            var userNodeOuter = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("only400"));
            var userNodeIner = userNodeOuter.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("style", "").Equals("display:inline-block;vertical-align:top;margin-left:10px;"));
            return userNodeIner.FirstChild.InnerHtml;
        }



        public UserComment MapFromHTMLNode(HtmlNode node)
        {
            var commentBuilder = new UserCommentBuilder();

            var user = ParseUserName(node);
            var date = ParseCommentDate(node);
            var opinion = ParseUserOpinion(node);
            var rating = ParseUserRating(node);

            return commentBuilder
                .WithUsername(user)
                .WithRating(int.Parse(rating))
                .WithDate(date)
                .WithOpinion(opinion)
                .Create();
           

        }
    }
}
