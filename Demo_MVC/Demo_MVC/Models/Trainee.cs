namespace Demo_MVC.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Level { get; set; }
        public int? Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<CourseResult> CourseResults { get; set; }
    }
}
