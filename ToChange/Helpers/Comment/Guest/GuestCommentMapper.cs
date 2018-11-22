using System.Linq;
using ETL.Model;
using HtmlAgilityPack;

namespace ETL.Helpers
{
    public class GuestCommentMapper: CommentsMapper
    {

        private bool IsGuestUser(string username)
        {
            return username == "Gość";
        }

        private string ParseGuestOpinion(HtmlNode node)
        {
            string divClosure = "</div>";
            var rowNode = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("comment"));
            var opinion = rowNode.InnerHtml.ToString();
            var startIndex = opinion.IndexOf(divClosure);
        
            return  opinion.Substring(startIndex + divClosure.Length);
        }


        public GuestComment MapFromHTMLNode(HtmlNode node)
        {
            var commentBuilder = new GuestCommentBuilder();
            var date = ParseCommentDate(node);
            var opinion = ParseGuestOpinion(node);

            return commentBuilder
                .WithDate(date)
                .WithOpinion(opinion)
                .Create();
            

        }
    }
}
