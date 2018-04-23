using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DetailObject
{
    public DetailObject(int key, string value)
    {
        Key = key;
        Value = value;
    }
    public int Key { get; set; }
    public string Value { get; set; }
}