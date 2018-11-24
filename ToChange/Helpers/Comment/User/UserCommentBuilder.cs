using System;
using System.Text.RegularExpressions;
using ETL.Model;

namespace ETL.Helpers
{
    public class UserCommentBuilder
    {
        private readonly UserComment comment;

        public UserCommentBuilder()
        {
            comment = new UserComment();
        }

        public UserCommentBuilder WithOpinion(string opinion)
        {
            comment.Opinion = opinion;
            return this;
        }

        public UserCommentBuilder WithDate(string date)
        {
            comment.Date = date;
            return this;
        }

        public UserCommentBuilder WithRating(int rating)
        {
            comment.Rating = rating;
            return this;
        }

       
        public UserCommentBuilder WithUsername(string username)
        {
            comment.Username = username;
            return this;
        }
        

        public UserComment Create()
        {
            return comment;
        }
    }
}
