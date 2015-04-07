using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;

namespace CheapSharkMobile
{
	public class CheapSharkAPI
	{
		const string RootApi = "http://www.cheapshark.com/api/1.0/";

		private string DealsApi {
			get{ return RootApi + "deals"; }
		}

		private string GamesApi {
			get{ return RootApi + "games"; }
		}

		private string StoresApi {
			get{ return RootApi + "stores"; }
		}

		private string AlertsApi {
			get{ return RootApi + "alerts"; }
		}

		public CheapSharkAPI ()
		{
		}


		public async Task<List<Deal>> GetDeals (string storeID = "", int pageNumber = 0, int pageSize = 60, string sortBy = "Deal Rating", bool desc = false, int lowerPrice = 0, int upperPrice = 50, int metacritic = 0, string title = "", bool exact = false, bool tripleA = false, bool steamworks = false, bool onSale = false)
		{
			if (pageSize > 60) {
				throw new ArgumentOutOfRangeException ("pageSize", "Page size cannot be greater than 60.");
			}

			return await DealsApi.SetQueryParams (null).GetJsonAsync<List<Deal>> ();
		}

		public async Task<DealInformation> GetDeal (string storeId)
		{
			return await DealsApi.SetQueryParam ("storeId", storeId).GetJsonAsync<DealInformation> ();

		}
	}
}

