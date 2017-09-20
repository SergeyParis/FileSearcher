using System.IO;

namespace FileSearcher.Helpers
{
    public static class FileSystemInfo
    {
        public static string[] GetAllDrives { get; }

        static FileSystemInfo()
        {
            GetAllDrives = Directory.GetLogicalDrives();
        }

        public static bool CheckExistFolder(string path)
        {
            return Directory.Exists(path);
        }
    }
}
