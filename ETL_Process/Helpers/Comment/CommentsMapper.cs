using System.Linq;
using ETL.Model;
using HtmlAgilityPack;

namespace ETL.Helpers
{
    public abstract class CommentsMapper
    { 

        public virtual HtmlNode GetRowNode(HtmlNode parentNode)
        {
            return parentNode.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("comment"));
        }

        public virtual string ParseCommentDate(HtmlNode node)
        {
            var rowNode = node.Descendants("div").SingleOrDefault(n => n.GetAttributeValue("class", "").Equals("comment"));
            return rowNode.FirstChild.InnerHtml;
        }
        
    }
}
