using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace OrderApi.Services
{
	using Repository;
	using Entities;
	

	public class OrderService
	{
		private readonly IGenericRepository<Entities.Order> orderRepository;
		private readonly IMapper mapper;

		public OrderService(IGenericRepository<Entities.Order> orderRepository, IMapper mapper)
		{
			this.orderRepository = orderRepository;
			this.mapper = mapper;
		}


		public IEnumerable<Entities.Order> MapOrderCollection(Models.OrderCollection orderCollection)
		{
			var orders = this.mapper.Map<Models.Order[], IEnumerable<Entities.Order>>(orderCollection.Orders);
			foreach(var order in orders)
			{
				foreach(var article in order.Articles)
				{
					article.OrderOxId = order.OxId;
					article.Order = order;
				}
				foreach(var payment in order.Payments)
				{
					payment.OrderOxId = order.OxId;
					payment.Order = order;
				}
				order.BillingAddresses.Order = order;
				order.BillingAddresses.OrderOxId = order.OxId;

				order.OrderStatus = (byte)OrderStatusEnum.Processed;

			}

			return orders;
		}

		public Entities.Order GetOrderByOxid(long oxid)
		{
			return GetFullIncludeQuery().FirstOrDefault(o => o.OxId == oxid);
		}
		public IEnumerable<Order> GetOrders()
		{
			return GetFullIncludeQuery().ToList();
		}
		
		public void SetOrderStatus(OrderStatusEnum status, long oxid)
		{
			var order = this.orderRepository.GetQuery().FirstOrDefault(o => o.OxId == oxid);
			if(order != null)
			{
				order.OrderStatus = (byte)status;
				this.orderRepository.Update(order);
				this.orderRepository.SaveChanges();
			}
		}
		public void SetInvoiceNumber(int invoiceNumber, long oxid)
		{
			var order = this.orderRepository.GetQuery().FirstOrDefault(o => o.OxId == oxid);
			if (order != null)
			{
				order.InvoiceNumber = invoiceNumber;
				this.orderRepository.Update(order);
				this.orderRepository.SaveChanges();
			}
		}

		public void AddOrder(Order order)
		{
			if (!Contains(order.OxId))
			{
				this.orderRepository.Add(order);
				this.orderRepository.SaveChanges();
			}
		}
		public void AddOrders(IEnumerable<Order> orders)
		{
			foreach(var order in orders)
			{
				if (!Contains(order.OxId))
				{
					this.orderRepository.Add(order);
				}
			}
			this.orderRepository.SaveChanges();
		}
		private bool Contains(long oxid)
		{
			if(this.orderRepository.GetQuery().FirstOrDefault(o=>o.OxId == oxid) != null)
			{
				return true;
			}
			return false;
		}

		private IQueryable<Order> GetFullIncludeQuery()
		{
			return this.orderRepository.GetWithIncludeQuery(
				o => o.Articles,
				o => o.BillingAddresses,
				o => o.Status,
				o => o.Payments
				);
		}
	}
}
