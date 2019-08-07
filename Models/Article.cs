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
	public class Article
	{
		[XmlElement("artnum")]
		public long Nomenclature { get; set; }
		[XmlElement("title")]
		public string Title { get; set; }
		[XmlElement("amount")]
		public int Amount { get; set; }
		[XmlElement("brutprice")]
		public double BrutPrice { get; set; }
	}
}
