using System;
using Nito.AsyncEx;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CheapSharkMobile
{
	public class StoreSideDrawerViewModel : BasePageViewModel
	{
		private INotifyTaskCompletion<ObservableCollection<StoreCellViewModel>> stores;

		public INotifyTaskCompletion<ObservableCollection<StoreCellViewModel>> Stores {
			get { return stores; }
			set { Set (() => Stores, ref stores, value); }
		}

		readonly CheapSharkAPI API;

		public StoreSideDrawerViewModel (CheapSharkAPI api)
		{
			Title = "Stores";
			API = api;
			Stores = NotifyTaskCompletion.Create<ObservableCollection<StoreCellViewModel>> (GetStores);

		}

		public async Task<ObservableCollection<StoreCellViewModel>> GetStores ()
		{
			ObservableCollection<StoreCellViewModel> results = new ObservableCollection<StoreCellViewModel> ();
			try {
				var stores = await API.GetStores ();
				foreach (var store in stores) {
					var model = new StoreCellViewModel ();
					model.StoreName = store.StoreName;
					model.StoreId = store.StoreId;
					var filters = Application.Current.Properties ["StoreFilters"] as Dictionary<int,bool>;
					foreach (var filter in filters) {
						if (filter.Value) {
							model.On = filter.Value;
						}
					}
					results.Add (model);
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}

			return results;
		}
	}
}

