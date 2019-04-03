using System;
using System.Windows.Forms;

namespace Gibbed.Borderlands.SaveEdit
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor());
        }
    }
}
