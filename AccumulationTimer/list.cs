// list.cs
// データの保存等に関わるクラスを記述

using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using PCLStorage;


namespace AccumulationTimer
{
	interface ITimerData
	{
		string Title { get; set; }
		long Time { get; set; }
		string Remark { get; set;}
	}

	public class TimerData : ITimerData, INotifyPropertyChanged
	{
		// INotifyPropertyChangedインターフェースを実装することで、プロパティの値が変更されたときに通知を行うようになる。
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
}