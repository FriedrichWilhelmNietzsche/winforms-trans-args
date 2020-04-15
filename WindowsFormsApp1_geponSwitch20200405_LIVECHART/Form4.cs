using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1_geponSwitch20200405
{

    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提供外部访问自己元素的方法
        /// </summary>
        /// <param name="txt"></param>
        public void SetText(string txt)
        {
            this.textBox_f4.Text = txt;
        }
        public void AfterParentFrmTextChange(object sender, EventArgs e)
        {
            //拿到父窗体的传来的文本
            WinFrmDemo.MyEventArg arg = e as WinFrmDemo.MyEventArg;
            this.SetText(arg.Text);
        }

        internal void MainFormTxtChaned(object sender, EventArgs e)
        {
            //取到主窗体的传来的文本
            WinFrmDemo.MyEventArg arg = e as WinFrmDemo.MyEventArg;
            this.SetText(arg.Text);

        }


        //子传父
        public Action<string> ChangeText;//之前的定义委托和定义事件由这一句话代替
        private void button1_Click(object sender, EventArgs e)
        {
            if (ChangeText != null)//判断事件是否为空
            {
                  ChangeText(textBox2.Text);//执行委托实例  
                  this.Close();
            }
        }
    }
}
