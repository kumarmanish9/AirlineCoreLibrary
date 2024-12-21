using Newtonsoft.Json;

namespace AirlineCoreLibrary.Utility
{
    public static class AppLogger
    {
        private static void LogError(string message)
        {
            Console.WriteLine($"\n{message}");
        }

        public static void LogError(string message, Exception ex)
        {
            LogError($"Error: {message}, ErrorMessage: {ex.Message}, StackTrace: {ex.StackTrace}, InnerException: {ex.InnerException}");
        }

        public static void LogWarning(string message, object? data = null)
        {
            if (data == null)
            {
                LogError($"Warning: {message}");
            }
            else
            {
                LogError($"Warning: {message}, Data: {JsonConvert.SerializeObject(data)}");
            }
        }

        public static void LogInfo(string message, object? data = null)
        {
            if (data == null)
            {
                LogError($"Info: {message}");
            }
            else
            {
                LogError($"Info: {message}, Data: {JsonConvert.SerializeObject(data)}");
            }
        }

    }
}
