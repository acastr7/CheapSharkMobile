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

		public string DealsApi {
			get{ return RootApi + "Deals"; }
		}

		public string GamesApi {
			get{ return RootApi + "Games"; }
		}

		public string StoresApi {
			get{ return RootApi + "stores"; }
		}

		public string AlertsApi {
			get{ return RootApi + "Alerts"; }
		}

		public CheapSharkAPI ()
		{
		}


		public async Task<List<Deal>> GetDeals (string storeID = "", int pageNumber = 0, int pageSize = 60, string sortBy = "Deal Rating", bool desc = false, int lowerPrice = 0, int upperPrice = 50, int metacritic = 0, string title = "", bool exact = false, bool tripleA = false, bool steamworks = false, bool onSale = false)
		{
			if (pageSize > 60) {
				throw new ArgumentOutOfRangeException ("Max Page size is 60.");
			}

			return await DealsApi.SetQueryParams (null).GetJsonAsync<List<Deal>> ();
		}
	}
}

