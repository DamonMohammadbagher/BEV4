using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4
{
    public partial class WaitForm2 : Form
    {
       

        private BackgroundWorker BGW_LocalEvt_View;
        private static BindingSource TempBinding = new BindingSource();
        private static BindingSource TempBinding_for_search1 = new BindingSource();
        private EventLogQuery eventsQuery;
        private EventLogReader logReader;
        public bool IsFilteredByDateTime = false;
        public Thread _Thread;
        private static EventRecord CastObject;
        Master_Value.MasterValueClass MObj = new BEV4.Master_Value.MasterValueClass();
        string Temps1, Temps2;

        public async Task Powershell_Run_inBackgroud_Fast(bool FilteredByDate, string ActiveEventNameNode)
        {
            await Task.Run(() =>
            {
                PowerShell ps = PowerShell.Create();
                bool EventLogEntryError = false;

                if (ActiveEventNameNode.StartsWith("Microsoft-Windows-") && ActiveEventNameNode.Contains('/'))
                {
                    ps.AddScript("Get-WinEvent -LogName " + "\"" + ActiveEventNameNode + "\"", true);
                    EventLogEntryError = true;
                }
                else
                {
                    ps.AddScript("Get-Eventlog -Logname " + ActiveEventNameNode, true);
                    EventLogEntryError = false;
                }

                System.Collections.ObjectModel.Collection<PSObject> PowershellObjects = ps.Invoke();
                EventLogEntry evt = null;
                EventLogRecord evt2 = null;
               

                if (!FilteredByDate)
                {
                    foreach (var _items in PowershellObjects.ToArray())
                    {
                        try
                        {
                            if (!EventLogEntryError)
                            {
                                evt = ((EventLogEntry)_items.BaseObject);
                                if (evt != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt);


                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local(evt.Index.ToString(), evt.EntryType.ToString(),
                                            evt.InstanceId.ToString(), evt.Message.ToString(), evt.TimeGenerated.ToString());

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                            evt.Index.ToString(), evt.EntryType.ToString(), evt.InstanceId.ToString(),
                                            evt.Message.ToString(), evt.TimeGenerated.ToString(), (object)evt);
                                }
                            }
                            else if (EventLogEntryError)
                            {
                                evt2 = ((EventLogRecord)_items.BaseObject);
                                if (evt2 != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt2);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt2);


                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local(evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(),
                                            evt2.Id.ToString(), evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString());

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                           evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(), evt2.Id.ToString(),
                                            evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString(), (object)evt2);
                                }
                            }
                        }
                        catch (Exception err)
                        {

                            /// "Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'
                            /// to type 'System.Diagnostics.EventLogEntry'." 
                            if (err.Message.Contains("Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'"))
                                EventLogEntryError = true;
                        }


                    }
                }
                else
                {
                    foreach (var _items in PowershellObjects.ToArray())
                    {
                        try
                        {

                            if (!EventLogEntryError)
                            {
                                evt = ((EventLogEntry)_items.BaseObject);
                                if (evt != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt);


                                    if (evt.TimeGenerated.Date >= dateTimePicker1.Value.Date
                                        && evt.TimeGenerated.Date <= dateTimePicker2.Value.Date)
                                    {
                                        if (!Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local(evt.Index.ToString(), evt.EntryType.ToString(),
                                                evt.InstanceId.ToString(), evt.Message.ToString(), evt.TimeGenerated.ToString());

                                        if (Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                                evt.Index.ToString(), evt.EntryType.ToString(), evt.InstanceId.ToString(),
                                                evt.Message.ToString(), evt.TimeGenerated.ToString(), (object)evt);
                                    }
                                }
                            }
                            else if (EventLogEntryError)
                            {
                                evt2 = ((EventLogRecord)_items.BaseObject);
                                if (evt2 != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt2);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt2);

                                    if (evt2.TimeCreated.Value.Date >= dateTimePicker1.Value.Date
                                        && evt2.TimeCreated.Value.Date <= dateTimePicker2.Value.Date)
                                    {
                                        if (!Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local(evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(),
                                                evt2.Id.ToString(), evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString());

                                        if (Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                               evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(), evt2.Id.ToString(),
                                                evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString(), (object)evt2);
                                    }
                                }
                            }

                        }
                        catch (Exception err2)
                        {
                            /// "Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'
                            /// to type 'System.Diagnostics.EventLogEntry'." 
                            if (err2.Message.Contains("Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'"))
                                EventLogEntryError = true;
                        }
                    }
                }

                Form1.IsLocalRemote_SearchReloadFormActived = false;
                CopyBindingSource();
            });
        }

        public async Task Powershell_Run_inBackgroud_Fast_once(bool FilteredByDate, string ActiveEventNameNode)
        {
            await Task.Run(() =>
            {
                PowerShell ps = PowerShell.Create();
                bool EventLogEntryError = false;

                if (ActiveEventNameNode.StartsWith("Microsoft-Windows-") && ActiveEventNameNode.Contains('/'))
                {
                    ps.AddScript("Get-WinEvent -LogName " + "\"" + ActiveEventNameNode + "\"", true);
                    EventLogEntryError = true;
                }
                else
                {
                    ps.AddScript("Get-Eventlog -Logname " + ActiveEventNameNode, true);
                    EventLogEntryError = false;
                }

                System.Collections.ObjectModel.Collection<PSObject> PowershellObjects = ps.Invoke();
                EventLogEntry evt = null;
                EventLogRecord evt2 = null;


                if (!FilteredByDate)
                {
                    foreach (var _items in PowershellObjects.ToArray())
                    {
                        try
                        {
                            if (!EventLogEntryError)
                            {
                                evt = ((EventLogEntry)_items.BaseObject);
                                if (evt != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt);


                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local(evt.Index.ToString(), evt.EntryType.ToString(),
                                            evt.InstanceId.ToString(), evt.Message.ToString(), evt.TimeGenerated.ToString());

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                            evt.Index.ToString(), evt.EntryType.ToString(), evt.InstanceId.ToString(),
                                            evt.Message.ToString(), evt.TimeGenerated.ToString(), (object)evt);
                                }
                            }
                            else if (EventLogEntryError)
                            {
                                evt2 = ((EventLogRecord)_items.BaseObject);
                                if (evt2 != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt2);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt2);


                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local(evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(),
                                            evt2.Id.ToString(), evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString());

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                           evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(), evt2.Id.ToString(),
                                            evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString(), (object)evt2);
                                }
                            }
                        }
                        catch (Exception err)
                        {

                            /// "Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'
                            /// to type 'System.Diagnostics.EventLogEntry'." 
                            if (err.Message.Contains("Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'"))
                                EventLogEntryError = true;
                        }


                    }
                }
                else
                {
                    foreach (var _items in PowershellObjects.ToArray())
                    {
                        try
                        {

                            if (!EventLogEntryError)
                            {
                                evt = ((EventLogEntry)_items.BaseObject);
                                if (evt != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt);

                                   

                                    if (evt.TimeGenerated.Date == DateTime.Today.Date)
                                    {
                                        if (!Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local(evt.Index.ToString(), evt.EntryType.ToString(),
                                                evt.InstanceId.ToString(), evt.Message.ToString(), evt.TimeGenerated.ToString());

                                        if (Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                                evt.Index.ToString(), evt.EntryType.ToString(), evt.InstanceId.ToString(),
                                                evt.Message.ToString(), evt.TimeGenerated.ToString(), (object)evt);
                                    }
                                }
                            }
                            else if (EventLogEntryError)
                            {
                                evt2 = ((EventLogRecord)_items.BaseObject);
                                if (evt2 != null)
                                {
                                    if (!Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding.Add(evt2);

                                    if (Form1.IsFilteringMode_Mittre_EID1)
                                        TempBinding_for_search1.Add(evt2);

                                    if (evt2.TimeCreated.Value.Date == DateTime.Today.Date)
                                    {
                                        if (!Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local(evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(),
                                                evt2.Id.ToString(), evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString());

                                        if (Form1.IsFilteringMode_Mittre_EID1)
                                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                               evt2.RecordId.ToString(), evt2.LevelDisplayName.ToString(), evt2.Id.ToString(),
                                                evt2.FormatDescription().ToString(), evt2.TimeCreated.ToString(), (object)evt2);
                                    }
                                }
                            }

                        }
                        catch (Exception err2)
                        {
                            /// "Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'
                            /// to type 'System.Diagnostics.EventLogEntry'." 
                            if (err2.Message.Contains("Unable to cast object of type 'System.Diagnostics.Eventing.Reader.EventLogRecord'"))
                                EventLogEntryError = true;
                        }
                    }
                }

                Form1.IsLocalRemote_SearchReloadFormActived = false;
                CopyBindingSource();
            });
        }


        public void _Reload_Init()
        {

            try
            {
                ThreadStart T_Core1_Search1 = new ThreadStart(delegate
                {
                    
                    Thread.Sleep(3);

                    BGW_LocalEvt_View = new BackgroundWorker();
                    BGW_LocalEvt_View.DoWork += new DoWorkEventHandler(BGW_LocalEvt_View_DoWork);
                    BGW_LocalEvt_View.ProgressChanged += new ProgressChangedEventHandler(BGW_LocalEvt_View_ProgressChanged);
                    BGW_LocalEvt_View.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_LocalEvt_View_RunWorkerCompleted);
                    BGW_LocalEvt_View.WorkerReportsProgress = true;
                    BGW_LocalEvt_View.WorkerSupportsCancellation = true;
                    BGW_LocalEvt_View.RunWorkerAsync();                    
                });

                Thread _T8__CoreSearchThread = new Thread(T_Core1_Search1);
                _T8__CoreSearchThread.Priority = ThreadPriority.Highest;
                _T8__CoreSearchThread.Start();

              

            }
            catch (Exception err)
            {


            }


        }

        void BGW_LocalEvt_View_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DisplayEventAndLogInformation(BGW_LocalEvt_View, e);
            }
            catch (Exception err)
            {


            }
        }

        void BGW_LocalEvt_View_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                try
                {

                    if (!Form1.IsFilteringMode_Mittre_EID1)
                        TempBinding.Add((EventRecord)e.UserState);

                    if (Form1.IsFilteringMode_Mittre_EID1)
                        TempBinding_for_search1.Add((EventRecord)e.UserState);

                    lock (MObj)
                    {
                        Thread.Sleep(2);
                        CastObject = ((EventRecord)e.UserState);
                        
                        if (CastObject == null)
                        {
                            Temps1 = CastObject.RecordId.ToString();
                            Temps2 = CastObject.LevelDisplayName.ToString();
                        }
                        else
                        {
                            if (!Form1.IsFilteringMode_Mittre_EID1)
                                Master_Value.MasterValueClass.SetRows_TO_table_Local(CastObject.RecordId.ToString(), CastObject.LevelDisplayName.ToString(),
                                    CastObject.Id.ToString(),
                                    CastObject.FormatDescription(), CastObject.TimeCreated.ToString());

                            if (Form1.IsFilteringMode_Mittre_EID1)
                                Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1, 
                                    CastObject.RecordId.ToString(), CastObject.LevelDisplayName.ToString(), CastObject.Id.ToString(),
                                    CastObject.FormatDescription(), CastObject.TimeCreated.ToString(),(object) CastObject);

                        }

                    }

                }
                catch (EventLogNotFoundException err)
                {
                   // Master_Value.MasterValueClass.SetRows_TO_table_Local(Temps1, Temps2, " ", "Null -- Message is Null OR Messages NotFound", "");
                }
            }
            catch (Exception err)
            {

                
            }
        }

        public void CopyBindingSource()
        {
            if (!Form1.IsFilteringMode_Mittre_EID1)
                Master_Value.MasterValueClass.LocalBindingSource = TempBinding;

            //GC.Collect();
            //Form1.IsLocalRemote_SearchReloadFormActived = false;
            this.Close();

        }

        void BGW_LocalEvt_View_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Form1.IsLocalRemote_SearchReloadFormActived = false;
                CopyBindingSource();
                //_Thread = new Thread(new ThreadStart(CopyBindingSource));
                //_Thread.Name = "TT-110";
                //_Thread.Start();

                
            }
            catch (Exception err)
            {

                
            }
        }

        public void DisplayEventAndLogInformation(BackgroundWorker bgw, DoWorkEventArgs e)
        {
            try
            {

                //  int i = 0;
                string X = "\"" + Master_Value.MasterValueClass.ActiveNode + "\"";
                string queryString = "*[System/Channel=" + X + "]";

                eventsQuery = new EventLogQuery(Master_Value.MasterValueClass.ActiveNode, PathType.LogName, queryString);
                EventLogSession Local_session = new EventLogSession();

                int counter = 0;
                // Gets Events for Local or Remote Eventlogs 
                eventsQuery.Session = Local_session;
                
                if (Form1.IsFilteringMode_Mittre_EID1)
                {
                    
                    logReader = new EventLogReader(eventsQuery);
                    for (EventRecord eventInstance = logReader.ReadEvent();
                        null != eventInstance; eventInstance = logReader.ReadEvent())
                    {
                        if (Form1.Isclosing) break;
                       
                        try
                        {
                            if (eventInstance.Id == 1)
                            {
                                if (counter == 100) counter = 0;
                                
                                Mitre_Attack.MitreAttackClass.percent = counter;

                                if (!IsFilteredByDateTime)
                                {
                                    bgw.ReportProgress(0, (object)eventInstance);
                                }
                                else
                                {
                                    if(eventInstance.TimeCreated.Value.Date >= dateTimePicker1.Value.Date 
                                        && eventInstance.TimeCreated.Value.Date <= dateTimePicker2.Value.Date)
                                        bgw.ReportProgress(0, (object)eventInstance);
                                }
                                counter++;
                            }
                        }
                        catch (EventLogException eeee)
                        {
                            Console.WriteLine("BEV Internal Error Zero" + eeee.Message);
                        }


                    }
                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                {
                    logReader = new EventLogReader(eventsQuery);
                    for (EventRecord eventInstance = logReader.ReadEvent();
                        null != eventInstance ; eventInstance = logReader.ReadEvent())
                    {
                        if (Form1.Isclosing) break;

                        try
                        {
                            if (!IsFilteredByDateTime)
                            {
                                bgw.ReportProgress(0, (object)eventInstance);
                            }
                            else
                            {
                                if (eventInstance.TimeCreated.Value.Date >= dateTimePicker1.Value.Date 
                                    && eventInstance.TimeCreated.Value.Date <= dateTimePicker2.Value.Date)
                                    bgw.ReportProgress(0, (object)eventInstance);
                            }

                           // bgw.ReportProgress(0, (object)eventInstance);
                        }
                        catch (EventLogException eeee)
                        {
                            Console.WriteLine("BEV Internal Error Zero" + eeee.Message);
                        }


                    }
                }


                }
            catch (Exception err)
            {

                Console.WriteLine("BEV Internal Error Zero" + err.Message);
            }

        }

        public WaitForm2()
        {
            InitializeComponent();
            //TempBinding.DataSource = typeof(System.Diagnostics.Eventing.Reader.EventLogRecord);
            //TempBinding_for_search1.DataSource = typeof(System.Diagnostics.Eventing.Reader.EventLogRecord);
        }

        private void WaitForm2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                IsFilteredByDateTime = false;
                this.Text = "Loading , Please Wait...";
                toolStripStatusLabel1.Text = "Connecting to Local System";
                toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                    + Master_Value.MasterValueClass.ActiveNode_Count + " Records";
                if (Form1.IsFilteringMode_Mittre_EID1)
                {
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_LocalTable();

                statusStrip1.Update();
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                Thread.Sleep(1500);
                this.Update();
                _Reload_Init();

            }
            catch (Exception err)
            {


            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                IsFilteredByDateTime = true;
                this.Text = "Loading , Please Wait...";
                toolStripStatusLabel1.Text = "Connecting to Local System";
                toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                    + Master_Value.MasterValueClass.ActiveNode_Count + " Records";
                if (Form1.IsFilteringMode_Mittre_EID1)
                {
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_LocalTable();
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                Thread.Sleep(1500);
                this.Update();
                _Reload_Init();

            }
            catch (Exception err)
            {


            }
        }

        private void WaitForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.IsLocalRemote_SearchReloadFormActived = false;
        }

        private async void Button4_Click(object sender, EventArgs e)
        {
            try
            {


                IsFilteredByDateTime = false;
                this.Text = "Loading , Please Wait...";
                toolStripStatusLabel1.Text = "Connecting to Local System";
                toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                    + Master_Value.MasterValueClass.ActiveNode_Count + " Records";
                if (Form1.IsFilteringMode_Mittre_EID1)
                {
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_LocalTable();

                statusStrip1.Update();
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                Thread.Sleep(1500);
                this.Update();
            }
            catch (Exception)
            {
            }

            string Xeventname = Master_Value.MasterValueClass.ActiveNode;
            Task _ReloadviaPowershell_All = Powershell_Run_inBackgroud_Fast(false, Xeventname);
            await _ReloadviaPowershell_All.ConfigureAwait(true);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                IsFilteredByDateTime = true;
                this.Text = "Loading , Please Wait...";
                toolStripStatusLabel1.Text = "Connecting to Local System";
                toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                    + Master_Value.MasterValueClass.ActiveNode_Count + " Records";
                if (Form1.IsFilteringMode_Mittre_EID1)
                {
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_LocalTable();
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

                Thread.Sleep(1500);
                this.Update();
               

            }
            catch (Exception err)
            {


            }
            string Xeventname = Master_Value.MasterValueClass.ActiveNode;
            Task _ReloadviaPowershell_All = Powershell_Run_inBackgroud_Fast(true, Xeventname);
            await _ReloadviaPowershell_All.ConfigureAwait(true);
        }

       
        private void Button5_Click_2(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.PaleGoldenrod;
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
