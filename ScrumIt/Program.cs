using System;
using System.Threading;
using System.Windows.Forms;
using ScrumIt.Forms;
using ScrumIt.Models;

namespace ScrumIt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Thread mailingThread = new Thread(ProjectModel.NotifyUsersAboutEndOfSprint);
            mailingThread.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

        }
    }
}
