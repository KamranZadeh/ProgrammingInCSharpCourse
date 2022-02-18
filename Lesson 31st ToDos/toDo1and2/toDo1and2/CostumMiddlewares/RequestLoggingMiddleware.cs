using System.Diagnostics;

namespace toDo1and2.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public static Stopwatch stopWath = new();

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var stringInterpolation = "Timestamp of request : {timestamp}\r\n" +
                "Whole url of request : {fullUrl}\r\n" +
                "Http method : {method}\r\n" +
                "Response time in seconds : {responseTime}";

            var timestamp = DateTime.Now;
            var method = context.Request.Method;
            var fullUrl = context.Request?.Host.ToString() + context.Request?.Path.Value.ToString();
            var responseTime = (decimal)stopWath.ElapsedMilliseconds / 1000;

            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(stringInterpolation, timestamp, fullUrl, method, responseTime);
            }
        }
    }
}
