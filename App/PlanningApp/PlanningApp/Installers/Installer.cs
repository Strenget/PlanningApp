using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PlanningApp.ViewModels;
using PlanningApp.Views;


namespace PlanningApp.Installers
{
	public class Installer : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<MainWindowView>().LifestyleSingleton());
			container.Register(Component.For<MainWindowViewModel>().LifestyleSingleton());
			container.Register(Component.For<CardViewModel>());
		}
	}
}
