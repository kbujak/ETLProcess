using System;

namespace ETL.Model
{
    public class GuestComment
    { 
        public Int32 GuestId { get; set; }

        public string Date { get; set; }

        public string Opinion { get; set; }

        public Int32 BeerHash { get; set; }
    }    
}
