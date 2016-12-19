// list.cs
// データの保存等に関わるクラスを記述

using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using PCLStorage;
using System.Threading;
using System.Threading.Tasks;


namespace AccumulationTimer
{
	interface ITimerData
	{
		string FileName { get; set}
		string Title { get; set; }
		long Time { get; set; }
		string Remark { get; set;}
	}

	public class TimerData : ITimerData, INotifyPropertyChanged
	{
		// INotifyPropertyChangedインターフェースを実装することで、プロパティの値が変更されたときに通知を行うようになる。
		private string fileName = "";
		private string title = "";
		private long time = 0;
		private string remark = "";

		// ジェネリックで全ての型に対応。refで呼び出し元に反映させる
		private void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(storage, value))
			{
				storage = value;
				OnPropertyChanged(propertyName);
			}
		}
		// プロパティの変更時に呼び出される
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public string FileName
		{
			get { return fileName; }
			set { SetProperty(ref fileName, value); }
		}

		public string Title
		{
			get{ return title; }
			set{ SetProperty(ref title, value); }
		}
		public long Time
		{
			get { return time; }
			set { SetProperty(ref time, value); }
		}
		public string Remark
		{
			get { return remark; }
			set { SetProperty(ref remark, value); }
		}


	}

	public class TimerDataHandler
	{
		static public async Task SaveTimerDataAsync(TimerData data)
		// ラムダ式使ってview側で書いた方が良いかも　<- Handlerとしての仕事の為にはこちらに書くことにした方が良いと判断
		{
			var rootFolder = FileSystem.Current.LocalStorage;
			// プラットフォーム別にルートフォルダーを取得

			var storageFolder = await rootFolder.CreateFolderAsync("Storage", CreationCollisionOption.OpenIfExists);
			// storageフォルダを作成、すでにある場合はオープン
			var file = await storageFolder.CreateFileAsync(data.Title, CreationCollisionOption.GenerateUniqueName);
			// ファイルを作成、ファイル名はtitleの文字列に依存し、被ったらユニーク名をつけてくれる。


			return;


		}
	}
}