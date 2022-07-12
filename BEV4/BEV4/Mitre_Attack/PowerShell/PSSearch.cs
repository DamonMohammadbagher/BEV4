using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4.Mitre_Attack.PowerShell
{
    public partial class PSSearch : Form
    {
        public PSSearch()
        {
            InitializeComponent();
        }

        public static DateTime dt;
        public static string Search_String_Textbox1 = "";
        public static string Search_String_TechniqueID = "";

        public async Task _TechniqueIDs_Search1_Powershell(string FirstQuery,string TechniqueId)
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

                    string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
                    string FirstQuery_strings = FirstQuery.Replace(' ', '*');
                    FirstQuery_strings = FirstQuery_strings.Replace("**", "*");
                    string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
                    bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
                    bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
                    bat += " | where-object {$_.ID -eq 1} ";
                    bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + FirstQuery_strings + "\\\")} ";

                    if (radioButton1.Checked)
                    {
                        bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
                    }
                    else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File CSVReport.csv  \""; }
                    
                    File.WriteAllText("PSSearch.bat", bat);
                    Process prcs = new Process();
                    prcs.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    prcs.StartInfo.CreateNoWindow = false;
                    prcs.StartInfo.FileName = "PSSearch.bat";
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

        public  async Task _TechniqueIDs_SearchAllRecords_Powershell(string FirstQuery, string TechniqueId)
        {

            await Task.Run(() =>
            {

                try
                {
                    /// cmd /c powershell "Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)} | Select-Object -Property RecordId,Id,Level,Message | where-object {$_.ID -eq 1} |?{$_.Message -like \"*CommandLine:*reg.exe*add*hkcu\software\classes\mscfile\shell\open\command*/ve*/d*\"}  |ConvertTo-Html | Out-File aliases.htm"
                    /// cmd /c powershell "Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)} | Select-Object -Property TimeCreated,RecordId,Id,Level,Message | where-object {$_.ID -eq 1} |?{$_.Message -like \"*CommandLine:*reg.exe*add*hkcu\software\classes\mscfile\shell\open\command*/ve*/d*\"} | ConvertTo-Html | Out-File HTMLReport.htm  "

                    string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
                    string FirstQuery_strings = FirstQuery.Replace(' ', '*');
                    FirstQuery_strings = FirstQuery_strings.Replace("**", "*");
                    string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
                    //bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
                    bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
                    bat += " | where-object {$_.ID -eq 1} ";
                    bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + FirstQuery_strings + "\\\")} ";

                    if (radioButton1.Checked)
                    {
                        bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
                    }
                    else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File HTMLReport.csv  \""; }
                     

                    File.WriteAllText("PSSearch.bat", bat);
                    Process prcs = new Process();
                    prcs.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    prcs.StartInfo.CreateNoWindow = false;
                    prcs.StartInfo.FileName = "PSSearch.bat";
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

        private void PSSearch_Load(object sender, EventArgs e)
        {
            Form1.IsLocalRemote_SearchReloadFormActived = true;
            Form1.PSFormIsActive = true;
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + "-1" + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
            bat += " | where-object {$_.ID -eq 1} ";
            bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + Search_String_Textbox1 + "\\\")} ";
            bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            richTextBox1.Text = bat;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value;
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            MessageBox.Show("PSSearch.bat is Running in background.\nPlease wait ... \nHTMLReport.htm will Open...!");
           
            Task _SearchTask = _TechniqueIDs_Search1_Powershell(Search_String_Textbox1,Search_String_TechniqueID);
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
                    Thread.Sleep(1000);
                    if (_SearchTask.IsCompleted) break;

                } while (_SearchTask.IsCompleted);

                if (radioButton1.Checked)
                {
                    try
                    {
                        string NewFile = css + " " + File.ReadAllText("HTMLReport.htm");
                        string _Filename_str = "BEV_(" + Search_String_TechniqueID + ")_HTMLReport.htm";
                        File.WriteAllText(_Filename_str, NewFile);
                        Process.Start(_Filename_str);
                    }
                    catch (Exception)
                    {

                       
                    }
                    
                }else if(radioButton2.Checked)
                {
                    try
                    {
                        string NewFile = File.ReadAllText("CSVReport.csv");
                        string _Filename_str = "BEV_(" + Search_String_TechniqueID + ")_CSVReport.csv";
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value;
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + ((TimeSpan) (dt - DateTime.Now)).TotalDays.ToString().Split('.')[0] + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
            bat += " | where-object {$_.ID -eq 1} ";
            bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + Search_String_Textbox1 + "\\\")} ";
            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File HTMLReport.csv  \""; }
            richTextBox1.Text = bat;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form1.PSFormIsActive = false;
            this.Close();
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";            
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
            bat += " | where-object {$_.ID -eq 1} ";
            bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + Search_String_Textbox1 + "\\\")} ";
            bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            richTextBox1.Text = bat;
            MessageBox.Show("PSSearch.bat is Running in background.\nPlease wait ... \nHTMLReport.htm will Open...!");

            ///> powershell "Get-EventLog -LogName "ETWPM2Monitor2" | ?{$_.Message -like \"*Target Process: notepad*\"} | Select-Object -Property Index,EventId,EntryType,Message |ConvertTo-Html | Out-File aliases.htm "

            Task _SearchTask = _TechniqueIDs_SearchAllRecords_Powershell(Search_String_Textbox1,Search_String_TechniqueID);
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
                    Thread.Sleep(1000);
                    if (_SearchTask.IsCompleted) break;

                } while (_SearchTask.IsCompleted);

                string NewFile = css + " " + File.ReadAllText("HTMLReport.htm");
                string _Filename_str = "BEV_(" + Search_String_TechniqueID + ")_HTMLReport.htm";
                File.WriteAllText(_Filename_str, NewFile);
                Process.Start(_Filename_str);
                //Form1.button2.Enabled = true;
                 
                button2.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = true;
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

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
               
            }

            string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
            bat += " | where-object {$_.ID -eq 1} ";
            bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + Search_String_Textbox1 + "\\\")} ";

            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File HTMLReport.csv  \""; }
            richTextBox1.Text = bat;
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                
            }

            string d = ((TimeSpan)(dt - DateTime.Now)).TotalDays.ToString().Split('.')[0];
            string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
            bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(" + d + ")} ";
            bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
            bat += " | where-object {$_.ID -eq 1} ";
            bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + Search_String_Textbox1 + "\\\")} ";
            if (radioButton1.Checked)
            {
                bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
            }
            else if (radioButton2.Checked) { bat += " | ConvertTo-Csv | Out-File HTMLReport.csv  \""; }
            richTextBox1.Text = bat;
        }

        private void PSSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.PSFormIsActive = false;
            Form1.IsLocalRemote_SearchReloadFormActived = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
