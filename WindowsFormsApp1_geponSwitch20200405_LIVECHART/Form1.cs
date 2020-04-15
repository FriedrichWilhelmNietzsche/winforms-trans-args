using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1_geponSwitch20200405
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshPortname();
        }


        #region serial open & close
        private void ToggleControls(bool value)
        {
            comboBoxOS.Enabled = !value;
            comboBoxF1.Enabled = !value;
            comboBoxF2.Enabled = !value;

        }


        private void RefreshPortname()
        {
            try
            {
                List<string> list = new List<string>();
                string[] ports = USB.GetPorts(); //SerialPort.GetPortNames();//
                ComboBox[] PortcomboBox = { comboBoxOS, comboBoxF1, comboBoxF2 };
                //this.BeginInvoke(new Action(() =>
                //{
                foreach (ComboBox combo in PortcomboBox)
                {
                    combo.Items.Clear();
                    for (int i = 0; i < ports.Length; i++)
                    {
                        combo.Items.Add(ports[i]);
                    }
                    if (ports.Length > 0)
                    {
                        combo.SelectedIndex = ports.Length - 1;
                    }
                }
                //   }));                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Thread thread;
        USB usb = new USB();
        private Boolean isOpen = false;


        private void btnSerialPort_Click(object sender, EventArgs e)
        {

            if (!isOpen)
            {
                try
                {

                    //  comboBoxOS, comboBoxF1, comboBoxF2               
                    this.BeginInvoke(new Action(() =>
                    {
                        Boolean isOpenSuccess = usb.SetCom(comboBoxOS.SelectedItem.ToString(), comboBoxF1.SelectedItem.ToString(), comboBoxF2.SelectedItem.ToString());
                        if (isOpenSuccess)   // 
                        {
                            isOpen = true;
                            btnSerialPort.Text = "Close";
                            ToggleControls(true);

                            //ComboBox[] PortcomboBox = { comboBoxOS, comboBoxF1, comboBoxF2 };
                            //foreach (ComboBox combo in PortcomboBox)
                            //{
                            //    combo.Enabled = false;
                            //}
                        }
                        else
                        {
                            isOpen = false;
                            btnSerialPort.Text = "Open";
                            ToggleControls(false);
                        }
                    }));
                }
                catch
                {
                    MessageBox.Show("Check Connection!");

                }
            }
            else
            {
                // stop_sample();   //stop sample
                usb.Close3Com();
                btnSerialPort.Text = "Open";
                isOpen = false;
                ToggleControls(false);

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            RefreshPortname();
        }

        #endregion



    }
}
