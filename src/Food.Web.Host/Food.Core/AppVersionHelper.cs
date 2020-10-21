using System;
using System.IO;
using Abp.Reflection.Extensions;

namespace Food
{
    /// <summary>
    /// Central point for application version.
    /// </summary>
    public class AppVersionHelper
    {
        public static readonly string Version = $"1.0.{Year}-{Month}-{Day}";
        private const string Year = "2020";
        private const string Month = "10";
        private const string Day = "21";
        /// <summary>
        /// Gets release (last build) date of the application.
        /// It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate => LzyReleaseDate.Value;

        private static readonly Lazy<DateTime> LzyReleaseDate = new Lazy<DateTime>(() =>
            new FileInfo(typeof(AppVersionHelper).GetAssembly().Location).LastWriteTime);
    }
}
