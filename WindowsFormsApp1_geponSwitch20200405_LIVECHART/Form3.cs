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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        //增加event关键字
        //定 义消息发布的事件  事件是委托的一个特殊实例  事件只能在类的内部触发执行
        public event EventHandler SendMsgEvent; //使用默认的事件处理委托
        private void button_f3_Click(object sender, EventArgs e)
        {

            setFormTextValue();
            //触发事件
            //EventArgs,写一个子类继承该类，子类中添加需要封装的数据信息，此处只需要传递string信息，详见MyEventArgs
            SendMsgEvent(this, new WinFrmDemo.MyEventArg() { Text = this.textBox_f3.Text });

        }

        public void setFormTextValue()
        {
            //子窗体弹出来之前，注册事件，关注主窗体消息的变化，当有多个窗体需要接收信息，只需要在此修改即可
            Form4 childFormA = new Form4();
            SendMsgEvent += childFormA.MainFormTxtChaned;//为子窗体注册事件，在子窗体中事件处理代码中设置文本
            childFormA.Show();
          
        }


        //子传父
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ChangeText = (str) => textBox1.Text = str;//用lambda表达式实现，这句话必须放在f2.ShowDialog();前面
            f4.ShowDialog();
        }
    }
}
