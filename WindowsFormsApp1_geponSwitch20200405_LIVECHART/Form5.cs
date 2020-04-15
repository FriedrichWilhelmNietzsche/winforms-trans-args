using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using MetroFramework.Forms;
using System.Data;
using MetroFramework;

namespace WindowsFormsApp1_geponSwitch20200405
{
    public partial class Form5 : MetroForm
    {
        public Form5()
        {
            InitializeComponent();

            this.BorderStyle = MetroFormBorderStyle.FixedSingle;
            this.ShadowType = MetroFormShadowType.AeroShadow;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            //  metroStyleManager1.Theme = metroStyleManager1.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroTileSwitch_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `OK` only button", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `OK` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Yes` and `No` button", "MetroMessagebox", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Yes`, `No` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample `default` MetroMessagebox ", "MetroMessagebox");

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Retry` and `Cancel` button.  With warning style.", "MetroMessagebox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Abort`, `Retry` and `Ignore` button.  With Error style.", "MetroMessagebox", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //  metroContextMenu2.Show(metroButton4, new Point(0, metroButton4.Height));

        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show(metroTile8, new Point(0, metroTile8.Height));

        }


        public event EventHandler SendMsgEvent; //use Invoke
        public event EventHandler SendMsgEvent1;

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            //slaver trans to master
            form6.ChangeTheme = (MetroThemeStyle) => metroStyleManager.Theme = MetroThemeStyle;//lambda
            form6.ChangeStyle = (MetroColorStyle) => metroStyleManager.Style = MetroColorStyle;

            //master trans to slaver
            SendMsgEvent += form6.MainFormThemeChaned;//for slaver sets
            SendMsgEvent1 += form6.MainFormStyleChaned;


            form6.Show();
            SendMsgEvent(this, new TransEventArg() { Theme = this.metroStyleManager.Theme });  //master trans to slaver
            SendMsgEvent1(this, new TransEventArg() { Style = this.metroStyleManager.Style });  //master trans to slaver

            while (!form6.IsDisposed)
            {
                Application.DoEvents();
                this.Enabled = false;
            }
            this.Enabled = true;

        }

        private void metroContextMenu2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void metroToolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroContextMenu1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
