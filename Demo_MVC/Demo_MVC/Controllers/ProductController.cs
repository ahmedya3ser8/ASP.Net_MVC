using Demo_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class ProductController : Controller
    {
        // Action
            //can't be private
            //can't be static
            //can't be overload

        // Type Action can return
            // Content --> string --> ContentResult
            // View --> html --> ViewResult
            // JavaScript --> JavaScriptResult
            // Json --> JsonResult
            // NotFound --> NotFoundResult
            // File --> FileResult

        // URL --> product/ShowMsg
        public ContentResult ShowMsg()
        {
            ContentResult result = new ContentResult();
            result.Content = "Msg1";
            return result;
        }
        // URL --> product/ShowView
        public ViewResult ShowView()
        {
            ViewResult result = new ViewResult();
            result.ViewName = "View1";
            return result;
        }
        public JsonResult ShowJson()
        {
            JsonResult result = new JsonResult(new {Id = 1, Name = "ahmed"});
            return result;
        }
        // URL --> product/ShowMix/2
        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
            {
                return Content("Hello Guest!1");
            }
            else
            {
                return View("View1");
            }
        }

        ProductSampleData sampleData = new ProductSampleData();
        
        // URL --> product/Details
        public IActionResult Details(int id)
        {
            Product productModel =  sampleData.GetById(id);
            return View("ProductDetails", productModel);
        }

		// URL --> product/Index
		public IActionResult Index()
        {
            List<Product> productsList = sampleData.GetAll();
            return View("ShowAll", productsList);
        }
    }
}
