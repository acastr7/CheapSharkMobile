using System;
using GalaSoft.MvvmLight.Ioc;

namespace CheapSharkMobile.iOS
{
	public static class Bootstrap
	{
		public static void Run ()
		{
			SimpleIoc.Default.Register<ISQLite,SQLite_iOS> ();
		}
	}
}

