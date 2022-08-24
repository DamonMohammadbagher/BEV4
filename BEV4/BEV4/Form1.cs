using BEV4.Local_Forms;
using BEV4.Remote_Forms;
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
using BEV4.Remote_Forms;
using BEV4.Filtering.Local;
using System.Threading;
using System.Management.Automation;
//using Microsoft.WSMan.Management;
using System.Diagnostics;

namespace BEV4
{

    public partial class Form1 : Form
    {

        /// <summary>
        /// Basic Event Viewer v4.3 For Windows 10 and Windows Server (.NET Framework 4.5) 2009-2022 , Published by Damon Mohammadbagher.
        /// 
        /// Note: I Created this code in 2009 & in May 2022 Updated by me to Work with Win7/Win10/11  (tested by Win10, with .NetFramework 4.5),
        /// also Some Security Features Like Working with ETWProcessMon2/ETWPM2Monitor2/Sysmon Logs will add this Source Code soon! ;)
        /// 
        /// </summary>
        
        public static System.Timers.Timer t = new System.Timers.Timer(100);
        public static System.Timers.Timer t1 = new System.Timers.Timer(5000);
        public static System.Timers.Timer t2 = new System.Timers.Timer(400);
        public static System.Timers.Timer t3 = new System.Timers.Timer(5000);
        public static System.Timers.Timer t4 = new System.Timers.Timer(10000);
        Mitre_Attack.MitreAttackClass mitre = new Mitre_Attack.MitreAttackClass();
        private BindingSource TempBinding_Local;
        private BindingSource TempBinding_Remote;
        //private EventRecord CastObject = null;
        private bool init = false;
        private bool init2 = false;
        public static bool IsLocalRemote_SearchReloadFormActived = false;
        public static bool PSFormIsActive = false;
        public static bool IsStopRealTime = false;
        public static bool IsRealTimeOn = false;
        public static bool Isclosing = false;
        public static bool _IsScanningFast = true;
        public static bool _IsScanningSlow = false;
        public delegate BindingSource _Core2(string str);
        public delegate void _Core1(string str);
        public delegate void _Core3(TreeNode obj);
        public delegate void _Core4(object s1, object s2);
        public delegate void _Core0();       
        public static Thread _Thread_RealTimeMon;
        public static event EventHandler Save_MittreAttack_Result_1;
                
        public int CountEvents = 0;
        public DateTime dt = DateTime.Now;
        public string _Description = "";
        public static bool IsFilteringMode_Mittre_EID1 = false;
        public List<ListViewItem> SortedList1 = new List<ListViewItem>();
        public List<ListViewItem> SortedList2 = new List<ListViewItem>();
        public static List<ListViewItem> SortedList3_HighScore = new List<ListViewItem>();
        public List<ListViewItem> SortedList4_HSTruePositives = new List<ListViewItem>();
        public ListViewItem iList2 = new ListViewItem();
        public List<string> DetectedList_Listview2 = new List<string>();
        public static string Textbox1Text = "";
        private static string EIDSelected = "";
        private static string TempScript = "";
        public static EventLog BEV4 = null;
        public static string CurrentStr = "";
        public static string CurrentStr2 = "";
        public static bool IsSummary = false;
        public static bool IsSummary_Details = false;       
        
        public void Refresh_Remote_TreeNodes()
        {
            try
            {
                treeView2.Nodes.Clear();
                treeView2.Nodes.Add(Master_Value.MasterValueClass._RemoteConnection_Root_Nodes);
                treeView2.Refresh();

            }
            catch (Exception err)
            {

            }
        }

        public async Task Refresh_Remote_DataGrid_3and4()
        {
            await Task.Run(() =>
            {
                try
                {
                   
                    TempBinding_Remote.DataSource = Master_Value.MasterValueClass.table_Remoting;
                    dataGridView3.DataSource = TempBinding_Remote;

                    dataGridView3.Update();
                    dataGridView3.Refresh();

                    groupBox6.Text = Master_Value.MasterValueClass.Remote_Description_Groupbox6;
                  
                }
                catch (Exception err)
                {

                    MessageBox.Show(null, "Loading Error " + "\n" + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        public void Refresh_Local_TreeNodes()
        {
            try
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(Master_Value.MasterValueClass._LocalConnection_Root_Nodes);
                treeView1.Refresh();

            }
            catch (Exception err)
            {

            }
        }

        public async Task Refresh_Local_DataGrid1and2()
        {
          await Task.Run(() =>
            {
                try
                {

                    TempBinding_Local.DataSource = Master_Value.MasterValueClass.table_Local;
                    dataGridView2.DataSource = TempBinding_Local.DataSource;

                    dataGridView2.Update();
                    dataGridView2.Refresh();

                    dataGridView2.Visible = true;
                    dataGridView2.Show();

                    groupBox6.Text = Master_Value.MasterValueClass.Local_Description_Groupbox6;

                }
                catch (Exception err)
                {

                    MessageBox.Show(null, "Loading Error " + "\n" + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        public Form1()
        {

            try
            {
                InitializeComponent();
                TempBinding_Remote = new BindingSource();
                TempBinding_Local = new BindingSource();

            }
            catch (Exception error)
            {
                MessageBox.Show(null, "Loading Error " + "\n" + error.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            tabControl1.Refresh();

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Text != null && Master_Value.MasterValueClass.Remote_Host_Name != null)
                {

                    toolStripStatusLabel_Nodes.Text = e.Node.Text + " (" + e.Node.ToolTipText + ")";
                    Master_Value.MasterValueClass.ActiveNode_Count = e.Node.ToolTipText;
                    Master_Value.MasterValueClass.ActiveNode = e.Node.Text;
                }
            }
            catch (Exception error)
            {


            }


        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Forms.Remote_Connection_MainForm RF = new BEV4.Remote_Forms.Remote_Connection_MainForm();
                RF.ShowDialog();
                Refresh_Remote_TreeNodes();
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception error)
            {


            }


        }

        public async Task _Reload_Remote()
        {
            await Task.Run(() =>
            {
                try
                {

                    tabControl1.SelectedIndex = 1;
                    if (Master_Value.MasterValueClass.Remote_Host_Name != null)
                    {
                        Master_Value.MasterValueClass.RemoteBindingSource.DataSource = typeof(System.Diagnostics.Eventing.Reader.EventLogRecord);
                        Master_Value.MasterValueClass.RemoteBindingSource.Clear();
                        Master_Value.MasterValueClass.table_Remoting.Clear();
                        Master_Value.MasterValueClass.Settable_RemoteTable();
                      
                        Master_Value.MasterValueClass.Remote_Description_Groupbox6 = "Event Messages for Event Name (" + Master_Value.MasterValueClass.ActiveNode + ") " + " , Remote System Name : " + Master_Value.MasterValueClass.Remote_Host_Name;

                    }
                    else if (Master_Value.MasterValueClass.Remote_Host_Name == null)
                    {

                    }


                }
                catch (Exception err)
                {

                    MessageBox.Show(null, "Loading Error " + "\n" + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            WaitForm WForm = new WaitForm();
            WForm.ShowDialog();
            Thread.Sleep(1500);
            await Refresh_Remote_DataGrid_3and4();
        }

        private async void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRealTimeOn)
                {
                   // await _Reload_Remote();
                    BeginInvoke((MethodInvoker)delegate { RunAsyn__Reload_Remote(); });
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitoring is ON\nPlease First Stop this!", "Warning!");

                }
                
            }
            catch (Exception)
            {

            }
        }

        public void _Set_iListview_Properties(ListView TargetListView, string[] _ColumnsText, int[] _widthColumns, ImageList imglist)
        {

            TargetListView.SmallImageList = imglist;
            /// Set the view to show details.
            TargetListView.View = View.Details;
            /// Allow the user to edit item text.
            TargetListView.LabelEdit = false;
            /// Allow the user to rearrange columns.
            TargetListView.AllowColumnReorder = true;
            /// Display check boxes.
            TargetListView.CheckBoxes = false;
            /// Select the item and subitems when selection is made.
            TargetListView.FullRowSelect = true;
            /// Display grid lines.
            TargetListView.GridLines = false;           

            int icounter = 0;

            foreach (string item in _ColumnsText)
            {
                TargetListView.Columns.Add(item, _widthColumns[icounter], HorizontalAlignment.Left);
                icounter++;
            }

        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            try
            {
                Form.CheckForIllegalCrossThreadCalls = false;
                toolStripProgressBar2.AutoToolTip = true;
                try
                {
                   
                    if (!EventLog.Exists("BEV4.3"))
                    {
                        EventSourceCreationData ESCD = new EventSourceCreationData("BEV_4", "BEV4.3");
                        System.Diagnostics.EventLog.CreateEventSource(ESCD);

                    }

                    BEV4 = new EventLog("BEV4.3", ".", "BEV_4");
                    BEV4.WriteEntry("BEV4 Started", EventLogEntryType.Information, 1);
                }
                catch (Exception ee)
                {
                  
                }

                t.Elapsed += T_Elapsed;
                t.Enabled = false;
                t1.Elapsed += T1_Elapsed;
                t1.Enabled = false;
                t2.Elapsed += T2_Elapsed;
                t2.Enabled = false;
                t3.Elapsed += T3_Elapsed;
                t3.Enabled = false;
                t4.Elapsed += T4_Elapsed;
                tabControl1.SelectedIndex = 0;
                // this.Icon = SystemIcons.Shield;
                GC.Collect();

                dataGridView3.Hide();
                //dataGridView4.Hide();
                //dataGridView1.Show();
                dataGridView2.Show();

                dataGridView3.RowEnter += new DataGridViewCellEventHandler(dataGridView3_RowEnter);
                dataGridView3.DataError += new DataGridViewDataErrorEventHandler(dataGridView3_DataError);
                //dataGridView4.DataError += new DataGridViewDataErrorEventHandler(dataGridView4_DataError);

                tabControl1.SelectedIndex = 0;
                Local_Class _LocalClass = new Local_Class();
                string Lhost = System.Environment.MachineName;
                _LocalClass._Connect(Lhost);
                Refresh_Local_TreeNodes();

                _Set_iListview_Properties(listView1, new string[] { " ","Event Time", "Display Name", "TechniqueID", "Your Query","Technique Description"
                 , "Event Message"}
                , new int[] { 25,120, 180, 100,100, 200,200 }, imageList1);
               

                _Set_iListview_Properties(listView2, new string[] { " ","Event Time","TechniqueID", "Display Name", "Detection Score",
                    "DB SubItemIndex","Process Name","PID","CommandLine","EventRecord_Id", "Event Message"}
              , new int[] { 20, 130, 100, 180, 100, 140,140, 50,400,100,100 }, imageList1);


                //_Set_iListview_Properties(listView3, new string[] { " ","Event Time","TechniqueID", "Display Name", "Detection Score",
                //    "SubItemIndex:CheckScore","Process Name","PID","CommandLine","Event_Record_Id", "Event Message"}
                //    , new int[] { 20, 130, 100, 180, 100, 140, 140, 50, 400, 100, 100 }, imageList1);

                /// event for Save MItreSearch Results_1
                Save_MittreAttack_Result_1 += Form1_Save_MittreAttack_Result_1;

               
            }
            catch (Exception err)
            {

            }

            try
            {
                treeView3.Nodes.Add("Respond Analysis");
                foreach (TabPage item in tabControl6.TabPages)
                {
                    treeView3.Nodes[0].Nodes.Add(item.Text);
                }

                treeView3.ExpandAll();
                treeView4.Nodes.Add("Log Auditing");
                foreach (TabPage item in tabControl8.TabPages)
                {
                    if(!item.Text.StartsWith("0.Intrusion EventIDs"))
                    treeView4.Nodes[0].Nodes.Add(item.Text);
                }

                treeView4.Nodes[0].Nodes.Add("Intrusion EventIDs (Purple Teaming)");
                treeView4.ExpandAll();
                

                string[] BluePurpleTeam_Events = Mitre_Attack.Resource1.EventIDs.Split('\n');
                dataGridView8.Columns.Add("EventID", "EID");
                dataGridView8.Columns.Add("Evtname", "Event Name");
                dataGridView8.Columns.Add("Description", "Event Description");

                foreach (string item in BluePurpleTeam_Events)
                {
                    if (!item.StartsWith("#") && item.ToLower().StartsWith("event"))
                    {                       
                        dataGridView8.Rows.Add(new object[]
                        { (object)item.Split(':')[0].Split(' ')[2],
                          (object)item.Split(':')[1],
                          (object)"security"
                        });

                    }
                }
            }
            catch (Exception)
            {

               
            }


            try
            {

                if (!File.Exists("BEV_Temp.tmp"))
                {
                    FileStream fs = File.Create("BEV_Temp.tmp");
                    using (fs)
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(Master_Value.Large_String.All_Security_Events_Description2);
                        fs.Write(info, 0, info.Length);
                    }

                    Master_Value.Reloading_EventsID.GetAllEvents(fs.Name, false);
                    File.Delete(fs.Name);
                }
                else
                {
                    File.Delete("BEV_Temp.tmp");
                }


            }
            catch (Exception err)
            {


            }

            try
            {
                Master_Value.MasterValueClass.Settable_MitreAttackTechniques();
                string CommandsListFile = RealTime.Resource2.TextFile1_AllCommandPrompts;

                /// 365: [- name: Enumeration for PuTTY Credentials in Registry] [attack_technique: T1552.002] [      reg query HKCU\Software\SimonTatham\PuTTY\Sessions /t REG_SZ /s]
                string[] _DetailsCommands_yamlfiles_details = CommandsListFile.Split('\n');
                string steps = "";
                int count = 0;
                string temp = "";
                foreach (string item in _DetailsCommands_yamlfiles_details)
                {
                    if (!item.Contains(" [    command: |]"))
                    {
                        try
                        {
                            if (item.Split('[')[1].Split(']')[0].Substring(8) == temp)
                            {
                                count++;
                            }
                            else { count = 0; }
                            string techId = item.Split('[')[2].Split(']')[0].Substring(18);
                            Master_Value.MasterValueClass.SetRows_TO_table_MitreAttackTechniques(Master_Value.MasterValueClass.table_MitreAttackTechniques
                            , Convert.ToInt32(item.Split(':')[0])
                            , item.Split('[')[1].Split(']')[0].Substring(8)
                            , item.Split('[')[2].Split(']')[0].Substring(18)
                            , count
                            , item.Substring(Mitre_Attack.MitreAttackClass._FindAllIndex("attack_technique:", item, 0)[0] + 17 + techId.Length + 3)
                            , "", "");
                            temp = item.Split('[')[1].Split(']')[0].Substring(8);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

                dataGridView7.DataSource = Master_Value.MasterValueClass.table_MitreAttackTechniques;
            }
            catch (Exception)
            {

               
            }

            /// reload BEV4.3 Events When BEV4 Started.
            /// bad bug fixed here ;)
            try
            {
                treeView1.ExpandAll();               
                treeView1.SelectedNode = treeView1.Nodes.Find("Application", true)[0];                

                BeginInvoke((MethodInvoker)delegate { RunAsync_BEVStartupLoading(); });
            }
            catch (Exception)
            {
           
            }

        }

        public async void RunAsync_BEVStartupLoading()
        {
            await BEVStartupLoading();
        }

        private async Task BEVStartupLoading()
        {
            try
            {
                IsFilteringMode_Mittre_EID1 = false;
                //Master_Value.MasterValueClass.ActiveNode = "BEV4.3";
                Master_Value.MasterValueClass.ActiveNode = "Application";
                if (IsFilteringMode_Mittre_EID1)
                {
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                }

                if (!IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_LocalTable();
            }
            catch (Exception)
            {
            }
        
            WaitForm2 wf2 = new WaitForm2();
            string Xeventname = Master_Value.MasterValueClass.ActiveNode;
            Task _ReloadviaPowershell_All = wf2.Powershell_Run_inBackgroud_Fast_once(true, Xeventname);
            await _ReloadviaPowershell_All.ConfigureAwait(false);

            do
            {

                Thread.Sleep(50);

            } while (!_ReloadviaPowershell_All.IsCompleted);

            groupBox6.Text = "Event Messages for Event Name (" + Master_Value.MasterValueClass.ActiveNode + ") Filter: TODAY events only"
           + " , Local System";


            await Task.Run(() =>
            {

                BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {

                        TempBinding_Local.DataSource = Master_Value.MasterValueClass.table_Local;
                        dataGridView2.DataSource = TempBinding_Local.DataSource;

                        dataGridView2.Update();
                        dataGridView2.Refresh();

                        dataGridView2.Visible = true;
                        dataGridView2.Show();

                    }
                    catch (Exception err)
                    {

                    }
                });
           });

        }

        private async void T4_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
            t3.Enabled = false;
            t3.Stop();
         
            await Task.Run(() =>
            {
                try
                {
                    toolStripStatusLabel10.BackColor = Color.DarkGray;
                   // int count = 0;
                    if (IsSummary_Details)
                    {
                        
                        foreach (ListViewItem obj in SortedList3_HighScore.OrderByDescending(x => x.SubItems[4].Text))
                        {
                            try
                            {
                               // if (count >= 10) break;

                                string Note = "Note: TechniqueID (" + obj.SubItems[2].Text + ") with High Score ["
                                + obj.SubItems[4].Text.ToString() + "] Detected for Process"
                                + obj.SubItems[6].Text.Replace('\r', ' ') + " (PID:" + obj.SubItems[7].Text.ToString() + ")";
                                Thread.Sleep(1500);
                                if (Note != null && !string.IsNullOrWhiteSpace(Note) && !IsSummary)
                                {
                                    var _Delay = Task.Delay(TimeSpan.FromSeconds(2));
                                    do
                                    {
                                        Thread.Sleep(2);
                                        if (_Delay.IsCompleted)
                                        {
                                            break;
                                        }

                                    } while (!_Delay.IsCompleted);

                                    Thread.Sleep(50);
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        toolStripStatusLabel10.Text = Note;
                                    });
                                }

                               
                            }
                            catch (Exception)
                            {

                                //   throw;
                            }

                           // count++;
                        }                      
                    }

                    IsSummary = true;
                    IsSummary_Details = false;
                    t3.Enabled = true;
                    t3.Start();
                    t4.Enabled = false;
                    t4.Stop();

                }
                catch (Exception)
                {

                }
            });

           
        }

        private async void T3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                if (IsSummary)
                {
                    IsSummary = false;
                    IsSummary_Details = false;
                    t4.Enabled = false;
                    t4.Stop();
                }
                else
                {
                    IsSummary = false;
                    IsSummary_Details = true;
                    t4.Enabled = true;
                    t4.Start();
                }
            });
        }

        private async void RunAsync_RefreshCurrentScan(object obj1, object obj2)
        {
            await RefreshCurrentScan(obj1, obj2);
        }

        private async Task RefreshCurrentScan(object CurrentScan, object CurrentScan2)
        {
            await Task.Run(() =>
             {
                

                 try
                 {
                     Delegate _RefreshCurrentScan2 = ((MethodInvoker)delegate
                     {
                         try
                         {
                             if (!toolStripStatusLabel8.Text.Contains("Scan Finished!"))
                             {

                                 toolStripStatusLabel12.Text = "[" +
                                 (RealTime.RealtimeEventIDsMonitor.iCounter + 1).ToString()
                                 + " of " +
                                 RealTime.RealtimeEventIDsMonitor.icounter_Max.ToString() + "]";
                             }
                         }
                         catch (Exception)
                         {


                         }
                     });

                     Task.Run(() => { BeginInvoke((MethodInvoker)delegate { _RefreshCurrentScan2.DynamicInvoke(); }); }).GetAwaiter();
                 }
                 catch (Exception)
                 {


                 }

                 try
                 {
                     Delegate _RefreshCurrentScan1 = ((MethodInvoker)delegate
                     {
                         try
                         {
                             if (!toolStripStatusLabel8.Text.Contains("Scan Finished!"))
                             {
                                 if (RealTime.RealtimeEventIDsMonitor.iCounter > 0)
                                     toolStripProgressBar2.Value =
                                         RealTime.RealtimeEventIDsMonitor.iCounter * 100
                                         / RealTime.RealtimeEventIDsMonitor.icounter_Max;
                             }
                             else toolStripProgressBar2.Value = 0;
                         }
                         catch (Exception)
                         {
                             toolStripProgressBar2.Value = 0;
                         }
                     });

                     Task.Run(() =>
                     {
                         BeginInvoke((MethodInvoker)delegate
                         {
                             try
                             {
                                 _RefreshCurrentScan1.DynamicInvoke();

                             }
                             catch (Exception)
                             {


                             }
                         });

                     }).GetAwaiter();

                 }
                 catch (Exception)
                 {

                 }

                 try
                 {
                     Delegate _RefreshCurrentScan = ((MethodInvoker)delegate
                     {
                         try
                         {

                             if (CurrentScan2 != null && CurrentStr2 != CurrentScan2.ToString()
                             && !string.IsNullOrWhiteSpace(CurrentScan2.ToString()))
                             {
                                 toolStripStatusLabel6.Text = CurrentScan2.ToString();
                                 CurrentStr2 = CurrentScan2.ToString();
                             }

                             if (CurrentScan != null && CurrentStr != CurrentScan.ToString()
                             && !string.IsNullOrWhiteSpace(CurrentScan.ToString()))
                             {
                                 toolStripStatusLabel8.Text = CurrentScan.ToString();
                                 CurrentStr = CurrentScan.ToString();
                             }
                         }
                         catch (Exception)
                         {
                          
                         }
                     });

                     Task.Run(() => { BeginInvoke((MethodInvoker)delegate { _RefreshCurrentScan.DynamicInvoke(); }); }).GetAwaiter();
                 }
                 catch (Exception)
                 {


                 }

                 Thread.Sleep(1500);
             });
        }
      
        private void T1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
          
        }

        private async void T2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            //Delegate _RefreshCurrentScan = ((MethodInvoker)delegate
            //{
            //         RunAsync_RefreshCurrentScan(RealTime.RealtimeEventIDsMonitor.CurrentScan,
            //         RealTime.RealtimeEventIDsMonitor.CurrentScan2);

            //});

            //System.Runtime.CompilerServices.TaskAwaiter _Task =
            //    Task.Run(() => { _RefreshCurrentScan.DynamicInvoke(); }).GetAwaiter();

            await RefreshCurrentScan(RealTime.RealtimeEventIDsMonitor.CurrentScan,
                          RealTime.RealtimeEventIDsMonitor.CurrentScan2);

            await Task.Run(() =>
            {
                listView2.BeginInvoke((MethodInvoker)delegate
                 {
                     try
                     {
                         int counts = 0;
                         List<RealTime.RealtimeEventIDsMonitor._TableOfSysmon_Processes> list =
                        new List<RealTime.RealtimeEventIDsMonitor._TableOfSysmon_Processes>();

                         string tmp = "";

                         try
                         {
                             toolStripStatusLabel10.BackColor = Color.DarkGray;                           
                             if (IsSummary && !IsSummary_Details && !t4.Enabled)
                                 toolStripStatusLabel10.Text = "Detection Summary: FullScore Detected: [" + SortedList4_HSTruePositives.Count.ToString()
                                 + "] , HighScore Detected: [" + SortedList3_HighScore.Count.ToString() + "]";
                         }
                         catch (Exception)
                         {

                         }


                         if (RealTime.RealtimeEventIDsMonitor.Sysmon_Process_Table.Count > 0)
                         {
                             try
                             {                               
                                 //list = RealTime.RealtimeEventIDsMonitor.Sysmon_Process_Table
                                 //.OrderBy(x => x.TechniqueID_Name).Distinct()
                                 //.ToList()
                                 //.FindAll(x => Convert.ToInt32(x.ProcessItemsDetectedCount_Score.Split('/')[0]) >= 2)
                                 //.ToList();

                                 list = RealTime.RealtimeEventIDsMonitor.Sysmon_Process_Table.FindAll(x =>
                                       x.ProcessItemsDetectedCount_Score != "0" 
                                    && x.ProcessItemsDetectedCount_Score != null)
                                 .FindAll(x => Convert.ToInt32(x.ProcessItemsDetectedCount_Score.Split('/')[0]) >= 2
                                    || Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[1]) / 2 <
                                       Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[0])
                                    || Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[1]) / 2 ==
                                       Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[0]) / 2 )
                                   //.OrderBy(x => x.TechniqueID_Name)
                                   .ToList();
                                                                      
                             }
                             catch (Exception)
                             {

                             }

                             if (list != null)
                                 counts = list.Count;

                             if (counts != listView2.Items.Count)
                             {
                                 foreach (RealTime.RealtimeEventIDsMonitor._TableOfSysmon_Processes items in list)
                                 {
                                     //Task.Delay(20);
                                     Task.Delay(20).GetAwaiter();

                                     if (DetectedList_Listview2.FindIndex(x => x == items.ProcessName + "@" + items.PID.ToString()
                                            + "@" + items.ProcessItemsDetectedCount_Score.ToString() + items.Event_Record_ID.ToString()
                                            + " [" + items.CheckingMitreSubItems_Index.ToString() + "]"
                                            + items.TechniqueID_Name + "@" + items.TechniqueID) == -1)
                                     {

                                         iList2 = new ListViewItem();

                                         iList2.SubItems.Add(items.EventTime.ToString());
                                         iList2.SubItems.Add(items.TechniqueID);
                                         iList2.SubItems.Add(items.TechniqueID_Name);
                                         iList2.SubItems.Add(items.ProcessItemsDetectedCount_Score.ToString());
                                         iList2.SubItems.Add(items.CheckingMitreSubItems_Index.ToString());
                                         iList2.SubItems.Add(items.ProcessName);
                                         iList2.SubItems.Add(items.PID.ToString());
                                         iList2.SubItems.Add(items._CommandLine);
                                         iList2.SubItems.Add(items.Event_Record_ID.ToString());
                                         iList2.SubItems.Add(items._EventMessage);
                                         iList2.Name = items._EventMessage;

                                         float a = Convert.ToSingle(items.ProcessItemsDetectedCount_Score.Split('/')[1]) / 2;
                                         float b = Convert.ToSingle(items.ProcessItemsDetectedCount_Score.Split('/')[0]);

                                         try
                                         {
                                             toolStripStatusLabel10.BackColor = Color.DarkGray;

                                       //      if (!IsSummery && !IsSummery_Details)
                                       //      {
                                       //          var obj = RealTime.RealtimeEventIDsMonitor.Sysmon_Process_Table.FindAll(x =>
                                       //      x.ProcessItemsDetectedCount_Score != "0"
                                       //   && x.ProcessItemsDetectedCount_Score != null)
                                       //.FindAll(x => Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[1]) / 2 ==
                                       //      Convert.ToSingle(x.ProcessItemsDetectedCount_Score.Split('/')[0]) / 2)
                                       //  .OrderBy(x => x.TechniqueID_Name).Last();
                                  
                                       //          toolStripStatusLabel10.Text = "Note: TechniqueID (" + obj.TechniqueID + ") with High Score ["
                                       //                 + obj.ProcessItemsDetectedCount_Score.ToString()+ "] Detected for Process"
                                       //                 + obj.ProcessName_Path.Replace('\r', ' ') + " (PID:" + obj.PID.ToString() + ")";
                                       //      }
                                       //      else

                                             if (IsSummary && !IsSummary_Details && !t4.Enabled)
                                                 toolStripStatusLabel10.Text = "Detection Summary: FullScore Detected: [" + SortedList4_HSTruePositives.Count.ToString()
                                                 + "] , HighScore Detected: [" + SortedList3_HighScore.Count.ToString() + "]";
                                         }
                                         catch (Exception)
                                         {

                                         }


                                         if (a == b / 2)
                                         {
                                             iList2.ImageIndex = 9;
                                             iList2.ForeColor = Color.Red;

                                             if (iList2.SubItems[3].Text + "@" + iList2.SubItems[4].Text != tmp)
                                             {
                                                 listView2.Items.Add((ListViewItem)iList2.Clone());
                                                 Thread.Sleep(10);
                                             }

                                             SortedList4_HSTruePositives.Add(iList2);
                                             SortedList3_HighScore.Add(iList2);

                                             try
                                             {
                                                 toolStripStatusLabel10.BackColor = Color.DarkGray;

                                                 if (IsSummary && !IsSummary_Details && !t4.Enabled)
                                                     toolStripStatusLabel10.Text = "Detection Summary: FullScore Detection: [" + SortedList4_HSTruePositives.Count.ToString()
                                                     + "] , HighScore Detection: [" + SortedList3_HighScore.Count.ToString() + "]";
                                             }
                                             catch (Exception)
                                             {

                                             }

                                             /// create event id 2 in BEV4.3 EventLog
                                             RealTime.RealtimeEventIDsMonitor._RunAsync_Save_New_DetectionLogs_Events_to_WinEventLog((object)iList2);
                                         }
                                         else
                                            if (a < b)
                                         {


                                             try
                                             {
                                                 toolStripStatusLabel10.BackColor = Color.DarkGray;

                                                 if (IsSummary && !IsSummary_Details && !t4.Enabled)
                                                     toolStripStatusLabel10.Text = "Detection Summary: FullScore Detected: [" + SortedList4_HSTruePositives.Count.ToString()
                                                     + "] , HighScore Detected: [" + SortedList3_HighScore.Count.ToString() + "]";
                                             }
                                             catch (Exception)
                                             {

                                             }

                                             iList2.ImageIndex = 9;
                                             iList2.ForeColor = Color.DarkOrange;

                                             if (iList2.SubItems[3].Text + "@" + iList2.SubItems[4].Text != tmp)
                                             {
                                                 listView2.Items.Add((ListViewItem)iList2.Clone());
                                                 Thread.Sleep(10);
                                             }

                                             SortedList3_HighScore.Add(iList2);
                                             /// create event id 2 in BEV4.3 EventLog
                                             RealTime.RealtimeEventIDsMonitor._RunAsync_Save_New_DetectionLogs_Events_to_WinEventLog((object)iList2);

                                         }
                                         else
                                         {

                                             try
                                             {
                                                 toolStripStatusLabel10.BackColor = Color.DarkGray;

                                                 if (IsSummary && !IsSummary_Details && !t4.Enabled)
                                                     toolStripStatusLabel10.Text = "Detection Summary: FullScore Detected: [" + SortedList4_HSTruePositives.Count.ToString()
                                                     + "] , HighScore Detected: [" + SortedList3_HighScore.Count.ToString() + "]";
                                             }
                                             catch (Exception)
                                             {

                                             }

                                             iList2.ImageIndex = 10;
                                             iList2.ForeColor = Color.Black;

                                             if (iList2.SubItems[3].Text + "@" + iList2.SubItems[4].Text != tmp)
                                             {
                                                 listView2.Items.Add((ListViewItem)iList2.Clone());
                                                 Thread.Sleep(10);
                                                 /// create event id 3 in BEV4.3 EventLog
                                                 RealTime.RealtimeEventIDsMonitor._RunAsync_Save_New_DetectionLogs_Events_to_WinEventLog2((object)iList2);

                                             }
                                         }

                                         tmp = iList2.SubItems[3].Text + "@" + iList2.SubItems[4].Text;
                                         a = 0;
                                         b = 0;
                                         Task.Delay(5);

                                         DetectedList_Listview2.Add(items.ProcessName + "@" + items.PID.ToString()
                                              + "@" + items.ProcessItemsDetectedCount_Score.ToString() + items.Event_Record_ID.ToString()
                                              + " [" + items.CheckingMitreSubItems_Index.ToString() + "]"
                                              + items.TechniqueID_Name + "@" + items.TechniqueID);
                                     }
                                 }
                             }
                         }
                     }
                     catch (Exception)
                     {

                     }
                 });
            });

        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
                try
                {
                   
                    toolStripProgressBar1.Value = Mitre_Attack.MitreAttackClass.percent;
                    toolStripStatusLabel3.Text = "(Checking: " + Mitre_Attack.MitreAttackClass.TechniqueIDDisplayName + " )";
                    toolStripStatusLabel4.Text = "(" + Mitre_Attack.MitreAttackClass.TechniqueID + ")";
                }
                catch (Exception)
                {

                }
           
        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView3.Show();
                dataGridView3.Visible = true;

                try
                {

                    if (Master_Value.MasterValueClass.RemoteBindingSource.Position != e.RowIndex)
                    {
                        Master_Value.MasterValueClass.RemoteBindingSource.Position = e.RowIndex;

                        /// fix error ;) with init

                        richTextBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                                                
                        if (e.RowIndex == 0 && !init2) init2 = true;
                    }


                }
                catch (Exception err)
                {

                    if (err.Message == "Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index")
                    {

                    }


                }
            }
            catch (Exception err)
            {


            }

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
               
                try
                {

                    if (Master_Value.MasterValueClass.LocalBindingSource.Position != e.RowIndex)
                    {
                        Master_Value.MasterValueClass.LocalBindingSource.Position = e.RowIndex;

                        /// fix error ;) with init

                        richTextBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        
                        if (e.RowIndex == 0 && !init) init = true;
                    }


                }
                catch (Exception err)
                {

                    if (err.Message == "Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index")
                    {
                       
                    }

                }
            }
            catch (Exception err)
            {


            }

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch (Exception err)
            {


            }

        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
             
            }
            catch (Exception err)
            {


            }

        }

        private void aboutBEVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox1 ABFM = new AboutBox1();
                ABFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void RunAsyn__Reload_Local()
        {
            await _Reload_Local();
        }

        public async void RunAsyn__Reload_Remote()
        {
            await _Reload_Remote();
        }

        private async void relaodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRealTimeOn)
                {
                    //  await _Reload_Local();
                    BeginInvoke((MethodInvoker)delegate { RunAsyn__Reload_Local(); });
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitoring is ON\nPlease First Stop this!", "Warning!");
                }
            }
            catch (Exception err)
            {


            }
            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 0;
                Local_Class LClass = new Local_Class();
                string Lhost = System.Environment.MachineName;
                LClass._Connect(Lhost);
                Refresh_Local_TreeNodes();

            }
            catch (Exception err)
            {


            }
        }

        private void remoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Class RClass = new Remote_Class();
                if (treeView2.SelectedNode.ToolTipText == null | treeView2.SelectedNode.ToolTipText == string.Empty | treeView2.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Selected Event is Empty or Not Found any Record for this Event" + "\nSystem Error: ", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RClass.RemoteEventSave(treeView2.SelectedNode.Text);
                }
                else
                {
                    RClass.RemoteEventSave(treeView2.SelectedNode.Text);
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(null, "Warning : Remote System " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Class RClass = new Remote_Class();
                Local_Class LClass = new Local_Class();

                if (treeView1.SelectedNode.ToolTipText == null | treeView1.SelectedNode.ToolTipText == string.Empty | treeView1.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Selected Event is Empty or Not Found any Record for this Event" + "\nSystem Error: ", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LClass.LocalEventSave(treeView1.SelectedNode.Text);
                }
                else
                {
                    LClass.LocalEventSave(treeView1.SelectedNode.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(null, "Warning : Local System " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process MyProcessHelp = new System.Diagnostics.Process();
                MyProcessHelp.StartInfo.FileName = "BEV4.CHM";
                MyProcessHelp.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(null, "Loading Error " + "\n" + "File 'BEV4.CHM' can not loading!\n" + error.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ChangeTreviewInfo(TreeNode Node)
        {
            try
            {
                if (Node != null)
                {
                    toolStripStatusLabel_Nodes.Text = Node.Text + " (" + Node.ToolTipText + ")";
                    Master_Value.MasterValueClass.ActiveNode_Count = Node.ToolTipText;
                    Master_Value.MasterValueClass.ActiveNode = Node.Text;
                }

            }
            catch (Exception err)
            {


            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Text != null)
                {                  
                    ThreadStart T_Core1_Search1 = new ThreadStart(delegate
                    {
                         BeginInvoke(new _Core3(ChangeTreviewInfo), e.Node);
                       
                    });
                    Thread _T8__CoreScanThread = new Thread(T_Core1_Search1);
                    _T8__CoreScanThread.Priority = ThreadPriority.Highest;
                    _T8__CoreScanThread.Start();

                }

            }
            catch (Exception err)
            {


            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";
                if (tabControl1.SelectedIndex == 0)
                {
                    groupBox6.Text = Master_Value.MasterValueClass.Local_Description_Groupbox6;
                    if (groupBox6.Text == string.Empty)
                    {
                        groupBox6.Text = "Event Messages";
                    }

                    dataGridView3.Hide();                   
                    dataGridView2.Show();
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = TempBinding_Local;


                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    groupBox6.Text = Master_Value.MasterValueClass.Remote_Description_Groupbox6;
                    if (groupBox6.Text == string.Empty)
                    {
                        groupBox6.Text = "Event Messages";
                    }

                    dataGridView2.Hide();
                    dataGridView3.Show();
                    dataGridView3.Visible = true;
                    dataGridView3.DataSource = TempBinding_Remote;

                }
            }
            catch (Exception err)
            {


            }
        }

        public async Task _Reload_Local()
        {
            IsLocalRemote_SearchReloadFormActived = true;
            await Task.Run(() =>
            {
                try
                {

                    Master_Value.MasterValueClass.LocalBindingSource.Clear();
                    Master_Value.MasterValueClass.table_Local.Clear();
                    Master_Value.MasterValueClass.Settable_LocalTable();
                                       
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    
                    dataGridView2.Show();                    
                    dataGridView2.Visible = true;

                    richTextBox1.Text = "";
                    /// true => force waitform2 to search event id 1 only for search CreateProcess only (Mitre attack)
                    IsFilteringMode_Mittre_EID1 = false;
                    Master_Value.MasterValueClass.ActiveNode = toolStripStatusLabel_Nodes.Text.Split('(')[0];
                    Master_Value.MasterValueClass.ActiveNode = Master_Value.MasterValueClass.ActiveNode.Substring(0, Master_Value.MasterValueClass.ActiveNode.Length - 1);
                    WaitForm2 WForm2 = new WaitForm2();
                    WForm2.ShowDialog();

                    Master_Value.MasterValueClass.Local_Description_Groupbox6 = "Event Messages for Event Name (" + Master_Value.MasterValueClass.ActiveNode + ") "
                        + " , Local System";
                 
                }
                catch (Exception err)
                {


                }
            });

            await Refresh_Local_DataGrid1and2();
        }

        private async void reloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsRealTimeOn)
                {
                    //await _Reload_Local();
                    BeginInvoke((MethodInvoker)delegate { RunAsyn__Reload_Local(); });
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitoring is ON\nPlease First Stop this!", "Warning!");
                }
            }
            catch (Exception err)
            {


            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 0;
                Local_Class LClass = new Local_Class();
                string Lhost = System.Environment.MachineName;
                LClass._Connect(Lhost);
                Refresh_Local_TreeNodes();

            }
            catch (Exception err)
            {


            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Forms.Remote_Connection_MainForm RF = new BEV4.Remote_Forms.Remote_Connection_MainForm();
                RF.ShowDialog();
                Refresh_Remote_TreeNodes();

            }
            catch (Exception err)
            {


            }
        }

        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRealTimeOn)
                {
                    // await _Reload_Remote();
                    BeginInvoke((MethodInvoker)delegate { RunAsyn__Reload_Remote(); });
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitoring is ON\nPlease First Stop this!", "Warning!");

                }
            }
            catch (Exception)
            {

            }



        }
      
        private void saveThisEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Class RClass = new Remote_Class();
                Local_Class LClass = new Local_Class();

                if (treeView1.SelectedNode.ToolTipText == null | treeView1.SelectedNode.ToolTipText == string.Empty | treeView1.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Selected Event is Empty or Not Found any Record for this Event" + "\nSystem Error: ", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LClass.LocalEventSave(treeView1.SelectedNode.Text);
                }
                else
                {
                    LClass.LocalEventSave(treeView1.SelectedNode.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(null, "Warning : Local System " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void saveThisEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Remote_Class RClass = new Remote_Class();
                if (treeView2.SelectedNode.ToolTipText == null | treeView2.SelectedNode.ToolTipText == string.Empty | treeView2.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Selected Event is Empty or Not Found any Record for this Event" + "\nSystem Error: ", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RClass.RemoteEventSave(treeView2.SelectedNode.Text);
                }
                else
                {
                    RClass.RemoteEventSave(treeView2.SelectedNode.Text);
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(null, "Warning : Remote System " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filterByEventTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    FilterForm_Form1._ZIndex = 0;
                    FilterForm_Form1 MFTF = new FilterForm_Form1();
                    MFTF.ShowDialog();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Filtering.Remote.FilterForm_Form2._ZIndex = 0;
                    Filtering.Remote.FilterForm_Form2 MFTF = new Filtering.Remote.FilterForm_Form2();
                    MFTF.ShowDialog();
                }


            }
            catch (Exception err)
            {


            }

        }

        private void filterByMessageTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    FilterForm_Form1._ZIndex = 1;
                    FilterForm_Form1 MFTF = new FilterForm_Form1();
                    MFTF.ShowDialog();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Filtering.Remote.FilterForm_Form2._ZIndex = 1;
                    Filtering.Remote.FilterForm_Form2 MFTF = new Filtering.Remote.FilterForm_Form2();
                    MFTF.ShowDialog();
                }
            }
            catch (Exception err)
            {


            }


        }

        private void otherFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                if (tabControl1.SelectedIndex == 0)
                {
                    FilterForm_Form1._ZIndex = 2;
                    FilterForm_Form1 MFTF = new FilterForm_Form1();
                    MFTF.ShowDialog();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Filtering.Remote.FilterForm_Form2._ZIndex = 2;
                    Filtering.Remote.FilterForm_Form2 MFTF = new Filtering.Remote.FilterForm_Form2();
                    MFTF.ShowDialog();
                }



            }
            catch (Exception err)
            {


            }


        }

        private void filterByEventTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FilterForm_Form1._ZIndex = 0;
                FilterForm_Form1 MFTF = new FilterForm_Form1();
                MFTF.ShowDialog();
            }
            catch (Exception err)
            {


            }

        }

        private void filterByMessageTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FilterForm_Form1._ZIndex = 1;
                FilterForm_Form1 MFTF = new FilterForm_Form1();
                MFTF.ShowDialog();

            }
            catch (Exception err)
            {


            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_1 = ((System.Data.DataRowView)TempBinding_Local.List[e.RowIndex]);
                Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_2 = ((EventLogRecord)Master_Value.MasterValueClass.LocalBindingSource.List[e.RowIndex]);
                Filtering.Local.PropertiesForm_Local PFM = new Filtering.Local.PropertiesForm_Local();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_1 = ((System.Data.DataRowView)TempBinding_Local.List[e.RowIndex]);
                Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_2 = ((EventLogRecord)Master_Value.MasterValueClass.LocalBindingSource.List[e.RowIndex]);
                Filtering.Local.PropertiesForm_Local PFM = new Filtering.Local.PropertiesForm_Local();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {                               
                Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_1 = ((System.Data.DataRowView)TempBinding_Local.List[dataGridView2.CurrentRow.Index]);
                Filtering.Local.PropertiesForm_Local PFM = new Filtering.Local.PropertiesForm_Local();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Filtering.Remote.PropertiesForm_Remote.Properties_Datarow_Remote_1 = ((System.Data.DataRowView)TempBinding_Remote.List[dataGridView3.CurrentRow.Index]);
                Filtering.Remote.PropertiesForm_Remote PFM = new Filtering.Remote.PropertiesForm_Remote();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                Filtering.Remote.PropertiesForm_Remote.Properties_Datarow_Remote_1 = ((System.Data.DataRowView)TempBinding_Remote.List[dataGridView3.CurrentRow.Index]);
                Filtering.Remote.PropertiesForm_Remote.Properties_Datarow_Remote_2 = ((EventLogRecord)Master_Value.MasterValueClass.RemoteBindingSource.List[dataGridView3.CurrentRow.Index]);
                Filtering.Remote.PropertiesForm_Remote PFM = new Filtering.Remote.PropertiesForm_Remote();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void dataGridView4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Filtering.Remote.PropertiesForm_Remote PFM = new Filtering.Remote.PropertiesForm_Remote();
                PFM.ShowDialog();
            }
            catch (Exception err)
            {


            }
        }

        private void filterByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Filtering.Remote.FilterForm_Form2._ZIndex = 0;
                Filtering.Remote.FilterForm_Form2 MFTF = new Filtering.Remote.FilterForm_Form2();
                MFTF.ShowDialog();
            }
            catch (Exception err)
            {

            }

        }

        private void filterByMessageTextToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Filtering.Remote.FilterForm_Form2._ZIndex = 1;
                Filtering.Remote.FilterForm_Form2 MFTF = new Filtering.Remote.FilterForm_Form2();
                MFTF.ShowDialog();
            }
            catch (Exception err)
            {

            }

        }

        private void propertiesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    try
                    {

                        Filtering.Local.PropertiesForm_Local.Properties_Datarow_Local_1 = ((System.Data.DataRowView)TempBinding_Local.List[dataGridView2.CurrentRow.Index]);
                        Filtering.Local.PropertiesForm_Local PFM = new Filtering.Local.PropertiesForm_Local();
                        PFM.ShowDialog();
                    }
                    catch (Exception err)
                    {


                    }
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    try
                    {
                        Filtering.Remote.PropertiesForm_Remote.Properties_Datarow_Remote_1 = ((System.Data.DataRowView)TempBinding_Remote.List[dataGridView3.CurrentRow.Index]);
                        Filtering.Remote.PropertiesForm_Remote PFM = new Filtering.Remote.PropertiesForm_Remote();
                        PFM.ShowDialog();
                    }
                    catch (Exception err)
                    {


                    }
                }
            }
            catch (Exception error)
            {


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Isclosing = true;
            Thread.Sleep(1000);
            WaitForm F1 = new WaitForm();
            WaitForm2 F2 = new WaitForm2();
            try
            {
                if (_Thread_RealTimeMon.IsAlive) _Thread_RealTimeMon.Abort();
            }
            catch (Exception)
            {

                //throw;
            }
           

            try
            {
               
                if (F1._Thread.IsAlive)
                    F1._Thread.Abort();

                if (F2._Thread.IsAlive)
                    F2._Thread.Abort();
            }
            catch (Exception)
            {


            }
        }

        private void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                textBox1.Text = "";
                textBox3.Text = "";
                richTextBox3.Text = "";
                string _name = listBox6.SelectedItems[0].ToString().Split('[')[0];
                toolStripStatusLabel11.Text= "SelectedItem: " + _name;
                _name = _name.Substring(0, _name.Length - 2);
                
                string dump;
                using (StreamReader sw = new StreamReader(toolStripStatusLabel1.Text.Substring(10)))
                {
                    dump = sw.ReadToEnd();
                    sw.Close();
                }

              

                if (!listBox6.SelectedItems[0].ToString().ToLower().Contains("command_prompt") 
                    && !listBox6.SelectedItems[0].ToString().ToLower().Contains("powershell"))
                {
                    // error_invalid_techid_loaded = true;
                    button1.Enabled = false;
                    button13.Enabled = false;

                    MessageBox.Show("Invlid CommandType Detected\nSelected Technique ID or Selected SubItem was not for Windows!?\nPlease Reload another Technique Id/Subitems!");

                }
                else
                {
                    button1.Enabled = true;
                    button13.Enabled = true;
                }
                


                richTextBox3.Text = dump;
                richTextBox3.Select(Mitre_Attack.MitreAttackClass._FindAllIndex(_name, richTextBox3.Text, 0)[0], _name.Length);
                richTextBox3.ScrollToCaret();
                richTextBox3.SelectionBackColor = Color.Aqua;                              
            }
            catch (Exception m)
            {
               // MessageBox.Show(m.Message);

            }
          
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd2 = new OpenFileDialog();
                
                ofd2.Filter = "yaml files (*atomic-red-team*.yaml)|*.yaml";
                ofd2.FilterIndex = 0;
                ofd2.ShowDialog();
                string targetfile2 = ofd2.FileName;
                mitre.DumpYamlInfo(targetfile2);
                toolStripStatusLabel1.Text = "yaml file: " + targetfile2;
                string dump;
                using (StreamReader sw = new StreamReader(toolStripStatusLabel1.Text.Substring(10)))
                {
                    dump = sw.ReadToEnd();
                    sw.Close();
                }
                richTextBox3.Text = dump;
                listBox6.Items.Clear();
                tabPage5.Text = "MITRE ATT&CK [" + mitre.MitreAttackList.ToArray()[0].Attack_technique_ID.ToString() + "]";
                bool error_invalid_techid_loaded = false;
                foreach (Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items item in mitre.MitreAttackList.ToArray())
                {                  
                        listBox6.Items.Add(item.Name.Substring(7) + "  [ " + item.CommandTypes + " ]");

                    if (!item.CommandTypes.Contains("command_prompt") && !item.CommandTypes.Contains("powershell"))
                    {
                        error_invalid_techid_loaded = true;
                    }
                }

                if (error_invalid_techid_loaded)
                {
                  
                    MessageBox.Show("Invlid CommandType Detected\nSelected Technique ID has one more SubItems which is not for Windows!?");
                }
                else
                {
                    button1.Enabled = true;
                    button13.Enabled = true;
                    
                }
            }
            catch (Exception)
            {


            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSource Filtering_TempBinding_Local_2 = null;
                Filtering_TempBinding_Local_2 = new BindingSource();
                DataTable TempTable_For_Tab2 = Master_Value.MasterValueClass.table_Local;
                Filtering_TempBinding_Local_2.DataSource = TempTable_For_Tab2;
                string text = textBox1.Text;
                Filtering_TempBinding_Local_2.Filter = "Message LIKE '*" + text + "*'";
                dataGridView5.DataSource = Filtering_TempBinding_Local_2;
                toolStripStatusLabel2.Text = "Result: " + dataGridView5.RowCount.ToString();
            }
            catch (Exception err)
            {


            }
        }

        private void DataGridView5_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox4.Text = "";
            richTextBox4.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        /// <summary>
        /// Save C# Event to Dump/Save all results to Search History list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_Save_MittreAttack_Result_1(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel5.Text = "";
                string TechniqueFile = sender.ToString().Split('@')[1];

                if (sender.ToString().Split('@')[0] == "save")
                {

                    DataTable TempTable_For_Tab2_saveresult = Master_Value.MasterValueClass.table_Local_search1_Results;
                    string item2, item3, item4, item5, item1 = "";
                    ListViewItem iList1 = new ListViewItem();
                    CountEvents = TempTable_For_Tab2_saveresult.Rows.Count;
                    dt = DateTime.Now;
                    _Description = richTextBox3.Text;
                    SortedList1.Clear();
                    SortedList1 = new List<ListViewItem>();
                    string EventRecordsXML = "";
                    string TechID = "";
                    string DisplayName = toolStripStatusLabel11.Text.Split(':')[1];
                    for (int ii = 0; ii < CountEvents; ii++)
                    {
                        iList1 = new ListViewItem();
                        try
                        {
                            /// event time
                            iList1.SubItems.Add(TempTable_For_Tab2_saveresult.Rows[ii][4].ToString());
                            /// display name                           
                            iList1.SubItems.Add(DisplayName.Substring(1));
                            /// technique id
                            iList1.SubItems.Add(_Description.Split('\n')[0].Split(':')[1]);
                            TechID = _Description.Split('\n')[0].Split(':')[1];
                            
                            /// your Search Query String
                            iList1.SubItems.Add("Defualt Query is: \n[" + textBox1.Text + "]\n  Second Query is:\n[" + textBox3.Text + "]");
                            /// technique Description                        
                            iList1.SubItems.Add(_Description + "\n\nYour String Search Defualt Query is: \n[" + textBox1.Text + "]\nSecond Query is:\n[" + textBox3.Text +"]" );
                            /// event message
                            item1 += "\nEventRecordId: " + TempTable_For_Tab2_saveresult.Rows[ii][0].ToString() + " ";
                            item1 += "\nType: " + TempTable_For_Tab2_saveresult.Rows[ii][1].ToString() + " ";
                            item1 += "\nEventID: " + TempTable_For_Tab2_saveresult.Rows[ii][2].ToString() + " ";
                            /// event messages
                            item1 += "\nEventMessage: \n" + TempTable_For_Tab2_saveresult.Rows[ii][3].ToString();
                            /// event datetime
                            item1 += "\nEventTime: " + TempTable_For_Tab2_saveresult.Rows[ii][4].ToString();
                            EventRecordsXML += ((EventLogRecord)TempTable_For_Tab2_saveresult.Rows[ii][5]).ToXml() + "\n";
                            iList1.Name = TempTable_For_Tab2_saveresult.Rows[ii][5].ToString();                                                  
                            iList1.SubItems.Add(item1);
                            SortedList1.Add(iList1);
                            //listView1.Items.Add(iList1);
                            item1 = "";
                        }
                        catch (Exception)
                        {


                        }
                    }

                    dataGridView6.DataSource = TempTable_For_Tab2_saveresult;
                    listView1.Items.AddRange(SortedList1.ToList().OrderBy(x => x.SubItems[0].Text).ToArray());
                    DateTime now = DateTime.Now;
                    string _now = now.ToString("hh.mm.ss");
                    string[] TechniqueFileStr = TechniqueFile.Split('\\');
                    string FileName = TechniqueFileStr[TechniqueFileStr.Length - 1];
                    string save_xml_file_name = FileName + "_SearchResults_" + "(" + DisplayName.Substring(1) + ")" + _now + ".xml";

                    using (StreamWriter xml = new StreamWriter(save_xml_file_name))
                    {
                        xml.WriteLine(EventRecordsXML);
                        xml.Close();
                    }
                    toolStripStatusLabel5.Text = "Last Result AutoSaved into xml file: " + save_xml_file_name;
                    SortedList1.Clear();
                }

                if (sender.ToString().Split('@')[0] == "saveall")
                {

                    DataTable TempTable_For_Tab2_saveresult_All = Master_Value.MasterValueClass.table_Local_searchAll_Results;
                    string item2, item3, item4, item5, item1 = "";
                    ListViewItem iList1 = new ListViewItem();
                    CountEvents = TempTable_For_Tab2_saveresult_All.Rows.Count;
                    dt = DateTime.Now;
                    _Description = richTextBox3.Text;
                    SortedList2.Clear();
                    SortedList2 = new List<ListViewItem>();
                    string EventRecordsXML = "";
                    string TechID = "";
                    for (int ii = 0; ii < CountEvents; ii++)
                    {
                        iList1 = new ListViewItem();
                        try
                        {
                            /// event time
                            iList1.SubItems.Add(TempTable_For_Tab2_saveresult_All.Rows[ii][4].ToString());
                            /// display name
                            iList1.SubItems.Add(TempTable_For_Tab2_saveresult_All.Rows[ii][5].ToString());
                            /// technique id
                            iList1.SubItems.Add(TempTable_For_Tab2_saveresult_All.Rows[ii][6].ToString().ToUpper().Split(':')[1]);
                            TechID = TempTable_For_Tab2_saveresult_All.Rows[ii][6].ToString().ToUpper().Split(':')[1];
                            /// your Search Query String
                            iList1.SubItems.Add(TempTable_For_Tab2_saveresult_All.Rows[ii][7].ToString());
                            /// technique Description                        
                            iList1.SubItems.Add(_Description + "\n\nYour String Search Defualt Query is: \n" + TempTable_For_Tab2_saveresult_All.Rows[ii][7].ToString() + "\n");
                            /// event message
                            item1 += "\nEventRecordId: " + TempTable_For_Tab2_saveresult_All.Rows[ii][0].ToString() + " ";
                            item1 += "\nType: " + TempTable_For_Tab2_saveresult_All.Rows[ii][1].ToString() + " ";
                            item1 += "\nEventID: " + TempTable_For_Tab2_saveresult_All.Rows[ii][2].ToString() + " ";
                            /// event messages
                            item1 += "\nEventMessage: \n" + TempTable_For_Tab2_saveresult_All.Rows[ii][3].ToString();
                            /// event datetime
                            item1 += "\nEventTime: " + TempTable_For_Tab2_saveresult_All.Rows[ii][4].ToString();
                            EventRecordsXML += ((EventLogRecord)TempTable_For_Tab2_saveresult_All.Rows[ii][8]).ToXml() + "\n";
                            iList1.Name = TempTable_For_Tab2_saveresult_All.Rows[ii][8].ToString();
                            
                            iList1.SubItems.Add(item1);                          
                            SortedList2.Add(iList1);
                            //listView1.Items.Add(iList1);
                            item1 = "";
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);

                        }
                    }

                    dataGridView6.DataSource = TempTable_For_Tab2_saveresult_All;
                    listView1.Items.AddRange(SortedList2.ToList().OrderBy(x => x.SubItems[0].Text).ToArray());
                    DateTime now = DateTime.Now;
                    string _now = now.ToString("hh.mm.ss");
                    string[] TechniqueFileStr = TechniqueFile.Split('\\');
                    string FileName = TechniqueFileStr[TechniqueFileStr.Length - 1];
                    string save_xml_file_name = FileName + "_SearchAllResults_" + "(" + TechID + ")" + _now + ".xml";
                    using (StreamWriter xml = new StreamWriter(save_xml_file_name))
                    {
                        xml.WriteLine(EventRecordsXML);
                        xml.Close();
                    }
                   
                    toolStripStatusLabel5.Text = "Last Result AutoSaved into xml file: " + save_xml_file_name;
                    SortedList2.Clear();
                }
            }
            catch (Exception)
            {


            }
        }
     
        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRealTimeOn)
                {
                    if (listBox6.Items.Count == 0)
                    {
                        MessageBox.Show("Please load your MitreAttack AtomicRedTeam yaml file," +
                                  "\nthen select your TechniqueID and type your Query String based on Technique ID Descriptions (use Command: in description for query)"
                                  + "\nthen you can click Search Technique!");

                    }
                    else
                    {
                        if (textBox1.Text == "" || string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            MessageBox.Show("Please Set your Query First! , string is empty or whitespace!");
                        }
                        else if(toolStripStatusLabel11.Text == "SelectedItem:")
                        {
                            MessageBox.Show("Please Select your Technique ID Name First!");
                        }
                        else
                        {
                            button1.Enabled = false;
                            button14.Enabled = false;
                            button2.Enabled = false;
                            button13.Enabled = false;
                            textBox1.Enabled = false;
                            textBox3.Enabled = false;
                            listBox6.Enabled = false;
                            richTextBox1.Text = "";
                            IsFilteringMode_Mittre_EID1 = true;
                            string first_query = textBox1.Text;
                            string second_query = textBox3.Text;
                            IsLocalRemote_SearchReloadFormActived = true;
                            if ((first_query != "" && !string.IsNullOrWhiteSpace(first_query) && !string.IsNullOrEmpty(first_query))
                                && (second_query == "" && string.IsNullOrWhiteSpace(second_query) && string.IsNullOrEmpty(second_query)))
                            {
                                Task<BindingSource> _SearchTask = Mitre_Attack.MitreAttackClass._TechniqueIDs_Search1(first_query);
                                BindingSource temp_table_Local_search1 = await _SearchTask.ConfigureAwait(true);

                                do
                                {
                                    Thread.Sleep(10);
                                    if (_SearchTask.IsCompleted)
                                    {
                                        dataGridView5.DataSource = temp_table_Local_search1.DataSource;
                                        break;
                                    }

                                } while (!_SearchTask.IsCompleted);
                            }
                            else
                            if ((first_query != "" && !string.IsNullOrWhiteSpace(first_query) && !string.IsNullOrEmpty(first_query))
                                && (second_query != "" && !string.IsNullOrWhiteSpace(second_query) && !string.IsNullOrEmpty(second_query)))
                            {
                                Task<BindingSource> _SearchTask = Mitre_Attack.MitreAttackClass._TechniqueIDs_Search1(first_query, second_query);
                                BindingSource temp_table_Local_search1 = await _SearchTask.ConfigureAwait(true);

                                do
                                {
                                    Thread.Sleep(10);
                                    if (_SearchTask.IsCompleted)
                                    {
                                        dataGridView5.DataSource = temp_table_Local_search1.DataSource;
                                        break;
                                    }

                                } while (!_SearchTask.IsCompleted);
                            }
                            else
                            {
                                MessageBox.Show("Blank Space or WhiteSpace Detected in one of your First or Second String/Queries!\nthis is invalid String Query!"
                                    + "\nSome TechniqueIDs has two or more CommandPrompts so you can use two of them for Search, First Query is Defualt\n" +
                                    "Second Query is optional which you can use that for Second Command Prompts for your TechniqueID which Selected.");
                            }

                            toolStripStatusLabel2.Text = "Result: " + dataGridView5.RowCount.ToString();
                            string TechniqueFile = toolStripStatusLabel1.Text;
                            Save_MittreAttack_Result_1.Invoke((object)"save" + "@" + TechniqueFile, null);

                            IsLocalRemote_SearchReloadFormActived = false;
                            button1.Enabled = true;
                            button14.Enabled = true;
                            button2.Enabled = true;
                            button13.Enabled = true;
                            textBox1.Enabled = true;
                            textBox3.Enabled = true;
                            listBox6.Enabled = true;

                            //ThreadStart T_Core1_Search1 = new ThreadStart(delegate
                            //{
                            //    // BeginInvoke(new _Core1(_Core1_Search1), textBox1.Text);
                            //    //BindingSource temp_table_Local_search1 = Mitre_Attack.MitreAttackClass._Core1_Search1(textBox1.Text);
                            //    // BeginInvoke(new _Core2(Mitre_Attack.MitreAttackClass._Core1_Search1), textBox1.Text);
                            //});
                            //Thread _T8__CoreScanThread = new Thread(T_Core1_Search1);
                            //_T8__CoreScanThread.Priority = ThreadPriority.Highest;
                            //_T8__CoreScanThread.Start();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitor is ON,\nPlease First Stop this then you can use Search.");
                }
            }
            catch (Exception err)
            {


            }
        }

        private async void Button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRealTimeOn)
                {
                    if (listBox6.Items.Count == 0)
                    {
                        MessageBox.Show("Please load your MitreAttack AtomicRedTeam yaml file,"
                                  + "\nthen you can click Search All Techniques!");

                    }
                    else
                    {
                        //ThreadStart Core2 = new ThreadStart(delegate { });
                        //Thread _T1_Core2 = new Thread(Core2);
                        //_T1_Core2.Priority = ThreadPriority.Highest;
                        //_T1_Core2.Start();

                        t.Enabled = true;
                        t.Start();
                        button1.Enabled = false;
                        button14.Enabled = false;
                        button2.Enabled = false;
                        button13.Enabled = false;
                        listBox6.Enabled = false;
                        richTextBox1.Text = "";
                        toolStripProgressBar1.Value = 0;
                        toolStripStatusLabel3.Text = "";
                        toolStripStatusLabel4.Text = "";
                        IsFilteringMode_Mittre_EID1 = true;
                        IsLocalRemote_SearchReloadFormActived = true;
                        Task<BindingSource> _SearchTask = Mitre_Attack.MitreAttackClass
                            ._TechniqueIDs_SearchAll(Mitre_Attack.MitreAttackClass.MitreAttackList_Array_Copy);
                        BindingSource temp_table_Local_searchAll = await _SearchTask.ConfigureAwait(true);

                        do
                        {
                            Thread.Sleep(10);
                            if (_SearchTask.IsCompleted)
                            {
                                dataGridView5.DataSource = temp_table_Local_searchAll.DataSource;
                                t.Enabled = false;
                                t.Stop();
                                break;
                            }

                        } while (!_SearchTask.IsCompleted);

                        toolStripStatusLabel2.Text = "Result: " + dataGridView5.RowCount.ToString();
                        string TechniqueFile = toolStripStatusLabel1.Text;
                        Save_MittreAttack_Result_1.Invoke((object)"saveall" + "@" + TechniqueFile, null);
                        IsLocalRemote_SearchReloadFormActived = false;
                        button1.Enabled = true;
                        button14.Enabled = true;
                        button2.Enabled = true;
                        button13.Enabled = true;
                        listBox6.Enabled = true;
                        toolStripProgressBar1.Value = 0;
                        toolStripStatusLabel3.Text = "";
                        toolStripStatusLabel4.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mitre Attack Real-time Monitor is ON,\nPlease First Stop this then you can use Search.");
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void ToolStripStatusLabel2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void Update_Richtexbox2__info()
        {
            try
            {
                textBox2.Text = "";
                textBox4.Text = "";
                richTextBox2.Text = "";
                richTextBox5.Text = "";
                richTextBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
                richTextBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
                try
                {
                    if (listView1.SelectedItems[0].SubItems[4].Text.Contains('['))
                    {
                        textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text.Split('[')[1].Split(']')[0];
                        textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text.Split('[')[2].Split(']')[0];
                    }
                    else
                    {
                        textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
                        textBox4.Text = "";
                    }
                }
                catch (Exception)
                {

                    textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
                    textBox4.Text = "";
                }
               
                string findstr = "";

                if (listView1.SelectedItems[0].SubItems[2].Text.Contains('['))
                {
                    findstr = listView1.SelectedItems[0].SubItems[2].Text.Split('[')[0];
                    findstr = findstr.Substring(0, findstr.Length - 2);
                }
                else
                {
                    findstr = listView1.SelectedItems[0].SubItems[2].Text;
                    if (findstr.EndsWith(" ")) { findstr = findstr.Substring(0, findstr.Length - 1); }
                    if (findstr.EndsWith(" ")) { findstr = findstr.Substring(0, findstr.Length - 1); }
                }
                 
                richTextBox2.Select(Mitre_Attack.MitreAttackClass._FindAllIndex(findstr, richTextBox2.Text, 0)[0], findstr.Length);
                richTextBox2.ScrollToCaret();
                richTextBox2.SelectionBackColor = Color.Aqua;
                
            }
            catch (Exception)
            {


            }

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                BeginInvoke(new _Core0(Update_Richtexbox2__info));
            }
            catch (Exception m)
            {
                

            }
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            EventLogSession g = new EventLogSession();
            string _Query = "<QueryList><Query Id=\"0\" Path=\"Microsoft-Windows-Sysmon/Operational\"><Select Path=\"Microsoft-Windows-Sysmon/Operational\">*[System[(EventID=1 and Message include 'reg.exe')]]</Select></Query></QueryList>";
            g.ExportLogAndMessages("Microsoft-Windows-Sysmon/Operational", PathType.FilePath, _Query, "demo.evtx");

            ///> powershell "Get-EventLog -LogName "ETWPM2Monitor2" | ?{$_.Message -like \"*Target Process: notepad*\"} | Select-Object -Property Index,EventId,EntryType,Message |ConvertTo-Html | Out-File aliases.htm "
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            if (!IsRealTimeOn)
            {
                if (listBox6.Items.Count == 0)
                {
                    MessageBox.Show("Please load your MitreAttack AtomicRedTeam yaml file,"
                              + "\nthen you can click Search via Powershell!");

                }
                else
                {
                    if (Form1.PSFormIsActive == false)
                    {

                        Textbox1Text = "";
                        Textbox1Text = textBox1.Text;

                        if (textBox1.Text == "" || string.IsNullOrWhiteSpace(textBox1.Text))
                        { MessageBox.Show("Please Type your First Query!"); }
                        else
                        {
                            PSFormIsActive = true;
                            await Task.Run(() =>
                         {
                             Mitre_Attack.PowerShell.PSSearch.Search_String_Textbox1 = Textbox1Text;

                             if (toolStripStatusLabel11.Text != "SelectedItem:")
                                 Mitre_Attack.PowerShell.PSSearch.Search_String_TechniqueID = toolStripStatusLabel11.Text.Split(':')[1];

                             ThreadStart T_Core1_Search1 = new ThreadStart(delegate
                             {
                                 Mitre_Attack.PowerShell.PSSearch PSForm = new Mitre_Attack.PowerShell.PSSearch();
                                 PSForm.ShowDialog();
                             });

                             Thread _T8__CoreSearchThread = new Thread(T_Core1_Search1);
                             _T8__CoreSearchThread.Priority = ThreadPriority.Highest;
                             _T8__CoreSearchThread.Start();
                         });
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Mitre Attack Real-time Monitor is ON,\nPlease First Stop this then you can use Search.");
            }

            //button2.Enabled = true;

           // PowerShell ps = PowerShell.Create();
           // ps.AddCommand("Get-Process").AddParameter("Name", "PowerShell");
           // ps.AddStatement().AddCommand("Get-Service");
           // System.Collections.ObjectModel.Collection<PSObject> p = ps.Invoke();
           // foreach (var item in p)
           // {
                
           // }

        }

        private void StartRealtimeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsLocalRemote_SearchReloadFormActived)
            {
                try
                {
                    if (_Thread_RealTimeMon.IsAlive)
                    {
                        IsStopRealTime = true;
                        _Thread_RealTimeMon.Abort();

                        if (RealTime.RealtimeEventIDsMonitor._Thread_RealTimeMon2.IsAlive)
                            RealTime.RealtimeEventIDsMonitor._Thread_RealTimeMon2.Abort();

                    }
                }
                catch (Exception)
                {


                }
                tabControl2.SelectedIndex = 2;
                startRealtimeMonitorToolStripMenuItem.Checked = true;
                stopMonitorToolStripMenuItem.Checked = false;
                IsRealTimeOn = true;
                IsStopRealTime = false;
                
                _Thread_RealTimeMon = new Thread(new ThreadStart(RealTime.RealtimeEventIDsMonitor.RunMonitor_Sysmon));
                _Thread_RealTimeMon.Priority = ThreadPriority.Highest;                
                _Thread_RealTimeMon.Start();

                t2.Enabled = true;
                t2.Start();
                t1.Enabled = true;
                t1.Start();
                t3.Enabled = true;
                t3.Start();
                toolStripStatusLabel9.Text = "| MITRE ATTACK Realtime Monitor is on";
            }
            else
            {
                MessageBox.Show("SearchForm for Reloading Events is Actived!\nPlease First Close that!", "Warning");
            }
        }

        private void StopMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Thread_RealTimeMon.IsAlive)
                {
                    IsStopRealTime = true; _Thread_RealTimeMon.Abort();
                    
                }

                if (RealTime.RealtimeEventIDsMonitor._Thread_RealTimeMon2.IsAlive)
                    RealTime.RealtimeEventIDsMonitor._Thread_RealTimeMon2.Abort();
            }
            catch (Exception)
            {

                
            }
            startRealtimeMonitorToolStripMenuItem.Checked = false;
            stopMonitorToolStripMenuItem.Checked = true;
            IsRealTimeOn = false;
            toolStripStatusLabel9.Text = "| MITRE ATTACK Realtime Monitor is off";
            t2.Enabled = false;
            t2.Stop();
            t3.Enabled = false;
            t3.Stop();
            ////foreach (RealTime.RealtimeEventIDsMonitor._TableOfSysmon_Processes item 
            ////    in RealTime.RealtimeEventIDsMonitor.Sysmon_Process_Table_history.ToArray())
            ////{
            ////    listView3.Items.Add()
            ////}
        }

        public async void Listview2_indexchange_info()
        {
            try
            {
                richTextBox6.Text = "";
                richTextBox7.Text = "";
                richTextBox6.Text = listView2.SelectedItems[0].SubItems[10].Text.ToString();
                string _SysmonEventID1_Record_Id = listView2.SelectedItems[0].SubItems[9].Text.ToString();
                string _evttime = listView2.SelectedItems[0].SubItems[1].Text.ToString();
                string _TechniqueID = listView2.SelectedItems[0].SubItems[2].Text.ToString();
                string _TechniqueID_Name = listView2.SelectedItems[0].SubItems[3].Text.ToString();
                string _DetectionScore = listView2.SelectedItems[0].SubItems[4].Text.ToString();
                string _TechniqueID_SubItems_IndexData = listView2.SelectedItems[0].SubItems[5].Text.ToString();
                string _ProcessName = listView2.SelectedItems[0].SubItems[6].Text.ToString();
                string _ProcessName_ID = listView2.SelectedItems[0].SubItems[7].Text.ToString();
                string _ProcessCommandLine = listView2.SelectedItems[0].SubItems[8].Text.ToString();

                float a = Convert.ToSingle(listView2.SelectedItems[0].SubItems[4].Text.ToString().Split('/')[1]) / 2;
                float b = Convert.ToSingle(listView2.SelectedItems[0].SubItems[4].Text.ToString().Split('/')[0]);
                string FalsePositive = "";
                if(a == b / 2)
                {
                    FalsePositive = "Probably this Event is True Positive!";

                }
                else
                if (a < b)
                {
                    FalsePositive = "Probably this Event is True Positive";
                }
                else
                {
                    FalsePositive = "Probably this Event is False Positive";
                }

                richTextBox7.Text = "Event Time: " + _evttime
                    + "\nTechnique ID: " + _TechniqueID
                    + "\nTechnique ID Name: " + _TechniqueID_Name
                    + "\nDetection Score: " + _DetectionScore
                    + "\nDB SubItems_Index: " + _TechniqueID_SubItems_IndexData
                    + "\nDetected Process Name: " + _ProcessName
                    + "\nDetected Process ID: " + _ProcessName_ID
                    + "\nDetected Process CommandLine: " + _ProcessCommandLine
                    + "\nSysmon EventRecord_Id: " + _SysmonEventID1_Record_Id.ToString()
                    + "\n------------------------------\nDetection False/True Positive: " + FalsePositive;
                try
                {
                    DataTable TempTable = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                    DataRow[] dts = TempTable.Select("Record_SubItemIndex = " + Convert.ToInt32(_TechniqueID_SubItems_IndexData));
                    string TechniqueId_Command_Details_DB_Index = dts[0].ItemArray[0].ToString();
                    string TechniqueId_Command_Details_DisplayName = dts[0].ItemArray[1].ToString();
                    string TechniqueId_Command_Details_TechniqueID = dts[0].ItemArray[2].ToString();
                    string TechniqueId_Command_Details_Command_Str = dts[0].ItemArray[4].ToString();

                    richTextBox7.Text += "\n------------------------------"
                        + "\n\nNote: YOU Can Check False Positive Detection via Compare \"1.Your Event CommandLine\" with \"2.Detected Technique CommandLine\".\n\n"
                        + "TechniqueID: " + TechniqueId_Command_Details_TechniqueID + "\n"
                        + "Technique Name: " + TechniqueId_Command_Details_DisplayName + "\n"
                        + "1.DETECTED TECHNIQUE CommandLine ==> " + TechniqueId_Command_Details_Command_Str + "\n"
                        + "2.YOUR EVENT CommandLine ==>" + _ProcessCommandLine;
                }
                catch (Exception)
                {


                }

                string select = "Detection False/True Positive:";
                richTextBox7.Select(Mitre_Attack.MitreAttackClass._FindAllIndex(select, richTextBox7.Text, 0)[0], select.Length + FalsePositive.Length + 1);

                if (FalsePositive == "Probably this Event is True Positive!")
                {
                    richTextBox7.SelectionColor = Color.Black;
                    richTextBox7.SelectionBackColor = Color.Orange;
                }
                if (FalsePositive == "Probably this Event is True Positive")
                {
                    richTextBox7.SelectionColor = Color.Black;
                    richTextBox7.SelectionBackColor = Color.Orange;
                }
                if (FalsePositive == "Probably this Event is False Positive")
                {
                    richTextBox7.SelectionColor = Color.Black;
                    richTextBox7.SelectionBackColor = Color.Aqua;
                }

              
            }
            catch (Exception)
            {


            }

        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new _Core0(Listview2_indexchange_info));
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false;
            if (radioButton1.Checked) { radioButton1.Checked = true;   }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false; radioButton1.Checked = false; radioButton4.Checked = false;
            if (radioButton3.Checked) { radioButton3.Checked = true;  }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false;
            if (radioButton2.Checked) { radioButton2.Checked = true;   }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false; radioButton3.Checked = false; radioButton1.Checked = false;
            if (radioButton4.Checked) { radioButton4.Checked = true;  }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable TempTable_For_Tab1 = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                DataTable TempTable_For_Tab2 = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                DataTable TempTable_For_Tab3 = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                DataTable TempTable_For_Tab4 = Master_Value.MasterValueClass.table_MitreAttackTechniques;

                if (radioButton1.Checked)
                {                                     
                    BindingSource Filtering = new BindingSource();
                    Filtering.DataSource = TempTable_For_Tab1;
                    Filtering.Filter = "TechniqueDisplayName LIKE '*" + textBox5.Text + "*'";
                    dataGridView7.DataSource = Filtering;
                    dataGridView7.Refresh();
                }
                if (radioButton2.Checked)
                {
                    BindingSource Filtering = new BindingSource();
                    Filtering.DataSource = TempTable_For_Tab2;
                    Filtering.Filter = "TechniqueID LIKE '*" + textBox5.Text + "*'";
                    dataGridView7.DataSource = Filtering;
                }
                if (radioButton3.Checked)
                {
                    BindingSource Filtering = new BindingSource();
                    Filtering.DataSource = TempTable_For_Tab3;
                    Filtering.Filter = "Technique_Step_Command LIKE '*" + textBox5.Text + "*'";
                    dataGridView7.DataSource = Filtering;
                }
                if (radioButton4.Checked)
                {
                    BindingSource Filtering = new BindingSource();
                    Filtering.DataSource = TempTable_For_Tab4;
                    Filtering.Filter = "Record_SubItemIndex =" + textBox5.Text;
                    dataGridView7.DataSource = Filtering;
                }
            }
            catch (Exception)
            {

               
            }
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DataTable TempTable_For_Tab1 = Master_Value.MasterValueClass.table_MitreAttackTechniques;
            BindingSource Filtering = new BindingSource();
            Filtering.Filter = "TechniqueDisplayName LIKE '*'";
            Filtering.DataSource = TempTable_For_Tab1;
            dataGridView7.DataSource = Filtering;
        }

        private void ScanningFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _IsScanningFast = true;
            _IsScanningSlow = false;
            scanningArgsSlowToolStripMenuItem.Checked = false;
            scanningFastToolStripMenuItem.Checked = true;
        }

        private void ScanningArgsSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _IsScanningFast = false;
            _IsScanningSlow = true;
            scanningArgsSlowToolStripMenuItem.Checked = true;
            scanningFastToolStripMenuItem.Checked = false;
        }

        private async void LoadCMDPromptsFromAllYamlFilesIntoTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                List<Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items> AllMitreAttackIndeXEDtechniqueIds
                    = new List<Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items>();

                OpenFileDialog ofd2 = new OpenFileDialog();

                ofd2.Filter = "md files (windows-index.md)|windows-index.md";
                ofd2.FilterIndex = 0;
                ofd2.ShowDialog();
                string targetfile2 = ofd2.FileName;
                ofd2.RestoreDirectory = true;
                string _dir = ofd2.InitialDirectory;
                string dump;

                using (StreamReader sw = new StreamReader(targetfile2))
                {
                    dump = sw.ReadToEnd();
                    sw.Close();
                }

                string[] listAll = dump.Split('\n');
                int[] indexAll = Mitre_Attack.MitreAttackClass._FindAllIndex("- [T", dump, 0);
                string filename = "";
                string[] PATH = targetfile2.Split('\\');
                int INDEXPATH = PATH.Length - 2;
                string finalpath = "";

                for (int i = 0; i <= INDEXPATH; i++)
                {
                    finalpath += PATH[i] + "\\";
                }

                foreach (string item in listAll)
                {
                    try
                    {
                        if (item.StartsWith("- [T"))
                        {
                            /// ting](../../T1558.004/T1558.004.md)
                            filename = item.Split('(')[1].Split(')')[0];
                            filename = filename.Substring(0, filename.Length - 2);
                            filename = filename + "yaml";

                            if (!filename.StartsWith("https://"))
                                mitre.DumpYamlInfo(finalpath + filename);

                            foreach (Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items xitem in Mitre_Attack.MitreAttackClass.MitreAttackList_Array_Copy)
                            {
                                if (xitem.CommandTypes.Contains("command_prompt") || xitem.CommandTypes.Contains("powershell"))
                                    AllMitreAttackIndeXEDtechniqueIds.Add(xitem);
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
                }

                richTextBox1.Text = "";
                IsFilteringMode_Mittre_EID1 = true;

                Task _SearchTask = Mitre_Attack.MitreAttackClass.MakeSimpleTextFile_AllCommandPrompts(AllMitreAttackIndeXEDtechniqueIds
                   .ToList<Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items>().ToArray<Mitre_Attack.MitreAttackClass.MitreAttack_Attack_Items>());
                await _SearchTask.ConfigureAwait(true);

                do
                {
                    Thread.Sleep(10);
                    if (_SearchTask.IsCompleted)
                    {
                        break;
                    }

                } while (!_SearchTask.IsCompleted);

            }
            catch (Exception eee)
            {

                MessageBox.Show(eee.Message);
            }
        }

        private void SaveHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mitre_Attack.MitreAttackClass._Save_SearchHistory(listView1);
        }

        private void LoadHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Object[] obj = Mitre_Attack.MitreAttackClass._Load_SearchHistory();
            string _filename = "";

            if (((ListViewItem[])obj[0]) != null)
            {
                
                listView1.Items.AddRange((ListViewItem[])obj[0]);
                
            }

            if (((string)obj[1]) != null)
            {
                _filename = obj[1].ToString();
                MessageBox.Show("Search History file Data loaded:" + _filename);
            }
        }

        private void LoadHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Object[] obj = Mitre_Attack.MitreAttackClass._Load_SearchHistory();
            string _filename = "";

            if (((ListViewItem[])obj[0]) != null)
            {
               
                listView1.Items.AddRange((ListViewItem[])obj[0]);
                
            }

            if (((string)obj[1]) != null)
            {
                _filename = obj[1].ToString();
                MessageBox.Show("Search History file Data loaded:" + _filename );
            }
        }

        private void SaveHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mitre_Attack.MitreAttackClass._Save_SearchHistory(listView1);
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void TreeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {                 
                tabControl6.SelectedIndex = Convert.ToInt32(treeView3.SelectedNode.Text.Split('.')[0]);
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void TreeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tabControl8.SelectedIndex = Convert.ToInt32(treeView4.SelectedNode.Text.Split('.')[0]);
            }
            catch (Exception)
            {

                //throw;
            }

            if (treeView4.SelectedNode.Text.StartsWith("Intrusion EventIDs"))
                tabControl8.SelectedIndex = 0;
            
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
            try
            {

                Master_Value.MasterValueClass.ActiveNode = toolStripStatusLabel_Nodes.Text.Split('(')[0];
                Master_Value.MasterValueClass.ActiveNode = Master_Value.MasterValueClass.ActiveNode.Substring(0, Master_Value.MasterValueClass.ActiveNode.Length - 1);
                if (Master_Value.MasterValueClass.ActiveNode.ToLower() != "windows logs"
                    && Master_Value.MasterValueClass.ActiveNode.ToLower() != "application and services logs"
                    && Master_Value.MasterValueClass.ActiveNode.ToLower() != "microsoft")
                {
                    Local_Forms.Powershell.Local_PSSearch LF = new Local_Forms.Powershell.Local_PSSearch();
                    LF.ShowDialog();
                }
                else
                { MessageBox.Show("Please First Select Your Target EventLog Name", "Error!"); }

            }
            catch (Exception)
            {

                MessageBox.Show("Please First Select Your Target EventLog Name", "Error!");
            }

        }

        private void ReloadExportToHTMLCSVViaPowershellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Master_Value.MasterValueClass.ActiveNode = toolStripStatusLabel_Nodes.Text.Split('(')[0];
                Master_Value.MasterValueClass.ActiveNode = Master_Value.MasterValueClass.ActiveNode.Substring(0, Master_Value.MasterValueClass.ActiveNode.Length - 1);
                if (Master_Value.MasterValueClass.ActiveNode.ToLower() != "windows logs"
                    && Master_Value.MasterValueClass.ActiveNode.ToLower() != "application and services logs"
                    && Master_Value.MasterValueClass.ActiveNode.ToLower() != "microsoft")
                {
                    Local_Forms.Powershell.Local_PSSearch LF = new Local_Forms.Powershell.Local_PSSearch();
                    LF.ShowDialog();
                }
                else
                { MessageBox.Show("Please First Select Your Target EventLog Name", "Error!"); }

            }
            catch (Exception)
            {

                MessageBox.Show("Please First Select Your Target EventLog Name", "Error!");
            }
        }

        private void DataGridView8_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EIDSelected = dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString();
            string _EID_Filename = "";
            if (EIDSelected.Contains(','))
            {
                _EID_Filename = EIDSelected.Replace(',', '_');
            }
            else { _EID_Filename = EIDSelected; }

            TempScript = "HTML (Last 14 Days):\ncmd.exe /c Powershell  \"Get-Eventlog Security "
                + EIDSelected
                + " -after ((get-date).addDays(-14)) | Select-Object -Property Index,EventId,EntryType,Message | ConvertTo-html | out-file "
                + "SecurityEID_" + _EID_Filename
                + ".html\"\n"
                + "\nHTML:\ncmd.exe /c Powershell  \"Get-Eventlog Security "
                + EIDSelected
                + " | Select-Object -Property Index,EventId,EntryType,Message | ConvertTo-html | out-file "
                + "SecurityEID_" + _EID_Filename
                + ".html\""
                + "\n\nCSV (Last 14 Days):\n"
                + "cmd.exe /c Powershell  \"Get-Eventlog Security "
                + EIDSelected
                + " -after ((get-date).addDays(-14)) | Select-Object -Property Index,EventId,EntryType,Message | ConvertTo-csv | out-file "                
                + "SecurityEID_" + _EID_Filename
                + ".csv\"\n"
                + "\nCSV:\n"
                + "cmd.exe /c Powershell  \"Get-Eventlog Security "
                + EIDSelected
                + " | Select-Object -Property Index,EventId,EntryType,Message | ConvertTo-csv | out-file "
                + "SecurityEID_" + _EID_Filename
                + ".csv\"";

            richTextBox34.Text = TempScript;
        }
    }
}
