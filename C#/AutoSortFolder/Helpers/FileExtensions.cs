using System.Collections.Generic;

namespace AutoSortFolder
{
    public class FileExtensions
    {
        public static readonly Dictionary<string, string[]> Extensions = new Dictionary<string, string[]> {
            { "text", new string[] { ".txt", ".doc", ".docx", ".rtf", ".tex", ".wpd", ".wp5" } },
            { "document", new string[] { ".pdf", ".key", ".odp", ".pps", ".ppt", ".pptx", ".potx", ".potm", ".pot", ".ppam", ".ppsm", ".ppsx" } },
            { "audio", new string[] { ".aif", ".aifc", ".aiff", ".cda", ".mid", ".midi", ".mp3", ".mpa", ".ogg", ".wav", ".wma", ".wpl", ".aac", ".adt", ".adts" } },
            { "compressed", new string[] { ".7z", ".arg", ".deb", ".pkg", ".rar", ".rpm", ".gz", ".z", ".zip" } },
            { "disc", new string[] { ".bin", ".dmg", ".iso", ".toast", ".vcd" } },
            { "data", new string[] { ".csv", ".dat", ".db", ".dbf", ".log", ".mdb", ".sav", ".sql", ".tar", ".xml", ".ab", ".accdb", ".accde", ".accdr", ".accdt" } },
            { "email", new string[] { ".email", ".eml", ".emlx", ".msg", ".oft", ".ost", ".pst", ".vcf" } },
            { "executable", new string[] { ".apk", ".bat", ".bin", ".com", ".exe", ".gadget", ".jar", ".msi", ".wsf" } },
            { "font", new string[] { ".fnt", ".fon", ".otf", ".ttf" } },
            { "image", new string[] { ".jpg", ".jpeg", ".JPG", ".JPEG", ".gif", ".bmp", ".ico", ".png", ".ps", ".svg", ".tif", ".tiff" } },
            { "internet", new string[] { ".asp", ".aspx", ".cer", ".cfm", ".css", ".htm", ".html", ".js", ".jsp", ".part", ".rss", ".xhtml" } },
            { "programming", new string[] { ".c", ".cgi", ".pl", ".class", ".cpp", ".cs", ".h", ".java", ".php", ".py", ".sh", ".swift", ".vb" } },
            { "spreadsheet", new string[] { ".ods", ".xls", ".xlsm", ".xlt", ".xltm", ".xlsx" } },
            { "system", new string[] { ".bak", ".cab", ".cfg", ".cpl", ".cur", ".dll", ".dmp", ".drv", ".icns", ".ini", ".lnk", ".sys", ".tmp" } },
            { "video", new string[] { ".3g2", ".3gp", ".avi", ".flv", ".h264", ".m4v", ".mkv", ".mov", ".mp4", ".mpg", ".mpeg", ".rm", ".swf", ".vob", ".wmv" } },
            { "adobe", new string[] { ".ai", ".psd", ".indd", ".prproj", ".aep" } }
        };
    }
}
