using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ETL.Helpers;
using ETL.Model;

namespace ETL
{
    public class BeerRankingWebsiteCrawler
    {
        private const string urlString = "https://ocen-piwo.pl/najwyzej-oceniane-piwa-";
        private const int pagesNumber = 10;
        private IReadOnlyList<string> urls;
        public IList<Beer> beerList = new List<Beer>();

        public async Task startCrawlerAsync()
        {        
            urls = makeUrls(pagesNumber);
            foreach(var url in urls)
            {
                await GetInformationAboutDevice(url);
            }

            saveDataToDB();
        }

        private IReadOnlyList<string> makeUrls(int pageCount)
        {
            IEnumerable<int> range = Enumerable.Range(1, pageCount);
            return range
                .Select(i => $"{urlString}{(i-1) * 10}")
                .ToArray();
        }

        private async Task GetInformationAboutDevice(string url)
        {
            var httpClient = new HttpClient();
            var htmlDocument = new HtmlDocument();
            var html = await httpClient.GetStringAsync(url);
            htmlDocument.LoadHtml(html);
            var nodes = htmlDocument.DocumentNode.Descendants("fieldset").ToList();

            var beerMapper = new BeerMapper();
            foreach (var node in nodes)
            {
                beerList.Add(beerMapper.MapFromHTMLNode(node));
            }
        }

        private bool saveDataToDB()
        {

        }
    }
}
