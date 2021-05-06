<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="companyList.aspx.cs" Inherits="_Default" Title="Quản lý công ty (업체 관리)" %>
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
            <td align="left" valign="top" style="height: 24px;text-align:center">
                <table style="width: 100%" id="TABLE2">
                    <tr>
                        <td style="width: 235px; height: 27px">
                            Số công ty đăng ký (등록된 업체 수):
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            개</td>
                        <td align="right" style="height: 27px;">
							&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="key"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="AllValidators">Nhập từ khóa tìm kiếm (검색어를 입력하세요)</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="keyWord" runat="server">
                                <asp:ListItem Value="companyName">Tên công ty (회사명)</asp:ListItem>
                                <asp:ListItem Value="phone">Số điện thoại (전화번호)</asp:ListItem>
                                <asp:ListItem Value="regNumber">Mã số kinh doanh (사업자번호)</asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="key" runat="server" CssClass="input1" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/icon/searchEng.gif"
                                ValidationGroup="AllValidators" />
                                <a href="companyEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a>
                                <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
								<input type="button" value="In (인쇄)" onclick="window.print()" />
                        </td>
                    </tr>
                </table>
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
					BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
					ForeColor="Black" GridLines="Horizontal" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" Width="100%" AllowPaging="True" PageSize="50" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다).">
					<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
					<Columns>
						<asp:BoundField DataField="CompanyName" HeaderText="Tên công ty (회사명)" SortExpression="CompanyName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="RegNumber1" HeaderText="Mã số kinh doanh (사업자번호)" SortExpression="RegNumber1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="RegNumber2" HeaderText="RegNumber2" SortExpression="RegNumber2" />
						<asp:BoundField DataField="RegNumber3" HeaderText="RegNumber3" SortExpression="RegNumber3" />
						<asp:BoundField DataField="Phone1" HeaderText="Số điện thoại (전화번호)" SortExpression="Phone1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="Phone2" HeaderText="Phone2" SortExpression="Phone2" />
						<asp:BoundField DataField="Phone3" HeaderText="Phone3" SortExpression="Phone3" />
						<asp:BoundField DataField="MasterName" HeaderText="Tên người đại diện (대표자명)" SortExpression="MasterName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Địa chỉ (주소)" SortExpression="Address" />
                        <asp:BoundField DataField="CompanyManagementNo" HeaderText="사업장관리번호" SortExpression="CompanyManagementNo" />
                        <asp:BoundField DataField="CompanyStartNo" HeaderText="사업개시번호" SortExpression="CompanyStartNo" />
						<asp:BoundField DataField="RegDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Ngày đăng ký (등록일)"
							HtmlEncode="False" SortExpression="RegDate">
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
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCompanyList"
					TypeName="HanaMicron.COMS.BLL.Company">
					<SelectParameters>
						<asp:ControlParameter ControlID="keyWord" Name="keyWord" PropertyName="SelectedValue"
							Type="String" />
						<asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
						<asp:Parameter DefaultValue="1" Name="approve" Type="Int32" />
						<asp:Parameter Name="employeeCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
                <br />
				<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
					BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1"
					ForeColor="Black" GridLines="Horizontal" OnRowCreated="GridView2_RowCreated" 
                    OnRowDataBound="GridView2_RowDataBound" Width="100%" AllowPaging="True" 
                    PageSize="9999" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다)." Visible="False">
					<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
					<Columns>
						<asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" 
                            SortExpression="CompanyCode" />
						<asp:BoundField DataField="CompanyName" HeaderText="Tên công ty (회사명)" SortExpression="CompanyName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="RegNumber1" HeaderText="Mã số kinh doanh (사업자번호)" SortExpression="RegNumber1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="RegNumber2" HeaderText="RegNumber2" SortExpression="RegNumber2" />
						<asp:BoundField DataField="RegNumber3" HeaderText="RegNumber3" SortExpression="RegNumber3" />
						<asp:BoundField DataField="Phone1" HeaderText="Số điện thoại (전화번호)" SortExpression="Phone1">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="Phone2" HeaderText="Phone2" SortExpression="Phone2" />
						<asp:BoundField DataField="Phone3" HeaderText="Phone3" SortExpression="Phone3" />
						<asp:BoundField DataField="MasterName" HeaderText="Tên người đại diện (대표자명)" SortExpression="MasterName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Địa chỉ (주소)" SortExpression="Address" />
                        <asp:BoundField DataField="CompanyManagementNo" HeaderText="사업장관리번호" SortExpression="CompanyManagementNo" />
                        <asp:BoundField DataField="CompanyStartNo" HeaderText="사업개시번호" SortExpression="CompanyStartNo" />
						<asp:BoundField DataField="RegDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Ngày đăng ký (등록일)"
							HtmlEncode="False" SortExpression="RegDate">
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
        <tr>
            <td align="left" valign="top">
               
                <table style="width: 100%">
                    <tr>
                        <td>
							&nbsp;</td>
                        <td align="right">
                            <%--<a href="companyEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a>--%></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

