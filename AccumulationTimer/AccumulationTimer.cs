using System;

using Xamarin.Forms;

namespace AccumulationTimer
{
	public class App : Application
	{


		public App()
		{
			// The root page of your application

			// 参照　-> http://ytabuchi.hatenablog.com/entry/2015/06/24/135407
			// NavigationBarの設定を変更するには、それぞれのOSごとに設定を変えなければいけない。
			var nav = new NavigationPage(new RootPage());
			//nav.BarBackgroundColor = Color.FromHex(Colors.BackgroundColor);
			//nav.BarTextColor = Color.FromHex("#333333");
			MainPage = nav;

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
