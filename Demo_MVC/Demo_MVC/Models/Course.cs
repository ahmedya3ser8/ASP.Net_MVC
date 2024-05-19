namespace Demo_MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int? Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<CourseResult> CourseResults { get; set; }
    }
}
