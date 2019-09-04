using System;
using System.Collections.Generic;
using System.Text;

namespace FutbinWebScraper
{
    class Player
    {
        WebScraperPlayerPage playerPage;
       
       
        public Array psPriceData { get; set; }
        public Array pcPriceData { get; set; }
        public Array xboxPriceData { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string league { get; set; }
        public string team { get; set; }

        Player(WebScraperPlayerPage playerPage) {
            this.playerPage = playerPage;
            var dataArrs = playerPage.getJsonData();
            this.pcPriceData = dataArrs[0];
            this.xboxPriceData = dataArrs[1];
            this.psPriceData = dataArrs[2];
            var ctl = playerPage.findCTL();
            this.country =Convert.ToString( ctl[0]);
            this.team = Convert.ToString(ctl[1]);
            this.league = Convert.ToString(ctl[2]);
            this.name = playerPage.getName();
        }
       

    }
}
