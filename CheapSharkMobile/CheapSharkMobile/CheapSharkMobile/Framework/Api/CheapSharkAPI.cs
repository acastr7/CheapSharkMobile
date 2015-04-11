using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Linq;

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


		public async Task<List<Deal>> GetDeals (List<string> storeID = null, int pageNumber = 0, int pageSize = 60, string sortBy = "Deal Rating", bool desc = false, int lowerPrice = 0, int upperPrice = 50, int metacritic = 0, string title = "", bool exact = false, bool tripleA = false, bool steamworks = false, bool onSale = false)
		{
			if (pageSize > 60) {
				throw new ArgumentOutOfRangeException ("pageSize", "Page size cannot be greater than 60.");
			}

			var queryParams = new Dictionary<string,string> ();
			if (storeID != null && storeID.Any ()) {
				queryParams.Add ("storeID", string.Join (",", storeID));
			}
			if (!string.IsNullOrEmpty (title)) {
				queryParams.Add ("title", title);
			}
			queryParams.Add ("lowerPrice", lowerPrice.ToString ());
			queryParams.Add ("upperPrice", upperPrice.ToString ());
			queryParams.Add ("metacritic", metacritic.ToString ());
			queryParams.Add ("AAA", tripleA.ToString ());
			queryParams.Add ("steamworks", steamworks.ToString ());
			queryParams.Add ("onSale", onSale.ToString ());
			var url = DealsApi.SetQueryParams (queryParams);
			Debug.WriteLine (url.ToString ());
			return await DealsApi.SetQueryParams (queryParams).GetJsonAsync<List<Deal>> ();
		}

		public async Task<DealInformation> GetDeal (string id)
		{
			Debug.WriteLine ("GetDeal: " + id);
			id = System.Net.WebUtility.UrlDecode (id); // for some reason the url comes in encoded alread, unfortunatly FLURL also encodes it before it is sent.
			var result = await DealsApi.SetQueryParam ("id", id).GetStringAsync ();
			Debug.WriteLine ("GetDeal: " + result);

			return JsonConvert.DeserializeObject<DealInformation> (result);

		}

		public async Task<List<Store>> GetStores ()
		{
			return await StoresApi.GetJsonAsync < List<Store>> ();
		}
	}
}

