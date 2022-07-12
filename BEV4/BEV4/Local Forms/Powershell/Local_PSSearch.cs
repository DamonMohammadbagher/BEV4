using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BEV4.Local_Forms.Powershell
{
    public partial class Local_PSSearch : Form
    {
        public Local_PSSearch()
        {
            InitializeComponent();
        }

        public static DateTime dt;
        public static string Search_String_Textbox1 = "";
        public static string Search_String_TechniqueID = "";
        public static string CurrentEventLogName = "";

        /// <summary>
        /// Powershell C# Code to dump Event Logs via Management.Automation namespace
        /// </summary>
        /// <param name="_CurrentEventName"></param>
        /// <param name="SearchbyTime"></param>
        /// <returns></returns>
        public static void PSDumpLocalEvents(string EvtlogName)
        {

  
            PowerShell ps = PowerShell.Create();
            ps.AddScript("Get-Eventlog -LogName application", true);            
            System.Collections.ObjectModel.Collection<PSObject> p = ps.Invoke();
            foreach (var _items in p.ToArray())
            {
                string s = ((EventLogEntry)_items.BaseObject).Message;
            }
            
            //PowerShell ps = PowerShell.Create("Get-winEvent").;


            //ps.AddCommand("Get-winEvent").AddArgument("LogName").AddParameter("Security");
            //ps.AddStatement().AddCommand("Where-Object").AddParameter("{ $_.TimeCreated -ge $(Get-Date).AddDays(" + "-1" + ")}");
            //System.Collections.ObjectModel.Collection<PSObject> p = ps.Invoke();
            //foreach (var item in p)
            //{
            //    string s = item.Members.ToString();
            //}
        }

        public async Task __Search_by_Date_Powershell(string _CurrentEventName, bool SearchbyTime)
        {

            await Task.Run(() =>
            {

                try
                {
                    
                    /// cmd /c powershell "Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" 
                    /// | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)}
                    /// | Select-Object -Property TimeCreated,RecordId,Id,Level,Message 
                    /// | where-object {$_.ID -eq 1}
                    /// | ?{$_.Message -like \"*CommandLine:*reg.exe*add*hkcu\software\classes\mscfile\shell\open\command*/ve*/d*\"}
                    /// | ConvertTo-Html | Out-File HTMLReport.htm  "                                        
                    string bat = "cmd /c powershell \"Get-winEvent -LogName \"" + _CurrentEventName + "\" ";
                    string filename = "";

                    if (_CurrentEventName.Contains('/')) filename = _CurrentEventName.Split('/')[0];
                    else filename = _CurrentEventName; 
                    
                    if (SearchbyTime)
                    {
                        string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
                        bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
                    }

                    bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
                    
                    if (radioButton1.Checked)
                    {
                        bat += " | ConvertTo-Html | Out-File " + filename + ".html" + "\"";
                    }
                    else if (radioButton2.Checked)
                    { bat += " | ConvertTo-Csv | Out-File " + filename + ".csv" + "\""; }

                    File.WriteAllText("LocalReloadPSSearch.bat", bat);
                    Process prcs = new Process();
                    prcs.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    prcs.StartInfo.CreateNoWindow = false;
                    prcs.StartInfo.FileName = "LocalReloadPSSearch.bat";
                    prcs.StartInfo.RedirectStandardOutput = true;
                    prcs.StartInfo.RedirectStandardError = true;
                    prcs.StartInfo.UseShellExecute = false;
                    prcs.Start();
                    string CMDoutput = prcs.StandardOutput.ReadToEnd();
                    string error = prcs.StandardError.ReadToEnd();

                    do
                    {
                        Task.Delay(250);
                        if (CMDoutput != "") break;

                    } while (CMDoutput != "");


                }
                catch (Exception)
                {


                }


            });


        }

        private void Local_PSSearch_Load(object sender, EventArgs e)
        {
            Form1.IsLocalRemote_SearchReloadFormActived = true;
            Form1.PSFormIsActive = true;
            CurrentEventLogName = Master_Value.MasterValueClass.ActiveNode;

            string bat = "cmd /c powershell \"Get-winEvent -LogName \"" + CurrentEventLogName + "\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + "-1" + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
           
            bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            richTextBox1.Text = bat;

            // PSDumpLocalEvents("");
        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value;
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            string filename = "";
            if (CurrentEventLogName.Contains('/')) filename = CurrentEventLogName.Split('/')[0];
            else filename = CurrentEventLogName;

            MessageBox.Show("LocalReloadPSSearch.bat is Running in background.\nPlease wait ... \n"+ filename + ".html/.csv will Open...!");

            Task _SearchTask = __Search_by_Date_Powershell(CurrentEventLogName , true);
            await _SearchTask.ConfigureAwait(true);

            await Task.Run(() =>
            {
                string css = "<style>"
                          + "tr,th{background-color:#ddd;margin:2;padding:2;border:2;font-size:100%;vertical-align:baseline;font-size:14px;font-weight:bold}"
                          + "hr{background-color:#ddc;border:0;height:1px;margin:4px}"
                          + "td{background-color:#0dd;}"
                          + "</style>";
                do
                {
                    Task.Delay(1000);
                    if (_SearchTask.IsCompleted) break;

                } while (_SearchTask.IsCompleted);

                if (radioButton1.Checked)
                {
                    try
                    {
                        string NewFile = css + " " + File.ReadAllText(filename + ".html");
                        string _Filename_str = "BEV_(Event " + filename + ")_HTMLReport.html";
                        File.WriteAllText(_Filename_str, NewFile);
                        Process.Start(_Filename_str);
                    }
                    catch (Exception)
                    {


                    }

                }
                else if (radioButton2.Checked)
                {
                    try
                    {
                        string NewFile = File.ReadAllText(filename + ".csv");
                        string _Filename_str = "BEV_(Event " + filename + ")_CSVReport.csv";
                        File.WriteAllText(_Filename_str, NewFile);
                        Process.Start(_Filename_str);
                    }
                    catch (Exception)
                    {


                    }

                }

                button3.Enabled = true;
                button4.Enabled = true;
                button2.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                this.Close();

                if (radioButton1.Checked)
                {
                    MessageBox.Show("html file is opened!");
                }
                else
                {
                    MessageBox.Show("csv file is opened!");
                }

            });

        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value;
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            string filename = "";
            if (CurrentEventLogName.Contains('/')) filename = CurrentEventLogName.Split('/')[0];
            else filename = CurrentEventLogName;

            MessageBox.Show("LocalReloadPSSearch.bat is Running in background.\nPlease wait ... \n" + filename + ".html/.csv will Open...!");

            Task _SearchTask = __Search_by_Date_Powershell(CurrentEventLogName, false);
            await _SearchTask.ConfigureAwait(true);

            await Task.Run(() =>
            {
                string css = "<style>"
                          + "tr,th{background-color:#ddd;margin:2;padding:2;border:2;font-size:100%;vertical-align:baseline;font-size:14px;font-weight:bold}"
                          + "hr{background-color:#ddc;border:0;height:1px;margin:4px}"
                          + "td{background-color:#0dd;}"
                          + "</style>";
                do
                {
                    Task.Delay(1000);
                    if (_SearchTask.IsCompleted) break;

                } while (_SearchTask.IsCompleted);

                if (radioButton1.Checked)
                {
                    try
                    {
                        string NewFile = css + " " + File.ReadAllText( filename + ".html");
                        string _Filename_str = "BEV_(Event " + filename + ")_HTMLReport.htm";
                        File.WriteAllText(_Filename_str, NewFile);
                        Process.Start(_Filename_str);
                    }
                    catch (Exception)
                    {


                    }

                }
                else if (radioButton2.Checked)
                {
                    try
                    {
                        string NewFile = File.ReadAllText(filename + ".csv");
                        string _Filename_str = "BEV_(Event " + filename + ")_CSVReport.csv";
                        File.WriteAllText(_Filename_str, NewFile);
                        Process.Start(_Filename_str);
                    }
                    catch (Exception)
                    {


                    }

                }

                button3.Enabled = true;
                button4.Enabled = true;
                button2.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                this.Close();

                if (radioButton1.Checked)
                {
                    MessageBox.Show("html file is opened!");
                }
                else
                {
                    MessageBox.Show("csv file is opened!");
                }

            });

        }

        private void Local_PSSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.PSFormIsActive = false;
            Form1.IsLocalRemote_SearchReloadFormActived = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form1.PSFormIsActive = false;
            this.Close();
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;

            }
            string filename = "";
            if (CurrentEventLogName.Contains('/')) filename = CurrentEventLogName.Split('/')[0];
            else filename = CurrentEventLogName;

            string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"" + CurrentEventLogName + "\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
        
            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File " + filename + ".html" + "\"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File " + filename + ".csv" + "\""; }
            richTextBox1.Text = bat;
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {

            if (!radioButton1.Checked)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;

            }
            string filename = "";
            if (CurrentEventLogName.Contains('/')) filename = CurrentEventLogName.Split('/')[0];
            else filename = CurrentEventLogName;

            string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"" + CurrentEventLogName + "\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";

            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File " + filename + ".html" + "\"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File " + filename + ".csv" + "\""; }
            richTextBox1.Text = bat;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string filename = "";
            if (CurrentEventLogName.Contains('/')) filename = CurrentEventLogName.Split('/')[0];
            else filename = CurrentEventLogName;

            dt = dateTimePicker1.Value;
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"" + CurrentEventLogName + "\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0] + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";

            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File " + filename + ".html" + "\"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File " + filename + ".csv" + "\""; }
            richTextBox1.Text = bat;
        }
    }
}
