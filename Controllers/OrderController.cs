using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
	using Services;

	[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
		private readonly OrderService orderService;
		public OrderController(OrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpPost]
		public IActionResult PutOrder([FromBody] Models.OrderCollection orderCollection)
		{
			try
			{
				var result = this.orderService.MapOrderCollection(orderCollection);
				this.orderService.AddOrders(result);
			}
			catch(Exception ex)
			{
				return this.BadRequest(ex.GetBaseException().Message);
			}

			return this.Ok();
		}

		[HttpGet]
		public IActionResult GetOrders()
		{
			var orders = this.orderService.GetOrders();

			return new JsonResult(orders);
		}
		[HttpGet("{id}")]
		public IActionResult GetOrder(long id)
		{
			var order = this.orderService.GetOrderByOxid(id);

			return new JsonResult(order);
		}

		[HttpGet("[action]")]
		public IActionResult SetStatus(string status, long oxid)
		{
			object orderStatus;
			if(!Enum.TryParse(typeof(Entities.OrderStatusEnum), status, out orderStatus))
			{
				return this.BadRequest();
			}

			this.orderService.SetOrderStatus((Entities.OrderStatusEnum)orderStatus, oxid);
			return this.Ok();
		}

		[HttpGet("[action]")]
		public IActionResult SetInvoceNumber(int number, long oxid)
		{
			this.orderService.SetInvoiceNumber(number, oxid);
			return this.Ok();
		}
    }
}