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
	[Table("Orders")]
	public class Order
	{
		[Key]
		public long OxId { get; set; }
		public DateTime OrderDatetime { get; set; }
		public int InvoiceNumber { get; set; }
		
		[ForeignKey("Status")]
		public byte OrderStatus { get; set; }
		public virtual OrderStatus Status { get; set; }
		
		public ICollection<Article> Articles { get; set; }
		
		public BillingAddress BillingAddresses { get; set; }
		
		public ICollection<Payment> Payments { get; set; }

	}
}
