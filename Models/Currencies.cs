using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "currencies")]
	public class Currencies
	{
		[XmlElement(ElementName = "currency")]
		public Currency Currency { get; set; }
	}
}
