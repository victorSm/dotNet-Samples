using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

/// <summary>
/// Utility to convert strings to byte arrays for use with streams
/// </summary>
public class String_Byterize
{
    public static byte[] Ascii2Bytes(String inputStr)
    {
        byte[] byteArray = Encoding.ASCII.GetBytes(inputStr);
        return byteArray;
    }

    public static Int32 ByteCount(String inputStr)
    {
        Int32 bCount = Encoding.ASCII.GetByteCount(inputStr);
        return bCount;
    }
}
