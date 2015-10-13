using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CheapSharkMobile
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			InitializeComponent ();

			Detail = new NavigationPage (new DealsPage ());
		}
	}
}

