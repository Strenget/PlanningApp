namespace PlanningApp.ViewModels
{
	public class CardViewModel
	{
		public CardViewModel(string info, string nameOfTask, string nameOfDeveloper, int points)
		{
			Info = info;
			NameOfTask = nameOfTask;
			NameOfDeveloper = nameOfDeveloper;
			Points = points;
		}

		public string Info { get; set; }
		public string NameOfTask { get; set; }
		public string NameOfDeveloper { get; set; }
		public int Points { get; set; }

	}
}
