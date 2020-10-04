using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "shop")]
	public class Shop
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "company")]
		public string Company { get; set; }
		[XmlElement(ElementName = "url")]
		public string Url { get; set; }
		[XmlElement(ElementName = "currencies")]
		public Currencies Currencies { get; set; }
		[XmlElement(ElementName = "categories")]
		public Categories Categories { get; set; }
		[XmlElement(ElementName = "local_delivery_cost")]
		public string Local_delivery_cost { get; set; }
		[XmlElement(ElementName = "offers")]
		public Offers Offers { get; set; }
	}
}
