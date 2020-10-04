using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XamarinTest.Models
{
	[XmlRoot(ElementName = "category")]
	public class Category
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlText]
		public string Text { get; set; }
		[XmlAttribute(AttributeName = "parentId")]
		public string ParentId { get; set; }
	}
}
