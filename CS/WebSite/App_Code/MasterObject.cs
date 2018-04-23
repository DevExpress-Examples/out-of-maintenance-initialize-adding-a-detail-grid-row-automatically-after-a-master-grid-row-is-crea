using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MasterObject
{
    public MasterObject(int key, string value)
    {
        Key = key;
        Value = value;
        Items = new List<DetailObject>();
    }
    public int Key { get; set; }
    public string Value { get; set; }
    public List<DetailObject> Items { get; set; }

}