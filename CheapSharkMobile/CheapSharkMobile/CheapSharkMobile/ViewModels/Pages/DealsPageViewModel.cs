using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nito.AsyncEx;

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
			Deals = NotifyTaskCompletion.Create<ObservableCollection<Deal>> (GetDeals);
		}

		public async Task<ObservableCollection<Deal>> GetDeals ()
		{
			var deals = await API.GetDeals ();
			return new ObservableCollection<Deal> (deals);
		}
	}
}

