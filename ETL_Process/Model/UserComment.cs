using System;

namespace ETL.Model
{
    public class UserComment
    {
        public string Username { get; set; }

        public int? Rating { get; set; }

        public string Date { get; set; }

        public string Opinion { get; set; }

        public string BeerHash { get; set; }

    }
}
