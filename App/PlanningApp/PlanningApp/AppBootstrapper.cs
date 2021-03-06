﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using Caliburn.Micro;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PlanningApp.Properties;
using PlanningApp.ViewModels;


namespace PlanningApp
{

	public class AppBootstrapper : BootstrapperBase
	{
		private WindsorContainer _container;

		public AppBootstrapper()
		{
			Initialize();
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			InitializeCulture();
			DisplayRootViewFor<MainWindowViewModel>();
		}

		protected override void Configure()
		{
			_container = new WindsorContainer();

			_container.AddFacility<TypedFactoryFacility>();
			_container.AddFacility<LoggingFacility>(x => x.LogUsing<NLogFactory>().WithAppConfig());

			_container.Register(Component.For<IEventAggregator>().ImplementedBy<EventAggregator>());
			_container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());

			_container.Install(FromAssembly.This());
		}

		protected override object GetInstance(Type service, string key)
		{

			return string.IsNullOrWhiteSpace(key) ? _container.Resolve(service) : _container.Resolve(key, service);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.ResolveAll(service).Cast<object>();
		}

		protected override void BuildUp(object instance)
		{
			instance.GetType().GetProperties()
				.Where(property => property.CanWrite && property.PropertyType.IsPublic)
				.Where(property => _container.Kernel.HasComponent(property.PropertyType))
				.ToList().ForEach(property => property.SetValue(instance, _container.Resolve(property.PropertyType), null));
		}

		private void InitializeCulture()
		{
			var cultureName = Settings.Default.Culture;
			var culture = new CultureInfo(cultureName);
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
			var lang = XmlLanguage.GetLanguage(cultureName);
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(lang));
			FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(TextElement), new FrameworkPropertyMetadata(lang));
		}
	}

}
