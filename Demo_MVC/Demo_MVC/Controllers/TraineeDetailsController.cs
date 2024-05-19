using Demo_MVC.Models;
using Demo_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class TraineeDetailsController : Controller
    {
		/*
         * Trainee
         * CourseResult
         * Course
         * Result --> TraineeId, TraineeName, CourseName, MinDegree, Degree
        */

		AppDbContext dbContext = new AppDbContext();
        public IActionResult Details(int id)
        {
            /*
            var result = from c in dbContext.Courses
                         join cr in dbContext.CourseResults
                         on c.Id equals cr.Course_Id
                         join t in dbContext.Trainees
                         on cr.Trainee_Id equals t.Id
                         select new
                         {
                             traineeId = t.Id,
                             traineeName = t.Name,
                             courseName = c.Name,
                             minDegree = c.MinDegree,
                             degree = c.Degree
                         };
            */

            Trainee trainees = dbContext.Trainees.FirstOrDefault(t => t.Id == id);
            Course courses = dbContext.Courses.FirstOrDefault(c => c.Id == id);

            TraineeWithCourseViewModel viewModel = new TraineeWithCourseViewModel();

            viewModel.TraineeId = trainees.Id;
            viewModel.TraineeName = trainees.Name;
            viewModel.CousreName = courses.Name;
            viewModel.MinDegree = courses.MinDegree;
            viewModel.Degree = courses.Degree;

            return View(viewModel);
        }
    }
}
