using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace cvx200datamgr_02
{
    public partial class cvx200datamgr_02 : ServiceBase
    {
        public cvx200datamgr_02()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("cvx200Source"))
            {
                System.Diagnostics.EventLog.CreateEventSource("cvx200Source", "cvx200Log");
            }

            eventLog1.Source = "cvx200Source";
            eventLog1.Log = "cvx200Log";
        }

        protected override void OnStart(string[] args)
        {
           // FileWatcher Cam1 = new FileWatcher("10.2.11.56", 45231, "E:\\CameraResults\\FTPData\\T-0220-R0\\CAM1", eventLog1);
            FileWatcher Cam2 = new FileWatcher("10.2.11.56", 45232, "E:\\CameraResults\\FTPData\\T-0220-R0\\CAM2", eventLog1);

            eventLog1.WriteEntry("CVX200 Data Mgr Service started...");

          //  Cam1.Run();
           Cam2.Run();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("CVX200 Data Mgr Service stopped...");
        }
    }
}
