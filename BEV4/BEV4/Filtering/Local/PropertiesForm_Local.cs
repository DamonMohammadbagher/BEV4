using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4.Filtering.Local
{
    public partial class PropertiesForm_Local : Form
    {
        public PropertiesForm_Local()
        {
            InitializeComponent();
        }

        public static System.Data.DataRowView Properties_Datarow_Local_1;
        public static EventLogRecord Properties_Datarow_Local_2;

        private void PropertiesForm_Local_Load(object sender, EventArgs e)
        {

            try
            {

                button1.Select();

                if (Properties_Datarow_Local_1.Row[1].ToString() == "Information")
                {
                    this.Icon = SystemIcons.Information;
                    //MessageBox.Show(null, "Event Type : " + Properties_Datarow_Local_1.Row[1].ToString() + "\n" + "Message:\n------------------------\n" + Properties_Datarow_Local_1.Row[2].ToString() + "\n" + "\n\n\nProvide Name: " + Properties_Datarow_Local_2.ProviderName.ToString() + "\nTime: " + Properties_Datarow_Local_2.TimeCreated.ToString(), "Properties For Record " + Properties_Datarow_Local_1.Row[0].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (Properties_Datarow_Local_1.Row[1].ToString() == "Warning")
                {
                    this.Icon = SystemIcons.Warning;
                    //MessageBox.Show(null, "Event Type : " + Properties_Datarow_Local_1.Row[1].ToString() + "\n" + "Message:\n------------------------\n" + Properties_Datarow_Local_1.Row[2].ToString(), "Properties For Record " + Properties_Datarow_Local_1.Row[0].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }
                else
                        if (Properties_Datarow_Local_1.Row[1].ToString() == "Error")
                {
                    this.Icon = SystemIcons.Error;
                    //MessageBox.Show(null, "Event Type : " + Properties_Datarow_Local_1.Row[1].ToString() + "\n" + "Message:\n------------------------\n" + Properties_Datarow_Local_1.Row[2].ToString(), "Properties For Record " + Properties_Datarow_Local_1.Row[0].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
                else
                {
                    this.Icon = SystemIcons.Asterisk;
                    //MessageBox.Show(null, "Event Type : " + Properties_Datarow_Local_1.Row[1].ToString() + "\n" + "Message:\n------------------------\n" + Properties_Datarow_Local_1.Row[2].ToString(), "Properties For Record " + Properties_Datarow_Local_1.Row[0].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

                label1.Text = "Record: " + Properties_Datarow_Local_1.Row[0].ToString();//record count
                if (Properties_Datarow_Local_2.TimeCreated != null) { label8.Text = "Logged: " + Properties_Datarow_Local_2.TimeCreated.ToString(); }
                if (Properties_Datarow_Local_2.Opcode != null) { label7.Text = "OpCode: " + Properties_Datarow_Local_2.Opcode.ToString(); }
                if (Properties_Datarow_Local_2.Keywords != null) { label10.Text = "Keywords: " + Properties_Datarow_Local_2.Keywords.ToString(); }
                if (Properties_Datarow_Local_2.Task != null) { label9.Text = "Task Category: " + Properties_Datarow_Local_2.Task.ToString(); }
                if (Properties_Datarow_Local_2.Id != null) { label4.Text = "Event ID: " + Properties_Datarow_Local_2.Id.ToString(); }


                if (Properties_Datarow_Local_2.ProviderName != null) { label3.Text = "Source: " + Properties_Datarow_Local_2.ProviderName; }


                if (Properties_Datarow_Local_2.UserId != null) { label6.Text = "User: " + Properties_Datarow_Local_2.UserId.Value.ToString(); }


                if (Properties_Datarow_Local_1.Row[1] != null) label5.Text = "Level: " + Properties_Datarow_Local_1.Row[1].ToString();//leveldisplayname


                if (Properties_Datarow_Local_2.MachineName != null) label11.Text = "Computers: " + Properties_Datarow_Local_2.MachineName;


                if (Properties_Datarow_Local_2.LogName != null) label2.Text = "LogName: " + Properties_Datarow_Local_2.LogName;

                try
                {

                    //EventRecord CastObject = ((EventRecord)Master_Value.MasterValueClass.LocalBindingSource.Current);
                    //string msg = CastObject.FormatDescription();

                    //bug this code is ok
                    string msg = Properties_Datarow_Local_2.FormatDescription();
                    //bug this code is ok

                    if (msg != null) richTextBox1.Text = msg;  // textBox1.Text = Properties_Datarow_Local_1.Row[3].ToString();
                }
                catch (Exception err)
                {

                    richTextBox1.Text = " ";
                }



            }
            catch (Exception err)
            {


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            _Save();
        }

        private void _Save()
        {

            try
            {


                using (StreamWriter sw = new StreamWriter(label1.Text.Replace(':', '_').ToString().Replace(' ', '_').ToString() + ".txt"))
                {
                    // Add some text to the file.
                    sw.WriteLine("This Event Saved:" + System.DateTime.Now.ToString() + "\n");
                    sw.WriteLine(label1.Text);
                    sw.WriteLine("--------------Other Properties------------");
                    sw.WriteLine(label2.Text);
                    sw.WriteLine(label3.Text);
                    sw.WriteLine(label4.Text);
                    sw.WriteLine(label5.Text);
                    sw.WriteLine(label6.Text);
                    sw.WriteLine(label7.Text);
                    sw.WriteLine(label8.Text);
                    sw.WriteLine(label9.Text);
                    sw.WriteLine(label10.Text);
                    sw.WriteLine(label11.Text);
                    sw.WriteLine("-----------------Message-------------------");
                    sw.WriteLine(richTextBox1.Text);
                    sw.WriteLine("-------------------------------------------");
                    sw.Close();
                }


            }
            catch (Exception err)
            {

            }

        }
    }
}
