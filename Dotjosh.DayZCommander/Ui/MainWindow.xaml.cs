﻿using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using Dotjosh.DayZCommander.Core;
using Application = System.Windows.Application;
using Control = System.Windows.Controls.Control;

namespace Dotjosh.DayZCommander.Ui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new MainWindowViewModel();
//Causes UAC Crashes
//			var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
//			MaxHeight = screen.WorkingArea.Height;

		}

		private MainWindowViewModel ViewModel
		{
			get { return ((MainWindowViewModel) DataContext); }
		}

		private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void CloseButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MainWindow_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if(e.OriginalSource != VisualRoot)
				return;

			ToggleMaximized();
		}

		private void ToggleMaximized()
		{
			if(WindowState == WindowState.Normal)
			{
				//UAC Crash
//				var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
//				MaxHeight = screen.WorkingArea.Height;
				WindowState = WindowState.Maximized;
			}
			else
			{
				WindowState = WindowState.Normal;
			}
		}

		private void RefreshAll_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ServerList.UpdateAll();
		}



		private void TabHeader_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.CurrentTab = (ViewModelBase) ((Control) sender).DataContext;
		}
	}
}
