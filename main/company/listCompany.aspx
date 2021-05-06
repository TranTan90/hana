<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listCompany.aspx.cs" Inherits="_Default" title="Tìm kiếm công ty (업체 검색)" MasterPageFile="~/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<script language="javascript" type="text/javascript">
function confirmDelete(url){
    if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
        window.location=url;
    }else{
        return false;
    }
}

function selectIt(companyName,companyCode){
    opener.addNameID(companyName,companyCode);
    self.close();
}
</script>
    <table style="width: 100%; height: 100%;" id="TABLE1">
        <tr>
            <td align="left" valign="top" style="height: 24px">
                <table style="width: 100%" id="TABLE2">
                    <tr>
                        <td style="width: 250px; height: 27px">
                            Số công ty đã đăng ký (등록된 업체 수):
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            개</td>
                        <td align="right" style="height: 27px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="key"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="AllValidators">Nhập từ khóa tìm kiếm (검색어를 입력하세요)</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="keyWord" runat="server">
                                <asp:ListItem Value="companyName">Tên công ty (회사명)</asp:ListItem>
                                <asp:ListItem Value="phone">Số điện thoại (전화번호)</asp:ListItem>
                                <asp:ListItem Value="regNumber">Mã số kinh doanh (사업자번호)</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="key" runat="server" CssClass="input1" Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/icon/searchEng.gif"
                                ValidationGroup="AllValidators" />

                        </td>
                    </tr>
                </table>
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
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
					BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
					CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Horizontal"
					OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" PageSize="50"
					Width="100%" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다)." CssClass="table table-stripe">
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
						<asp:BoundField DataField="MasterName" HeaderText="Người đại diện (대표자명)" SortExpression="MasterName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>

                        

						<asp:BoundField DataField="RegDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Ngày đăng ký (등록일)"
							HtmlEncode="False" SortExpression="RegDate">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Người đăng ký (신청자)" SortExpression="EmployeeName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="EmployeeDept" HeaderText="Bộ phận đăng ký (신청부서)" SortExpression="EmployeeDept" >
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
				&nbsp;<table style="width: 670px">
                    <tr>
                        <td>
                        </td>
                        <td>
							&nbsp;</td>
                        <td align="right">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

   </div>
</asp:Content>
