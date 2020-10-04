using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "categories")]
	public class Categories
	{
		[XmlElement(ElementName = "category")]
		public List<Category> Category { get; set; }
	}
}
