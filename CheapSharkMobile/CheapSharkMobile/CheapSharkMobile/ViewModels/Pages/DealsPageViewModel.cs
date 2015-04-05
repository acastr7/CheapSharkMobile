using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nito.AsyncEx;
using System.Diagnostics;

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

		public DealsPageViewModel (CheapSharkAPI api)
		{
			API = api;
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

