﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo_MVC.Filter
{
	public class MyFilter : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			Console.WriteLine("OnActionExecuted");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			Console.WriteLine("OnActionExecuting");
		}
	}
}
