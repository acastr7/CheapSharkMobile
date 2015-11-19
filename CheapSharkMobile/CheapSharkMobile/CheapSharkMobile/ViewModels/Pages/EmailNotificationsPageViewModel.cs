using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin;

namespace CheapSharkMobile
{
	public class EmailNotificationsPageViewModel : BasePageViewModel
	{
		RelayCommand doneCommand;

		public RelayCommand DoneCommand {
			get {
				return doneCommand ?? (doneCommand = new RelayCommand (delegate {
					Navigation.GoBack ();
				}));
			}
		}

		private string price;

		public string Price {
			get { return price; }
			set { Set (() => Price, ref price, value); }
		}

		private string email;

		public string Email {
			get { return email; }
			set { Set (() => Email, ref email, value); }
		}

		private FormattedString gameName;

		public FormattedString GameName {
			get { return gameName; }
			set { Set (() => GameName, ref gameName, value); }
		}

		RelayCommand submitEmailNotificationsCommand;

		public RelayCommand SubmitEmailNotificationsCommand {
			get {
				return submitEmailNotificationsCommand ?? (submitEmailNotificationsCommand = new RelayCommand (async delegate {
					await HandleSubmit ();
				}));
			}
		}

		readonly INavigationService Navigation;
		readonly CheapSharkAPI Api;
		readonly IDialogService DialogService;

		int GameId { get; set; }

		public EmailNotificationsPageViewModel (INavigationService navigation, CheapSharkAPI api, IDialogService dialogService)
		{
			Title = "Price Notifications";
			Navigation = navigation;
			Api = api;
			DialogService = dialogService;
		}

		public void Init (int gameId, string gameName)
		{
			var gameTitle = new FormattedString ();
			gameTitle.Spans.Add (new Span {
				Text = "To get price alerts via email for "
			});
			gameTitle.Spans.Add (new Span {
				Text = " " + gameName,
				FontAttributes = FontAttributes.Bold
			});
			gameTitle.Spans.Add (new Span {
				Text = " fill out the information below.."
			});
			GameId = gameId;
			GameName = gameTitle;
		}

		async Task HandleSubmit ()
		{
			decimal tempPrice = 0;
			if (!decimal.TryParse (Price, out tempPrice)) {
				await DialogService.ShowMessage ("Invalid Price Format.", "Error");
				return;
			}

			bool result = false;
			try {
				if (!string.IsNullOrEmpty (Email)) {
					Insights.Identify (Email, Insights.Traits.Email, Email);
				}
				result = await Api.SetAlert (Email, GameId, tempPrice);
			} catch (Exception ex) {
				Insights.Report (ex);
				// await DialogService.ShowMessage ("Could not submit request at this time.", "Error");
				Navigation.GoBack ();
				return;
			}

			if (result) {
				Navigation.GoBack ();
			} else {
				await DialogService.ShowMessage ("Please provide valid email and price", "Error");
			}
		}
	}
}

