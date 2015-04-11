using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CheapSharkMobile
{
	public partial class FilterPage : ContentPage, IModalPage
	{
		public FilterPage ()
		{
			InitializeComponent ();

			this.BindViewModel<FilterPageViewModel> ();
		}
	}
}

