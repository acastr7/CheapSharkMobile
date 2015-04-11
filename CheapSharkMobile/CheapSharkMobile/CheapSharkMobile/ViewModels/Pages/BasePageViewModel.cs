using System;
using GalaSoft.MvvmLight;

namespace CheapSharkMobile
{
	public abstract class BasePageViewModel : ViewModelBase
	{
		private bool isBusy;

		public bool IsBusy {
			get { return isBusy; }
			set { Set (() => IsBusy, ref isBusy, value); }
		}

		private string title;

		/// <summary>
		/// Gets or sets the "Title" property
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get { return title; }
			set { Set (() => Title, ref title, value); }
		}

		private string subTitle;

		/// <summary>
		/// Gets or sets the "Subtitle" property
		/// </summary>
		public string Subtitle {
			get { return subTitle; }
			set { Set (() => Subtitle, ref subTitle, value); }
		}

		private string icon = null;

		/// <summary>
		/// Gets or sets the "Icon" of the viewmodel
		/// </summary>

		public string Icon {
			get { return icon; }
			set { Set (() => Icon, ref icon, value); }
		}

	}
}

