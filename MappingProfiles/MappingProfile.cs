using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.MappingProfiles
{
	public class MappingProfile :Profile
	{
		public MappingProfile()
		{
			AllowNullCollections = true;

			CreateMap<Models.Order, Entities.Order>()
				.ForMember("Articles", option => option.MapFrom(o => o.Articles.ToList()))
				.ForMember("Payments", option => option.MapFrom(o => o.Payments.ToList()));

			CreateMap<Models.Article, Entities.Article>();
			CreateMap<Models.Payment, Entities.Payment>();
			CreateMap<Models.BillingAddress, Entities.BillingAddress>()
				.ForMember("Country", option => option.MapFrom(b => b.Country.Geo));
		}
	}
}
