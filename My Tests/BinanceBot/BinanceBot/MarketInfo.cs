using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceBot
{
    public class MarketInfo
    {
        public List<OfferInfo> Bids { get; set; }
        public List<OfferInfo> Asks { get; set; }
    }


    public class OfferInfo
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get { return this.Price * this.Quantity; } }
    }
}
