using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace BEV4.Mitre_Attack
{
    class MitreAttackClass
    {
        public struct MitreAttack_Attack_Items
        {
            public string Attack_technique_ID { set; get; }
            public string Name { set; get; }
            public string Description { set; get; }
            public string CommandPrompt { set; get; }
            public string CommandTypes { set; get; }

        }

        public List<MitreAttack_Attack_Items> MitreAttackList = new List<MitreAttack_Attack_Items>();
        public static MitreAttack_Attack_Items[] MitreAttackList_Array_Copy;
        public static int percent = 0;
        public static string TechniqueID = "";
        public static string TechniqueIDDisplayName = "";

        public static object[] _Load_SearchHistory()
        {
            object[] _return_obj = new object[2];
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "sdata files (SearchHistory_Saved_*.sdata)|*.sdata";
                    ofd.FilterIndex = 0;
                    ofd.ShowDialog();
                }
                catch (Exception)
                {


                }

                string targetfile = ofd.FileName;

                using (Stream file = File.Open(targetfile, FileMode.Open))
                {
                    BinaryFormatter _data = new BinaryFormatter();
                    object obj = _data.Deserialize(file);

                    ListViewItem[] _Items = (obj as IEnumerable<ListViewItem>).ToArray();

                    _return_obj[0] = _Items;
                }

                _return_obj[1] = targetfile;
                return _return_obj;

            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }

            return _return_obj;
        }
        public static void _Save_SearchHistory(ListView Target_Listview)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy_MM_dd_hh.mm.ss");

                using (Stream Snapshot = File.Open("SearchHistory_Saved_" + date + ".sdata", FileMode.Create))
                {
                    BinaryFormatter _data = new BinaryFormatter();
                    _data.Serialize(Snapshot, Target_Listview.Items.Cast<ListViewItem>().ToList());
                }
 
                MessageBox.Show("Search History Data saved into file: \n\n" + "1. SearchHistory_Saved_" + date + ".sdata");
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
        public static List<string> _Get_MitreList_Items(ListBox _listbox)
        {
            /// get all TechniqueID Display Names....
            string tmp = "";
            string[] _Xlist_TechniqueIds_DisplayNames = new string[_listbox.Items.Count];

            for (int i = 0; i < _Xlist_TechniqueIds_DisplayNames.Length; i++)
            {
                tmp = _listbox.Items[i].ToString().Split('[')[0];
                tmp = tmp.Substring(0, tmp.Length - 1);
                _Xlist_TechniqueIds_DisplayNames[i] = tmp;
            }

            return _Xlist_TechniqueIds_DisplayNames.ToList();
        }

        public void DumpYamlInfo(string filename_yaml)
        {
            string dump = "";
            using (StreamReader sw = new StreamReader(filename_yaml))
            {
                dump = sw.ReadToEnd();
                sw.Close();
            }

            MitreAttackList.Clear();
            string[] _Dumps = dump.Split('\n');
            int[] allindex = _FindAllIndex("- name: ", dump, 0);
            string _attack_technique = "";
            string _name = "";
            string _Description = "";
            string _CommandPrompt = "";
            string _CommandType = "";
            Int32 counter = 0;
            bool descriptionFlag = false;
            bool attacktechniqqueFlag = false;

            foreach (string item in _Dumps.ToArray())
            {
                if (item.Contains("attack_technique:"))
                {
                    _attack_technique = item;
                }
                else if (item.Contains("- name: "))
                {
                    _name = item;
                }
                else if ((item.Contains("  description:") || item.Contains("  description: |")) || descriptionFlag == true)
                {
                    descriptionFlag = true;
                    _Description += item + ", \n";
                    if (item.Contains("supported_platforms:") || _Description.Contains("supported_platforms:")) descriptionFlag = false;
                }
                else if (item.Contains("    command: |") || attacktechniqqueFlag == true)
                {
                    attacktechniqqueFlag = true;
                    _CommandPrompt += item + "\n";

                    if (/*item.Contains("    cleanup_command: ") ||*/ item.Contains("    name: "))
                    {
                        attacktechniqqueFlag = false;
                        try
                        {
                            _CommandType = item.Split(':')[1];
                        }
                        catch (Exception)
                        {


                        }

                        MitreAttackList.Add(new MitreAttack_Attack_Items
                        {
                            Attack_technique_ID = _attack_technique,
                            Name = _name,
                            Description = _Description,
                            CommandPrompt = _CommandPrompt,
                            CommandTypes = _CommandType

                        });

                         
                        _name = "";
                        _Description = "";
                        _CommandPrompt = "";
                        _CommandType = "";
                    }
                }

                counter++;
            }

            MitreAttackList_Array_Copy = new MitreAttack_Attack_Items[MitreAttackList.Count];
            MitreAttackList.CopyTo(MitreAttackList_Array_Copy);

        }

        public static async Task _TechniqueIDs_Search1_Powershell(string FirstQuery)
        {
            
            await Task.Run(() =>
            {

                try
                {
                    Master_Value.MasterValueClass.ActiveNode = "Microsoft-Windows-Sysmon/Operational";
                 
                    /// cmd /c powershell "Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)} | Select-Object -Property RecordId,Id,Level,Message | where-object {$_.ID -eq 1} |?{$_.Message -like \"*CommandLine:*reg.exe*add*hkcu\software\classes\mscfile\shell\open\command*/ve*/d*\"}  |ConvertTo-Html | Out-File aliases.htm"
                    /// cmd /c powershell "Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)} | Select-Object -Property TimeCreated,RecordId,Id,Level,Message | where-object {$_.ID -eq 1} |?{$_.Message -like \"*CommandLine:*reg.exe*add*hkcu\software\classes\mscfile\shell\open\command*/ve*/d*\"} | ConvertTo-Html | Out-File HTMLReport.htm  "
 
                    string FirstQuery_strings = FirstQuery.Replace(' ', '*');
                    FirstQuery_strings = FirstQuery_strings.Replace("**", "*");
                    string bat = "cmd /c powershell \"Get-winEvent -LogName \"Microsoft-Windows-Sysmon/Operational\" ";
                    bat += " | Where-Object { $_.TimeCreated -ge $(Get-Date).AddDays(-40)} ";
                    bat += " | Select-Object -Property TimeCreated,RecordId,Id,Level,Message ";
                    bat += " | where-object {$_.ID -eq 1} ";
                    bat += " | where-object {$_.Message -like $(\\\"*CommandLine:*" + FirstQuery_strings + "\\\")} ";
                    bat += " | ConvertTo-Html | Out-File HTMLReport.htm  \"";
                    File.WriteAllText("PSSearch.bat", bat);
                    Process prcs = new Process();
                    prcs.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
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
                        Thread.Sleep(1000);
                        if (CMDoutput != "") break;

                    } while (CMDoutput != "");

                }
                catch (Exception)
                {


                }

                
            });

           
        }
        /// <summary>
        /// Search One item of TechniqueIDs in Yaml file only
        /// </summary>
        /// <param name="FirstQuery"></param>
        /// <returns></returns>
        public static async Task<BindingSource> _TechniqueIDs_Search1(string FirstQuery)
        {
            /// search for one Mitre Attack TechniqueID....
            /// 

            BindingSource temp_table_Local_search1 = new BindingSource();

            await Task.Run(() =>
            {

                try
                {
                    Master_Value.MasterValueClass.ActiveNode = "Microsoft-Windows-Sysmon/Operational";

                    /// IsFilteringMode_Mittre_EID1 true => force waitform2 to search event id 1 only for search sysmon CreateProcess only (Mitre attack find process args)
                    /// EventID 1 , search for CommandPrompt Args in New Processes....
                    /// with this filter search performace is faster.
                    /// But local Event Reload will efect by this filter so for search all EID you should reload sysmon in Local Events TAB again ;)                    

                    WaitForm2 WForm2 = new WaitForm2();
                    WForm2.ShowDialog();

                    Master_Value.MasterValueClass.Local_Description_Groupbox6 = "Event Messages for Event Name (" +
                        Master_Value.MasterValueClass.ActiveNode + ") " + " , Local System";

                    BindingSource Filtering_TempBinding_Local_2 = new BindingSource();
                    DataTable TempTable_For_Tab2 = Master_Value.MasterValueClass.table_Local_search1;
                    string _FirstQuery = FirstQuery.ToLower();
                    
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                    Master_Value.MasterValueClass.table_Local_search1_Results.Rows.Clear();

                    string item1, item2, item3, item4, item5, _EventMessage_String, _SearchString_FirstQuery = "";
                    object item6;

                    for (int i = 0; i < TempTable_For_Tab2.Rows.Count; i++)
                    {
                        item1 = TempTable_For_Tab2.Rows[i][0].ToString();
                        item2 = TempTable_For_Tab2.Rows[i][1].ToString();
                        item3 = TempTable_For_Tab2.Rows[i][2].ToString();
                        /// event messages
                        item4 = TempTable_For_Tab2.Rows[i][3].ToString();
                        /// event datetime
                        item5 = TempTable_For_Tab2.Rows[i][4].ToString();
                        /// event record objects
                        item6 = TempTable_For_Tab2.Rows[i][5];
                        /// optional
                        _EventMessage_String = System.Text.RegularExpressions.Regex.Replace(item4.ToString().ToLower(), "-", " ").ToLower();
                        _SearchString_FirstQuery = System.Text.RegularExpressions.Regex.Replace(_FirstQuery.ToLower(), "-", " ").ToLower();
                        /// core_search
                        _EventMessage_String = System.Text.RegularExpressions.Regex.Replace(item4.ToString().ToLower(), @"\s+", "").ToLower();
                        _SearchString_FirstQuery = System.Text.RegularExpressions.Regex.Replace(_FirstQuery.ToLower(), @"\s+", "").ToLower();

                        string[] __find0 = _EventMessage_String.Split('"');
                        string[] __find1 = _SearchString_FirstQuery.Split('"');
                        _EventMessage_String = "";
                        _SearchString_FirstQuery = "";

                        foreach (string _xitem0 in __find0)
                        {
                            _EventMessage_String += _xitem0;
                        }
                        foreach (string _xitem1 in __find1)
                        {
                            _SearchString_FirstQuery += _xitem1;
                        }


                        if (_EventMessage_String.ToLower().Contains(_SearchString_FirstQuery.ToLower()))
                        {
                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(
                                Master_Value.MasterValueClass.table_Local_search1_Results,
                                item1, item2, item3, item4, item5, (object)item6);
                        }
                    }

                    temp_table_Local_search1.DataSource = Master_Value.MasterValueClass.table_Local_search1_Results;
                    return temp_table_Local_search1;
                }
                catch (Exception)
                {


                }

                return temp_table_Local_search1;
            });

            return temp_table_Local_search1;
        }
        public static async Task<BindingSource> _TechniqueIDs_Search1(string FirstQuery,string SecondQuery)
        {
            /// search for one Mitre Attack TechniqueID....
            /// 

            BindingSource temp_table_Local_search1 = new BindingSource();
            await Task.Run(() =>
            {

                try
                {
                    Master_Value.MasterValueClass.ActiveNode = "Microsoft-Windows-Sysmon/Operational";

                    /// IsFilteringMode_Mittre_EID1 true => force waitform2 to search event id 1 only for search sysmon CreateProcess only (Mitre attack find process args)
                    /// EventID 1 , search for CommandPrompt Args in New Processes....
                    /// with this filter search performace is faster.
                    /// But local Event Reload will efect by this filter so for search all EID you should reload sysmon in Local Events TAB again ;)

                    //IsFilteringMode_Mittre_EID1 = true;

                    WaitForm2 WForm2 = new WaitForm2();
                    WForm2.ShowDialog();

                    Master_Value.MasterValueClass.Local_Description_Groupbox6 = "Event Messages for Event Name (" +
                        Master_Value.MasterValueClass.ActiveNode + ") " + " , Local System";

                    BindingSource Filtering_TempBinding_Local_2 = new BindingSource();
                    DataTable TempTable_For_Tab2 = Master_Value.MasterValueClass.table_Local_search1;
                    string _FirstQuery = FirstQuery.ToLower();
                    string _SecondQuery = SecondQuery.ToLower();
                    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                    Master_Value.MasterValueClass.table_Local_search1_Results.Rows.Clear();

                    string item1, item2, item3, item4, item5, _EventMessage_String, _SearchString_FirstQuery = "";
                    object item6;
                    string _SearchString_SecondQuery = "";

                    for (int i = 0; i < TempTable_For_Tab2.Rows.Count; i++)
                    {
                        item1 = TempTable_For_Tab2.Rows[i][0].ToString();
                        item2 = TempTable_For_Tab2.Rows[i][1].ToString();
                        item3 = TempTable_For_Tab2.Rows[i][2].ToString();
                        /// event messages
                        item4 = TempTable_For_Tab2.Rows[i][3].ToString();
                        /// event datetime
                        item5 = TempTable_For_Tab2.Rows[i][4].ToString();
                        /// event record objects
                        item6 = TempTable_For_Tab2.Rows[i][5];
                        
                        /// optional
                        _EventMessage_String = Regex.Replace(item4.ToString().ToLower(), "-", " ").ToLower();
                        _SearchString_FirstQuery = Regex.Replace(_FirstQuery.ToLower(), "-", " ").ToLower();
                        ///  
                        _EventMessage_String = Regex.Replace(item4.ToString().ToLower(), @"\s+", "").ToLower();
                        _SearchString_FirstQuery = Regex.Replace(_FirstQuery.ToLower(), @"\s+", "").ToLower();
                        
                        /// optional                       
                        _SearchString_SecondQuery = Regex.Replace(SecondQuery.ToLower(), "-", " ").ToLower();
                        ///                       
                        _SearchString_SecondQuery = Regex.Replace(SecondQuery.ToLower(), @"\s+", "").ToLower();


                        string[] __find0 = _EventMessage_String.Split('"');
                        string[] __find1 = _SearchString_FirstQuery.Split('"');
                        string[] __find2 = _SearchString_SecondQuery.Split('"');
                        _EventMessage_String = "";
                        _SearchString_FirstQuery = "";
                        _SearchString_SecondQuery = "";

                        foreach (string _xitem0 in __find0)
                        {
                            _EventMessage_String += _xitem0;
                        }
                        foreach (string _xitem1 in __find1)
                        {
                            _SearchString_FirstQuery += _xitem1;
                        }
                        foreach (string _xitem2 in __find2)
                        {
                            _SearchString_SecondQuery += _xitem2;
                        }


                        if (_EventMessage_String.ToLower().Contains(_SearchString_FirstQuery.ToLower())
                        || _EventMessage_String.ToLower().Contains(_SearchString_SecondQuery.ToLower()))
                        {
                            Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(
                                Master_Value.MasterValueClass.table_Local_search1_Results,
                                item1, item2, item3, item4, item5, (object)item6);
                        }
                    }

                    temp_table_Local_search1.DataSource = Master_Value.MasterValueClass.table_Local_search1_Results;
                    return temp_table_Local_search1;
                }
                catch (Exception)
                {


                }

                return temp_table_Local_search1;
            });

            return temp_table_Local_search1;
        }

        /// <summary>
        /// Search All items of TechniqueID in Yaml file!
        /// </summary>
        /// <param name="searchitems_string"></param>
        /// <returns></returns>
        public static async Task<BindingSource> _TechniqueIDs_SearchAll(MitreAttack_Attack_Items[] _MitreAttackList_Array_Copy)
        {
            /// search for one Mitre Attack TechniqueID....
            /// 

            BindingSource temp_table_Local_search1 = new BindingSource();
            await Task.Run(() =>
            {               
                try
                {
                    Master_Value.MasterValueClass.ActiveNode = "Microsoft-Windows-Sysmon/Operational";
                    TechniqueIDDisplayName = "";
                    TechniqueID = "";
                    /// IsFilteringMode_Mittre_EID1 true => force waitform2 to search event id 1 only for search sysmon CreateProcess only (Mitre attack find process args)
                    /// EventID 1 , search for CommandPrompt Args in New Processes....
                    /// with this filter search performace is faster.
                    /// But local Event Reload will efect by this filter so for search all EID you should reload sysmon in Local Events TAB again ;)

                    //IsFilteringMode_Mittre_EID1 = true;

                    WaitForm2 WForm2 = new WaitForm2();
                    WForm2.ShowDialog();

                    Master_Value.MasterValueClass.Local_Description_Groupbox6 = "Event Messages for Event Name (" +
                        Master_Value.MasterValueClass.ActiveNode + ") " + " , Local System";

                    /// dump wform2 result for search all EID 1 in sysmon via TempTable_For_Tab2
                    /// table_Local_search1 is output which made by wform2
                    BindingSource Filtering_TempBinding_Local_2 = new BindingSource();                   
                    DataTable TempTable_For_Tab2 = Master_Value.MasterValueClass.table_Local_search1;

                    string TextQuery_CommanLine_01 = "";
                    string TextQuery_CommanLine_02 = "";
                    bool _CommandPrompts_has_Lines_or_more = false;
                    /// now TechniqueIDs search results will save to table_Local_searchAll_Results table ;)
                    Master_Value.MasterValueClass.Settable_LocalTable_for_searchAll_result();
                    Master_Value.MasterValueClass.table_Local_searchAll_Results.Rows.Clear();

                    string item1, item2, item3, item4, item5, _EventMessages_Sysmon, _Find1 = "";
                    object item6;
                    string _Find2 = "";
                    int counter2 = 0;

                    /// make all items one by one
                    
                   
                    for (int i = 0; i < TempTable_For_Tab2.Rows.Count; i++)
                    {
                        item1 = TempTable_For_Tab2.Rows[i][0].ToString();
                        item2 = TempTable_For_Tab2.Rows[i][1].ToString();
                        item3 = TempTable_For_Tab2.Rows[i][2].ToString();
                        /// event messages
                        item4 = TempTable_For_Tab2.Rows[i][3].ToString();
                        /// event datetime
                        item5 = TempTable_For_Tab2.Rows[i][4].ToString();
                        /// event record objects
                        item6 = TempTable_For_Tab2.Rows[i][5];
                        percent = i * 100 / TempTable_For_Tab2.Rows.Count;
                        string Commandline = "";

                        foreach (MitreAttack_Attack_Items Xitem in _MitreAttackList_Array_Copy)
                        {
                            try
                            {

                                TechniqueIDDisplayName = "[RecordNumber: " + i.ToString()  + "]" + Xitem.Name + "[" + Xitem.CommandTypes + "]";
                                TechniqueID = Xitem.Attack_technique_ID;
                                ///"    command: |\n      New-Item \"HKCU:\\software\\classes\\mscfile\\shell\\open\\command\" -Force\n      Set-ItemProperty \"HKCU:\
                                /// command prompt + args which made by yaml file
                                /// in this case only search two commandprompt for each Display Name...
                                /// better way is make list of command prompts (in this version only check 2 lines of command prompts only)

                                /// first command prompt for Technique ID
                                TextQuery_CommanLine_01 = Xitem.CommandPrompt.Split('\n')[1];
                                _CommandPrompts_has_Lines_or_more = false;
                                TextQuery_CommanLine_02 = "";

                                //try
                                //{
                                //    /// second command prompt for Technique ID
                                //    if (Xitem.CommandPrompt.Split('\n').ToArray().Length >= 2)
                                //    {
                                //        if ((!Xitem.CommandPrompt.Split('\n')[2].ToLower().Contains("cleanup_command: |"))
                                //            && (!Xitem.CommandPrompt.Split('\n')[2].ToLower().Contains("    name: ")))
                                //        {
                                //            TextQuery_CommanLine_02 = Xitem.CommandPrompt.Split('\n')[2];
                                //            _CommandPrompts_has_Lines_or_more = true;
                                //        }
                                //        else { TextQuery_CommanLine_02 = ""; }
                                //    }
                                //    else { TextQuery_CommanLine_02 = "";}
                                //}
                                //catch (Exception)
                                //{

                                    
                                //}
                                
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    TextQuery_CommanLine_01 = Xitem.CommandPrompt.Substring(14);
                                }
                                catch (Exception)
                                {
                                    if(TextQuery_CommanLine_01.StartsWith("    command: |")) { TextQuery_CommanLine_01 = ""; } else { TextQuery_CommanLine_01 = Xitem.CommandPrompt.ToLower(); }                                    
                                }

                            }
                            /// check command prompt for remove string from query
                            if (TextQuery_CommanLine_01.ToLower().Contains("\"#{executable_binary}\"") || TextQuery_CommanLine_02.ToLower().Contains("\"#{executable_binary}\""))
                            {
                                try
                                {
                                    ///  reg.exe add hkcu\software\classes\ms-settings\shell\open\command /ve /d "#{executable_binary}" /f
                                    int findindex = _FindAllIndex("\"#{executable_binary}\"", TextQuery_CommanLine_01, 0)[0];
                                    TextQuery_CommanLine_01 = TextQuery_CommanLine_01.Substring(0, findindex - 1);
                                    if (_CommandPrompts_has_Lines_or_more)
                                    {
                                        int findindex2 = _FindAllIndex("\"#{executable_binary}\"", TextQuery_CommanLine_02, 0)[0];
                                        TextQuery_CommanLine_02 = TextQuery_CommanLine_02.Substring(0, findindex - 1);
                                    }
                                }
                                catch (Exception)
                                {


                                }
                            }
                            else if (TextQuery_CommanLine_01.ToLower().Contains("\"#{") || TextQuery_CommanLine_02.ToLower().Contains("\"#{"))
                            {
                                try
                                {
                                    ///  reg.exe add hkcu\software\classes\ms-settings\shell\open\command /ve /d "#{?????}" /f
                                    int findindex = _FindAllIndex("\"#{", TextQuery_CommanLine_01, 0)[0];
                                    TextQuery_CommanLine_01 = TextQuery_CommanLine_01.Substring(0, findindex - 1);

                                    if (_CommandPrompts_has_Lines_or_more)
                                    {
                                        int findindex2 = _FindAllIndex("\"#{", TextQuery_CommanLine_02, 0)[0];
                                        TextQuery_CommanLine_02 = TextQuery_CommanLine_02.Substring(0, findindex - 1);
                                    }
                                }
                                catch (Exception)
                                {


                                }
                            }

                            _EventMessages_Sysmon = "";

                            try
                            {
                                /// comandline + args (search focus on this)
                                if ((item4 != null || !string.IsNullOrEmpty(item4)) && item4 != "")
                                {
                                    Commandline = item4.Split('\n')[11];
                                    _EventMessages_Sysmon = Commandline.ToString().Substring(13);

                                }

                            }
                            catch (Exception)
                            {
                                Commandline = item4.Split('\n')[11];
                                _EventMessages_Sysmon = Commandline.ToString();

                            }
                                                        
                            /// optional
                            _EventMessages_Sysmon = System.Text.RegularExpressions.Regex.Replace(Commandline.ToString().ToLower(), "-", " ").ToLower();
                            _Find1 = System.Text.RegularExpressions.Regex.Replace(TextQuery_CommanLine_01.ToLower(), "-", " ").ToLower();
                            _Find2 = System.Text.RegularExpressions.Regex.Replace(TextQuery_CommanLine_02.ToLower(), "-", " ").ToLower();
                            /// core_search
                            _EventMessages_Sysmon = System.Text.RegularExpressions.Regex.Replace(Commandline.ToString().ToLower(), @"\s+", "").ToLower();
                            _Find1 = System.Text.RegularExpressions.Regex.Replace(TextQuery_CommanLine_01.ToLower(), @"\s+", "").ToLower();
                            _Find2 = System.Text.RegularExpressions.Regex.Replace(TextQuery_CommanLine_02.ToLower(), @"\s+", "").ToLower();

                            if (_EventMessages_Sysmon.Contains('"'))
                            {
                                string[] __find0 = _EventMessages_Sysmon.Split('"');
                                string[] __find1 = _Find1.Split('"');
                                string[] __find2 = _Find2.Split('"');
                                _EventMessages_Sysmon = "";
                                _Find1 = "";
                                _Find2 = "";
                                foreach (string _xitem0 in __find0)
                                {
                                    _EventMessages_Sysmon += _xitem0;
                                }
                                foreach (string _xitem1 in __find1)
                                {
                                    _Find1 += _xitem1;
                                }
                                foreach (string _xitem2 in __find2)
                                {
                                    _Find2 += _xitem2;
                                }
                            }
                           

                            if (_EventMessages_Sysmon.ToLower().Contains(_Find1.ToLower()) && _Find1 != "")
                            {
                                Master_Value.MasterValueClass.SetRows_TO_table_Local_for_SearchAll(
                                    Master_Value.MasterValueClass.table_Local_searchAll_Results,
                                    item1, item2, item3, item4, item5, Xitem.Name.Substring(7),
                                    Xitem.Attack_technique_ID, TextQuery_CommanLine_01, (object) item6);
                            }
                            //else if (_Find2 !="" && _EventMessages_Sysmon.ToLower().Contains(_Find2.ToLower()) && _Find1 != "")
                            //{
                            //    Master_Value.MasterValueClass.SetRows_TO_table_Local_for_SearchAll(
                            //       Master_Value.MasterValueClass.table_Local_searchAll_Results,
                            //       item1, item2, item3, item4, item5, Xitem.Name.Substring(7), Xitem.Attack_technique_ID, TextQuery_CommanLine_02);
                            //}
                            //else { }

                            counter2++;
                           
                        }
                    }

                    temp_table_Local_search1.DataSource = Master_Value.MasterValueClass.table_Local_searchAll_Results;
                    return temp_table_Local_search1;
                }
                catch (Exception)
                {


                }

                return temp_table_Local_search1;
               
            });

            return temp_table_Local_search1;
        }

        public static async Task MakeSimpleTextFile_AllCommandPrompts(MitreAttack_Attack_Items[] _MitreAttackList_Array_Copy)
        {
            try
            {
                List<MitreAttack_Attack_Items> commands = new List<MitreAttack_Attack_Items>();
                await Task.Run(() =>
                {
                    string[] cmds = null;
                    foreach (MitreAttack_Attack_Items Xitem in _MitreAttackList_Array_Copy)
                    {
                        cmds = Xitem.CommandPrompt.Split('\n');
                        foreach (string item_cmd in cmds)
                        {
                            string[] s = new string[3];
                            s[0] = item_cmd;
                            s[1] = Xitem.Name;
                            s[2] = Xitem.Attack_technique_ID;
                            commands.Add(new MitreAttack_Attack_Items
                            {
                                Attack_technique_ID = s[2],
                                CommandPrompt = s[0],
                                Name = s[1]
                            });
                        }

                    }
                    string dump = "";
                    using (StreamWriter sw = new StreamWriter("All_yaml_Files_Details.txt"))
                    {
                        int counter = 1;
                        foreach (MitreAttack_Attack_Items item in commands)
                        {

                            sw.WriteLine(counter.ToString() + ": [" + item.Name + "] [" + item.Attack_technique_ID + "] [" + item.CommandPrompt + "]");
                            counter++;
                        }
                        sw.Close();

                    }

                    using (StreamWriter sw = new StreamWriter("All_TechniqueIDs_CommandPrompt.txt"))
                    {
                        int counter = 1;
                        bool write = false;
                        foreach (MitreAttack_Attack_Items item in commands)
                        {
                            if (item.CommandPrompt == "    command: |") write = true;
                            if (item.CommandPrompt.Contains("    cleanup_command: |") || item.CommandPrompt.Contains("    name: ")) write = false;
                            if (write)
                                sw.WriteLine(counter.ToString() + ": [" + item.Name + "] [" + item.Attack_technique_ID + "] [" + item.CommandPrompt + "]");

                            counter++;
                        }
                        sw.Close();

                    }
                    try
                    {
                        Process.Start("Notepad.exe", "All_TechniqueIDs_CommandPrompt.txt");
                    }
                    catch (Exception)
                    {

                    }

                });
            }
            catch (Exception)
            {


            }
        }

        public static int[] _FindAllIndex(string match, string Source_to_Search, int StartIndex)
        {
            int found = -1;
            int count = 0;

            List<int> founditems = new List<int>();
            Source_to_Search = Source_to_Search.ToUpper();
            match = match.ToUpper();

            do
            {
                found = Source_to_Search.IndexOf(match, StartIndex);
                if (found > -1)
                {
                    StartIndex = found + match.Length;
                    count++;
                    founditems.Add(found);
                }

            } while (found > -1 && StartIndex < Source_to_Search.Length);

            return ((int[])founditems.ToArray());
        }
    }
}
