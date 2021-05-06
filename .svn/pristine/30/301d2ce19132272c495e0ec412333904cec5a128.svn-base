<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchEmployee.aspx.cs" Inherits="main_visit_searchEmployee" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tìm kiếm nhân viên (임직원 검색)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" type="text/css" />
    <script language="javascript" type="text/javascript">
		function searchEnd(upnid,displayName){
			opener.endSearchEmployee(upnid,displayName);
			self.close();
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		&nbsp;
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="searchEmployeeList"
			TypeName="HanaMicron.COMS.BLL.Employee">
			<SelectParameters>
				<asp:Parameter DefaultValue="displayName" Name="keyWord" Type="String" />
				<asp:ControlParameter ControlID="txtSearchKey" DefaultValue="" Name="key" PropertyName="Text"
					Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<table width="100%">
			<tr>
				<td align="right">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchKey"
						ErrorMessage="Nhập từ khóa tìm kiếm (검색어를 입력하여 주십시오) >> " ValidationGroup="v1"></asp:RequiredFieldValidator> Hãy nhập tên nhân viên cần tìm kiếm (임직원 이름을 기입해주세요)
		<asp:TextBox ID="txtSearchKey" runat="server" CssClass="input" ValidationGroup="v1" style="ime-mode:active"></asp:TextBox>
					<asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/icon/searchEng.gif"
						ValidationGroup="v1" /></td>
			</tr>
			<tr>
				<td style="height: 195px">
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
			BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
			ForeColor="Black" GridLines="Horizontal" Width="100%" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="50">
			<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
			<Columns>
				<asp:BoundField DataField="DisplayName" HeaderText="Tên (이름)" SortExpression="DisplayName" >
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</asp:BoundField>
				<asp:BoundField DataField="Dep_name" HeaderText="Bộ phận (부서)" SortExpression="Dep_name" >
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</asp:BoundField>
				<asp:BoundField DataField="Title_name" HeaderText="Chức vụ (직책)" SortExpression="Title_name" >
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</asp:BoundField>
			</Columns>
			<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
			<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
		</asp:GridView>
				</td>
			</tr>
		</table>
    
    </div>
    </form>
</body>
</html>
