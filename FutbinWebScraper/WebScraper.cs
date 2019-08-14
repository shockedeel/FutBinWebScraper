using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutbinWebScraper
{
   abstract class WebScraper
    {

        public HtmlDocument htmlDocument;
        public static String baseUrl = "https://www.futbin.com";



        public static HtmlDocument getHtml(String url)
        {
            

           var htmlDocument = new HtmlDocument();
            //"C:\\Users\\kolbe\\OneDrive\\Desktop"
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            ChromeDriver chromeDriver = new ChromeDriver("C:\\Users\\kolbe\\OneDrive\\Desktop",options);
            
            
            
            
            chromeDriver.Navigate().GoToUrl(url);
            var html = chromeDriver.PageSource;
            htmlDocument.LoadHtml(html);
          
            chromeDriver.Quit();
            return htmlDocument;
        }


    }


}
