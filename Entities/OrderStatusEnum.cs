using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Entities
{
	public enum OrderStatusEnum : byte
	{
		Processed = 4,
		Unprocessed = 5,
		Cancelled = 6
	};
}
