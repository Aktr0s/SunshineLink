using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sun6502IDE
{
    // All texts (title, catchphrase, author...) are plain Label.Text properties:
    // change them in the Designer. Only the version and the icon are filled in here.
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + Application.ProductVersion;

            try
            {
                using (Icon ico = new Icon(
                    SunshineLink.Properties.Resources.SunshineLink_Icon_Upright,
                    64,
                    64))
                {
                    picIcon.Image = ico.ToBitmap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
