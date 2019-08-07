using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OrderApi
{
	using Entities;
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>().Property(o => o.OrderDatetime).HasColumnType("smalldatetime");


			base.OnModelCreating(modelBuilder);
		}
	}
}
