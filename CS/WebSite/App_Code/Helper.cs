using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

static public class Helper
{
    static private List<MasterObject> _Data;
    static public List<MasterObject> Data
    {
        get
        {
            if (_Data == null)
            {
                _Data = new List<MasterObject>();
                FillData();
            }
            return _Data;
        }
        set
        {
            _Data = value;
        }
    }
    static private void FillData()
    {
        _Data.Add(new MasterObject(0, "foo"));
        _Data[0].Items.Add(new DetailObject(0, "foo1"));
        _Data[0].Items.Add(new DetailObject(1, "foo2"));
        _Data[0].Items.Add(new DetailObject(2, "foo3"));

        _Data.Add(new MasterObject(1, "bar"));
        _Data[1].Items.Add(new DetailObject(0, "bar1"));
        _Data[1].Items.Add(new DetailObject(1, "bar2"));
        _Data[1].Items.Add(new DetailObject(2, "bar3"));
    }

    static public List<MasterObject> GetMasterData()
    {
        return Data;
    }
    static public bool AddItem(int key, string value)
    {
        Data.Add(new MasterObject(key, value));
        return true;
    }
    static public bool EditItem(int key, string value)
    {
        MasterObject item = Find(key);
        if (item == null) return false;
        item.Value = value;
        return true;
    }
    static public bool DeleteItem(int key)
    {
        MasterObject item = Find(key);
        if (item == null) return false;
        Data.Remove(item);
        return true;
    }

    static private MasterObject Find(int key)
    {
        return Data.Find(d => d.Key == key);
    }

    static public List<DetailObject> GetDetailData(int masterKey)
    {
        return Find(masterKey).Items;
    }

    static public bool AddDetailItem(int masterKey, int key, string value)
    {
        Find(masterKey).Items.Add(new DetailObject(key, value));
        return true;
    }

    static public bool EditDetailItem(int masterKey, int key, string value)
    {
        DetailObject item = Find(masterKey).Items.Find(d => d.Key == key);
        if (item == null) return false;
        item.Value = value;
        return true;
    }

    static public bool DeleteDetailItem(int masterKey, int key)
    {
        MasterObject masterItem = Find(masterKey);
        if (masterItem == null) return false;
        DetailObject item = masterItem.Items.Find(d => d.Key == key);
        if (item == null) return false;
        masterItem.Items.Remove(item);
        return true;
    }
}