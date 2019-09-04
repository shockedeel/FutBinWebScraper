using System;
using System.Collections.Generic;
using System.Text;

namespace FutbinWebScraper
{
    class Player
    {
        WebScraperPlayerPage playerPage;


        public Newtonsoft.Json.Linq.JArray psPriceData { get; set; }
        public Newtonsoft.Json.Linq.JArray pcPriceData { get; set; }
        public Newtonsoft.Json.Linq.JArray xboxPriceData { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string league { get; set; }
        public string team { get; set; }

       public Player(WebScraperPlayerPage playerPage) {
            this.playerPage = playerPage;
            var dataArrs = playerPage.getJsonData();
            try
            {
                this.pcPriceData = dataArrs[0];
                Console.WriteLine(pcPriceData[0][0].GetType());
                Console.WriteLine(pcPriceData[0][1].GetType());
                this.xboxPriceData = dataArrs[1];
                this.psPriceData = dataArrs[2];
            }
            catch (Exception e) {
                Console.WriteLine("Error in loading price data");
                Console.WriteLine(e.GetType());
            }
            var ctl = playerPage.findCTL();
            this.country =Convert.ToString( ctl[0]);
            this.team = Convert.ToString(ctl[1]);
            this.league = Convert.ToString(ctl[2]);
            this.name = playerPage.getName();
        }
       

    }
}
