<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="disApprovalCategoryView.aspx.cs" Inherits="admin_car_carCategoryView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White"
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
		ForeColor="Black" GridLines="Horizontal" Height="50px" Width="100%" OnItemCreated="DetailsView1_ItemCreated">
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<Fields>
			<asp:BoundField DataField="DisApprovalCategoryCode" HeaderText="code (코드)" SortExpression="DisApprovalCategoryCode" />
			<asp:BoundField DataField="CodeName" HeaderText="Tên (이름)" SortExpression="CodeName" />
			<asp:BoundField DataField="RegDate" HeaderText="Ngày đăng ký (등록일)" SortExpression="RegDate" />
			<asp:HyperLinkField />
		</Fields>
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:DetailsView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectDisApprovalCategory"
		TypeName="HanaMicron.COMS.BLL.DisApprovalCategory">
		<SelectParameters>
			<asp:QueryStringParameter Name="disApprovalCategoryCode" QueryStringField="disApprovalCategoryCode" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>

