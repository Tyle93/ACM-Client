using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.Maui.Controls.Compatibility.Platform.UWP;
using ACM.Models;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new MainPage();
	}
}
