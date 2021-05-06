<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchVisitor.aspx.cs" Inherits="main_visit_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Tim kiếm khách thăm (내방객 검색)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<script language="javascript" type="text/javascript">
function selectEnd(visitorCode,regNumber,passportNumber,visitorName,companyName,visitorPhone,index){
	opener.endSearch(visitorCode,regNumber,passportNumber,visitorName,companyName,visitorPhone,index);
	self.close();
}
</script>
    <table style="width: 100%; height: 100%;" id="TABLE1">
        <tr>
            <td align="left" valign="top" style="height: 24px; width: 1020px;">
                <table style="width: 670px" id="TABLE2">
                    <tr>
                        <td style="width: 192px; height: 27px">
                            Khách thăm đã đăng ký (등록된 내방객 수):
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            Người (명)</td>
                        <td align="right" style="height: 27px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="key"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="AllValidators">Nhập từ khóa tìm kiếm (검색어를 입력하세요)</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="keyWord" runat="server">
                                <asp:ListItem Value="visitorName">Tên (이름)</asp:ListItem>
                                  
                                <%--2021-05-04 반안: 주민번호는 빼고 “생년월일” 을 추가함 (박민수 차장)--%>
                                <asp:ListItem Value="visitorRegNumber1">Ngày, tháng, năm sinh (생년월일)</asp:ListItem>     
                                <%--<asp:ListItem Value="visitorRegNumber2">주민등록번호 뒷자리</asp:ListItem>--%>
                            </asp:DropDownList><asp:TextBox ID="key" runat="server" CssClass="input1" Width="80px" style="ime-mode:active"></asp:TextBox>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/icon/btn_search.gif" ImageAlign="AbsMiddle"
                                ValidationGroup="AllValidators" />
                                <a href="visitorEdit.aspx?mode=write&index=<%=Request["index"]%>"><img src="../../images/icon/write_visitor.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" align="absmiddle" /></a>
                        </td>
                    </tr>
                </table>
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
					BackColor="White" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="1px"
					CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Horizontal"
					OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" PageSize="50"
					Width="100%" Visible="False" EmptyDataText="Không có kết quả tìm kiếm (검색된 결과가 없습니다)." HorizontalAlign="Center">
					<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
					<Columns>
						<asp:BoundField DataField="CompanyName" HeaderText="Công ty (회사)" SortExpression="CompanyName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="VisitorName" HeaderText="Tên (이름)" SortExpression="VisitorName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="VisitorPhone1" HeaderText="Số điện thoại (전화번호)" SortExpression="VisitorPhone1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="VisitorPhone2" HeaderText="VisitorPhone2" SortExpression="VisitorPhone2" />
						<asp:BoundField DataField="VisitorPhone3" HeaderText="VisitorPhone3" SortExpression="VisitorPhone3" />
						<asp:BoundField DataField="VisitorRegNumber1" HeaderText="Ngày, tháng, năm sinh (생년월일)" SortExpression="VisitorRegNumber1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="VisitorRegNumber2" HeaderText="VisitorRegNumber2" SortExpression="VisitorRegNumber2" />
					</Columns>
					<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
					<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
				</asp:GridView>
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listVisitor"
					TypeName="HanaMicron.COMS.BLL.Visitor">
					<SelectParameters>
						<asp:ControlParameter ControlID="keyWord" Name="keyWord" PropertyName="SelectedValue"
							Type="String" />
						<asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
						<asp:Parameter DefaultValue="false" Name="reject" Type="Boolean" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:Panel ID="pnNotice" runat="server" Height="50px" HorizontalAlign="Center" Width="100%">
					Hãy tìm kiếm bằng tên chính xác vì vấn đề rò rỉ thông tin cá nhân (개인정보 누출로 인한 문제로 정확한 이름으로 검색하셔야 합니다).</asp:Panel>
				<asp:HiddenField ID="index" runat="server" />
                </td>
        </tr>
<%--        <tr>
            <td align="left" valign="top" style="width: 1020px">
				<table style="width: 670px">
                    <tr>
                        <td align="right">
                            <a href="visitorEdit.aspx?mode=write&index=<%=Request["index"]%>"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="신규 등록" /></a></td>
                    </tr>
                </table>
            </td>
        </tr>--%>
    </table>
    </div>
    </form>
</body>
</html>