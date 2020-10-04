using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "offers")]
	public class Offers
	{
        [XmlElement(ElementName = "offer")]
		public List<Offer> Offer { get; set; }
	}

}
