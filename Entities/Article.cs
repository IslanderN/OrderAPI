﻿using Newtonsoft.Json;
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
	[Table("Articles")]
	public class Article
	{
		[Key]
		public int Id { get; set; }
		public long Nomenclature { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public double BrutPrice { get; set; }

		[JsonIgnore]
		[ForeignKey("Order")]
		public long OrderOxId { get; set; }
		[JsonIgnore]
		public Order Order { get; set; }
	}
}
