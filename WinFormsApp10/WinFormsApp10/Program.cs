using System;
using System.Windows.Forms;

namespace ReadingRoomApp
{
    static class Program
    {
        /// <summary>
        /// ���ø����̼��� �� �������Դϴ�.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
