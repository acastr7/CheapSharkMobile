using System;
using Newtonsoft.Json;

namespace CheapSharkMobile
{
	public class Deal
	{
		public string InternalName { get; set; }

		public string Title { get; set; }

		public string MetacriticLink { get; set; }

		public string DealID { get; set; }

		public string StoreID { get; set; }

		public string GameID { get; set; }

		public Decimal SalePrice { get; set; }

		public Decimal NormalPrice { get; set; }

		public Decimal Savings { get; set; }

		public string MetacriticScore { get; set; }

		[JsonConverter (typeof(EpochToDateTimeConverter))]
		public DateTime ReleaseDate { get; set; }

		[JsonConverter (typeof(EpochToDateTimeConverter))]
		public DateTime LastChange { get; set; }

		public Double DealRating { get; set; }

		public string Thumb { get; set; }
	}
}

