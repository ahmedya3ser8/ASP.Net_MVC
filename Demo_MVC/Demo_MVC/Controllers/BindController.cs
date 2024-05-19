using Demo_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class BindController : Controller
	{
		/*
		 * Model Binding
		 * Retrive Data From Client(html)
		 * Client ----- Server
		 * Form --> Get --> QueryString  || Post --> FormData(Req Body)
		 * Anchor Tag --> <a href="department/details/1"></a>
		 * Ajax  --> Jquery | JS
		 * Model Binding : Map Action Parameter With Request Data (FormData, QueryString, Route)
		 * Default int = 0 || string = null
		*/

		// Bind/testPrimitive/1?name=ahmed
		// Bind/testPrimitive?id=1&name=ahmed&color=red&color=blue
		public IActionResult testPrimitive(int id, string name, string[] color)
		{
			return Content($"id ={id} - name ={name}");
		}
		// Bind/testPrimitive?name=ahmed&phones[ahmed]=123&phones[ali]=456
		public IActionResult testDictionary(Dictionary<string, int> phones, string name)
		{
			return Content($"name ={name}");
		}
		// Bind/testPrimitive?id=1&name=ahmed
		public IActionResult testComplex([Bind(include:"id,name")]Department dept)
		{
			return Content("Ok");
		}
	}
}
