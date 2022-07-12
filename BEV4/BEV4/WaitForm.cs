using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4
{
    public partial class WaitForm : Form
    {       
        private BackgroundWorker BGW_RemoteEvt_View;
        private static BindingSource TempBinding = new BindingSource();
        private EventLogQuery eventsQuery;
        private EventLogReader logReader;
        private string Temps1, Temps2;
        public Thread _Thread;
        public bool IsFilteredByDateTime = false;
        Master_Value.MasterValueClass MObj = new Master_Value.MasterValueClass();
      
       
        public WaitForm()
        {
            InitializeComponent();
            TempBinding.DataSource = typeof(System.Diagnostics.Eventing.Reader.EventLogRecord);
        }

        public void _Reload_Init()
        {
            try
            {
                try
                {

                    ThreadStart T_Core1_Search1 = new ThreadStart(delegate
                    {
                         
                        Thread.Sleep(3);
                        BGW_RemoteEvt_View = new BackgroundWorker();
                        BGW_RemoteEvt_View.DoWork += new DoWorkEventHandler(BGW_RemoteEvt_View_DoWork);
                        BGW_RemoteEvt_View.ProgressChanged += new ProgressChangedEventHandler(BGW_RemoteEvt_View_ProgressChanged);
                        BGW_RemoteEvt_View.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RemoteEvt_View_RunWorkerCompleted);
                        BGW_RemoteEvt_View.WorkerReportsProgress = true;
                        BGW_RemoteEvt_View.WorkerSupportsCancellation = true;
                        BGW_RemoteEvt_View.RunWorkerAsync();
                    });

                    Thread _T8__CoreSearchThread = new Thread(T_Core1_Search1);
                    _T8__CoreSearchThread.Priority = ThreadPriority.Highest;
                    _T8__CoreSearchThread.Start();
                }
                catch (Exception err)
                {


                }


            }
            catch (Exception err)
            {


            }



        }

        public void DisplayEventAndLogInformation(BackgroundWorker bgw, DoWorkEventArgs e)
        {
            try
            {
                string X = "\"" + Master_Value.MasterValueClass.ActiveNode + "\"";
                string queryString = "*[System/Channel=" + X + "]";

                eventsQuery = new EventLogQuery(Master_Value.MasterValueClass.ActiveNode, PathType.LogName, queryString);
                EventLogSession Remote_session = new EventLogSession(Master_Value.MasterValueClass.Remote_Host_Name);


                // Gets Events for Local or Remote Eventlogs 
                eventsQuery.Session = Remote_session;
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
                                if (!IsFilteredByDateTime)
                                {
                                    bgw.ReportProgress(0, (object)eventInstance);
                                }
                                else
                                {
                                    if (eventInstance.TimeCreated.Value.Date >= dateTimePicker1.Value.Date && eventInstance.TimeCreated.Value.Date <= dateTimePicker2.Value.Date)
                                        bgw.ReportProgress(0, (object)eventInstance);
                                }
                            }


                        }
                        catch (EventLogNotFoundException eeee)
                        {
                            // Console.WriteLine("BEV Internal Error Zero A" + eeee.Message);
                        }


                    }

                }

                if (!Form1.IsFilteringMode_Mittre_EID1)
                {
                    logReader = new EventLogReader(eventsQuery);
                    for (EventRecord eventInstance = logReader.ReadEvent();
                        null != eventInstance; eventInstance = logReader.ReadEvent())
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
                                if (eventInstance.TimeCreated.Value.Date >= dateTimePicker1.Value.Date && eventInstance.TimeCreated.Value.Date <= dateTimePicker2.Value.Date)
                                    bgw.ReportProgress(0, (object)eventInstance);
                            }


                        }
                        catch (EventLogNotFoundException eeee)
                        {
                            // Console.WriteLine("BEV Internal Error Zero A" + eeee.Message);
                        }


                    }

                }

 
            }
            catch (Exception err)
            {
                //  Console.WriteLine("BEV Internal Error Zero C" + err.Message);

            }
        }

        void BGW_RemoteEvt_View_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DisplayEventAndLogInformation(BGW_RemoteEvt_View, e);
            }
            catch (Exception err)
            {


            }


        }

        void BGW_RemoteEvt_View_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {

                try
                {               

                    if (!Form1.IsFilteringMode_Mittre_EID1)
                        TempBinding.Add((EventRecord)e.UserState);

                    //if (Form1.IsFilteringMode_Mittre_EID1)
                    //    TempBinding_for_search1.Add((EventRecord)e.UserState);

                    lock (MObj)
                    {


                        //Master_Value.MasterValueClass.RemoteBindingSource.Add((EventRecord)e.UserState);
                        EventRecord CastObject = ((EventRecord)e.UserState);
                        

                        string msg = CastObject.FormatDescription();
                        if (CastObject == null || msg == null)
                        {
                            Temps1 = CastObject.RecordId.ToString();
                            Temps2 = CastObject.LevelDisplayName.ToString();
                        }
                        else
                        {

                            if (!Form1.IsFilteringMode_Mittre_EID1)
                                Master_Value.MasterValueClass.SetRows_TO_table_Remoting(CastObject.RecordId.ToString(), 
                                    CastObject.LevelDisplayName.ToString(), CastObject.Id.ToString(), msg,
                                    CastObject.TimeCreated.ToString());


                            if (Form1.IsFilteringMode_Mittre_EID1)
                                Master_Value.MasterValueClass.SetRows_TO_table_Local_for_Search1(Master_Value.MasterValueClass.table_Local_search1,
                                    CastObject.RecordId.ToString(), CastObject.LevelDisplayName.ToString(), CastObject.Id.ToString(),
                                    CastObject.FormatDescription(), CastObject.TimeCreated.ToString(),(object)CastObject);


                           // Master_Value.MasterValueClass.SetRows_TO_table_Remoting(CastObject.RecordId.ToString(), CastObject.LevelDisplayName.ToString(), CastObject.Id.ToString(), msg, CastObject.TimeCreated.ToString());
                        }
                    }


                }
                catch (EventLogNotFoundException err)
                {
                   // Master_Value.MasterValueClass.SetRows_TO_table_Remoting(Temps1, Temps2, " ", "Null -- Message is Null OR Messages NotFound", "");
                    // Console.WriteLine("BEV Internal Error Zero BB" + err.Message + "{" + ((EventRecord)e.UserState).FormatDescription() + "}");
                }
            }
            catch (Exception err)
            {


            }
        }

        public void CopyBindingSource()
        {
            if (!Form1.IsFilteringMode_Mittre_EID1)
                Master_Value.MasterValueClass.RemoteBindingSource = TempBinding;

            this.Close();

        }

        void BGW_RemoteEvt_View_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                Form1.IsLocalRemote_SearchReloadFormActived = false;
                CopyBindingSource();                                 
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
                toolStripStatusLabel1.Text = "Connecting to Remote System";
                toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                    + Master_Value.MasterValueClass.ActiveNode_Count + " Records";

                //if (Form1.IsFilteringMode_Mittre_EID1)
                //{
                //    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
                //    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
                //}

                if (!Form1.IsFilteringMode_Mittre_EID1)
                    Master_Value.MasterValueClass.Settable_RemoteTable();

                Master_Value.MasterValueClass.Settable_RemoteTable();
                Thread.Sleep(1500);
                this.Update();
                _Reload_Init();

            }
            catch (Exception err)
            {


            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            IsFilteredByDateTime = false;
            this.Text = "Loading , Please Wait...";
            toolStripStatusLabel1.Text = "Connecting to Local System";
            toolStripStatusLabel2.Text = "Event Name: " + Master_Value.MasterValueClass.ActiveNode + " , Events Count: "
                + Master_Value.MasterValueClass.ActiveNode_Count + " Records";

            //if (Form1.IsFilteringMode_Mittre_EID1)
            //{
            //    Master_Value.MasterValueClass.Settable_LocalTable_for_search1();
            //    Master_Value.MasterValueClass.Settable_LocalTable_for_search1_result();
            //}

            if (!Form1.IsFilteringMode_Mittre_EID1)
                Master_Value.MasterValueClass.Settable_RemoteTable();

            Master_Value.MasterValueClass.Settable_RemoteTable();
            Thread.Sleep(1500);
            this.Update();
            _Reload_Init();
        }

        private void WaitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.IsLocalRemote_SearchReloadFormActived = false;
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
