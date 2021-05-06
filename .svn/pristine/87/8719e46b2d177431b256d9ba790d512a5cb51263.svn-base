<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="takeOutDataList.aspx.cs" Inherits="main_visit_listVisit" Title="Chi tiết đăng ký (신청 내역)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../../include/Calender/js/jsCalendar.js" type="text/javascript"></script>
<script src="../../include/Calender/js/jsCalendar.datepicker.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function confirmDelete(url) {
        if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
            window.location = url;
        } else {
            return;
        }
    }
</script>
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td valign="top" style="height: 1403px">			
							
		<table width="100%">
		<tr>
			<td align="right">
                <asp:CheckBox ID="ckTakeOut" runat="server" Text="Chưa mang vào 미반입" />
				<asp:DropDownList ID="dateType" runat="server">
                    <asp:ListItem>-</asp:ListItem>
                    <asp:ListItem Value="d.takeOutTime">Ngày mang ra (반출일)</asp:ListItem>
                    <asp:ListItem Value="d.takeInTime">Ngày mang vào (반입일)</asp:ListItem>
                    <asp:ListItem Value="a.scheduleOutDate">Ngày mang ra dự định (반출예정일)</asp:ListItem>
                    <asp:ListItem Value="a.scheduleInDate">Ngày mang vào dự định (반입예정일)</asp:ListItem>
                    <asp:ListItem Value="a.regDate">Ngày đăng ký (등록일)</asp:ListItem>
                </asp:DropDownList>
                <label> From </label>
                     <asp:TextBox ID="searchStartDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>
                <label> To </label>
                     <asp:TextBox ID="searchEndDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>
				<%--<input type="text" size="8" name="searchStartDate" value="<%=Request["searchStartDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchStartDate,'yyyy-mm-dd',-1,-1);" />
				<input type="text" size="8" name="searchEndDate" value="<%=Request["searchEndDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Lựa chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchEndDate,'yyyy-mm-dd',-1,-1);" />--%>
					<asp:DropDownList id="keyWord" runat="server">
                        <asp:ListItem Value="a.takeOutDataCode">Mã tài sản ra cổng (반출번호)</asp:ListItem>
                        <asp:ListItem Value="i.dep_name">Bộ phận đăng ký (신청부서)</asp:ListItem>
                        <asp:ListItem Value="b.displayName">Người đăng ký (신청자)</asp:ListItem>
                        <asp:ListItem Value="h.companyName">Nơi nhận (반출처)</asp:ListItem>
                    </asp:DropDownList><asp:TextBox id="key" runat="server" Width="80px"></asp:TextBox>
                <asp:DropDownList ID="cboPurpose" runat="server" AutoPostBack="True"
                    Width="120px">
                </asp:DropDownList>
				<asp:Button ID="Button2" runat="server" Text="Tìm kiếm 검색" />
                    <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
					<input type="button" value="In (인쇄)" onclick="window.print()" />
			</td>
		</tr>
		</table>
		<table width="100%">
		<tr>
				<td style ="text-align:center">
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True"
		CellPadding="4"
		PageSize="50" OnRowDataBound="GridView1_RowDataBound1" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" EmptyDataText="Nội dung đăng ký không có (등록 된 내용이 없습니다).">
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<Columns>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Mã tài sản ra cổng (반출번호)" SortExpression="TakeOutDataCode" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang ra (반출일)" >
			    <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Người đăng ký (신청자)" >
			    <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="CompanyName" HeaderText="Nơi nhận<br/>(반출처)" SortExpression="CompanyName" >
			    <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
            <asp:BoundField DataField="RecieveName" HeaderText="Người nhận (수령자)">
                <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="RequireIN" HeaderText="Có mang vào hay không (반입여부)" SortExpression="RequireIN" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Hạng mục mang ra (반출항목)" >
                <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutObjectName" HeaderText="Mục đích mang ra (반출목적)" SortExpression="TakeOutObjectName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="ScheduleOutDate" HeaderText="Ngày mang ra dự định<br/>(반출 예정일)">
                <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="ScheduleInDate" HeaderText="Ngày mang vào dự định (반입 예정일)" SortExpression="ScheduleInDate" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang vào (반입일)" >                        
                <HeaderStyle HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:HyperLinkField HeaderText="Tình trạng<br/>(상태)">
				<ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
			</asp:HyperLinkField>
		</Columns>
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
					<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectTakeOutDataList" TypeName="HanaMicron.COMS.SQLServerDAL.TakeOutData">
						<SelectParameters>
							<asp:ControlParameter ControlID="keyWord" Name="keyWord" PropertyName="SelectedValue" Type="String" />
							<asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
							<asp:FormParameter FormField="searchStartDate" Name="searchStartDate" Type="String" />
							<asp:FormParameter DefaultValue="" FormField="searchEndDate" Name="searchEndDate" Type="String" />
                            <asp:ControlParameter ControlID="dateType" Name="dateType" PropertyName="SelectedValue"
                                Type="String" />
							<asp:Parameter Name="requestUserCode" Type="String" />
                            <asp:Parameter Name="pageType" Type="String" />
                            <asp:ControlParameter ControlID="ckTakeOut" Name="check" PropertyName="Checked" Type="Boolean" />
                            <asp:ControlParameter ControlID="cboPurpose" Name="visitPurpose" PropertyName="SelectedValue"
                                Type="String" />
						</SelectParameters>
					</asp:ObjectDataSource>
				</td>
			</tr>
		</table>
        <asp:GridView ID="GridViewExcel" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
            Visible="False" OnRowDataBound="GridViewExcel_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Mã tài sản ra cổng (반출번호)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang ra (반출일)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Người đăng ký (신청자)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="RequestUserDepartment" HeaderText="Bộ phận mang ra (반출부서)" SortExpression="RequestUserDepartment" />
                <asp:BoundField DataField="RequestUserDisplayName" HeaderText="Người mang ra (반출자)" SortExpression="RequestUserDisplayName" />
                <asp:BoundField DataField="RequestUserTitleName" HeaderText="Chức vụ (반출자 직급)" SortExpression="RequestUserTitleName" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Tài sản lớn (대분류)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Tài sản vừa (중분류)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Tên tài sản (품명)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Quy cách (규격/Serial No)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Số lượng (수량)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Đơn vị (단위)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutObjectName" HeaderText="Mục đích (반출목적)" SortExpression="TakeOutObjectName" />
                <asp:BoundField DataField="ObjectContents" HeaderText="Mục đích chi tiết (반출세부목적)" SortExpression="ObjectContents" />
                <asp:BoundField DataField="CompanyName" HeaderText="Nơi nhận (반출처" SortExpression="CompanyName" />
                <asp:BoundField DataField="RecieveName" HeaderText="Người nhận (수령자" SortExpression="RecieveName" />
                <asp:BoundField DataField="RequireIN" HeaderText="Có mang vào hay không (반입여부" SortExpression="RequireIN" />
                <asp:BoundField DataField="ScheduleOutDate" HeaderText="Ngày mang ra dự định (반출예정일)" SortExpression="ScheduleOutDate" />
                <asp:BoundField DataField="ScheduleInDate" HeaderText="Ngày mang vào dự định (반입예정일)" SortExpression="ScheduleInDate" />
                <asp:BoundField DataField="CarNumber" HeaderText="Số xe (차량번호)" SortExpression="CarNumber" />
                <asp:BoundField DataField="ApproveTime" HeaderText="Thời gian phê duyệt (결재시간)" SortExpression="ApproveTime" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Người xử lý (반출처리자)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutPathStartName" HeaderText="Nơi bắt đầu mang đi (반출시작지)" SortExpression="TakeOutPathStartName" />
                <asp:BoundField DataField="DisApprovalCategoryName" HeaderText="Không thể mang vào (반입불가명)" SortExpression="DisApprovalCategoryName" />
                <asp:BoundField DataField="DisApprovalCategoryDetail" HeaderText="Chi tiết lý do (반입불가세부사유)" SortExpression="DisApprovalCategoryDetail" />
                <asp:BoundField DataField="RequestUserOfficeName" HeaderText="Nơi làm việc (사업장)" SortExpression="RequestUserOfficeName" />
                <asp:BoundField DataField="TakeOutPathEndName" HeaderText="Mục đích mang ra (반출목적지)" SortExpression="TakeOutPathEndName" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Thời gian mang vào (반입시간)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Tình trạng (상태)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="TakeOutDataCode" HeaderText="Người xử lý 반입처리자)" SortExpression="TakeOutDataCode" />
                <asp:BoundField DataField="RegDate" HeaderText="Ngày đăng ký (등록일)" SortExpression="RegDate" />
            </Columns>
        </asp:GridView>
	</td>
	<td valign="top" style="height: 1403px">&nbsp;</td>
</tr>
</table>
	
</asp:Content>

