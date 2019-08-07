using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApi.Models
{
	[Serializable]
	public class BillingAddress
	{
		[XmlElement("billemail")]
		public string Email { get; set; }
		[XmlElement("billfname")]
		public string Fullname { get; set; }
		[XmlElement("billstreet")]
		public string Street { get; set; }
		[XmlElement("billcity")]
		public string City { get; set; }
		[XmlElement("billstreetnr")]
		public short HomeNumber { get; set; }
		[XmlElement("country")]
		public Country Country { get; set; }
		[XmlElement("billzip")]
		public int Zip { get; set; }
		
	}
	[Serializable]
	public class Country
	{
		[XmlElement("geo")]
		public string Geo { get; set; }
	}
}
