using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ExceptionController : ControllerBase
	{
		[HttpGet("Case1")]
		public string Test1()
		{
			var a = 1;
			var b = 0;
			var result = a / b;
			return $"Result : {result}";
		}

		[HttpGet("Case2")]
		public string Case2()
		{
			try
			{
				var a = 1;
				var b = 0;
				var result = a / b;
				return $"Result : {result}";
			}
			catch (Exception)
			{
				return "Did you see any errors? They should be somewhere on here.";
			}
		}
	}
}