using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4.Remote_Forms
{
    public partial class Remote_Connection_MainForm : Form
    {
        public Remote_Connection_MainForm()
        {
            InitializeComponent();
        }
        

        Remote_Class MyClass = new Remote_Class();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SecureString _ = new SecureString();
                foreach (char item in textBox2.Text)
                {
                    _.AppendChar(item);
                }

                if (checkBox1.Checked) { MyClass._Connect(textBox1.Text, textBox4.Text, textBox3.Text, _, SessionAuthentication.Default); }
                else
                    if (checkBox2.Checked) { MyClass._Connect(textBox1.Text, textBox4.Text, textBox3.Text, _, SessionAuthentication.Kerberos); }
                else
                        if (checkBox3.Checked) { MyClass._Connect(textBox1.Text, textBox4.Text, textBox3.Text, _, SessionAuthentication.Negotiate); }
                else
                            if (checkBox4.Checked) { MyClass._Connect(textBox1.Text, textBox4.Text, textBox3.Text, _, SessionAuthentication.Ntlm); }
                else { MyClass._Connect(textBox1.Text, textBox4.Text, textBox3.Text, _, SessionAuthentication.Default); }

                // for Remote Host name
                Master_Value.MasterValueClass.Remote_Host_Name = textBox4.Text;
                Master_Value.MasterValueClass.Remote_Host_UserName = textBox1.Text;

                this.Close();
            }
            catch (Exception err)
            {

                Master_Value.MasterValueClass.Remote_Host_Name = null;
                this.Close();

            }


        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox3.Enabled = true;
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

            }
            else if (!checkBox5.Checked)
            {
                textBox3.Enabled = false;
                checkBox2.Checked = false;
                checkBox1.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = true;
            }
            else if (!checkBox2.Checked)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void Remote_Connection_MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
