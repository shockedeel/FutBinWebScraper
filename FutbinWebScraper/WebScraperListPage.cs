using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FutbinWebScraper
{
    class WebScraperListPage : WebScraper
    {
       

      public  WebScraperListPage(HtmlDocument htmlDocument) {

            this.htmlDocument = htmlDocument;
                
            

        }

        

        public void getPlayersUrls(List<String> urls)
        {
          
            var body = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"repTb\"]/tbody").SelectNodes(".//tr");
            var test = body[0].GetAttributeValue("data-url", "");

            foreach (var player in body)
            {
                var playerUrl = player.GetAttributeValue("data-url", "");
                playerUrl = playerUrl.Replace("\"", "");
                urls.Add(playerUrl);
            }



        }

        public String getNextPage() {//gets the next page
            String nextUrl=WebScraper.baseUrl;
            try
            {
                 nextUrl += htmlDocument.DocumentNode.SelectSingleNode("//a[@aria-label='Next']").GetAttributeValue("href", "");
                
            }
            catch(Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("No more Next Pages");
                nextUrl = null;

            }
            return nextUrl;
        }


    }


}
