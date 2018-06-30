using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace PlanningApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			DispatcherUnhandledException += CurrentDomainOnUnhandledException;
			AppDomain.CurrentDomain.AssemblyResolve += AppDomainOnAssemblyResolve;
		}

		private void CurrentDomainOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			File.AppendAllText("CrashLog.txt", string.Format("[{0:G}] {1}{2}", DateTime.Now, e.Exception, Environment.NewLine));
		}

		private Assembly AppDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			// zabrani vyhazovani vyjimek pri startu Kiwi v debuggeru
			if (args.Name.Contains(".XmlSerializers")) return typeof(Type).Assembly;
			return null;
		}
	}
}