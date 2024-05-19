namespace Demo_MVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int? Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public int? Course_Id { get; set; }
        public virtual Course? Course { get; set; }
    }
}
