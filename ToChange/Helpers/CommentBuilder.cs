using System;
using System.Text.RegularExpressions;
using ETL.Model;

namespace ETL.Helpers
{
    public class CommentBuilder
    {
        private readonly Comment comment;

        public CommentBuilder()
        {
            comment = new Comment();
        }

        public CommentBuilder WithOpinion(string opinion)
        {
            comment.Opinion = opinion;
            return this;
        }

        public CommentBuilder WithDate(string date)
        {
            comment.Date = date;
            return this;
        }

        public CommentBuilder WithRating(int rating)
        {
            comment.Rating = rating;
            return this;
        }

       
        public CommentBuilder WithUsername(string username)
        {
            comment.Username = username;
            return this;
        }
        

        public Comment Create()
        {
            return comment;
        }
    }
}
