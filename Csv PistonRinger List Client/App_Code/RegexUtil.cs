using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Utility Regex methods for Find, Match and Replace ops on string patterns...
/// </summary>
public class RegexUtil
{
    public static string MatchNdReplace(string input,
                                        string pattern,
                                        string replacement)
    {
        Regex bckSlash = new Regex(pattern);
        string result = bckSlash.Replace(input, replacement); 
        return result;                                       
    }
}
