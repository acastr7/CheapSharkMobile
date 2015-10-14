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
using System.Linq;

namespace CheapSharkMobile
{
	public class DealsPageViewModel : BasePageViewModel
	{
		CheapSharkAPI API;

		private INotifyTaskCompletion<ObservableCollection<CardViewModel>> deals;

		public INotifyTaskCompletion<ObservableCollection<CardViewModel>> Deals {
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
			Deals = NotifyTaskCompletion.Create<ObservableCollection<CardViewModel>> (GetDeals ());
			Title = "Deals";
			IsBusy = true;
			Messenger.Default.Register<RefreshDealsPageMessage> (this, RefreshPage);

		}


		public async void RefreshPage (RefreshDealsPageMessage message)
		{
			await Application.Current.SavePropertiesAsync ();
			Deals = NotifyTaskCompletion.Create<ObservableCollection<CardViewModel>> (GetDeals ());
		}

		public async Task<ObservableCollection<CardViewModel>> GetDeals (string title = "")
		{
			IsBusy = true;
			ObservableCollection<CardViewModel> results = new ObservableCollection<CardViewModel> ();
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
					var stores = await API.GetStores ();
					foreach (var deal in deals) {

						var store = stores.FirstOrDefault (x => x.StoreId == deal.StoreID);
						results.Add (new CardViewModel { 
							Description = store == null ? string.Empty : store.StoreName,
							MetaCriticScore = deal.MetacriticScore,
							ReleaseDate = deal.ReleaseDate,
							Price = deal.SalePrice.ToString ("C"),
							DealUrl = string.Format ("http://www.cheapshark.com/redirect?dealID={0}", deal.DealID),
							GameImage = deal.Thumb,
							Title = new FormattedString () {
								Spans = {
									new Span () {
										Text = deal.Title
									}
								}
							} 
						});
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
			IsBusy = false;
			return results;
		}

		public void Search ()
		{
			Deals = NotifyTaskCompletion.Create<ObservableCollection<CardViewModel>> (GetDeals (SearchText));
		}
	}
}

