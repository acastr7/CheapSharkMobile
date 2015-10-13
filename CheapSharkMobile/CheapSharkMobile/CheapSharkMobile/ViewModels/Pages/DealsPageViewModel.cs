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

		private INotifyTaskCompletion<ObservableCollection<Card>> deals;

		public INotifyTaskCompletion<ObservableCollection<Card>> Deals {
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
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Card>> (GetDeals ());
			Title = "Deals";
			IsBusy = true;
			Messenger.Default.Register<RefreshDealsPageMessage> (this, RefreshPage);

		}


		public async void RefreshPage (RefreshDealsPageMessage message)
		{
			await Application.Current.SavePropertiesAsync ();
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Card>> (GetDeals ());
		}

		public async Task<ObservableCollection<Card>> GetDeals (string title = "")
		{
			IsBusy = true;
			ObservableCollection<Card> results = new ObservableCollection<Card> ();
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
					foreach (var deal in deals) {
						results.Add (new Card () { 
							Status = CardStatus.Alert, 
							Description = "Data Structures",
							DueDate = DateTime.Now.AddDays (1),
							DirationInMinutes = 45,
							StatusMessage = "1 Day left!",
							StatusMessageFileSource = StyleKit.Icons.Alert,
							ActionMessage = "Resume",
							ActionMessageFileSource = StyleKit.Icons.Resume,
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
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Card>> (GetDeals (SearchText));
		}
	}
}

