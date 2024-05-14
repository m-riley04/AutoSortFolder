using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class AnchorVerifier
    {
        public AnchorVerifier() { }

        public static bool FoldersMatch(string anchorPath, string originalPath, bool sorted = false)
        {
            int totalOriginal;
            int totalAnchor;

            totalOriginal = DeepFileCount(originalPath);
            totalAnchor = DeepFileCount(anchorPath);

            if (sorted) totalAnchor -= Directory.GetDirectories(anchorPath).Length; // Get the sorted folders

            Console.WriteLine($"Anchor ({Path.GetPathRoot(anchorPath)}...\\{Path.GetFileName(anchorPath)}): {totalAnchor} files\t\tOriginal ({Path.GetPathRoot(originalPath)}...\\{Path.GetFileName(originalPath)}): {totalOriginal} files");

            if (totalOriginal != totalAnchor) return false; // Check if the file counts don't match

            return true;
        }

        public static int DeepFileCount(string directoryPath)
        {
            string[] subDirPaths = Directory.GetDirectories(directoryPath);
            int count = Directory.GetFiles(directoryPath).Length + subDirPaths.Length; // Get the number of files in the folder

            // Iterate through all directories
            foreach (string path in subDirPaths)
            {
                count += DeepFileCount(path);
            }

            return count;
        }
    }
}
