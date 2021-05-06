<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="carDataView.aspx.cs" Inherits="admin_car_carCategoryView" Title="Xem chi tiết (상세보기)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White"
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
		ForeColor="Black" GridLines="Horizontal" Height="50px" Width="100%" OnDataBound="DetailsView1_DataBound">
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<Fields>
			<asp:BoundField DataField="CarCode" HeaderText="code (코드)" SortExpression="CarCode" />
			<asp:BoundField DataField="CodeName" HeaderText="Loại xe (차종)" SortExpression="CodeName" />
            <asp:BoundField DataField="CarType" HeaderText="Phân loại (구분)" SortExpression="CarType" />
            <asp:BoundField DataField="CompanyName" HeaderText="Tên công ty (업체명)" SortExpression="CompanyName" />
			<asp:BoundField DataField="CarCode" HeaderText="Lái xe (운전자)" SortExpression="Handler" />
			<asp:BoundField DataField="CarCode" HeaderText="Liên lạc (연락처)" SortExpression="Phone" />
			<asp:BoundField DataField="Header" HeaderText="Ký tự trước của biển số (차량 번호 앞자리)" SortExpression="Header" />
			<asp:BoundField DataField="Number" HeaderText="Ký tự sau của biển số (차량 번호 뒷자리)" SortExpression="Number" />
			<asp:BoundField DataField="Reject" HeaderText="Có từ chối thăm hay không (방문 거부 여부)" SortExpression="Reject" />
			<asp:BoundField DataField="RejectContent" HeaderText="Lý do từ chối (거부 사유)" SortExpression="RejectContent" />
			<asp:BoundField DataField="RegDate" HeaderText="Ngày đăng ký (등록일)" SortExpression="RegDate" />
			<asp:HyperLinkField />
		</Fields>
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:DetailsView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCarData"
		TypeName="HanaMicron.COMS.BLL.Car">
		<SelectParameters>
            <asp:QueryStringParameter Name="type" QueryStringField="type" Type="String" />
            <asp:QueryStringParameter Name="code" QueryStringField="code" Type="Int32" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>

