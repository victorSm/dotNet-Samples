using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// Utility methods to log output from a webpage to a filestream object...
/// </summary>
public class FsLogger
{
    public static void CreateLog(string inputString)
    {
        FileStream logStream = new FileStream(HttpContext.Current.Server.MapPath("~/Log.txt"),
                                              FileMode.OpenOrCreate, FileAccess.ReadWrite);
        logStream.Write(String_Byterize.Ascii2Bytes(inputString), 0, String_Byterize.ByteCount(inputString));
        logStream.Dispose();
    }  

    public static void Append2Log(string inputString)
    {
        FileStream logStream = new FileStream(HttpContext.Current.Server.MapPath("~/Log.txt"), FileMode.Append,
                                              FileAccess.Write);
        logStream.Write(String_Byterize.Ascii2Bytes(inputString), 0, String_Byterize.ByteCount(inputString));
        logStream.Dispose();
    }  
}
