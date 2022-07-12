using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4.Remote_Forms
{
    class Remote_Class
    {
        public TreeNode T = null;
        public SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public void _Connect(string user, string PCName, string DomainName, SecureString PWD, SessionAuthentication _SA)
        {
            if (DomainName == null | DomainName == "" | DomainName == string.Empty)
            {
                DomainName = ".";
            }
            try
            {
                T = new TreeNode(PCName);
                TreeNode T2 = new TreeNode("Windows Logs");
                TreeNode T3 = new TreeNode("Application and Services Logs");
                TreeNode T4 = new TreeNode("Microsoft");

                // ! ! ETW ! !  System.Diagnostics.Eventing.EventProviderTraceListener ty = new System.Diagnostics.Eventing.EventProviderTraceListener(
                if (PCName == " " | PCName == null | PCName == string.Empty)
                {
                    Exception m = new Exception("Host name Is invalid or NotFound");
                    MessageBox.Show(null, "Loading Error " + "\n" + "Host name is invalid or NotFound", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    EventLogSession _Remote_VistaNode = new EventLogSession(PCName, DomainName, user, PWD, _SA);
                    IEnumerable<string> _VistaNode = _Remote_VistaNode.GetLogNames();

                    foreach (string item in _VistaNode)
                    {

                        //   if (ExitAction) { break; }
                        if (PCName == "" | PCName == null)
                        {
                            Exception m = new Exception("Host name Is invalid or NotFound");
                            MessageBox.Show(null, "Loading Error " + "\n" + "Host name is invalid or NotFound", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        // wellcome for label2 to view Event TotalRecords
                        try
                        {
                            //EventLogSession _ForRemoteObjectLog = new EventLogSession(PCName, DomainName, user, PWD, SessionAuthentication.Default);
                            EventLogSession _ForRemoteObjectLog = new EventLogSession(PCName);//, null, M,_S_, SessionAuthentication.Negotiate);
                            EventLogInformation _GetTotalRecords = _ForRemoteObjectLog.GetLogInformation(item, PathType.LogName);
                            string TOTALRECORDS = _GetTotalRecords.RecordCount.ToString();


                            if (item.ToUpper().StartsWith("MICROSOFT"))
                            {
                                T4.Nodes.Add(item).ToolTipText = _GetTotalRecords.RecordCount.ToString();
                            }
                            else
                                if (item == "Application" | item == "System" | item == "Security" | item == "Setup" | item == "ForwardedEvents")
                            {

                                T2.Nodes.Add(item).ToolTipText = _GetTotalRecords.RecordCount.ToString();
                            }
                            else
                            {
                                T3.Nodes.Add(item).ToolTipText = _GetTotalRecords.RecordCount.ToString();
                            }
                        }
                        catch (Exception err)
                        {
                            Master_Value.MasterValueClass.Remote_Host_Name = null;
                            string s = err.Message;
                            MessageBox.Show(null, "Loading Error " + "\n" + "BEV Cannot Complete Load Events Log in your PC , Check Security Permissions or Windows Event Log (Eventlog) Service" + "\n\nNote: BEV 4 Does Not Support Pre Windows Vista Platforms", "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        }

                    }
                }
                T.Nodes.Add(T2);
                T3.Nodes.Add(T4);
                T.Nodes.Add(T3);

                if (PCName == "" | PCName == null)
                {

                }
                else
                {

                }


            }
            catch (Exception err)
            {
                Master_Value.MasterValueClass.Remote_Host_Name = null;
                MessageBox.Show(null, "Error\n" + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Master_Value.MasterValueClass._RemoteConnection_Root_Nodes = T;
        }

        public void RemoteEventSave(string XPath)
        {
            try
            {

                EventLogSession _ForRemoteSystemLog = new EventLogSession(Master_Value.MasterValueClass.Remote_Host_Name);
                EventLogInformation _GetTotalRecords = _ForRemoteSystemLog.GetLogInformation(XPath, PathType.LogName);
                //saveFileDialog1.Filter = "Vista Event Log|*.evtx";
                //saveFileDialog1.FileName = XPath.Replace('/', '-');
                //saveFileDialog1.ShowDialog();
                string filename = XPath.Replace('/', '_') + ".evtx";
                _ForRemoteSystemLog.ExportLog(XPath, PathType.LogName, null, XPath.Replace('/', '_') + ".evtx");
                //_ForLocalSystemLog.ExportLog(XPath, PathType.LogName, null, saveFileDialog1.FileName);
                MessageBox.Show("File: " + filename + " Saved!");
            }
            catch (Exception err)
            {
                if (XPath == null | XPath == "")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        public void LocalEventSave(string XPath)
        {
            try
            {

                EventLogSession _ForLocalSystemLog = new EventLogSession();
                EventLogInformation _GetTotalRecords = _ForLocalSystemLog.GetLogInformation(XPath, PathType.LogName);
                saveFileDialog1.Filter = "Vista Event Log|*.evtx";
                saveFileDialog1.FileName = XPath.Replace('/', '-');
                saveFileDialog1.ShowDialog();
                _ForLocalSystemLog.ExportLog(XPath, PathType.LogName, null, saveFileDialog1.FileName);
            }
            catch (Exception err)
            {
                if (XPath == null | XPath == "")
                {
                    MessageBox.Show(null, "Warning " + "\n" + "Please Select Event or Relaod then Click Save" + "\nSystem Error: " + err.Message, "BEV 4", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
