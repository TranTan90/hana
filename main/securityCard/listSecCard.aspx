<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listSecCard.aspx.cs" Inherits="main_secCard_listSecCard" Title="Chi tiết đăng ký (신청 내역)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

// 전자 결재 관련 liên quan đến phê duyệt điện tử
var approveServerPath='<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH
var approveServerPort='<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;
	
// 삭제 여부 có xóa hay không 
function confirmDelete(url){
    if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
        window.location=url;
    }else{
        return;
    }
}

// 결재 상태 보기 xem tình trạng phê duyệt
function showApproveStatus(strDoc_code) {
	//strDoc_code 는 doc_code  입니다.
	var strOpt = 'dialogHeight:260px; dialogWidth:608px; leftmargin:30px; marginwidth:30px; dialogTop:'+(screen.height-250)/2+'px; dialogLeft:'+(screen.width-620)/2+'px;   center: yes; help: no; resizable: no; scroll: auto; status: no;';   
	var url = approveServerURL + '/Elec_legacy/Elec_status/Elec_status.asp?doc_code='+strDoc_code;
	strReturn = window.showModalDialog(url, 'Elec_status', strOpt);   
	return;  
}

</script>
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td>
		<!--################################ 타이틀, 현재위치 시작 ################################-->
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td width="26" height="35"><img src="/COMS/images/basic/icon_02.gif" width="25" height="20"></td>
			<td><span class="contents_title">Chi tiết đăng ký quyền hạn ra/ vào (출입권한 신청 내역)</span> (Phải tiến hành phê duyệt tài liệu lưu tạm thời > hoàn thành đăng ký quyền hạn ra/vào (임시저장된 문서는 결재를 진행하여야 출입권한 신청 처리가 가능합니다).)</td>
			<td align="right" class="location">HOME &gt;Chi tiết đăng ký quyền hạn ra/ vào (출입권한 신청 내역)</td>
		</tr>
		<tr>
			<td colspan="3" class="title_line"></td>
		</tr>
		</table>
	</td>
</tr>
<tr>
	<td valign="top">			
							
		<table width="100%">
		<tr>
			<td align="right">
				<asp:TextBox ID="txtStartDate" runat="server" Width="80px"></asp:TextBox>
				<img src="../../images/icon/calendar.gif" alt="chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, <%=txtStartDate.ClientID%>,'yyyy-mm-dd',-1,-1);" />
				<asp:TextBox ID="txtEndDate" runat="server" Width="80px"></asp:TextBox>
				<img src="../../images/icon/calendar.gif" alt="chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, <%=txtEndDate.ClientID%>,'yyyy-mm-dd',-1,-1);" />
					<asp:DropDownList id="txtKeyWord" runat="server">
                        <asp:ListItem Value="requestUserName">Người đăng ký (신청자)</asp:ListItem>
                    </asp:DropDownList><asp:TextBox id="txtKey" runat="server" Width="80px"></asp:TextBox>
				<asp:Button ID="Button2" runat="server" Text="Tìm kiếm 검색" />
                    <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" />
					<input type="button" value="In (인쇄)" onclick="window.print()" />
					<asp:HiddenField id="sisAdmin" runat="server"></asp:HiddenField>
			</td>
		</tr>
		</table>
		<table width="100%">
		<tr>
				<td>
					<asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" DataSourceID="ObjectDataSource1" PageSize="50" EmptyDataText="Không có nội dung đăng ký (등록 된 내용이 없습니다).">
			<FooterStyle BackColor="White" ForeColor="#000066" />
			<RowStyle ForeColor="#000066" />
			<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
			<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
						<Columns>
                            <asp:BoundField DataField="RegDate" HeaderText="Ngày đăng ký (신청일)" SortExpression="RegDate" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Flag" HeaderText="Phân loại mới (신규구분)" SortExpression="Flag">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestDepDesc" HeaderText="Bộ phận đăng ký (신청부서)" SortExpression="RequestDepDesc" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestUserName" HeaderText="Người đăng ký (신청자)" SortExpression="RequestUserName" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoleDesc" HeaderText="Chức vụ (직급)" SortExpression="RoleDesc" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OfficePhone" HeaderText="Liên lạc nội bộ (내선번호)" SortExpression="OfficePhone" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApprovalState" HeaderText="Trạng thái (상태)" SortExpression="ApprovalState" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Sửa (수정)" >
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:BoundField>
							<asp:BoundField HeaderText="Xóa (삭제)" >
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:BoundField>
                            
                            
                            
						</Columns>
					</asp:GridView>
					<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectSecCardDataList" TypeName="HanaMicron.COMS.BLL.SecCardData">
						<SelectParameters>
							<asp:ControlParameter ControlID="txtKeyWord" Name="keyWord" PropertyName="SelectedValue" Type="String" />
							<asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
							<asp:ControlParameter ControlID="txtStartDate" Name="searchStartDate" PropertyName="Text" Type="String" />
							<asp:ControlParameter ControlID="txtEndDate" Name="searchEndDate" PropertyName="Text" Type="String" />
							<asp:SessionParameter Name="upnid" SessionField="loginUpnid" Type="String" />
							<asp:ControlParameter ControlID="sisAdmin" Name="type" PropertyName="Value" Type="String" />
							<asp:Parameter Name="approveUserCode" Type="String" />
                           
						</SelectParameters>
					</asp:ObjectDataSource>
					&nbsp;
				</td>
			</tr>
		</table>
	</td>
</tr>
<!--
<tr>
			<td>
				<strong>상태 도움말</strong><br />
				임시저장 : 결재를 상신하지 않은 상태 입니다.<br />
				결재 상신 중 : 결재를 상신하여 결재 완료를 대기 하는 중입니다.<br />
				승인 : 결재를 완료 후 입문 대기 상태입니다.<br />
				입문 : 내방객이 입문을 하여 출문 대기 중인 상태 입니다.<br />
				출문 : 내방객이 출문 하여 종결된 상태 입니다.<br />
			</td>
		</tr>
-->
</table>
	
</asp:Content>

