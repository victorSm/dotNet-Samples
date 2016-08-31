using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;


public class SessionVars
{
    public static bool isAuthenticated{set;get;}
    public static string url{set;get;}
    public static string user{set;get;}
    public static string pass{set;get;} 
    
    public static ArrayList ldapObjPropNames = new ArrayList();
    public static ArrayList acctProps = new ArrayList(); 
}
