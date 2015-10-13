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

		public MasterDetailPage MainPage {
			get {
				return (MasterDetailPage)Application.Current.MainPage;
			}
		}

		public NavigationService ()
		{
			Pages = new Dictionary<string, Type> ();
			Pages.Add ("DealsDetailPage", typeof(DealsDetailPage));
			Pages.Add ("FilterPage", typeof(FilterPage));

		}

		#region INavigationService implementation

		public void GoBack ()
		{
			if (MainPage.Navigation.ModalStack.Count > 0) {
				MainPage.Navigation.PopModalAsync ();
			} else {
				MainPage.Navigation.PopAsync ();
			}
		}

		public void NavigateTo (string pageKey)
		{
			NavigateTo (pageKey, null);
		}

		public void NavigateTo (string pageKey, object parameter)
		{
			try {
				object[] parameters = null;
				if (parameter != null) {
					parameters = new object[]{ parameter };
				}
				Page displayPage = (Page)Activator.CreateInstance (Pages [pageKey], parameters);
				_currentPageKey = pageKey;
				var isModal = displayPage is IModalPage;
				if (isModal) {
					MainPage.Detail.Navigation.PushModalAsync (new NavigationPage (displayPage));
				} else {
					MainPage.Detail.Navigation.PushAsync (displayPage);
				}
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

