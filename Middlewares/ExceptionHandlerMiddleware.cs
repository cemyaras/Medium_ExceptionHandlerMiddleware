using System.Net;

namespace Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;
		public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next.Invoke(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext,ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
		{
			_logger.LogError($"Date:{DateTime.Now.ToString("u")}, Exception:{ex.Message}");
			await httpContext.Response.WriteAsJsonAsync(new
			{
				StatusCode = HttpStatusCode.InternalServerError,
				Message = ex.Message
			});
		}
	}
}
