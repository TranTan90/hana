<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="visitDataList.aspx.cs" Inherits="_Default" Title="Quản lý khách thăm (내방객 관리)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<script src="../../include/Calender/js/jsCalendar.js" type="text/javascript"></script>
<script src="../../include/Calender/js/jsCalendar.datepicker.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function confirmDelete(url) {
        if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không?한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?')) {
            window.location = url;
        } else {
            return false;
        }
    }
</script>
    <table style="width: 100%; height: 100%;" id="TABLE1">
        <tr>
            <td align="left" valign="top" style="height: 24px">
                <table width="100%">
			<tr>
				<td align="right">

                <label> From</label>
                     <asp:TextBox ID="searchStartDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>
                <label> To</label>
                     <asp:TextBox ID="searchEndDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>


				<%--<input type="text" size="8" name="searchStartDate" value="<%=Request["searchStartDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchStartDate,'yyyy-mm-dd',-1,-1);" />
				<input type="text" size="8" name="searchEndDate" value="<%=Request["searchEndDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchEndDate,'yyyy-mm-dd',-1,-1);" />--%>
				
						<asp:DropDownList id="keyWord" runat="server">
                                <asp:ListItem Value="visitorName">Họ tên (Khách thăm) (성명(내방객))</asp:ListItem>
                                <asp:ListItem Value="companyName">Tên công ty (업체명)</asp:ListItem>
						<asp:ListItem Value="DEPART_MTB.dep_name">Bộ phận đăng ký (신청부서)</asp:ListItem>
						<asp:ListItem Value="reqUser.displayName">Người đăng ký (신청자)</asp:ListItem>
                        
                            </asp:DropDownList>&nbsp;<asp:TextBox id="key" runat="server" Width="100px" CssClass="input1"></asp:TextBox><asp:ImageButton id="btnSearch" runat="server" ValidationGroup="AllValidators"  ImageUrl="~/images/icon/searchEng.gif"></asp:ImageButton>
						<asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
						<input type="button" value="In (인 쇄)" onclick="window.print()" />
				</td>
			</tr>
		</table>
		<table width="100%">
			<tr>
				<td style= "text-align :center">
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
		CellPadding="4"
		PageSize="50" OnRowDataBound="GridView1_RowDataBound1" Width="100%" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다).">
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<Columns>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Ngày đăng ký (신청일)" HtmlEncode="False" SortExpression="RegDate">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Thời gian thăm (방문시간)" HtmlEncode="False" SortExpression="InTime" >
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Thời gian vào (입문시간)"
				HtmlEncode="False" SortExpression="InTime" >
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Thời gian ra (출문시간)"
				HtmlEncode="False" SortExpression="OutTime" >
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Tên (성명)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Tên công ty (회사명)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Bộ phận đăng ký (신청부서)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="người đăng ký (신청자)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Người gặp (접견자)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Mục đích thăm (방문목적)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitDataCode" HeaderText="Số xe (차량번호)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:HyperLinkField HeaderText="Trạng thái (상태)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="Center" />
			</asp:HyperLinkField>
            <asp:BoundField DataField="VisitDataCode" HeaderText="Người xử ký vào (입문 처리자)">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="VisitDataCode" HeaderText="Người xử lý ra (출문 처리자)">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
		</Columns>
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
					<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectVisitDataList"
						TypeName="HanaMicron.COMS.BLL.VisitData">
						<SelectParameters>
							<asp:ControlParameter ControlID="keyWord" Name="keyWord" PropertyName="SelectedValue"
								Type="String" />
							<asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
							<asp:FormParameter FormField="searchStartDate" Name="searchStartDate" Type="String" />
							<asp:FormParameter DefaultValue="" FormField="searchEndDate" Name="searchEndDate" Type="String" />
                            <asp:Parameter Name="upnid" Type="String" />
                            <asp:Parameter Name="approveUserCode" Type="String" />
                            <asp:QueryStringParameter Name="type" QueryStringField="type" Type="String" />
						</SelectParameters>
					</asp:ObjectDataSource>
				</td>
			</tr>
		</table>
				<asp:GridView ID="GridViewExcel" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Visible="False" OnRowDataBound="GridViewExcel_RowDataBound1" >
					<Columns>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Nơi làm việc (사업장)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Ngày đến (방문일)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Tên người thăm (방문자 이름)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Số CMT người thăm (방문자 주민번호)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="SĐT người thăm (방문자 전화번호)"/>
                        <asp:BoundField DataField="VisitDataCode" HeaderText="Tên công ty (회사명)" />
						<asp:BoundField DataField="VisitDataCode" HeaderText="Loại xe (차종)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Số xe (차량 번호)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Mục đích thăm (방문 목적)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Chi tiết lí do thăm (방문 목적 세부 사유)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Thời gian vào (입문 시간)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Thời gian ra (출문 시간)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Tên người đăng ký (신청자 이름)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="ID người đăng ký (신청자 사번)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Chức vụ người đăng ký (신청자 직급)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Bộ phận người đăng ký (신청자 부서)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="SĐT người đăng ký (신청자 전화번호)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Tên người gặp (접견자 이름)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="ID người gặp (접견자 사번)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Trạng thái phê duyệt (결재상태)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Tên người xử lý vào (입문 처리자 이름)"/>
						<asp:BoundField DataField="VisitDataCode" HeaderText="Tên người xử lý ra (출문 처리자 이름)"/>
					</Columns>
				</asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

