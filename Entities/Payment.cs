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
	[Table("Payments")]
	public class Payment
	{
		[Key]
		public int Id { get; set; }
		public string MethodName { get; set; }
		public decimal Amount { get; set; }

		[JsonIgnore]
		[ForeignKey("Order")]
		public long OrderOxId { get; set; }
		[JsonIgnore]
		public Order Order { get; set; }
	}
}
