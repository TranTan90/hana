<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="approveList.aspx.cs" Inherits="admin_approve_approveList" Title="Quản lý người phê duyệt (결재자 관리)" %>
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
				<asp:ListBox ID="employeeList" runat="server" Height="500px" Width="200px" CssClass="input1"></asp:ListBox>
			</td>
			<td valign="middle" style="width: 23px">
				&nbsp;<br />
				<br />
				<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/arrowNext.GIF" OnClick="ImageButton1_Click" /><br />
				<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/icon/arrowPerv.GIF" OnClick="ImageButton2_Click" /></td>
			<td valign="middle">
				Người phê duyệt khách thăm (내방 결재자)<br />
				<asp:ListBox ID="visit" runat="server" Width="200px" DataSourceID="ObjectDataSource1" DataTextField="DisplayName" DataValueField="Upnid" Height="250px" CssClass="input1"></asp:ListBox><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listApprovor"
					TypeName="HanaMicron.COMS.BLL.Employee">
					<SelectParameters>
						<asp:Parameter DefaultValue="1" Name="isVisit" Type="String" />
						<asp:Parameter DefaultValue="0" Name="isTakeOut" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</td>
		</tr>
		<tr>
			<td valign="middle" style="width: 23px">
				&nbsp;<br />
				<br />
				<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/icon/arrowNext.GIF" OnClick="ImageButton3_Click" /><br />
				<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/icon/arrowPerv.GIF" OnClick="ImageButton4_Click" /></td>
			<td valign="middle">
				Người phê duyệt ra vào (반출입 결재자)<br />
				<asp:ListBox ID="takeOut" runat="server" Width="200px" DataSourceID="ObjectDataSource2" DataTextField="DisplayName" DataValueField="Upnid" Height="250px" CssClass="input1"></asp:ListBox><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listApprovor"
					TypeName="HanaMicron.COMS.BLL.Employee">
					<SelectParameters>
						<asp:Parameter DefaultValue="0" Name="isVisit" Type="String" />
						<asp:Parameter DefaultValue="1" Name="isTakeOut" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</td>
		</tr>
	</table>
	
</asp:Content>

