using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;

/// <summary>
/// Methods for parsing Csv files on the fly...     
/// </summary>
public static class CsvParser
{

    private static Char rdelimiter = '.';
    private static Char fdelimiter = ',';

///////////////////////////////////////////////////////////////
    public static String getCsvContent(String filepath)
    {
        using(StreamReader sr = new StreamReader(filepath))
        {
            StringBuilder sb = new StringBuilder();
            string line;
            String content;

            while((line = sr.ReadLine()) !=null)
            {
                sb.Append(line+rdelimiter);
            }
            content = sb.ToString();
            sr.Dispose();
            sb.Clear();
            return content;
        }
    }

/////////////////////////////////////////////////////////////////
    public static String getCsvString(String filepath)
    {
        using(StreamReader sr = new StreamReader(filepath))
        {
            StringBuilder sb = new StringBuilder();
            string line;
            String str;

            while((line = sr.ReadLine()) !=null)
            {
                sb.Append(line);
            }
            str = sb.ToString();
            sr.Dispose();
            sb.Clear();
            return str;
        }
    }

////////////////////////////////////////////////////////////////
    public static String getHeader(string filepath)
    {
        var content = getCsvContent(filepath);
        var records = getRecords(content);
        var csvHeader = records[0];
        return csvHeader;
    }

/////////////////////////////////////////////////////////////////
    public static String[] getRecords(String csvContent)
    {
        string[] recordArray = csvContent.Split(rdelimiter);
        return recordArray;
    }

//////////////////////////////////////////////////////////////////
    public static string[] getFields(String csvRecord)
    { 
        string[] fieldArray = csvRecord.Split(fdelimiter);
        return fieldArray; 
    }
	
///////////////////////////////////////////////////////////////////
	public static void deleteItem(String item, String filepath)
	{
		var deleteData = getCsvContent(filepath);
		var deleteEntries = getRecords(deleteData);

		if(item.Equals("")) return;

		using(StreamWriter sw = new StreamWriter(filepath))        
        {
            for(int e = 0; e < deleteEntries.Length-1; e++)
            {
                if(!deleteEntries[e].StartsWith(item) || deleteEntries[e].Equals(deleteEntries[0]))
                {
                    sw.WriteLine(deleteEntries[e]);
                }
            }
            sw.Dispose();
        }
	}
	
//////////////////////////////////////////////////////////////////
	public static void deleteContent(String filepath)
	{

		using(StreamWriter sw = new StreamWriter(filepath))        
        {
            sw.WriteLine("Name,Badge,Access");
            sw.Dispose();
        }
	}
	
////////////////////////////////////////////////////////////////////
	public static void addRecord(String name, String badge, String access, String filepath)
	{
		var fdelimiter = ",";
 
		var addData = getCsvContent(filepath);
		var addEntries = getRecords(addData);
		
		using(StreamWriter sw = new StreamWriter(filepath))
        {
            for(int r = 0; r < addEntries.Length-1; r++)
            {
                sw.WriteLine(addEntries[r]);
            }
            sw.WriteLine(name+fdelimiter+badge+fdelimiter+access);
            sw.Dispose();
       }		
	}
}
