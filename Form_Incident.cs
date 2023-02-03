using System.Resources;

namespace RA_Client
{
    public partial class Form_Incident : Form
    {
        public Form_Incident()
        {
            InitializeComponent();
        }

        private void PictureBox_Audio_Click(object sender, EventArgs e)
        {
            pictureBox_Audio.Image = RA_Client.Properties.Resources.speaker_active_white;
            //webView_Incident.CoreWebView2.IsMuted = !webView_Incident.CoreWebView2.IsMuted;
        }
    }
}
