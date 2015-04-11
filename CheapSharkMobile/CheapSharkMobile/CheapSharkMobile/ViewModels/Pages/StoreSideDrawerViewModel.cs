using System;
using Nito.AsyncEx;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

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
					results.Add (model);
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}

			return results;
		}
	}
}

