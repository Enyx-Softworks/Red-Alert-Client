using System.Runtime.InteropServices;

namespace RA_Client
{
    internal static class Program
    {
        public static Mutex mutex;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a mutex
            mutex = new Mutex(true, @"Global\" + Application.ProductName, out bool created_new);
            if (!created_new)
            {
                // Application already runnning -> Restore application by sending a custom message to the form
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                return;
            }
            else
            {
                // Application mutex not found -> Start the first instance
                GC.KeepAlive(mutex);


                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form_Main());
            }
        }

        /// <summary>
        /// External imports to send a custom message
        /// </summary>
        internal class NativeMethods
        {
            public const int HWND_BROADCAST = 0xffff;
            public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
            [DllImport("user32")]
            public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
            [DllImport("user32")]
            public static extern int RegisterWindowMessage(string message);
        }

    }
}