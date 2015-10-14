using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CheapSharkMobile
{
	public partial class EmailNotificationsModal : ContentPage, IModalPage
	{

		public EmailNotificationsModal (string gameName, int gameId)
		{
			InitializeComponent ();
			var viewModel = this.BindViewModel<EmailNotificationsPageViewModel> ();
			viewModel.Init (gameId, gameName);

		}
	}
}

