using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nito.AsyncEx;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;

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

		string searchText;

		public string SearchText {
			get{ return searchText; }
			set {
				Set (() => SearchText, ref searchText, value);
				if (string.IsNullOrEmpty (value)) {
					Search ();
				}
			}
		}

		RelayCommand searchCommand;

		public RelayCommand SearchCommand {
			get {
				return searchCommand ?? (searchCommand = new RelayCommand (Search));
			}
		}

		RelayCommand filterCommand;

		public RelayCommand FilterCommand {
			get {
				return filterCommand ?? (filterCommand = new RelayCommand (delegate {
					Navigation.NavigateTo ("FilterPage");
				}));
			}
		}

		readonly INavigationService Navigation;

		public DealsPageViewModel (CheapSharkAPI api, INavigationService navigation)
		{
			API = api;
			Navigation = navigation;
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Deal>> (GetDeals ());
			Title = "Deals";
			IsBusy = true;
			Messenger.Default.Register<RefreshDealsPageMessage> (this, RefreshPage);

		}


		public async void RefreshPage (RefreshDealsPageMessage message)
		{
			await Application.Current.SavePropertiesAsync ();
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Deal>> (GetDeals ());
		}

		public async Task<ObservableCollection<Deal>> GetDeals (string title = "")
		{
			IsBusy = true;
			ObservableCollection<Deal> results = new ObservableCollection<Deal> ();
			try {
				var filters = Application.Current.Properties ["StoreFilters"] as Dictionary<int,bool>;
				List<string> storeIds = new List<string> ();
				foreach (var store in filters) {
					if (store.Value) {
						storeIds.Add (store.Key.ToString ());
					}
				}
				int lowerPrice = (int)Application.Current.Properties ["lowerPrice"];
				int upperPrice = (int)Application.Current.Properties ["upperPrice"];
				int metacritic = (int)Application.Current.Properties ["metacritic"];
				bool tripleA = (bool)Application.Current.Properties ["aaa"];
				bool steamworks = (bool)Application.Current.Properties ["steamworks"];
				bool onsale = (bool)Application.Current.Properties ["onSale"];

				var deals = await API.GetDeals (storeID: storeIds, lowerPrice: lowerPrice, upperPrice: upperPrice, title: title, metacritic: metacritic, tripleA: tripleA, steamworks: steamworks, onSale: onsale);
				if (deals != null) {
					results = new ObservableCollection<Deal> (deals);
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
			IsBusy = false;
			return results;
		}

		public void Search ()
		{
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Deal>> (GetDeals (SearchText));
		}
	}
}

