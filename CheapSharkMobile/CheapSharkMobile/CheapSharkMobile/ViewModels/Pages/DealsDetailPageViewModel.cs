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


		private string metaCritic;

		public string MetaCritic {
			get { return metaCritic; }
			set { Set (() => MetaCritic, ref metaCritic, value); }
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
				IsBusy = true;
				result = await API.GetDeal (id);
				if (result != null) {
					if (result.GameInfo != null) {
						RetailPrice = result.GameInfo.RetailPrice.ToString ("C");
						SalePrice = result.GameInfo.SalePrice.ToString ("C");
						Name = result.GameInfo.Name;
						MetaCritic = result.GameInfo.MetacriticScore;
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
			IsBusy = false;
		}
	}
}

