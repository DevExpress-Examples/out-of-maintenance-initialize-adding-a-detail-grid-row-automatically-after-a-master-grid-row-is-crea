using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page
{

    protected void ASPxGridViewDetail_Init(object sender, EventArgs e)
    {
        string MasterKeyValue = (ASPxGridView.GetDetailRowKeyValue(sender as ASPxGridView)).ToString();
        ObjectDataSource2.SelectParameters["masterKey"].DefaultValue = MasterKeyValue;
        ObjectDataSource2.InsertParameters["masterKey"].DefaultValue = MasterKeyValue;
        ObjectDataSource2.UpdateParameters["masterKey"].DefaultValue = MasterKeyValue;
        ObjectDataSource2.DeleteParameters["masterKey"].DefaultValue = MasterKeyValue;
    }
    protected void ASPxGridView1_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        ASPxGridView thisASPxGridView = sender as ASPxGridView;
        thisASPxGridView.DetailRows.ExpandRowByKey(e.NewValues["Key"]);
    }
    protected void ASPxGridViewDetail_DataBound(object sender, EventArgs e)
    {
        ASPxGridView detailASPxGridView = sender as ASPxGridView;
        if (detailASPxGridView.VisibleRowCount == 0) detailASPxGridView.AddNewRow();
    }
}



