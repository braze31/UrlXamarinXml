using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	public class Offer
	{
		public string Id { get; set; }
		public string Type { get; set; }
		public string Bid { get; set; }
		public string Available { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public string CurrencyId { get; set; }
        public string Picture { get; set; }
        public CategoryId CategoryId { get; set; } = new CategoryId();
    }
}
