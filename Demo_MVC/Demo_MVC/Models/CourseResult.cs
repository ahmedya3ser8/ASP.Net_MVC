namespace Demo_MVC.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public int? Course_Id { get; set; }
        public virtual Course? Course { get; set; }
        public int? Trainee_Id { get; set; }
        public virtual Trainee? Trainee { get; set; }
    }
}
