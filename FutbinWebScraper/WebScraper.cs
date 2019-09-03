using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FutbinWebScraper
{
   abstract class WebScraper
    {

        public HtmlDocument htmlDocument;
        public static String baseUrl = "https://www.futbin.com";



        public static async System.Threading.Tasks.Task<HtmlDocument> getHtmlAsync(String url)
        {
            

           var htmlDocument = new HtmlDocument();
            //"C:\\Users\\kolbe\\OneDrive\\Desktop"
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);




            
            htmlDocument.LoadHtml(html);
          
           
            return htmlDocument;
        }


    }


}
