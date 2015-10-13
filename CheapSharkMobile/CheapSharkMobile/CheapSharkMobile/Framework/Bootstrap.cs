using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace CheapSharkMobile
{
	public static class Bootstrap
	{
		public static void Run ()
		{
			SimpleIoc.Default.Register<INavigationService, NavigationService> ();
			SimpleIoc.Default.Register<IDialogService, DialogService> ();
			SimpleIoc.Default.Register<CheapSharkAPI> ();
		}
	}
}

