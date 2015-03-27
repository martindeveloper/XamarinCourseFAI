using System;

namespace UltimateTasksManager.Model
{
	public enum TaskPriority {
		Low = 1,
		Medium = 2,
		High = 3
	};

	public class TaskEntity : ICloneable
	{
		[SQLite.PrimaryKey(), SQLite.AutoIncrement()]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TaskPriority Priority { get; set; }
		public DateTime DueDate { get; set; }
		public bool State { get; set; }
		public string Location { get; set; }

		public object Clone()
		{
			return MemberwiseClone ();
		}

		public void CopyDataFromTaskEntity (TaskEntity source)
		{
			Id = source.Id;
			Title = source.Title;
			Description = source.Description;
			Priority = source.Priority;
			DueDate = source.DueDate;
			State = source.State;
			Location = source.Location;
		}
	}
}