using System;
using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CheapSharkMobile
{
	public static class ViewModelBinder
	{
		public static TViewModel BindViewModel<TViewModel> (this BindableObject bindable)
			where TViewModel : ViewModelBase
		{
			if (!SimpleIoc.Default.IsRegistered<TViewModel> ()) {
				SimpleIoc.Default.Register<TViewModel> ();
			}

			var viewModel = ServiceLocator.Current.GetInstance<TViewModel> ();

			bindable.BindingContext = viewModel;

			return viewModel;
		}

		public static TViewModel GetViewModel<TViewModel> (this BindableObject bindable)
		{
			return ServiceLocator.Current.GetInstance<TViewModel> ();
		}
	}
}

