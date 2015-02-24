using System;

namespace UltimateTasksManager
{
	public enum TaskPriority {
		Low = 1,
		Medium = 2,
		High = 3
	};

	public class TaskEntity
	{
		public nint Id { get; set; }
		public string Title { get; set; }
		public TaskPriority Priority { get; set; }
		public DateTime DueDate { get; set; }
		public bool State { get; set; }
	}
}