using System;
using System.Text.RegularExpressions;
using ETL.Model;

namespace ETL.Helpers
{
    public class BeerBuilder
    {
        private readonly Beer beer;

        public BeerBuilder()
        {
            beer = new Beer();
        }

        public BeerBuilder WithName(string name)
        {
            beer.Name = name;
            return this;
        }

        public BeerBuilder WithType(string type)
        {
            beer.Type = type;
            return this;
        }

        public BeerBuilder WithPercentages(string percentagesString)
        {
            beer.Percentages = Convert.ToInt32(Regex.Match(percentagesString, @"\d+").Value);
            return this;
        }

        public BeerBuilder WithBlg(string blgString)
        {
            beer.Blg = Convert.ToInt32(Regex.Match(blgString, @"\d+").Value);
            return this;
        }

        public BeerBuilder WithCountry(string country)
        {
            beer.Country = country;
            return this;
        }

        public BeerBuilder WithRating(string ratingString)
        {
            beer.Rating = Convert.ToDouble(Regex.Match(ratingString, @"\d+").Value);
            return this;
        }

        public BeerBuilder WithUrl(string urlString)
        {
            beer.Url = urlString;
            return this;
        }

        public Beer Create()
        {
            return beer;
        }
    }
}
