using System;
using Newtonsoft.Json;

namespace CheapSharkMobile
{
	public class GameInfo
	{
		public string StoreID { get; set; }

		public string GameID { get; set; }

		public string Name { get; set; }

		public string SteamAppID { get; set; }

		public Decimal SalePrice { get; set; }

		public Decimal RetailPrice { get; set; }

		public string MetacriticScore { get; set; }

		public string MetacriticLink { get; set; }

		[JsonConverter (typeof(EpochToDateTimeConverter))]
		public DateTime ReleaseDate { get; set; }

		public string Publisher { get; set; }

		public string Steamworks { get; set; }

		public string Thumb { get; set; }
	}
}

