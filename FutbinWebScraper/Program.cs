using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace FutbinWebScraper
{
    struct card {
        String url;
        String version;
       public card(String u, String v) {

            url = u;

            version = v;
        }
    };
    class Program
    {
        public static async void getHtmlAsync(String ur,String t)
        {
           

            var url = ur;
            //var httpClient = new HttpClient();
            //var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
           // htmlDocument.LoadHtml(html);
            var chromeDriver = new ChromeDriver("C:\\Users\\kolbe\\OneDrive\\Desktop");
            

            chromeDriver.Navigate().GoToUrl(url);
            
           // chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var html = chromeDriver.PageSource;
            htmlDocument.LoadHtml(html);
            //getting the name
            var name= htmlDocument.DocumentNode.SelectNodes("//span[@class='header_name']")[0].InnerText;
            //getting the list for country team and league
            var List = htmlDocument.DocumentNode.SelectNodes("//ul[@class='list-unstyled list-inline ']")[0];
            var l = List.ChildNodes;

            var country = l[1].InnerText;//getting the country
            country = Regex.Replace(country, @"\r\n", "");
            country = Regex.Replace(country, @" ", "");


            var team = l[3].InnerText;//getting the team
            team = Regex.Replace(team, @"\r\n", "");
            team = Regex.Replace(team, @" ", "");

            var league = l[5].InnerText;//getting the league
            league = Regex.Replace(league, @"\r\n", "");
            league = Regex.Replace(league, @" ", "");



            var pslow1 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[3]/span").InnerText;
            pslow1 = Regex.Replace(pslow1, @"\r\n", "");
            pslow1 = Regex.Replace(pslow1, @" ", "");
            pslow1 = Regex.Replace(pslow1, @",", "");

            var pslow2 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[4]").InnerText;
            pslow2 = Regex.Replace(pslow2, @"\r\n", "");
            pslow2 = Regex.Replace(pslow2, @" ", "");
            pslow2 = Regex.Replace(pslow2, @",", "");

            var pslow3 = htmlDocument.DocumentNode.SelectSingleNode("html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[5]").InnerText;
            pslow3 = Regex.Replace(pslow3, @"\r\n", "");
            pslow3 = Regex.Replace(pslow3, @" ", "");
            pslow3 = Regex.Replace(pslow3, @",", "");

            var pslow4 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[6]").InnerText;
            pslow4 = Regex.Replace(pslow4, @"\r\n", "");
            pslow4 = Regex.Replace(pslow4, @" ", "");
            pslow4 = Regex.Replace(pslow4, @",", "");

            var pslow5 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[7]").InnerText;
            pslow5 = Regex.Replace(pslow5, @"\r\n", "");
            pslow5 = Regex.Replace(pslow5, @" ", "");
            pslow5 = Regex.Replace(pslow5, @",", "");

            var xbox1 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[3]/span").InnerText;
            xbox1 = Regex.Replace(xbox1, @"\r\n", "");
           xbox1 = Regex.Replace(xbox1, @" ", "");
            xbox1 = Regex.Replace(xbox1, @",", "");

            var xbox2 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[4]").InnerText;
            xbox2 = Regex.Replace(xbox2, @"\r\n", "");
            xbox2 = Regex.Replace(xbox2, @" ", "");
            xbox2 = Regex.Replace(xbox2, @",", "");

            var xbox3 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[5]").InnerText;
            xbox3 = Regex.Replace(xbox3, @"\r\n", "");
            xbox3 = Regex.Replace(xbox3, @" ", "");
            xbox3 = Regex.Replace(xbox3, @",", "");

            var xbox4 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[6]").InnerText;
            xbox4 = Regex.Replace(xbox4, @"\r\n", "");
            xbox4 = Regex.Replace(xbox4, @" ", "");
            xbox4 = Regex.Replace(xbox4, @",", "");

            var xbox5 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[7]").InnerText;
            xbox5 = Regex.Replace(xbox5, @"\r\n", "");
            xbox5 = Regex.Replace(xbox5, @" ", "");
            xbox5 = Regex.Replace(xbox5, @",", "");

            var overallRating = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[10]/div[3]/div[1]/h1").InnerText;

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var sixMonth = chromeDriver.FindElement(By.XPath("//*[@id=\"daily_graph\"]"));
            var sh = chromeDriver.FindElement(By.XPath("//*[@id=\"highcharts-0\"]"));
            var s = chromeDriver.FindElement(By.XPath("//*[@id=\"highcharts-0\"]/svg"));


            Console.WriteLine();
            chromeDriver.Quit();
        }

        public string performRegex(String src) {
            src = Regex.Replace(src, @"\r\n", "");
            src = Regex.Replace(src, @" ", "");
            src = Regex.Replace(src, @",", "");

            return src;
        }



       public static void Main(string[] args)
        {
            //getHtmlAsync("https://www.futbin.com/19/player/17575/Cristiano%20Ronaldo/");

            thisOneWaits("https://www.futbin.com/players");
            Console.ReadLine();



        }
        public static async void thisOneWaits(String pageUrl) {
            var ht = await WebScraper.getHtmlAsync(pageUrl);
           var test= new WebScraperListPage(ht);
            while (test.getNextPage() != null)
            {
                List<String> playerurls = new List<String>();
                List<Task<HtmlDocument>> playerHtmls = new List<Task<HtmlDocument>>();
                test.getPlayersUrls(playerurls);
                foreach (var playerUrl in playerurls)
                {
                    Console.WriteLine("loading new page");
                    var webHtml = WebScraper.getHtmlAsync(WebScraper.baseUrl + playerUrl);
                    playerHtmls.Add(webHtml);



                }
                foreach (var playerHtml in playerHtmls)
                {
                    var html = await playerHtml;
                    var playerScraper = new WebScraperPlayerPage(html);
                    Player player = new Player(playerScraper);
                }
                var nextPage =test.getNextPage();
                ht = await WebScraper.getHtmlAsync(nextPage);
                test = new WebScraperListPage(ht);

            }//for the page webscraper


        }


        public static async void getPlayersUrls(List<String> urls, String url)
        {
            var htmlDocument = new HtmlDocument();
           
            var chromeDriver = new ChromeDriver("C:\\Users\\kolbe\\OneDrive\\Desktop");


            chromeDriver.Navigate().GoToUrl(url);

           
            var html = chromeDriver.PageSource;
            htmlDocument.LoadHtml(html);
            var nextUrl = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div/div[4]/div[4]/nav/ul/li[7]/a").GetAttributeValue("href","");

            chromeDriver.Quit();

            Console.WriteLine();

        }





        public static async Task getPlayerPageInfoAsync(List<String>urls) {//there are 30 fuckers per thing
                                                                           //need to create big boi fuction for all the tings
            
            List<WebScraperPlayerPage> playerScrapers=new List<WebScraperPlayerPage>();
            var i = 0;
            var counter = 0;
            foreach (var url in urls) {
                if (i == 0)
                {
                    try
                    {
                        counter++;
                        Console.WriteLine("\n\nIT RUNS IT RUNS\n"+counter+"\n");
                        getHtmlAsync(url);
                        //WebScraperPlayerPage iScrape = new WebScraperPlayerPage(i);
                        //Console.WriteLine("\n\n\nName: " + iScrape.getName() + " Overall Rating: " + iScrape.getOverallRating() + "\n\n\n");
                        //playerScrapers.Add(iScrape);
                        i = 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Console.WriteLine("Failed Failed Failed\n\n");
                        
                    }
                }
                else {
                    i = 0;
                }


            }
            
          

        }
        public static async void getHtmlAsync(String url) {
          var i= await Task.Run(() => WebScraper.getHtmlAsync(WebScraper.baseUrl + url));
            var j = new WebScraperPlayerPage(i);
            Console.WriteLine(j.getOverallRating());
        }


    }
    


}
