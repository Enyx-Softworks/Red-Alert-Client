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
    }
}
