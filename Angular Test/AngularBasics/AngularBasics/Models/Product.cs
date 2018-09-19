using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularBasics.Models
{
    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public bool canPurchase { get; set; }
        public bool soldOut { get; set; }
        public string addDate { get; set; }
        public string specification { get; set; }
        public List<Review> reviews { get; set; }
    }

    public class Review
    {
        public string comment { get; set; }
        public string email { get; set; }
        public bool agree { get; set; }
    }
}