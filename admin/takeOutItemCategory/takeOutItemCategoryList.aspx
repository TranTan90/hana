<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="takeOutItemCategoryList.aspx.cs" Inherits="admin_approve_approveList" Title="Người quản lý khách thăm ra/ vào (내방 반출입 관리자)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<table>
		<tr>
			<td colspan="4">
				<asp:Image ID="imgError" runat="server" ImageUrl="~/images/icon/error.gif" Visible="False" />
				<asp:Label ID="lblError" runat="server" Font-Bold="False" CssClass="errorMsg" Visible="False"></asp:Label></td>
		</tr>
		<tr>
			<td rowspan="2">
				&nbsp;</td>
			<td rowspan="2" valign="top">
				Phân loại lớn (대메뉴)<br />
				<asp:ListBox ID="itemList" runat="server" Height="250px" Width="200px" CssClass="input1" DataSourceID="ObjectDataSource1" DataTextField="CodeName" DataValueField="TakeOutItemCategoryCode" AutoPostBack="True" OnSelectedIndexChanged="itemList_SelectedIndexChanged"></asp:ListBox><asp:ObjectDataSource
					ID="ObjectDataSource1" runat="server" SelectMethod="selectTakeOutItemCategoryList" TypeName="HanaMicron.COMS.BLL.TakeOutItemCategory">
					<SelectParameters>
						<asp:Parameter DefaultValue="1" Name="depthID" Type="Int32" />
						<asp:Parameter DefaultValue="0" Name="groupID" Type="Int32" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<table>
					<tr>
						<td><asp:TextBox ID="txtItemName" runat="server" CssClass="input"></asp:TextBox></td>
						<td>
							<asp:Button ID="btnItemInsert" runat="server" Text="Thêm (추가)" CssClass="input" OnClick="btnItemInsert_Click" />
							<asp:Button ID="btnItemModify" runat="server" Text="Sửa (수정)" CssClass="input" OnClick="btnItemModify_Click" />
							<asp:Button ID="btnItemDelete" runat="server" Text="Xóa (삭제)" CssClass="input" OnClick="btnItemDelete_Click" />
						</td>
					</tr>
				</table>
			</td>
			<td valign="middle">
				<br />
				</td>
			<td valign="middle">
				Phân loại nhỏ (소메뉴)<br />
				<asp:ListBox ID="subItemList" runat="server" Width="200px" DataSourceID="ObjectDataSource2" DataTextField="CodeName" DataValueField="TakeOutItemCategoryCode" Height="250px" CssClass="input1" AutoPostBack="True" OnSelectedIndexChanged="subItemList_SelectedIndexChanged"></asp:ListBox><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="selectTakeOutItemCategoryList" TypeName="HanaMicron.COMS.BLL.TakeOutItemCategory">
					<SelectParameters>
						<asp:Parameter DefaultValue="2" Name="depthID" Type="Int32" />
						<asp:ControlParameter ControlID="itemList" DefaultValue="" Name="groupID" PropertyName="SelectedValue" Type="Int32" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<table>
					<tr>
						<td><asp:TextBox ID="txtSubName" runat="server" CssClass="input"></asp:TextBox></td>
						<td>
							<asp:Button ID="btnSubInsert" runat="server" Text="Thêm (추가)" CssClass="input" OnClick="btnSubInsert_Click" />
							<asp:Button ID="btnSubModify" runat="server" Text="Sửa (수정)" CssClass="input" OnClick="btnSubModify_Click" />
							<asp:Button ID="btnSubDelete" runat="server" Text="Xóa (삭제)" CssClass="input" OnClick="btnSubDelete_Click" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	
</asp:Content>

