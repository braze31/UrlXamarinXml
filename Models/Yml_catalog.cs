using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "yml_catalog")]
	public class Yml_catalog
	{
		public string Filename { get; set; }
		[XmlElement(ElementName = "shop")]
		public Shop Shop { get; set; }
		[XmlAttribute(AttributeName = "date")]
		public string Date { get; set; }
	}
}
