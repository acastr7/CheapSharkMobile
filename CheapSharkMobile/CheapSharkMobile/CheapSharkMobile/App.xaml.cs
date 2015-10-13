using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace CheapSharkMobile
{
	public  class App : Application
	{
		public  App ()
		{
			SetupDefaults ();
			SetupGlobalStyles ();
			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);

			Bootstrap.Run ();
			// The root page of your application
			MainPage = new RootPage ();
		}

		protected override void OnStart ()
		{

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		void SetupGlobalStyles ()
		{
			Application.Current.Resources = new ResourceDictionary ();
			Application.Current.Resources.Add ("UriImageSouceConverter", new UriImageSouceConverter ()); // use the "AppStyle" key in the app
			Application.Current.Resources.Add ("InverseBool", new InverseBool ());

		}

		void SetupDefaults ()
		{
			Application.Current.Properties ["StoreFilters"] = new Dictionary<int,bool> ();
			Application.Current.Properties ["lowerPrice"] = 0;
			Application.Current.Properties ["upperPrice"] = 50;
			Application.Current.Properties ["metacritic"] = 0;
			Application.Current.Properties ["aaa"] = false;
			Application.Current.Properties ["steamworks"] = false;
			Application.Current.Properties ["onSale"] = false;
		}
			
	}
}
