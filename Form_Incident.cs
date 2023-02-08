using System.Resources;
using System.Runtime.InteropServices;
using System.Text;

namespace RA_Client
{
    public partial class Form_Incident : Form
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

        public Form_Incident()
        {
            InitializeComponent();
        }

        private void PictureBox_Audio_Click(object sender, EventArgs e)
        {
            if (Form_Main.audioMuted == false)
            {
                pictureBox_Audio.Image = Properties.Resources.speaker_inactive_white;
                
                // Force system wide mute of audio
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            }
            else
            {
                pictureBox_Audio.Image = Properties.Resources.speaker_active_white;

                // Force system wide mute of audio
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            }

            Form_Main.audioMuted = !Form_Main.audioMuted;
        }

        private void PictureBox_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Incident_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop playing the audio file
            StringBuilder sb = new();
            string sFileName = Path.Combine(Application.CommonAppDataPath, "tas_red_alert.mp3");
            string sAliasName = "MP3";

            int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);
            nRet = mciSendString("stop " + sAliasName, sb, 0, IntPtr.Zero);

        }
    }
}
