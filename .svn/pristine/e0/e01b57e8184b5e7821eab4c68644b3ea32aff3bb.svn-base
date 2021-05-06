<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carHandlerList.aspx.cs" Inherits="carHandlerList" Title="Quản lý xe (차량 관리)" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>
</title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp; [Đăng ký thêm lái xe (운전자 추가 등록)] &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label
            ID="Label1" runat="server" Text="Lái xe (운전자)"></asp:Label>
        <asp:TextBox ID="txthandler" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Liên lạc (연락처)"></asp:Label>
        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Thêm 추가" OnClick="Button1_Click" />
        <br /><br />
    <table style="width: 100%; height: 100%;" id="TABLE1">
        <tr>
            <td align="left" valign="top" style="height: 24px">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
					DataSourceID="ObjectDataSource1" ForeColor="Black" OnRowDataBound="GridView1_RowDataBound"
					Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" AllowPaging="True" PageSize="50" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다)." DataKeyNames="CarHandlerCode">
					<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
					<Columns>
                        <asp:BoundField DataField="CarHandlerCode" HeaderText="code của lái xe (운전자코드)" ReadOnly="True" SortExpression="CarHandlerCode">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CarCode" HeaderText="code xe (차량코드)" ReadOnly="True" SortExpression="CarCode">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Handler" HeaderText="Lái xe (운전자)" SortExpression="Handler" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Phone" HeaderText="Liên lạc (연락처)" SortExpression="Phone" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Có đăng ký hay không (등록여부)" SortExpression="VisFlag">
                            <EditItemTemplate>
                                <asp:DropDownList DataTextField ="VisFlag" runat="server" ID="StateList2" Text='<%# Bind("VisFlag") %>' >
                                    <asp:ListItem Text="Y">Y</asp:ListItem>
                                    <asp:ListItem Text="N">N</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("VisFlag") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="수정" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    ImageUrl="~/images/icon/edit.gif"></asp:ImageButton>
                                <asp:ImageButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    ImageUrl="~/images/icon/cancel.gif"></asp:ImageButton>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="border_txt_02" HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                ImageUrl="~/images/icon/edit.gif"></asp:ImageButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="삭제" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="border_txt_02" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/images/icon/delete.gif" OnClientClick="return confirm('Có chắc chắn xóa không? (정말로 삭제하시겠습니까?)');"  >
                                </asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
					</Columns>
					<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
					<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
				</asp:GridView>
				<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectCarHandlerList"
					TypeName="HanaMicron.COMS.BLL.Car" DataObjectTypeName="HanaMicron.COMS.Model.CarHandlerInfo" DeleteMethod="deleteCarHandler" UpdateMethod="updateCarHandler">
					<SelectParameters>
                        <asp:QueryStringParameter Name="carCode" QueryStringField="carCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
                </td>
        </tr>
    </table>
    </form>
</body>
</html>
