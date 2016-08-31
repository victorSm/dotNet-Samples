using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.DirectoryServices;

/// <summary>
/// AD Login authentication...
/// </summary>
public class AD_Auth
{
    public AD_Auth(string domainArg)
    {
        domain = domainArg;
    }
    private string domain = "";

    public bool authenticate(string user, string pass)
    {
        bool authentic = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://"+domain,user,pass);
            object nativeObject = entry.NativeObject;
            authentic = true;
        }
        catch(DirectoryServicesCOMException dse)
        {
            FsLogger.CreateLog("Auth exception..."+dse.Message+"..."+DateTime.Now.ToString());
        }
         return authentic;                                    
    }

    public ArrayList getAttribs()
    {
        DirectoryEntry entry = new DirectoryEntry("LDAP://"+domain);
        ArrayList props = new ArrayList();
        foreach( string strAttrName in entry.Properties.PropertyNames)
        {
            props.Add(strAttrName);
            FsLogger.Append2Log("\n"+strAttrName);
            FsLogger.Append2Log("\n"+entry.Path.ToString());
        }
        return props;
    }

    public ArrayList getAcctProps(string user, string pass)
    {
        DirectoryEntry entry = new DirectoryEntry("LDAP://"+domain,user,pass);
        ArrayList acctProps = new ArrayList();
        foreach(DirectoryEntry childEntry in entry.Children)
        {
            acctProps.Add(childEntry);
            FsLogger.Append2Log("\n"+childEntry.Name.ToString());
            FsLogger.Append2Log("\n"+childEntry.Path.ToString());
        }
        return acctProps;
    }
}
