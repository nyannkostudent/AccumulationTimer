// view.cs
// 画面操作に関わるクラスを記述する。

using System;
using Xamarin.Forms;

namespace AccumulationTimer
{
	public class Colors
	{
		// アプリ全体の色彩コードを記録する。
		// from "hue360"
		public static string BackgroundColor = "#FFFFFF";
		public static string TextColor = "#333333";
		public static string ButtonColor = "#97D3E3";
		public static string LabelColor = "#F9E3AA";
		public static string NavigationBarColor = "#97D3E3";

	}

	public class RootPage : ContentPage
	{
		public RootPage()
		{
			Padding = new Thickness(30);
			var red = new Label
			{
				Text = "This is the first example!",
				BackgroundColor = Color.FromHex(Colors.LabelColor),

			};
			var yellow = new Label
			{
				Text = "This is the second Label",
				BackgroundColor = Color.FromHex(Colors.LabelColor)
			};
			Content = new StackLayout
			{
				Spacing = 10,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children = { red, yellow }
			};

		}
	}
}