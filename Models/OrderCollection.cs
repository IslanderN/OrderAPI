using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApi.Models
{
	[Serializable]
	[XmlRoot("OrderCollection")]
	public class OrderCollection
	{
		[XmlArray("orders")]
		[XmlArrayItem("order", typeof(Order))]
		public Order[] Orders { get; set; }
	}
}
