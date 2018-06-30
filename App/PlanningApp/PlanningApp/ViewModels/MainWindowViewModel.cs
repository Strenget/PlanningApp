using Caliburn.Micro;

namespace PlanningApp.ViewModels
{
	public class MainWindowViewModel : Screen
	{


		

		public MainWindowViewModel()
		{
			ToDo = new BindableCollection<CardViewModel>();
		}


		public BindableCollection<CardViewModel> ToDo { get; set; }
		public BindableCollection<CardViewModel> InProgessing { get; set; }
		public BindableCollection<CardViewModel> InReview { get; set; }
		public BindableCollection<CardViewModel> Reviewd { get; set; }
		public BindableCollection<CardViewModel> Done { get; set; }


		public void TaskAdd()
		{
			ToDo.Add(new CardViewModel("Info", "NK-2", "Nikita", 3));
		}

	}
}
