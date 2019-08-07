using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApi.Entities
{
	[Table("BillingAddresses")]
	public class BillingAddress
	{
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
		public string Fullname { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public short HomeNumber { get; set; }
		public int Zip { get; set; }

		[JsonIgnore]
		[ForeignKey("Order")]
		public long OrderOxId { get; set; }
		[JsonIgnore]
		public Order Order { get; set; }
	}
}
