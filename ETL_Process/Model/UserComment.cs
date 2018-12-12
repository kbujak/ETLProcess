using System;

namespace ETL.Model
{
    public class UserComment
    {
        public Int32 UserId { get; set; }

        public string Username { get; set; }

        public int? Rating { get; set; }

        public string Date { get; set; }

        public string Opinion { get; set; }

        public Int32 BeerHash { get; set; }

    }
}
