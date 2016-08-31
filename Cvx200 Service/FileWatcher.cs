using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Permissions;
using System.Diagnostics;

namespace cvx200datamgr_02
{
    class FileWatcher
    {
        private static string path = "";
        private static string socketIp = "";
        private static Int32 socketPort = 0;
        private static EventLog logger;

        public FileWatcher(string ip, Int32 port, string folderpath, EventLog elog)
        {
            socketIp = ip;
            socketPort = port;
            path = folderpath;
            logger = elog;
        }
        public void Run()
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.Attributes
                                    | NotifyFilters.DirectoryName | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            watcher.Filter = "";

            //Event Handler
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
        }

        public static void OnCreated(object source, FileSystemEventArgs e)
        {
            SocketSender Sender = new SocketSender(socketIp, socketPort);
            logger.WriteEntry("File: " + e.Name + "_Path: " + e.FullPath);
            string filename = e.Name;
            Sender.SendData(filename);
        }
    }
}
