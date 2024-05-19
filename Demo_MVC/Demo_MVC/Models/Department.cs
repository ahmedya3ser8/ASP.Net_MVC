﻿namespace Demo_MVC.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ManagerName { get; set; }
		public virtual List<Employee> Employees { get; set; }
		public virtual List<Instructor> Instructors { get; set; }
		public virtual List<Course> Courses { get; set; }
		public virtual List<Trainee> Trainees { get; set; }
	}
}
