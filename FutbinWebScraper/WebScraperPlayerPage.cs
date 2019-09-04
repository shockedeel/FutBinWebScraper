using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Collections.ObjectModel;
using System.Collections;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace FutbinWebScraper
{


    class WebScraperPlayerPage : WebScraper
    {
       

       public WebScraperPlayerPage(HtmlDocument htmlDocument) {
            this.htmlDocument = htmlDocument;
            
        }

       

        public ArrayList findCTL() {//returns an arraylist with the following order {country,team,league}
            ArrayList toReturn = new ArrayList();
            var name = htmlDocument.DocumentNode.SelectNodes("//span[@class='header_name']")[0].InnerText;
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

            toReturn.Insert(0, country);
            toReturn.Insert(1, team);
            toReturn.Insert(2,league);

            return toReturn;

        }
        public List<String> getAvgPrices() {
            List<String> prices = new List<String>();
            var pslow1 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[3]/span").InnerText;
            pslow1 = performRegex(pslow1);
            prices.Add(pslow1);
            var pslow2 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[4]").InnerText;
            pslow2 = performRegex(pslow2);
            prices.Add(pslow2);
            var pslow3 = htmlDocument.DocumentNode.SelectSingleNode("html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[5]").InnerText;
            pslow3 = performRegex(pslow3);
            prices.Add(pslow3);
            var pslow4 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[6]").InnerText;
            pslow4 = performRegex(pslow4);
            prices.Add(pslow4);
            var pslow5 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[2]/div/div[7]").InnerText;
            pslow5 = performRegex(pslow5);
            prices.Add(pslow5);
            var xbox1 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[3]/span").InnerText;

            xbox1 = performRegex(xbox1);
            prices.Add(xbox1);
            var xbox2 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[4]").InnerText;
            xbox2 = performRegex(xbox2);
            prices.Add(xbox2);
            var xbox3 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[5]").InnerText;
            xbox3 = performRegex(xbox3);
            prices.Add(xbox3);
            var xbox4 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[6]").InnerText;

            xbox4 = performRegex(xbox4);
            prices.Add(xbox4);
            var xbox5 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[3]/div/div[7]").InnerText;

            xbox5 = performRegex(xbox5);
            prices.Add(xbox5);

            var pc1 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[4]/div/div[3]/span").InnerText;
            pc1 = performRegex(pc1);
            prices.Add(pc1);

            var pc2 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[4]/div/div[4]").InnerText;
            pc2 = performRegex(pc2);
            prices.Add(pc2);

            var pc3 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[4]/div/div[5]").InnerText;
            pc3 = performRegex(pc3);
            prices.Add(pc3);

            var pc4 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[4]/div/div[6]").InnerText;
            pc4 = performRegex(pc4);
            prices.Add(pc4);

            var pc5 = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[11]/div/div[2]/div[4]/div/div[7]").InnerText;
            pc5 = performRegex(pc5);
            prices.Add(pc5);

            return prices;
        }


        public ObservableCollection<card> getDifferentVersions() {

            var versionsBlock = htmlDocument.DocumentNode.SelectNodes("//div[@class='row player-versions inline-block float-left']")[0].ChildNodes;

            ObservableCollection<card> versions = new ObservableCollection<card>();//collection for different card versions
            foreach (var version in versionsBlock)
            {
                if (version.Name.Equals("div"))
                {
                    var f = version.InnerHtml.IndexOf("href");//to get the link to the related cards
                    var z = version.InnerHtml.IndexOf("data-rare");
                    String href = version.InnerHtml.ToString().Substring(f, z);
                    href = href.Substring(href.IndexOf("\"") + 1, href.Substring(href.IndexOf("\"") + 1).IndexOf("\""));


                    var idIndex = version.InnerHtml.IndexOf("id");//unique id just so it can identified by something
                    String id = version.InnerHtml.ToString().Substring(idIndex, f);
                    id = id.Substring(id.IndexOf("\"") + 1, id.Substring(id.IndexOf("\"") + 1).IndexOf("\""));
                    card i = new card(href, id);
                    Console.WriteLine(href);
                    versions.Add(i);
                }

            }


            return versions;
        }

        public String getOverallRating() {
            String overallRating = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[8]/div[10]/div[3]/div[1]/h1").InnerText;
            performRegex(overallRating);
            return overallRating;
        }

        public String getName() {
            var name = htmlDocument.DocumentNode.SelectNodes("//span[@class='header_name']")[0].InnerText;
            performRegex(name);
            return name;
        }

        public string performRegex(String src)
        {
            src = Regex.Replace(src, @"\r\n", "");
            src = Regex.Replace(src, @" ", "");
            src = Regex.Replace(src, @",", "");

            return src;
        }

        public string getPlayerId() {

            var div = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"page_comment_picture\"]");
            var pic=div.GetAttributeValue("data-picture", "");
            pic = pic.Substring(pic.IndexOf("ers/")+5);
            pic = pic.Substring(0, pic.IndexOf("."));
            
            return pic;
        }

        public List<Newtonsoft.Json.Linq.JArray> getJsonData() {//PC, XBOX, PS
            string id = this.getPlayerId();
            List<Newtonsoft.Json.Linq.JArray> toReturn = new List<Newtonsoft.Json.Linq.JArray>();
            string url = "https://www.futbin.com/19/playerGraph?type=daily_graph&year=19&player="+id+"&set_id=";
            using (WebClient wc = new WebClient())
            {
                
                var jsonString = wc.DownloadString(url);
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                Newtonsoft.Json.Linq.JArray pcPriceDataArray = json["pc"];
                toReturn.Add(pcPriceDataArray);

                Newtonsoft.Json.Linq.JArray xboxPriceDataArray = json["xbox"];
                toReturn.Add(xboxPriceDataArray);
                Newtonsoft.Json.Linq.JArray psPriceDataArray = json["ps"];
                toReturn.Add(psPriceDataArray);
                return toReturn;
            }

            return null;
        }




       


    }







}
