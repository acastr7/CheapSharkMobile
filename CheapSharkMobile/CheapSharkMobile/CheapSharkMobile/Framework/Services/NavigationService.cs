using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace CheapSharkMobile
{
	public class NavigationService : INavigationService
	{
		Dictionary<string, Type> Pages{ get; set; }

		string _currentPageKey;

		public Page MainPage {
			get {
				return Application.Current.MainPage;
			}
		}

		public NavigationService ()
		{
			Pages = new Dictionary<string, Type> ();
			Pages.Add ("DealsDetailPage", typeof(DealsDetailPage));
		}

		#region INavigationService implementation

		public void GoBack ()
		{
			MainPage.Navigation.PopAsync ();
		}

		public void NavigateTo (string pageKey)
		{
			NavigateTo (pageKey, null);
		}

		public void NavigateTo (string pageKey, object parameter)
		{
			try {
				Page displayPage = (Page)Activator.CreateInstance (Pages [pageKey], new object[]{ parameter });
				_currentPageKey = pageKey;
				MainPage.Navigation.PushAsync (displayPage);
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		public string CurrentPageKey {
			get {
				return _currentPageKey;
			}
		}

		#endregion
	}
}

