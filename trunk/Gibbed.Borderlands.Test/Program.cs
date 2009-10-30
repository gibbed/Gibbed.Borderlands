using System;
using System.IO;
using Gibbed.Borderlands.FileFormats;

namespace Gibbed.Borderlands.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "My Games");
            path = Path.Combine(path, "Borderlands");
            path = Path.Combine(path, "SaveData");
            path = Path.Combine(path, "Save0001.first");

            Stream input = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            SaveFile save = new SaveFile();
            save.Deserialize(input);
            input.Close();
        }
    }
}
