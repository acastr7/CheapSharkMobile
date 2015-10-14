using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class DialogService : IDialogService
	{
		public Page CurrentPage { get { return Application.Current.MainPage; } }

		public DialogService ()
		{
		}

		#region IDialogService implementation

		public System.Threading.Tasks.Task ShowError (string message, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task ShowError (Exception error, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task ShowMessage (string message, string title)
		{
			return CurrentPage.DisplayAlert (title, message, "Ok");
		}

		public System.Threading.Tasks.Task ShowMessage (string message, string title, string buttonText, Action afterHideCallback)
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task<bool> ShowMessage (string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task ShowMessageBox (string message, string title)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

