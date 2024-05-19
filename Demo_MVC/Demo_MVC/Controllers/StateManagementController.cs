using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class StateManagementController : Controller
    {
        /*
         * TempData --> Default Stored In Cookies
         * Session  --> Server --> Read Any Actions -- Views
         * Cookies  --> Client
         * QueryString
         * HiddenField
        */

        // TempData
        public IActionResult SetTempData()
        {
            TempData["msg"] = "Message Say Hello";
            return Content("Data Save");
        }
        public IActionResult GetTempData()
        {
            string message = TempData["msg"].ToString();
            return Content(message);
        }
        public IActionResult GetTempData2()
        {
            string message = TempData["msg"].ToString();
            return Content("get2" + message);
        }

        /*
         * TempData.Peek()
         * TempData.Keep()
         * TempData --> Stored in Session --> in program
         * builder.Services.AddControllersWithView().AddSessionStateTempDataProvider();
        */

        // Session
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "ahmed");
            HttpContext.Session.SetInt32("age", 22);
            return Content("Session Data Saved");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int age = HttpContext.Session.GetInt32("age").Value;
            return Content($"name={name} - age={age}");
        }

        // Cookies
        public IActionResult SetCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddHours(1);

            Response.Cookies.Append("name", "ahmed", cookieOptions);
            Response.Cookies.Append("age", "23", cookieOptions);
            return Content("Cookie Saved");
        }
        public IActionResult GetCookie()
        {
            string name = Request.Cookies["name"];
            int age = int.Parse(Request.Cookies["age"]);
            return Content($"name={name} - age={age}");
        }
    }
}
