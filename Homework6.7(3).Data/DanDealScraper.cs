using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._7_3.Data
{
    public static class DanDealScraper
    {
        public static List<DanDealItem> Scrape()
        {
            var html = GetDanDealHtml();
            return ParseHtml(html);

        }

        private static string GetDanDealHtml()
        {
            using var client = new HttpClient();
            return client.GetStringAsync("https://www.dansdeals.com/category/shopping-deals/").Result;
        }

        private static List<DanDealItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll(".td_module_10.td_module_wrap.td-animation-stack");
            var items = new List<DanDealItem>();
            foreach (var div in divs)
            {
                var item = new DanDealItem();
                items.Add(item);

                var titleElement = div.QuerySelector(".entry-title.td-module-title");
                if (titleElement != null)
                {
                    item.Title = titleElement.TextContent;
                }

                var imageElement = div.QuerySelector("a");
                if (imageElement != null)
                {
                    item.Image = imageElement.FirstElementChild.TextContent;
                }

                var detailsElement = div.QuerySelector(".td-module-meta-info");
                if (detailsElement != null)
                {
                    item.Details = detailsElement.TextContent;
                }

                var urlElement = div.QuerySelector("a");
                if (urlElement != null)
                {
                    item.Url = urlElement.Attributes["href"].Value;
                }
            }
            return items;
        }
    }
}
