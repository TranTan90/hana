<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="managerList3.aspx.cs" Inherits="admin_approve_approveList" Title="Quản lý Manager (관리자 관리)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
	<table>
		<tr>
			<td colspan="4">
				<asp:Image ID="imgError" runat="server" ImageUrl="~/images/icon/error.gif" Visible="False" />
				<asp:Label ID="lblError" runat="server" Font-Bold="False" CssClass="errorMsg" Visible="False"></asp:Label></td>
		</tr>
		<tr>
			<td rowspan="2">
			<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
				<ParentNodeStyle Font-Bold="False" />
				<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
				<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
					VerticalPadding="0px" />
				<NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
					NodeSpacing="0px" VerticalPadding="2px" />
			</asp:TreeView>
			</td>
			<td rowspan="2" valign="middle">
				Nhân viên (임직원) <br />
				<asp:ListBox ID="employeeList" runat="server" Height="250px" Width="200px" CssClass="input1"></asp:ListBox>
			</td>
			<td valign="middle">
				<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/arrowNext.GIF" OnClick="ImageButton1_Click" /><br />
				<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/icon/arrowPerv.GIF" OnClick="ImageButton2_Click" /></td>
			<td valign="middle">
				Người quản lý (관리자)<br />
				<asp:ListBox ID="managerList" runat="server" Width="200px" DataSourceID="ObjectDataSource1" DataTextField="DisplayName" DataValueField="Upnid" Height="250px" CssClass="input1"></asp:ListBox><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectManagerList"
					TypeName="HanaMicron.COMS.BLL.Manager">
					<SelectParameters>
						<asp:Parameter DefaultValue="2" Name="managerLevel" Type="Int32" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</td>
		</tr>
	</table>
	
</asp:Content>

