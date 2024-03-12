using Microsoft.AspNetCore.Mvc.Filters;

namespace filter_asp.Services
{
    public class LogActionFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public LogActionFilter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // тут покидаємо поки пустим
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            EnsureLogFileExists();
            string logMessage = $"Action Method: {context.ActionDescriptor.DisplayName} | Execution Time: {DateTime.Now}\n";
            File.AppendAllText(_logFilePath, logMessage);
        }

        private void EnsureLogFileExists()
        {
            if (!File.Exists(_logFilePath))
            {
                using (FileStream fs = File.Create(_logFilePath))
                {
                    Console.WriteLine($"Log file created at: {_logFilePath}");
                }
            }
        }
    }
}
