using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Entities
{
	[Table("OrderStatuses")]
	public class OrderStatus
	{
		[Key]
		public byte Id { get; set; }
		public string Name { get; set; }
	}
}
