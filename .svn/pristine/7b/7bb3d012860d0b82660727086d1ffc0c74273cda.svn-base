<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="takeOutDataView.aspx.cs" Inherits="main_visit_viewVisit" Title="Xem chi tiết (상세 보기)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>

	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle"> Thông tin người đăng ký (신청자정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Bộ phận (부서명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				ID (사번)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblUpnid" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi làm việc (사업장)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Tên (성명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisplayName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Chức vụ (직급)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTitle" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Liên lạc (연락처)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblPhone" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">
				Thông tin tài sản mang ra (반출정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Mã tài sản mang ra (반출번호)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTakeOutDataCode" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Ngày mang vào dự định (반입 예정일)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<%--<asp:Label ID="lblScheduleDate" runat="server"</asp:Label>--%>
				<input type="text" name="scheduleInDate" class="input" size="10" readonly  value="<%=scheduleDateTitle%>" />
                <img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày 날짜선택" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].scheduleInDate,'yyyy-mm-dd',950,330);"/>
            </td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Mục đích mang ra (반출목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTakeOutObject" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Mục đích chi tiết (반출세부목적)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblTakeOutObjectContents" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Lộ trình mang ra (반출경로)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTakeOutPathStart" runat="server"></asp:Label> ☞ <asp:Label ID="lblTakeOutPathEnd" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi nhận (반출처)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Người nhận (수령자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblReceiveName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Có mang vào hay không (반입필 여부)
			</td>
			<td style="background-color:#FFFFFF">
				<%--<asp:Label ID="lblRequireIN" runat="server"></asp:Label>--%>
                &nbsp;
                <input type="radio" name="requireIN" value="1" <%=ckRequire1%> /> Có mang vào (반입필)
				<input type="radio" name="requireIN" value="2" <%=ckRequire2%> /> Không thể mang vào (반입불가)
			<td style="background-color:#F5F5F5">
				Lý do từ chối (불가사유)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisApproveName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Lý do từ chối chi tiết (불가세부사유)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisApproveDetail" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				số xe (차량 번호)
			</td>
			<td style="background-color:#FFFFFF" >
				<asp:Label ID="lblCarNumber" runat="server"></asp:Label></td>
		    <td style="background-color:#F5F5F5">
		        Ghi chú (비고)
		    </td>
		    <td style="background-color:#FFFFFF" colspan="5">
		        <%--<asp:Label ID="lblNote" runat="server"></asp:Label>--%>
                <input type="text" name="txtNote" class="input" value="<%=stNote%>" style="width: 321px" /></td>
	    </tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Người xử lý mang ra (반출 처리자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOutUserName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Thời gian mang ra (반출 시간)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblOutTime" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Người xửu lý mang vào (반입 처리자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblINUserName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Thời gian mang vào (반입 시간)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblINTime" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
	<br />
	<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
		BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
		CellPadding="3" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound" Width="100%">
		<FooterStyle BackColor="White" ForeColor="#000066" />
		<Columns>
			<asp:BoundField DataField="ParentCodeName" HeaderText="Tài sản lớn (대분류)" SortExpression="ParentCodeName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="SubCodeName" HeaderText="Tài sản vừa (중분류)" SortExpression="SubCodeName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutItemName" HeaderText="Tên tài sản (품명)" SortExpression="TakeOutItemName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutItemType" HeaderText="Quy cách (규격)" SortExpression="TakeOutItemType" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Account" HeaderText="Số lượng (수량)" SortExpression="Account" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="UnitName" HeaderText="Đơn vị (단위)" SortExpression="UnitName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
		</Columns>
		<RowStyle ForeColor="#000066" />
		<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
		<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectTakeOutItemDataList"
		TypeName="HanaMicron.COMS.BLL.TakeOutItemData">
		<SelectParameters>
			<asp:QueryStringParameter Name="takeOutDataCode" QueryStringField="takeOutDataCode" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<br />
	<br />
	
	

	<table width="100%" cellpadding="6" cellspacing="1" id="approveBtnTable" style="display:block">
		<tr>
			<td align="center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sửa (수정)" />
				<input type="button" value="Xác nhận (확인)" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
</asp:Content>

