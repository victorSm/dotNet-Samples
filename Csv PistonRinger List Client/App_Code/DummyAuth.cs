using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for DummyAuth
/// </summary>
public class DummyAuth
{
    public static bool authenticate(string user, string pass)
    {
        bool authentic = false;

        if(String.Equals("victor", user))
            { authentic = true; }
        else{ authentic = false; }
        return authentic;                           
    }
}
