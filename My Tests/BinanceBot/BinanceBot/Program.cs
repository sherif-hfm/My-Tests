using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
namespace BinanceBot
{
    class Program
    {
        static void  Main(string[] args)
        {
            var stage1 = GetData("ETHBTC").GetAwaiter().GetResult();
            var stage2 = GetData("ADAETH").GetAwaiter().GetResult();
            var stage3 = GetData("ADABTC").GetAwaiter().GetResult();

            var coin51 = 1000 * stage1.Bids[0].Price; //ETHBTC
            var coin53 = 1000 / stage2.Asks[0].Price; //ADAETH
            var coin52 = coin53 * stage3.Bids[0].Price; //ADABTC

            var coin61 = 1000 * stage3.Asks[0].Price; //ADABTC
            var coin62 = 1000 * stage2.Bids[0].Price; //ADAETH
            var coin63 = coin62 * stage1.Bids[0].Price; //ETHBTC



            Console.ReadLine();
        }

        private static async Task<MarketInfo> GetData(string pair)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("https://api.binance.com/api/v1/depth?symbol=" + pair + "&limit=5"))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BinanceMarketInfo>(result);
                MarketInfo marketInfo = new MarketInfo();
                marketInfo.Asks = new List<OfferInfo>();
                marketInfo.Bids = new List<OfferInfo>();
                foreach (var bids in data.bids)
                {
                    marketInfo.Bids.Add(new OfferInfo() { Price = decimal.Parse(bids[0].ToString()), Quantity = decimal.Parse(bids[1].ToString()) });
                }
                foreach (var asks in data.asks)
                {
                    marketInfo.Asks.Add(new OfferInfo() { Price = decimal.Parse(asks[0].ToString()), Quantity = decimal.Parse(asks[1].ToString()) });
                }
                return marketInfo;
            }
        }
    }
}
