using System;
using GalaSoft.MvvmLight.Views;

namespace CheapSharkMobile
{
	public class NavigationService : INavigationService
	{
		public NavigationService ()
		{
		}

		#region INavigationService implementation

		public void GoBack ()
		{
			throw new NotImplementedException ();
		}

		public void NavigateTo (string pageKey)
		{
			throw new NotImplementedException ();
		}

		public void NavigateTo (string pageKey, object parameter)
		{
			throw new NotImplementedException ();
		}

		public string CurrentPageKey {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

