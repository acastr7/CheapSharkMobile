using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nito.AsyncEx;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;

namespace CheapSharkMobile
{
	public class DealsPageViewModel : BasePageViewModel
	{
		CheapSharkAPI API;

		private INotifyTaskCompletion<ObservableCollection<Deal>> deals;

		public INotifyTaskCompletion<ObservableCollection<Deal>> Deals {
			get { return deals; }
			set { Set (() => Deals, ref deals, value); }
		}

		Deal selectedItem;

		public Deal SelectedItem {
			get { return selectedItem; }
			set { 
				if (value != null) {
					Navigation.NavigateTo ("DealsDetailPage", value.DealID);
				}
				Set (() => SelectedItem, ref selectedItem, value);
			}
		}

		readonly INavigationService Navigation;

		public DealsPageViewModel (CheapSharkAPI api, INavigationService navigation)
		{
			API = api;
			Navigation = navigation;
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Deal>> (GetDeals);
			Title = "Deals";
		}

		public async Task<ObservableCollection<Deal>> GetDeals ()
		{
			ObservableCollection<Deal> results = new ObservableCollection<Deal> ();
			try {
				var deals = await API.GetDeals ();
				if (deals != null) {
					results = new ObservableCollection<Deal> (deals);
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}

			return results;
		}
	}
}

