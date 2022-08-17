using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace BEV4.RealTime
{
    class RealtimeEventIDsMonitor
    {
        public struct _TableofProcess
        {

            private string _TCPDetails2;
            public string TCPDetails2 { get { return _TCPDetails2; } set { _TCPDetails2 = value; } }
            public string TCPDetails { set; get; }
            public string Description { set; get; }
            public int PID { set; get; }
            public int Injector { set; get; }
            public string Injector_Path { set; get; }
            public string ProcessName { set; get; }
            public string ProcessName_Path { set; get; }
            public bool IsLive { set; get; }
            public bool IsShow_Alarm { set; get; }
            public DateTime Detection_EventTime { set; get; }
            public string Detection_Status { set; get; }
            public string MemoryScanner01_Result { set; get; }
            public string MemoryScanner02_Result { set; get; }
            public string InjectionType { set; get; }
            public string Descripton_Details { set; get; }
            public string SubItems_Name_Property { set; get; }
            public int SubItems_ImageIndex { set; get; }
        }

        public static List<_TableofProcess> Native_Process_Table = new List<_TableofProcess>();

        public struct _TableOfSysmon_Processes
        {
            public DateTime EventTime { set; get; }
            public Int64 Event_Record_ID { set; get; }
            public int PID { set; get; }
            public string ProcessName { set; get; }
            public string ProcessName_Path { set; get; }
            public string _EventMessage { set; get; }
            public string _CommandLine { set; get; }
            public string _ParentCommandLine { set; get; }
            public string _Image { set; get; }
            /// 1.powershell or 2.command_prompt            
            public int CommandTypes { set; get; }
            public string Description { set; get; }
            public string SubItems_Name_Property { set; get; }
            public int SubItems_ImageIndex { set; get; }
            public DateTime AddedTime { set; get; }
            private bool _IsChecked;
            public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; } }
            private string _ProcessItemsDetectedCount_Score;
            public string ProcessItemsDetectedCount_Score { get { return _ProcessItemsDetectedCount_Score; } set { _ProcessItemsDetectedCount_Score = value; } }
            private bool _IsDetected;
            public bool IsDetected { get { return _IsDetected; } set { _IsDetected = value; } }

            private string _TechniqueID;
            public string TechniqueID { get { return _TechniqueID; } set { _TechniqueID = value; } }

            private string _TechniqueID_Name;
            public string TechniqueID_Name { get { return _TechniqueID_Name; } set { _TechniqueID_Name = value; } }

            private Int32 _Score;
            public Int32 CheckScore { get { return _Score; } set { _Score = value; } }

            private Int32 _CheckingMitreSubItems_Index;
            public Int32 CheckingMitreSubItems_Index { get { return _CheckingMitreSubItems_Index; } set { _CheckingMitreSubItems_Index = value; } }

            private Int32 _Scan_Loops;
            public Int32 Scan_Loops { get { return _Scan_Loops; } set { _Scan_Loops = value; } }

            //private Int64 _Scan_UID;
            //public  Int64 Scan_UID { get { return _Scan_UID; } set { _Scan_UID = value; } }
        }

        /// <summary>
        ///  Scan_ID 1 record a
        ///  
        /// </summary>

        public static List<_TableOfSysmon_Processes> Sysmon_Process_Table = new List<_TableOfSysmon_Processes>();
        public static List<_TableOfSysmon_Processes> Sysmon_Process_Table_history = new List<_TableOfSysmon_Processes>();

        public static System.Timers.Timer t = new System.Timers.Timer(5000);
        public static EventLogQuery _Sysmon_RealtimeMonitor;
        public static EventLogWatcher _Sysmon_EvtWatcher;
        public static event EventHandler NewEventID1Raised;
        public static string[] _DetailsCommands_yamlfiles_details;
        public static List<string> Detected;
        public static string CurrentScan = "";
        public static string CurrentScan2 = "";
        public static bool init = false;
        public static EventLog BEV4 = null;
        public static string last_Detection = "";
        public static string last_Detection2 = "";
        public static string TechniqueId_Command_Details_DB_Index = "";
        public static string TechniqueId_Command_Details_DisplayName = "";
        public static string TechniqueId_Command_Details_TechniqueID = "";
        public static string TechniqueId_Command_Details_Command_Str = "";
        public static string CheckFalsePositive = "";
        public static Thread _Thread_RealTimeMon2;
        public static Int32 iCounter = 0;
        public static Int32 icounter_Max = 0;
        //public static Int64 _ScanUIDs = 0;

        public static void RunMonitor_Sysmon()
        {
            try
            {
                string CommandsListFile = Resource2.TextFile1_AllCommandPrompts;

                /// 365: [- name: Enumeration for PuTTY Credentials in Registry] [attack_technique: T1552.002] [      reg query HKCU\Software\SimonTatham\PuTTY\Sessions /t REG_SZ /s]
                _DetailsCommands_yamlfiles_details = CommandsListFile.Split('\n');

                NewEventID1Raised += RealtimeEventIDsMonitor_NewEventID1Raised;
                //t.Elapsed += T_Elapsed;
                //t.Enabled = true;
                _Sysmon_RealtimeMonitor = new EventLogQuery("Microsoft-Windows-Sysmon/Operational", PathType.LogName);

                _Sysmon_EvtWatcher = new EventLogWatcher(_Sysmon_RealtimeMonitor);
                _Sysmon_EvtWatcher.EventRecordWritten += EvtWatcher_EventRecordWritten;

                /// Run As Admin ;)
                _Sysmon_EvtWatcher.Enabled = true;

            }
            catch (Exception error)
            {


            }
        }

        public static async Task _Scan()
        {
            init = true;
            await Task.Run(() =>
            {
                ///365: [- name: Enumeration for PuTTY Credentials in Registry] [attack_technique: T1552.002] [      reg query HKCU\Software\SimonTatham\PuTTY\Sessions /t REG_SZ /s]
                string[] attack_technique_Commands_sub_Items = null;
                string[] Processes_Sysmon_CommandLines_sub_Items = null;
                string sub_Items_ListIndex = "";
                string sub_Items_ListIndex_temp = "";
                string temp = "";
                string xsub2 = "";
                string xitem2 = "";
                Detected = new List<string>();
                bool detected = false;
                int jump = 0;
                int counts = 0;
                int counts2 = 0;
                int loop = 1;

                TimeSpan ts = new TimeSpan();
                TimeSpan _ts = new TimeSpan();
                DateTime d1 = DateTime.Now;
                DateTime d2 = DateTime.Now;
                DateTime d11 = DateTime.Now;
                DateTime d22 = DateTime.Now;
                DateTime _xdt = DateTime.Now;
                DateTime _xdt2 = DateTime.Now;
                DateTime starttime = DateTime.Now;
                DateTime endtime = DateTime.Now;
                DataTable TempTable_MitreAttackTechniques = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                DataRow[] DataTable_rows_MitreAttack_DB = new DataRow[1];
                string[] _commandx = null;
                bool error = false;
                //Int64 Current_ScanID = _ScanUIDs;

                while (true)
                {
                    error = false;
                    if (Form1.IsStopRealTime) break;

                    DataTable_rows_MitreAttack_DB = new DataRow[1];
                    Thread.Sleep(2000);
                    _xdt = DateTime.Now;

                    //List<_TableOfSysmon_Processes> Process_list_Arguments =
                    //Sysmon_Process_Table.FindAll(X => X.IsChecked == false || X.CheckScore < 5);

                    List<_TableOfSysmon_Processes> Process_list_Arguments =
                    Sysmon_Process_Table.FindAll(X => (X.IsChecked == false || X.CheckScore < 5) && X.Scan_Loops <= 3);

                    List<_TableOfSysmon_Processes> Filtered_Process_list_Arguments = Sysmon_Process_Table
                          .GroupBy(x => x.PID).Select(x => x.First()).ToList()
                          .FindAll(X => (X.IsChecked == false || X.CheckScore < 5) && X.Scan_Loops <= 3);

                    foreach (_TableOfSysmon_Processes item in Filtered_Process_list_Arguments)
                    {
                        _commandx = item._CommandLine.Split(' ');

                        Thread.Sleep(200);
                        //Task.Delay(250);

                        if (_commandx != null)
                        {
                            starttime = DateTime.Now;
                            if (!_commandx[1].ToLower().Contains("powershell"))
                            {
                                if (Form1._IsScanningFast)
                                {
                                    try
                                    {
                                        DataTable_rows_MitreAttack_DB = new DataRow[1];
                                        string _query = "Technique_Step_Command LIKE '*" + _commandx[1].Replace('\'', ' ') + "*'";

                                        DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                        if (_query.Replace('\"', ' ') == "Technique_Step_Command LIKE '**'") error = true;
                                    }
                                    catch (Exception)
                                    {

                                    }

                                }
                                else
                                {
                                    if (_commandx.Length >= 3)
                                    {
                                        try
                                        {
                                            DataTable_rows_MitreAttack_DB = new DataRow[1];
                                            string _query = "Technique_Step_Command LIKE '*" + _commandx[1].Replace('\'', ' ') + "*' OR Technique_Step_Command LIKE'*" + _commandx[2].Replace('\'', ' ') + "*'";

                                            DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                            if (_query.Replace('\"', ' ').Contains("Technique_Step_Command LIKE '**'")) error = true;
                                        }
                                        catch (Exception)
                                        {

                                        }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            DataTable_rows_MitreAttack_DB = new DataRow[1];
                                            string _query = "Technique_Step_Command LIKE '*" + _commandx[1].Replace('\'', ' ') + "*'";

                                            DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                            if (_query.Replace('\"', ' ') == "Technique_Step_Command LIKE '**'") error = true;
                                        }
                                        catch (Exception)
                                        {

                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (!Form1._IsScanningFast)
                                {
                                    if (_commandx.Length >= 5)
                                    {
                                        try
                                        {
                                            DataTable_rows_MitreAttack_DB = new DataRow[1];
                                            string _query = "Technique_Step_Command LIKE '*" + _commandx[3].Replace('\'', ' ') + "*' OR Technique_Step_Command LIKE'*" + _commandx[4].Replace('\'', ' ') + "*'";

                                            DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                            if (_query.Replace('\"', ' ').Contains("Technique_Step_Command LIKE '**'")) error = true;
                                        }
                                        catch (Exception)
                                        {
                                            if (_commandx[3].Contains('[') || _commandx[3].Contains(']')
                                            || _commandx[4].Contains('[') || _commandx[4].Contains(']'))
                                            {
                                                DataTable_rows_MitreAttack_DB = new DataRow[1];
                                                string tmp_query3 = _commandx[3].Split('[')[1].Split(']')[0];
                                                string tmp_query4 = _commandx[4].Split('[')[1].Split(']')[0];
                                                string _query = "Technique_Step_Command LIKE '*" + tmp_query3.Replace('\'', ' ') + "*' OR Technique_Step_Command LIKE'*" + tmp_query4.Replace('\'', ' ') + "*'";

                                                DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                                if (_query.Replace('\"', ' ').Contains("Technique_Step_Command LIKE '**'")) error = true;
                                            }
                                        }
                                        finally { }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (_commandx[3].Contains('[') || _commandx[3].Contains(']'))
                                            {
                                                DataTable_rows_MitreAttack_DB = new DataRow[1];
                                                string tmp_query = _commandx[3].Split('[')[1].Split(']')[0];
                                                string _query = "Technique_Step_Command LIKE '*" + tmp_query.Replace('\'', ' ') + "*'";

                                                DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                                if (_query.Replace('\"', ' ') == "Technique_Step_Command LIKE '**'") error = true;
                                            }
                                        }
                                        catch (Exception)
                                        {

                                        }
                                        finally { }

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        DataTable_rows_MitreAttack_DB = new DataRow[1];
                                        string _query = @"Technique_Step_Command LIKE '*" + @_commandx[3].Replace('\'', ' ') + @"*'";

                                        DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(@_query.Replace('\"', ' '));
                                        if (_query.Replace('\"', ' ') == "Technique_Step_Command LIKE '**'") error = true;
                                    }
                                    catch (Exception)
                                    {
                                        if (_commandx[3].Contains('[') || _commandx[3].Contains(']'))
                                        {
                                            DataTable_rows_MitreAttack_DB = new DataRow[1];
                                            string tmp_query = _commandx[3].Split('[')[1].Split(']')[0];
                                            string _query = "Technique_Step_Command LIKE '*" + tmp_query.Replace('\'', ' ') + "*'";

                                            DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query.Replace('\"', ' '));
                                            if (_query.Replace('\"', ' ') == "Technique_Step_Command LIKE '**'") error = true;
                                        }
                                    }

                                }
                            }
                        }

                        if (error)
                        {
                            string _query = "Technique_Step_Command LIKE '" + "Bingo_Error" + "'";
                            DataTable_rows_MitreAttack_DB = TempTable_MitreAttackTechniques.Select(_query);
                            error = false;
                        }

                        icounter_Max = DataTable_rows_MitreAttack_DB.Length;

                        for (int i = 0; i < DataTable_rows_MitreAttack_DB.Length; i++)
                        {

                            //if (error) break;

                            if (Form1.IsStopRealTime) break;

                            if (!Form1._IsScanningFast)
                                Thread.Sleep(50);

                            if (Form1._IsScanningFast)
                                Thread.Sleep(10);

                            string _DetailsCommands_items = DataTable_rows_MitreAttack_DB[i][4].ToString().Substring(1);
                            iCounter = i;
                            try
                            {
                                /// 1 old
                                // Process_list_Arguments = Sysmon_Process_Table
                                //.GroupBy(x => x.PID).Select(x => x.First()).ToList()
                                //.FindAll(X => (X.IsChecked == false || X.CheckScore < 5) && X.Scan_Loops <= 3);

                                /// 2 current
                                Process_list_Arguments = Sysmon_Process_Table
                               .FindAll(X => (X.IsChecked == false || X.CheckScore < 5) && X.Scan_Loops <= 3)
                               .GroupBy(x => x.PID).Select(x => x.First()).ToList();


                            }
                            catch (Exception)
                            {

                            }

                            counts2 = 0;

                            try
                            {
                                ///"2: [- name: Rubeus asreproast] [attack_technique: T1558.004] [      cmd.exe /c \"#{local_folder}\\#{local_executable}\" asreproast /outfile:\"#{local_f

                                if (!_DetailsCommands_items.Contains("    command: |]"))
                                {
                                    try
                                    {
                                        attack_technique_Commands_sub_Items = DataTable_rows_MitreAttack_DB[i][4].ToString().Substring(1).Split(' ');
                                    }
                                    catch (Exception)
                                    {

                                    }

                                    foreach (_TableOfSysmon_Processes Args_Listitem in Process_list_Arguments)
                                    {
                                        if (Form1.IsStopRealTime) break;
                                        d11 = DateTime.Now;

                                        if (!Form1._IsScanningFast)
                                            Thread.Sleep(55);

                                        if (Form1._IsScanningFast)
                                            Thread.Sleep(25);

                                        jump = 0;
                                        foreach (string xsub in attack_technique_Commands_sub_Items)
                                        {
                                            /// count2 is number of attack_technique_Commands_sub_Items which is not blank
                                            counts2 = attack_technique_Commands_sub_Items.Length - 6;
                                            //Thread.Sleep(5);
                                            d1 = DateTime.Now;
                                            if (jump >= 5)
                                            {
                                                if (xsub != "" && xsub != " " && xsub != "\r")
                                                {

                                                    xsub2 = xsub;
                                                    if (xsub.Contains('\r'))
                                                    {
                                                        try
                                                        {
                                                            xsub2 = xsub.Split('\r')[0];
                                                            xsub2 = xsub2.Substring(0, xsub2.Length - 1);
                                                        }
                                                        catch (Exception ee)
                                                        {

                                                        }

                                                    }
                                                    if (xsub2.ToLower().Contains("%logonserver%"))
                                                    {
                                                        string logonserver = Environment.MachineName.ToLower();
                                                        xsub2 = xsub2.Replace("%logonserver%", "\\" + "\\" + logonserver.ToLower()).ToLower();
                                                    }

                                                    /// count is high if detected something like args in comandline ;) not bad code i hope ;)

                                                    Processes_Sysmon_CommandLines_sub_Items = Args_Listitem._CommandLine.Split(' ');
                                                    string[] _ImageStr = Args_Listitem._Image.Split('\\');
                                                    string _ImageFullStr = Args_Listitem._Image;
                                                    string __ImageFile = _ImageStr[_ImageStr.Length - 1];
                                                    
                                                    foreach (string xitem in Processes_Sysmon_CommandLines_sub_Items)
                                                    {
                                                        if (Form1.IsStopRealTime) break;
                                                        xitem2 = xitem;
                                                        if (xitem.Contains('\r'))
                                                        {
                                                            try
                                                            {
                                                                xitem2 = xitem.Split('\r')[0];
                                                            }
                                                            catch (Exception)
                                                            {

                                                            }

                                                        }

                                                        sub_Items_ListIndex_temp = DataTable_rows_MitreAttack_DB[i][0].ToString();

                                                        if (!_ImageFullStr.ToLower().Contains(xitem2.ToLower()) && xsub2 != "" && xsub2 != " " && xitem2 != "" && xitem2 != " "
                                                        && xitem2.ToLower() == xsub2.ToLower())
                                                        {
                                                            counts++;

                                                            /// count os 4 =>        1394: [- name: Bypass UAC using Event Viewer (cmd)] [attack_technique: T1548.002] [      reg.exe add hkcu\software\classes\mscfile\shell\open\command /ve /d
                                                            /// count could be 5 =>  1409: [- name: Bypass UAC using Fodhelper] [attack_technique: T1548.002] [      reg.exe add hkcu\software\classes\ms-settings\shell\open\command /ve /d

                                                            ///1937: [- name: Set Arbitrary Binary as Screensaver] [attack_technique: T1546.002] [      reg.exe add "HK
                                                            sub_Items_ListIndex = DataTable_rows_MitreAttack_DB[i][0].ToString();
                                                            sub_Items_ListIndex_temp = sub_Items_ListIndex;
                                                            Task.Delay(50);
                                                            int _DetectedxandAddedBefore = Detected.FindIndex(xx => xx == DataTable_rows_MitreAttack_DB[i][1].ToString()
                                                               + DataTable_rows_MitreAttack_DB[i][2].ToString()
                                                               + "::Counts=" + counts.ToString() + "/" + counts2.ToString()
                                                               + "sub_Items_ListIndex:" + sub_Items_ListIndex
                                                               + Args_Listitem._CommandLine);
                                                            Task.Delay(50);
                                                            if (_DetectedxandAddedBefore == -1)
                                                            {
                                                                Detected.Add(DataTable_rows_MitreAttack_DB[i][1].ToString()
                                                                   + DataTable_rows_MitreAttack_DB[i][2].ToString()
                                                                   + "::Counts=" + counts.ToString() + "/" + counts2.ToString()
                                                                   + "sub_Items_ListIndex:" + sub_Items_ListIndex
                                                                   + Args_Listitem._CommandLine);
                                                            }
                                                            Task.Delay(50);
                                                            int __found = Sysmon_Process_Table.FindIndex(x =>
                                                            x._Image == Args_Listitem._Image
                                                            && x.PID == Args_Listitem.PID
                                                            && x.CheckingMitreSubItems_Index == Convert.ToInt32(DataTable_rows_MitreAttack_DB[i][0].ToString()));
                                                            //&& x.CheckingMitreSubItems_Index == Convert.ToInt32(sub_Items_ListIndex));
                                                            Task.Delay(50);

                                                            if (__found != -1 /*&& _DetectedxandAddedBefore == -1*/)
                                                            {

                                                                _TableOfSysmon_Processes tempstruc = new _TableOfSysmon_Processes();
                                                                tempstruc.AddedTime = Args_Listitem.AddedTime;
                                                                tempstruc.CommandTypes = Args_Listitem.CommandTypes;
                                                                tempstruc.Description = Args_Listitem.Description;
                                                                tempstruc.EventTime = Args_Listitem.EventTime;
                                                                tempstruc.IsChecked = true;
                                                                tempstruc.IsDetected = true;
                                                                tempstruc.PID = Args_Listitem.PID;
                                                                tempstruc.ProcessItemsDetectedCount_Score = counts.ToString() + "/" + counts2.ToString();
                                                                tempstruc.ProcessName = Args_Listitem.ProcessName;
                                                                tempstruc.ProcessName_Path = Args_Listitem.ProcessName_Path;
                                                                tempstruc.SubItems_ImageIndex = Args_Listitem.SubItems_ImageIndex;
                                                                tempstruc.SubItems_Name_Property = Args_Listitem.SubItems_Name_Property;
                                                                tempstruc.TechniqueID = DataTable_rows_MitreAttack_DB[i][2].ToString();

                                                                tempstruc.TechniqueID_Name = DataTable_rows_MitreAttack_DB[i][1].ToString();
                                                                tempstruc._CommandLine = Args_Listitem._CommandLine;
                                                                tempstruc._Image = Args_Listitem._Image;
                                                                tempstruc._ParentCommandLine = Args_Listitem._ParentCommandLine;
                                                                tempstruc._EventMessage = Args_Listitem._EventMessage;
                                                                int checkcount = Sysmon_Process_Table[__found].CheckScore;
                                                                /// important to detection score
                                                                tempstruc.CheckScore = checkcount + 1;
                                                                /// important to detection

                                                                tempstruc.CheckingMitreSubItems_Index = Convert.ToInt32(DataTable_rows_MitreAttack_DB[i][0].ToString());
                                                                tempstruc.Event_Record_ID = Args_Listitem.Event_Record_ID;

                                                                int __loops = Sysmon_Process_Table[__found].Scan_Loops;
                                                                tempstruc.Scan_Loops = __loops + 1;

                                                                Sysmon_Process_Table[__found] = tempstruc;

                                                                Task.Delay(10);

                                                                detected = true;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Task.Delay(50);
                                                                if (_DetectedxandAddedBefore == -1)
                                                                {
                                                                    _TableOfSysmon_Processes tempstruc = new _TableOfSysmon_Processes();
                                                                    tempstruc.AddedTime = Args_Listitem.AddedTime;
                                                                    tempstruc.CommandTypes = Args_Listitem.CommandTypes;
                                                                    tempstruc.Description = Args_Listitem.Description;
                                                                    tempstruc.EventTime = Args_Listitem.EventTime;
                                                                    tempstruc.IsChecked = true;
                                                                    tempstruc.IsDetected = true;
                                                                    tempstruc.PID = Args_Listitem.PID;
                                                                    tempstruc.ProcessItemsDetectedCount_Score = counts.ToString() + "/" + counts2.ToString();
                                                                    tempstruc.ProcessName = Args_Listitem.ProcessName;
                                                                    tempstruc.ProcessName_Path = Args_Listitem.ProcessName_Path;
                                                                    tempstruc.SubItems_ImageIndex = Args_Listitem.SubItems_ImageIndex;
                                                                    tempstruc.SubItems_Name_Property = Args_Listitem.SubItems_Name_Property;
                                                                    tempstruc.TechniqueID = DataTable_rows_MitreAttack_DB[i][2].ToString();

                                                                    tempstruc.TechniqueID_Name = DataTable_rows_MitreAttack_DB[i][1].ToString();
                                                                    tempstruc._CommandLine = Args_Listitem._CommandLine;
                                                                    tempstruc._Image = Args_Listitem._Image;
                                                                    tempstruc._ParentCommandLine = Args_Listitem._ParentCommandLine;
                                                                    tempstruc._EventMessage = Args_Listitem._EventMessage;
                                                                    int checkcount = 0;
                                                                    /// important to detection score
                                                                    tempstruc.CheckScore = checkcount + 1;
                                                                    /// important to detection

                                                                    tempstruc.CheckingMitreSubItems_Index = Convert.ToInt32(DataTable_rows_MitreAttack_DB[i][0].ToString());
                                                                    tempstruc.Event_Record_ID = Args_Listitem.Event_Record_ID;

                                                                    int __loops = 0;
                                                                    tempstruc.Scan_Loops = __loops + 1;

                                                                    Sysmon_Process_Table.Add(tempstruc);

                                                                    Task.Delay(10);

                                                                    detected = true;
                                                                    break;
                                                                }
                                                            }
                                                        }

                                                    }

                                                    d2 = DateTime.Now;

                                                    _ts = d2 - d1;

                                                    List<_TableOfSysmon_Processes> _Detected = Sysmon_Process_Table.FindAll(X => X.IsChecked == true && X.IsDetected == true);
                                                    CurrentScan = "[PID:" + Args_Listitem.PID.ToString()
                                                    + "] Process: " + Args_Listitem.ProcessName_Path.Replace('\r', ' ');
                                                    CurrentScan2 = "[Detected/Total Objects: " + _Detected.Count.ToString() + "/" + Sysmon_Process_Table.Count.ToString() + "]"
                                                  + "[sub_Items_ListIndex:" + DataTable_rows_MitreAttack_DB[i][0].ToString() + "]" + "[Scanning TechniqueID:"
                                                  + DataTable_rows_MitreAttack_DB[i][2].ToString() + "]" +
                                                  " [SubItems Scanned in: " + _ts.TotalMilliseconds.ToString() + "ms]";

                                                }
                                            }
                                            jump++;
                                        }

                                        d22 = DateTime.Now;
                                        Thread.Sleep(5);
                                        ts = d22 - d11;

                                        List<_TableOfSysmon_Processes> _isDetected = Sysmon_Process_Table.FindAll(X => X.IsChecked == true && X.IsDetected == true);
                                        CurrentScan = "[PID:" + Args_Listitem.PID.ToString()
                                                + "] Process: " + Args_Listitem.ProcessName_Path.Replace('\r', ' ');
                                        CurrentScan2 = "[Detected/Total Objects: " + _isDetected.Count.ToString() + "/" + Sysmon_Process_Table.Count.ToString() + "]"
                                      + "[sub_Items_ListIndex:" + DataTable_rows_MitreAttack_DB[i][0].ToString() + "]" + "[Scanning TechniqueID:"
                                      + DataTable_rows_MitreAttack_DB[i][2].ToString() + "]"
                                      + " [Scanned in: " + ts.Minutes.ToString().Split('.')[0] + ":" + ts.Seconds.ToString() + ":" + ts.Milliseconds.ToString() + "ms]";

                                        if (detected) { counts2 = 0; counts = 0; detected = false; };
                                        counts = 0;
                                        counts2 = 0;                                        

                                    }
                                    
                                }
                    
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }

                    int Totalobj_Checked = Sysmon_Process_Table.FindAll(x => x.IsChecked).Count;
                    int Totalobj_Detected = Sysmon_Process_Table.FindAll(x => x.IsDetected).Count;
                    int Total = Sysmon_Process_Table.Count;

                    if (Total != 0)
                    {
                        CurrentScan2 = "[Total Objects:" + Total.ToString() + "][Checked Objects: "
                        + Totalobj_Checked + "][Detected Objects: " + Totalobj_Detected.ToString() + "]";
                    }

                    
                    if (loop > 2)
                    {
                        endtime = DateTime.Now;
                        TimeSpan __ts = endtime - starttime;

                        for (int i = 0; i < _commandx.Length; i++)
                        {
                            _commandx[i] = "";
                        }

                        if (__ts.TotalMilliseconds != 0.0 && loop == 2)
                            CurrentScan = "Scan Finished! in [" + __ts.TotalSeconds.ToString() + " Seconds]" + " , Waiting for New Process....";
                        else
                            CurrentScan = "Scan Finished!" + " , Waiting for New Process....";

                        ////try
                        ////{
                        ////    Sysmon_Process_Table_history.AddRange(Sysmon_Process_Table.ToArray());
                        ////}
                        ////catch (Exception)
                        ////{

                        ////}                                                                    

                        Task.Delay(1500);

                        //Sysmon_Process_Table.RemoveAll(X => 
                        //(X.IsChecked == false || X.CheckScore < 5 || X.IsChecked == true));

                        //Sysmon_Process_Table.RemoveAll(X =>
                        //X.IsChecked == false || X.CheckScore < 5 || X.IsChecked == true || X.Scan_Loops >= 2);

                        Sysmon_Process_Table.RemoveAll(X => X.CheckScore < 5 || X.Scan_Loops > 3);

                        /// bugs here
                        //Sysmon_Process_Table.RemoveAll(X => (X.CheckingMitreSubItems_Index != 0 && X.Scan_Loops > 3) 
                        //|| (X.CheckingMitreSubItems_Index == 0 && X.Scan_Loops > 3));

                        Detected.RemoveAll(x => x.Length > 0);
                        loop = 1;

                        //Current_ScanID = _ScanUIDs + 1;
                    }
                    else
                    {
                        endtime = DateTime.Now;
                        TimeSpan __ts = endtime - starttime;
                        CurrentScan = "Loop: " + loop.ToString() + "/2 , Scan Finished! in ["
                        + __ts.TotalSeconds.ToString() + " Seconds]" + ", Starting Next Loop!";

                        if (loop >= 2)
                        {
                            CurrentScan = "Loop: " + loop.ToString() + "/2 , Scan Finished! in ["
                            + __ts.TotalSeconds.ToString() + " Seconds]" + ", Waiting for New Process....";

                            starttime = DateTime.Now;
                        }
                    }

                    loop++;

                }


            });

        }

        private static async void RealtimeEventIDsMonitor_NewEventID1Raised(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                EventRecord _EventRecord = ((EventRecord)sender);

                if (_EventRecord != null)
                {
                    try
                    {

                        string[] EvtRecords_Details = _EventRecord.FormatDescription().Split('\n');
                        int _PID = Convert.ToInt32(EvtRecords_Details[4].Split(':')[1]);

                        string _Image = EvtRecords_Details[5].Substring(6);
                        string _CommandLine = EvtRecords_Details[11].Substring(12);
                        string _ParentCommandLine = EvtRecords_Details[22].Split(':')[1];
                        int _CommandType = 0;

                        /// Check Detection History 
                        /// Find New Event in History to avoid Search Again for Duplicate/Same Events (Same CommandLines etc.)
                        
                        ListViewItem FoundHistoryItem = null;
                        try
                        {
                            FoundHistoryItem = Form1.SortedList3_HighScore.Find(x =>
                               x.SubItems[6].Text.ToLower() == _Image.ToLower()
                            && x.SubItems[8].Text.ToLower().Contains(_CommandLine.ToLower())
                            && x.SubItems[8].Text.Split(' ').Length == _CommandLine.Split(' ').Length);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }

                        if (FoundHistoryItem != null)
                        {
                            /// this event raised before with same commanlines args so without scanning will add to Detected Process
                            /// this code was for avoid from scanning duplicate commandlines events which means
                            /// we have two events with two eventRecordID also with two different PID but both 
                            /// have same CommandLines Args also Same ProcessName_Image
                            
                            if (_Image.ToLower().Contains("powershell")) _CommandType = 1; else _CommandType = 2;

                            Sysmon_Process_Table.Add(new _TableOfSysmon_Processes
                            {
                                EventTime = Convert.ToDateTime(EvtRecords_Details[2].Substring(8)),
                                CommandTypes = _CommandType,
                                Description = "",
                                PID = _PID,
                                ProcessName = _Image,
                                ProcessName_Path = _Image,
                                SubItems_ImageIndex = 0,
                                SubItems_Name_Property = "",
                                _CommandLine = _CommandLine.ToLower(),
                                _EventMessage = _EventRecord.FormatDescription(),
                                _Image = _Image,
                                _ParentCommandLine = _ParentCommandLine,
                                AddedTime = DateTime.Now,
                                IsChecked = true,
                                ProcessItemsDetectedCount_Score = FoundHistoryItem.SubItems[4].Text,
                                IsDetected = true,
                                TechniqueID = FoundHistoryItem.SubItems[2].Text,
                                TechniqueID_Name = FoundHistoryItem.SubItems[3].Text,
                                CheckScore = Convert.ToInt32(FoundHistoryItem.SubItems[4].Text.Split('/')[0]),
                                CheckingMitreSubItems_Index = Convert.ToInt32(FoundHistoryItem.SubItems[5].Text),
                                Event_Record_ID = Convert.ToInt64(_EventRecord.RecordId),
                                Scan_Loops = 4
                            });
                        }
                        else
                        {

                            if (_Image.ToLower().Contains("powershell")) _CommandType = 1; else _CommandType = 2;

                            if (Sysmon_Process_Table.FindIndex(x => x.PID == _PID && x.ProcessName.ToLower() == _Image.ToLower()) == -1)
                            {
                                Sysmon_Process_Table.Add(new _TableOfSysmon_Processes
                                {
                                    EventTime = Convert.ToDateTime(EvtRecords_Details[2].Substring(8)),
                                    CommandTypes = _CommandType,
                                    Description = "",
                                    PID = _PID,
                                    ProcessName = _Image,
                                    ProcessName_Path = _Image,
                                    SubItems_ImageIndex = 0,
                                    SubItems_Name_Property = "",
                                    _CommandLine = _CommandLine.ToLower(),
                                    _EventMessage = _EventRecord.FormatDescription(),
                                    _Image = _Image,
                                    _ParentCommandLine = _ParentCommandLine,
                                    AddedTime = DateTime.Now,
                                    IsChecked = false,
                                    ProcessItemsDetectedCount_Score = 0.ToString(),
                                    IsDetected = false,
                                    TechniqueID = "",
                                    TechniqueID_Name = "",
                                    CheckScore = 0,
                                    CheckingMitreSubItems_Index = 0,
                                    Event_Record_ID = Convert.ToInt64(_EventRecord.RecordId),
                                    Scan_Loops = 0
                                });
                            }
                        }
                        if (!init)
                        {
                            try
                            {
                                /// bug fixed here ....
                                ThreadStart __Thread_RealTimeMon = new ThreadStart(delegate
                                {
                                    Task.Run(() =>
                                    {
                                        System.Runtime.CompilerServices.TaskAwaiter _Task = _Scan().GetAwaiter();
                                    });

                                });

                                _Thread_RealTimeMon2 = new Thread(__Thread_RealTimeMon);
                                _Thread_RealTimeMon2.Priority = ThreadPriority.Highest;
                                _Thread_RealTimeMon2.Start();

                                //await _Scan();
                            }
                            catch (Exception)
                            {


                            }
                        }

                    }
                    catch (Exception)
                    {


                    }
                }
            });
        }

        private static void EvtWatcher_EventRecordWritten(object sender, EventRecordWrittenEventArgs e)
        {

            if (e.EventRecord.FormatDescription() != string.Empty
                && e.EventRecord.FormatDescription() != null
                && e.EventRecord.Id == 1)
            {

                NewEventID1Raised.Invoke((object)e.EventRecord, null);

            }
        }

        public static async void _RunAsync_Save_New_DetectionLogs_Events_to_WinEventLog(object obj)
        {
            await _Save_New_DetectionLogs_Events_to_WinEventLog(obj);
        }

        public static async void _RunAsync_Save_New_DetectionLogs_Events_to_WinEventLog2(object obj)
        {
            await _Save_New_DetectionLogs_Events_to_WinEventLog(obj, true);
        }

        public static async Task _Save_New_DetectionLogs_Events_to_WinEventLog(object Obj)
        {
            await Task.Run(() =>
            {
                try
                {
                    ListViewItem _items_Objects = (ListViewItem)Obj;
                    BEV4 = new EventLog("BEV4.3", ".", "BEV_4");
                    StringBuilder st = new StringBuilder();

                    DataTable TempTable = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                    DataRow[] dts = TempTable.Select("Record_SubItemIndex = " + Convert.ToInt32(_items_Objects.SubItems[5].Text));
                    TechniqueId_Command_Details_DB_Index = dts[0].ItemArray[0].ToString();
                    TechniqueId_Command_Details_DisplayName = dts[0].ItemArray[1].ToString();
                    TechniqueId_Command_Details_TechniqueID = dts[0].ItemArray[2].ToString();
                    TechniqueId_Command_Details_Command_Str = dts[0].ItemArray[4].ToString();

                    CheckFalsePositive = "\n------------------------------"
                        + "\n\nNote: YOU Can Check False Positive Detection via Compare \"1.Your Event CommandLine\" with \"2.Detected Technique CommandLine\".\n\n"
                        + "TechniqueID: " + TechniqueId_Command_Details_TechniqueID + "\n"
                        + "Technique Name: " + TechniqueId_Command_Details_DisplayName + "\n"
                        + "1.DETECTED TECHNIQUE CommandLine ==> " + TechniqueId_Command_Details_Command_Str + "\n"
                        + "2.YOUR EVENT CommandLine ==>" + _items_Objects.SubItems[8].Text;

                    last_Detection = "[#] Time: " + _items_Objects.SubItems[1].Text + ", TechniqueID: "
                        + _items_Objects.SubItems[2].Text
                        + ", Technique Name: " + _items_Objects.SubItems[3].Text + " ==> Detected via Sysmon EventIDs (EID1) by BEV4.exe"
                        + "\nPID: " + _items_Objects.SubItems[7].Text + ", Process Name: " + _items_Objects.SubItems[6].Text
                        + "\nDetection Score: " + _items_Objects.SubItems[4].Text + "\nDB Index: " + _items_Objects.SubItems[5].Text
                        + CheckFalsePositive
                        + "\n\nSysmon Event_Record_Id: " + _items_Objects.SubItems[9].Text
                        + "\nSysmon Event Message:\n" + _items_Objects.SubItems[10].Text;

                    st.AppendLine(last_Detection);
                    Task.Delay(50);

                    if (last_Detection2 != last_Detection)
                    {
                        BEV4.WriteEntry(st.ToString(), EventLogEntryType.Warning, 2);
                    }

                    last_Detection2 = last_Detection;
                }
                catch (Exception ee)
                {

                }
            });
        }

        public static async Task _Save_New_DetectionLogs_Events_to_WinEventLog(object Obj, bool IsFalsePositive)
        {
            await Task.Run(() =>
            {
                try
                {
                    ListViewItem _items_Objects = (ListViewItem)Obj;
                    BEV4 = new EventLog("BEV4.3", ".", "BEV_4");
                    StringBuilder st = new StringBuilder();

                    DataTable TempTable = Master_Value.MasterValueClass.table_MitreAttackTechniques;
                    DataRow[] dts = TempTable.Select("Record_SubItemIndex = " + Convert.ToInt32(_items_Objects.SubItems[5].Text));
                    TechniqueId_Command_Details_DB_Index = dts[0].ItemArray[0].ToString();
                    TechniqueId_Command_Details_DisplayName = dts[0].ItemArray[1].ToString();
                    TechniqueId_Command_Details_TechniqueID = dts[0].ItemArray[2].ToString();
                    TechniqueId_Command_Details_Command_Str = dts[0].ItemArray[4].ToString();

                    CheckFalsePositive = "\n------------------------------"
                        + "\n\nNote: YOU Can Check False Positive Detection via Compare \"1.Your Event CommandLine\" with \"2.Detected Technique CommandLine\".\n\n"
                        + "TechniqueID: " + TechniqueId_Command_Details_TechniqueID + "\n"
                        + "Technique Name: " + TechniqueId_Command_Details_DisplayName + "\n"
                        + "1.DETECTED TECHNIQUE CommandLine ==> " + TechniqueId_Command_Details_Command_Str + "\n"
                        + "2.YOUR EVENT CommandLine ==>" + _items_Objects.SubItems[8].Text;

                    last_Detection = "[#] Time: " + _items_Objects.SubItems[1].Text + ", TechniqueID: "
                        + _items_Objects.SubItems[2].Text
                        + ", Technique Name: " + _items_Objects.SubItems[3].Text + " ==> (Probably False-Positive) Detected via Sysmon EventIDs (EID1) by BEV4.exe"
                        + "\nPID: " + _items_Objects.SubItems[7].Text + ", Process Name: " + _items_Objects.SubItems[6].Text
                        + "\nDetection Score: " + _items_Objects.SubItems[4].Text + "\nDB Index: " + _items_Objects.SubItems[5].Text
                        + CheckFalsePositive
                        + "\n\nSysmon Event_Record_Id: " + _items_Objects.SubItems[9].Text
                        + "\nSysmon Event Message:\n" + _items_Objects.SubItems[10].Text;

                    st.AppendLine(last_Detection);
                    Task.Delay(50);

                    if (last_Detection2 != last_Detection)
                    {
                        if (IsFalsePositive)
                            BEV4.WriteEntry(st.ToString(), EventLogEntryType.Information, 3);
                    }

                    last_Detection2 = last_Detection;
                }
                catch (Exception ee)
                {

                }
            });
        }


    }
}
