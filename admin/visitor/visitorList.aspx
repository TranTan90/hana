<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="visitorList.aspx.cs" Inherits="_Default" Title="Người quản lý khách thăm ra/vào (내방 반출입 관리자)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function confirmDelete(url){
    if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
        window.location=url;
    }else{
        return false;
    }
}
</script>
    <table style="width: 100%; height: 100%;" id="TABLE1">
        <tr>
            <td align="left" valign="top" style="height: 24px ;text-align:center">
                <table style="width: 100%" id="TABLE2">
                    <tr>
                        <td style="width: 22%; height: 27px ;">
                            Số lượng khách đăng ký (등록된 내방객 수):
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            người (명)</td>
                        <td align="right" style="height: 27px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="key"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="AllValidators">Hãy nhập từ khóa tìm kiếm (검색어를 입력하세요)</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="keyWord" runat="server">
                                <asp:ListItem Value="visitorName">Tên (이름)</asp:ListItem>
                                <asp:ListItem Value="companyName">Tên công ty (회사명)</asp:ListItem>
                                <asp:ListItem Value="visitorRegNumber1">주민등록번호 앞자리</asp:ListItem>
                                <asp:ListItem Value="visitorRegNumber2">주민등록번호 뒷자리</asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="key" runat="server" CssClass="input1" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/icon/searchEng.gif"
                                ValidationGroup="AllValidators" />
                                <a href="visitorEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a>
                                <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
								<input type="button" value="In (인쇄)" onclick="window.print()" />
                        </td>
                    </tr>
                </table>
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
					BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
					CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Horizontal"
					OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" PageSize="50"
					Width="100%" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다).">
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
						<asp:BoundField DataField="RegDate" HeaderText="Ngày đăng ký (등록일)" SortExpression="RegDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:HyperLinkField HeaderText="Sửa (수정)">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:HyperLinkField>
						<asp:HyperLinkField HeaderText="Xóa (삭제)">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:HyperLinkField>
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
                </td>
        </tr>
        <tr>
            <td align="left" valign="top">
				<table style="width: 100%">
                    <tr>
                        <td>
							&nbsp;</td>
                        <td align="right">
                            <%--<a href="visitorEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a--%></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

