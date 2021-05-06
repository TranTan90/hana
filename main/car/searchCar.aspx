<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchCar.aspx.cs" Inherits="main_visit_searchEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tìm kiếm xe (차량 검색)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" type="text/css" />
    <script language="javascript" type="text/javascript">
		function searchEnd(carCode,number){
			opener.endSearchCar(carCode,number);
			self.close();
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		&nbsp;
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCarDataList"
			TypeName="HanaMicron.COMS.BLL.Car">
			<SelectParameters>
                <asp:Parameter DefaultValue="handler" Name="type" Type="String" />
				<asp:ControlParameter ControlID="txtSearchKey" Name="txtKey" PropertyName="Text"
					Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<table width="100%">
			<tr>
				<td align="right">Có thể tìm kiếm bằng lái xe hoặc số xe (차량번호 또는 운전자로 검색가능합니다).
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchKey"
						ErrorMessage="Nhập từ khóa tìm kiếm 검색어를 입력하여 주십시오" ValidationGroup="v1"></asp:RequiredFieldValidator>Tìm kiếm (검색)
		<asp:TextBox ID="txtSearchKey" runat="server" CssClass="input" ValidationGroup="v1"></asp:TextBox>
					<asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/icon/searchEng.gif"
						ValidationGroup="v1" />
					<a href="carEdit.aspx?mode=write&index=<%=Request["index"]%>"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none;vertical-align:middle" alt="đăng ký mới (신규 등록)" /></a></td>
			</tr>
			<tr>
				<td style="height: 195px">
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
			BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
			ForeColor="Black" GridLines="Horizontal" Width="100%" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="50">
			<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
			<Columns>
				<asp:BoundField DataField="CodeName" HeaderText="Loại xe (차종)" SortExpression="CodeName">
					<ItemStyle HorizontalAlign="Center" />
				</asp:BoundField>
				<asp:BoundField DataField="Header" HeaderText="Số xe (차량번호)" SortExpression="Header">
					<ItemStyle HorizontalAlign="Center" />
				</asp:BoundField>
				<asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number">
					<ItemStyle HorizontalAlign="Center" />
				</asp:BoundField>
				<asp:BoundField DataField="carCode" HeaderText="Lái xe (운전자)" SortExpression="Handler">
					<ItemStyle HorizontalAlign="Center" />
				</asp:BoundField>

                <asp:BoundField DataField="carCode" HeaderText="Công ty đăng ký xe (업체 등록 차)" SortExpression="companyName">
					<ItemStyle HorizontalAlign="Center" />
				</asp:BoundField>

				<asp:BoundField DataField="Reject" HeaderText="Từ chối đến thăm (방문 거부)" SortExpression="Reject">
					<ItemStyle HorizontalAlign="Center" />
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
