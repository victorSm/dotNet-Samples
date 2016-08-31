using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for EmployeeRecord
/// </summary>
public class EmployeeRecord
{
    private string name;
    private string badge;
    private string access;

    public string Name{get{return name;} set{name = value;}}
    public string Badge{get{return badge;} set{badge = value;}}
    public string Access{get{return access;} set{access = value;}}
}
