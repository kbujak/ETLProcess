using System;
using System.Text.RegularExpressions;
using ETL.Model;

namespace ETL.Helpers
{
    public class GuestCommentBuilder
    {
        private readonly GuestComment comment;

        public GuestCommentBuilder()
        {
            comment = new GuestComment();
        }

        public GuestCommentBuilder WithOpinion(string opinion)
        {
            comment.Opinion = opinion;
            return this;
        }

        public GuestCommentBuilder WithDate(string date)
        {
            comment.Date = date;
            return this;
        }        

        public GuestComment Create()
        {
            return comment;
        }
    }
}
