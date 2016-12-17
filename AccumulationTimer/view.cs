// view.cs
// 画面操作に関わるクラスを記述する。

using System;
using Xamarin.Forms;
using System.Threading;

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
			var yellow = new Button
			{
				Text = "Move to SecondSamplePage!",
				BackgroundColor = Color.FromHex(Colors.ButtonColor)
			};
			Content = new StackLayout
			{
				Spacing = 10,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children = { red, yellow }
			};

			yellow.Clicked += delegate
			{
				moveToSecondSamplePage();
			};

			this.Title = "RootPage";
		}
		async void moveToSecondSamplePage()
		{
			await Navigation.PushAsync(new SecondSamplePage());
		}
	}

	public class SecondSamplePage : ContentPage
	{
		public SecondSamplePage()
		{
			Padding = new Thickness(10);
			var label = new Label
			{
				Text = "This is the SecondSamplePage!",
				BackgroundColor = Color.FromHex(Colors.LabelColor)
			};
			var button = new Button
			{
				Text = "MakeNewTimer",
				BackgroundColor = Color.FromHex(Colors.ButtonColor)
			};

			button.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new NewTimerPage());
			};
			Content = new StackLayout
			{
				Spacing = 10,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children = { label, button }
			};

			this.Title = "SecondSamplePage";
		}
	}

	public class AllListPage : ListView
	{

	}

	public class NewTimerPage: ContentPage
	{
		public NewTimerPage()
		{

			var titleLabel = new Label
			{
				Text = "Title",
				BackgroundColor = Color.FromHex(Colors.LabelColor),
				HorizontalOptions = LayoutOptions.Start

			};
			var titleEntry = new Entry
			{
				Keyboard = Keyboard.Default,
				Placeholder = "Title",


			};

			var remarksLabel = new Label
			{
				BackgroundColor = Color.FromHex(Colors.LabelColor),
				Text = "Remarks",
				HorizontalOptions = LayoutOptions.Start
			};


			// editorが表示されません!! なぜ!!
			var remarksEditor = new Editor
			{
				Keyboard = Keyboard.Default,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = new StackLayout
			{
				Spacing = 30,

				Children = { titleLabel , titleEntry,remarksLabel, remarksEditor }

			};

			this.Title = "NewTimerView";
		}


	}
}