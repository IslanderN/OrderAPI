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
	public class Payment
	{
		[XmlElement("method-name")]
		public string MethodName { get; set; }
		[XmlElement("amount")]
		public decimal Amount { get; set; }
	}
}
