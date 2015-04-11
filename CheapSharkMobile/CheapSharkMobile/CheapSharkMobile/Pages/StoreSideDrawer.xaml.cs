using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CheapSharkMobile
{
	public partial class StoreSideDrawer : ContentPage
	{
		public StoreSideDrawer ()
		{
			InitializeComponent ();

			this.BindViewModel<StoreSideDrawerViewModel> ();
		}
	}
}

