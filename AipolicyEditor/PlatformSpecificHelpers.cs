using System;
using System.Runtime.Versioning;

namespace AipolicyEditor
{
    /// <summary>
    /// Platform-specific helper methods to centralize platform checking
    /// </summary>
    public static class PlatformSpecificHelpers
    {
        /// <summary>
        /// Shows a message with platform check
        /// </summary>
        [SupportedOSPlatform("windows7.0")]
        public static void ShowMessage(string message, string title = "AipolicyEditor", bool isMarkdown = false)
        {
            Utils.ShowMessage(message, title, isMarkdown);
        }

        /// <summary>
        /// Gets the application startup path with platform check
        /// </summary>
        [SupportedOSPlatform("windows6.1")]
        public static string GetStartupPath()
        {
            return System.Windows.Forms.Application.StartupPath;
        }
    }
} 