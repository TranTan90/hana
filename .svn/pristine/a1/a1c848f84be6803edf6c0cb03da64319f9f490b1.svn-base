<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="listTakeOutTeam.aspx.cs" Inherits="main_takeOut_listTakeOutTeam" Title="Chi tiết đăng ký (theo nhóm) (신청 내역(팀별))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../include/Calender/js/jsCalendar.js" type="text/javascript"></script>
    <script src="../../include/Calender/js/jsCalendar.datepicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function confirmDelete(url) {
            if (confirm('Dữ liệu bị xóa 1 lần không thể khôi phục lại. Có chắc chắn xóa không \n\n ? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
                window.location = url;
            } else {
                return;
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <!--################################ 타이틀, 현재위치 시작 ################################-->
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="4" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td width="26" height="35">
                            <img src="/COMS/images/basic/icon_02.gif" width="25" height="20">
                        </td>
                        <td class="contents_title">
                            Chi tiết đăng ký ra cổng (Theo nhóm) (반출 신청 내역(팀별))
                        </td>
                        <td align="right" class="location">
                            HOME &gt;Chi tiết đăng ký ra cổng (Theo nhóm) (반출 신청 내역(팀별))
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="title_line">
                        </td>
                    </tr>
                </table>
                <!--################################ 타이틀, 현재위치 끝 ################################-->
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:DropDownList ID="dateType" runat="server">
                                <asp:ListItem>-</asp:ListItem>
                                <asp:ListItem Value="d.takeOutTime">Ngày mang ra (반출일)</asp:ListItem>
                                <asp:ListItem Value="d.takeInTime">Ngày mang vào (반입일)</asp:ListItem>
                                <asp:ListItem Value="a.scheduleOutDate">Ngày mang ra dự định (반출예정일)</asp:ListItem>
                                <asp:ListItem Value="a.scheduleInDate">Ngày mang vào dự định (반입예정일)</asp:ListItem>
                                <asp:ListItem Value="a.regDate">Ngày đăng ký (등록일)</asp:ListItem>
                            </asp:DropDownList>
                            <%--<input type="text" size="8" name="searchStartDate" value="<%=Request["searchStartDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchStartDate,'yyyy-mm-dd',-1,-1);" />
				<input type="text" size="8" name="searchEndDate" value="<%=Request["searchEndDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchEndDate,'yyyy-mm-dd',-1,-1);" />--%>
                            <label>
                                From</label>
                            <asp:TextBox ID="searchStartDate" runat="server" data-datepicker data-format="yyyy-MM-DD"
                                Style="width: 85px"></asp:TextBox>
                            <label>
                                To
                            </label>
                            <asp:TextBox ID="searchEndDate" runat="server" data-datepicker data-format="yyyy-MM-DD"
                                Style="width: 85px"></asp:TextBox>
                            <asp:DropDownList ID="keyWord" runat="server">
                                <asp:ListItem Value="a.takeOutDataCode">Mã tài sản ra cổng (반출번호)</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="key" runat="server" Width="80px"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Text="Tìm kiếm (검색)" />
                            <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
                            <input type="button" value="In (인쇄)" onclick="window.print()" />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" PageSize="50"
                                OnRowDataBound="GridView1_RowDataBound1" Width="100%" ForeColor="#333333" AutoGenerateColumns="False"
                                DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CssClass="table table-bordered">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <Columns>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Mã tài sản ra cổng (반출번호)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang ra (반출일)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Người đăng ký (신청자)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Nơi nhận (반출처)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RecieveName" HeaderText="Người nhận (수령자)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RequireIN" HeaderText="Có mang vào hay không (반입여부)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Hạng mục tài sản ra cổng (반출항목)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center"  Width="120px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutObjectName" HeaderText="Mục đích mang ra (반출목적)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center"  Width="100px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ScheduleInDate" HeaderText="Ngày mang vào dự định (반입예정일)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center"  Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang vào (반입일)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TakeOutDataCode" HeaderText="Trạng thái (상태)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            &nbsp;
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectTakeOutDataList"
                                TypeName="HanaMicron.COMS.BLL.TakeOutData">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="keyWord" Name="keyWord" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
                                    <asp:FormParameter FormField="searchStartDate" Name="searchStartDate" Type="String" />
                                    <asp:FormParameter DefaultValue="" FormField="searchEndDate" Name="searchEndDate"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="dateType" Name="dateType" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:SessionParameter DefaultValue="" Name="requestUserCode" SessionField="loginUpnid"
                                        Type="String" />
                                    <asp:Parameter DefaultValue="TEAM" Name="pageType" Type="String" />
                                    <asp:Parameter Name="check" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20" valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--	<%=Session["loginMember"]["Upnid"]%>--%>
</asp:Content>
