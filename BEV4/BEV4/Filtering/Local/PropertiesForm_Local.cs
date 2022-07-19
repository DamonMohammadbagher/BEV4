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
using System.Management.Automation;
using System.Diagnostics;

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
        private static EventRecord _EventInstance;
        private void PropertiesForm_Local_Load(object sender, EventArgs e)
        {
            string Xeventname = Master_Value.MasterValueClass.ActiveNode;
            string EventRecordId = Properties_Datarow_Local_1.Row[0].ToString();

            //string XPath = "<QueryList><Query Id=\"0\" Path=\"" + Xeventname + "\">"
            //             + "<Select Path=\"" + Xeventname + "\">*[System[(EventRecordID=" + EventRecordId + ")]]</Select>"
            //             + "</Query>"
            //             + "</QueryList>";

            string XPath = "*[System[(EventRecordID=" + EventRecordId + ")]]";
            EventLogQuery Query = null;
           

            if (Xeventname.StartsWith("Microsoft-Windows-") && Xeventname.Contains('/'))
                Query = new EventLogQuery(Xeventname, PathType.LogName, XPath);
            else
                Query = new EventLogQuery(Xeventname, PathType.LogName, XPath);


          
            try
            {
                _EventInstance = new EventLogReader(Query).ReadEvent();

                button1.Select();
                if (_EventInstance.LogName.ToLower() != "security")
                {
                    if (_EventInstance.LevelDisplayName.ToString() == "Information")
                    {
                        this.Icon = SystemIcons.Information;
                    }
                    else
                    if (_EventInstance.LevelDisplayName.ToString() == "Warning")
                    {
                        this.Icon = SystemIcons.Warning;
                    }
                    else
                    if (_EventInstance.LevelDisplayName.ToString() == "Error")
                    {
                        this.Icon = SystemIcons.Error;
                    }
                }
                else
                {
                    this.Icon = SystemIcons.Asterisk;
                }

                label1.Text = "Record: " + _EventInstance.RecordId.ToString();
                label8.Text = "Logged: " + _EventInstance.TimeCreated.ToString();
                label7.Text = "OpCode: " + _EventInstance.Opcode.ToString();
                label10.Text = "Keywords: " + _EventInstance.Keywords.ToString();
                //label9.Text = "Task Category: " + _EventInstance.TaskDisplayName.ToString();
                label4.Text = "Event ID: " + _EventInstance.Id.ToString();
                label3.Text = "Source: " + _EventInstance.ProviderName.ToString();
                //label6.Text = "User: " + _EventInstance.UserId.Value.ToString();
                label5.Text = "Level: " + _EventInstance.LevelDisplayName.ToString();
                label11.Text = "Computers: " + _EventInstance.MachineName.ToString();
                label2.Text = "LogName: " + _EventInstance.LogName.ToString();

                try
                {

                    //richTextBox1.Text = Properties_Datarow_Local_1.Row[3].ToString();
                    richTextBox1.Text =_EventInstance.FormatDescription();

                }
                catch (Exception err)
                {

                    richTextBox1.Text = "";
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
