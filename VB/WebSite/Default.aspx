<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to initialize adding a Detail Grid row automatically after a Master Grid row has been created</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="Key" DataSourceID="ObjectDataSource1" OnRowInserted="ASPxGridView1_RowInserted">
				<Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True"/>
					<dx:GridViewDataTextColumn FieldName="Key" VisibleIndex="1">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="Value" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
				</Columns>
				<SettingsDetail ShowDetailButtons="true" ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true" />
				<Templates>
					<DetailRow>
						<dx:ASPxGridView ID="ASPxGridViewDetail" runat="server" AutoGenerateColumns="False" KeyFieldName="Key" DataSourceID="ObjectDataSource2" OnInit="ASPxGridViewDetail_Init" OnDataBound="ASPxGridViewDetail_DataBound">
							<Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True"/>
								<dx:GridViewDataTextColumn FieldName="Key" VisibleIndex="1">
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn FieldName="Value" VisibleIndex="2">
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:ASPxGridView>
					</DetailRow>
				</Templates>
			</dx:ASPxGridView>
			<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="AddItem" SelectMethod="GetMasterData" TypeName="Helper" DeleteMethod="DeleteItem" UpdateMethod="EditItem">
				<DeleteParameters>
					<asp:Parameter Name="key" Type="Int32" />
				</DeleteParameters>
				<InsertParameters>
					<asp:Parameter Name="key" Type="Int32" />
					<asp:Parameter Name="value" Type="String" />
				</InsertParameters>
				<UpdateParameters>
					<asp:Parameter Name="key" Type="Int32" />
					<asp:Parameter Name="value" Type="String" />
				</UpdateParameters>
			</asp:ObjectDataSource>
			<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="DeleteDetailItem" InsertMethod="AddDetailItem" SelectMethod="GetDetailData" TypeName="Helper" UpdateMethod="EditDetailItem">
				<DeleteParameters>
					<asp:Parameter Name="masterKey" Type="Int32" />
					<asp:Parameter Name="key" Type="Int32" />
				</DeleteParameters>
				<InsertParameters>
					<asp:Parameter Name="masterKey" Type="Int32" />
					<asp:Parameter Name="key" Type="Int32" />
					<asp:Parameter Name="value" Type="String" />
				</InsertParameters>
				<SelectParameters>
					<asp:Parameter Name="masterKey" Type="Int32" />
				</SelectParameters>
				<UpdateParameters>
					<asp:Parameter Name="masterKey" Type="Int32" />
					<asp:Parameter Name="key" Type="Int32" />
					<asp:Parameter Name="value" Type="String" />
				</UpdateParameters>
			</asp:ObjectDataSource>
		</div>
	</form>
</body>
</html>