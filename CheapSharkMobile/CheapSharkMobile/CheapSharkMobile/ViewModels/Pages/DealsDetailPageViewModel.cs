using System;
using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CheapSharkMobile
{
	public class DealsDetailPageViewModel : BasePageViewModel
	{
		CheapSharkAPI API;

		private string salePrice;

		public string SalePrice {
			get { return salePrice; }
			set { Set (() => SalePrice, ref salePrice, value); }
		}

		private string retailPrice;

		public string RetailPrice {
			get { return retailPrice; }
			set { Set (() => RetailPrice, ref retailPrice, value); }
		}

		private string name;

		public string Name {
			get { return name; }
			set { Set (() => Name, ref name, value); }
		}


		public DealsDetailPageViewModel (CheapSharkAPI api)
		{
			Title = "Details";
			API = api;

			IsBusy = true;

		}

		public async void GetDeal (string id)
		{
			DealInformation result;
			try {
				result = await API.GetDeal (id);
				if (result != null) {
					if (result.GameInfo != null) {
						RetailPrice = result.GameInfo.RetailPrice.ToString ("C");
						SalePrice = result.GameInfo.SalePrice.ToString ("C");
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}
	}
}

