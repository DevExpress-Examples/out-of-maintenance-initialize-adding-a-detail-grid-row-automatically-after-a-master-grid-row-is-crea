Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub ASPxGridViewDetail_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim MasterKeyValue As String = (ASPxGridView.GetDetailRowKeyValue(TryCast(sender, ASPxGridView))).ToString()
		ObjectDataSource2.SelectParameters("masterKey").DefaultValue = MasterKeyValue
		ObjectDataSource2.InsertParameters("masterKey").DefaultValue = MasterKeyValue
		ObjectDataSource2.UpdateParameters("masterKey").DefaultValue = MasterKeyValue
		ObjectDataSource2.DeleteParameters("masterKey").DefaultValue = MasterKeyValue
	End Sub
	Protected Sub ASPxGridView1_RowInserted(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertedEventArgs)
		Dim thisASPxGridView As ASPxGridView = TryCast(sender, ASPxGridView)
		thisASPxGridView.DetailRows.ExpandRowByKey(e.NewValues("Key"))
	End Sub
	Protected Sub ASPxGridViewDetail_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		Dim detailASPxGridView As ASPxGridView = TryCast(sender, ASPxGridView)
		If detailASPxGridView.VisibleRowCount = 0 Then
			detailASPxGridView.AddNewRow()
		End If
	End Sub
End Class



