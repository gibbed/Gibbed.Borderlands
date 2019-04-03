using System;
using System.IO;

namespace Gibbed.Borderlands.SaveEdit
{
    internal static class Helpers
    {
        public static string GetSavePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "My Games");
            path = Path.Combine(path, "Borderlands");
            path = Path.Combine(path, "SaveData");
            return path;
        }
    }
}
