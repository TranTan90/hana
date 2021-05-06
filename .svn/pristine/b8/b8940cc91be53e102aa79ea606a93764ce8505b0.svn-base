<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="unitList.aspx.cs" Inherits="_Default" Title="Người quản lý khách thăm ra/vào (내방 반출입 관리자)" %>
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
                        <td align="right" style="height: 27px;">
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="key" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="AllValidators">Nhập từ khóa tìm kiếm (검색어를 입력하세요)</asp:RequiredFieldValidator><asp:DropDownList
								ID="keyWord" runat="server">
								<asp:ListItem Value="takeOutPathStartName">Tên (이름)</asp:ListItem>
							</asp:DropDownList><asp:TextBox ID="key" runat="server" CssClass="input1" Width="80px"></asp:TextBox>
							&nbsp;<a href="unitEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a>&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="Tìm kiếm (검색하기)" ValidationGroup="AllValidators" />&nbsp;
                        </td>
                    </tr>
                </table>
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
					DataSourceID="ObjectDataSource1" ForeColor="Black" OnRowDataBound="GridView1_RowDataBound"
					Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" AllowPaging="True" PageSize="50" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다).">
					<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
					<Columns>
						<asp:BoundField DataField="UnitCode" HeaderText="Code (코드)" SortExpression="UnitCode">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="CodeName" HeaderText="Tên (이름)" SortExpression="CodeName">
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle HorizontalAlign="Center" />
						</asp:BoundField>
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
                        <asp:BoundField DataField="Status" HeaderText="Có sử dụng hay không ? (사용유무)" SortExpression="Status">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
					</Columns>
					<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
					<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
				</asp:GridView>
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectUnitList"
					TypeName="HanaMicron.COMS.BLL.Unit">
					<SelectParameters>
						<asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
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
                            <%--<a href="unitEdit.aspx?mode=write"><img src="../../images/icon/write.gif" style="border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none" alt="Đăng ký mới (신규 등록)" /></a>--%></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

