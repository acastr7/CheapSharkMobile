using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace CheapSharkMobile
{
	public class App : Application
	{
		public App ()
		{
			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);

			Bootstrap.Run ();
			// The root page of your application
			MainPage = new DealsPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
