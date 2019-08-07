using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApi.Models
{
	[XmlRoot("test1")]
	public class TestOrder
	{
		[XmlElement("order")]
		public string test { get; set; }

		[XmlElement("test")]
		public string order { get; set; }

		//[BindProperty(Name ="num")]
		//[FromBody]
		//[DataMember(Name = "num")]
		[XmlElement("num")]
		public string enu { get; set; }

		[XmlArray("array")]
		[XmlArrayItem("el", typeof(Element))]
		public Element[] element { get; set; }
	}
	public class Element
	{
		[XmlElement("item")]
		public string Item { get; set; }
	}
}
