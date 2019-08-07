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
	public class Order
	{
		[XmlElement("oxid")]
		public long OxId { get; set; }
		[XmlElement("orderdate")]
		public DateTime OrderDatetime { get; set; }
		
		[XmlArray("articles")]
		[XmlArrayItem("orderarticle", typeof(Article))]
		public Article[] Articles { get; set; }

		[XmlElement("billingaddress")]
		public BillingAddress BillingAddresses { get; set; }

		[XmlArray("payments")]
		[XmlArrayItem("payment",typeof(Payment))]
		public Payment[] Payments { get; set; }

	}
}
