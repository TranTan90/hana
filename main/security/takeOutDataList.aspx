<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="takeOutDataList.aspx.cs" Inherits="main_visit_listVisit" Title="Chi tiết đăng ký 신청 내역" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../../include/Calender/js/jsCalendar.js" type="text/javascript"></script>
<script src="../../include/Calender/js/jsCalendar.datepicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
function confirmDelete(url){
    if (confirm('Không thể khôi phục dữ liệu đã bị xóa. \n\nCó chắc chắn xóa không? (한번 삭제된 데이터는 복구가 불가능합니다.\n\n정말로 삭제하시겠습니까?)')) {
        window.location=url;
    }else{
        return;
    }
}

// 2019-01-17-임종우 : 엔터키면 검색 되도록 수정 Sửa sao cho ấn enter thì tìm kiếm
function enterkey() {
    if (window.event.keyCode == 13) { // 엔터:13        // 엔터 = enter
        searchStart();
    }
}

function searchStart(){
    var f= document.forms[0];
	var dateType=f.dateType.value;
	var startDate=f.searchStartDate.value;
	var endDate=f.searchEndDate.value;
	var keyWord=f.keyWord.value;
	var key=f.key.value;
	var check = f.ckTakeOut.checked;
	var url='';	
	
	url='takeOutDataList.aspx?dateType='+ dateType + '&startDate='+startDate+'&endDate='+endDate + '&keyWord='+ keyWord + '&key='+ key +'&check=' + check ;
	window.location=url; 
}
</script>
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" onkeyup="enterkey()">
<tr>
	<td><!--################################ 타이틀, 현재위치 시작 ################################-->
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>                                                                                                                                                                                 
			<td height="4" colspan="3"></td>
		</tr>
		<tr>
			<td width="26" height="35"><img src="/COMS/images/basic/icon_02.gif" width="25" height="20"></td>
			<td class="contents_title">Phòng bảo an (보안실) > Tài sản ra vào cổng (반출입)</td>
			<td align="right" class="location">HOME &gt;Phòng bảo an (보안실) > Tài sản ra vào cổng (반출입) <asp:Button ID="Button9" runat="server" Text="" BackColor="White" 
                    BorderColor="White" ForeColor="White" Height="16px" Width="0px"  /> <%-- 엔터버튼 클릭시 다음 버튼으로 이동하는 문제로 가짜버튼 만듬.(text 태그와 asp 컨트롤러 동시 사용으로 인해..)--%></td>
		</tr>
		<tr>
			<td colspan="3" class="title_line"></td>
		</tr>
	</table>
	<!--################################ 타이틀, 현재위치 끝 ################################--></td>
</tr>
<tr>
	<td height="10"></td>
</tr>
<tr>
	<td valign="top">			
							
		<table width="100%">
		<tr>
			<td align="right">
                <%--<asp:CheckBox ID="ckTakeOut" runat="server" Text="미반입" />--%>
			    <%--<asp:DropDownList ID="dateType" runat="server">
                    <asp:ListItem>-</asp:ListItem>
                    <asp:ListItem Value="d.takeOutTime">반출일</asp:ListItem>
                    <asp:ListItem Value="d.takeInTime">반입일</asp:ListItem>
                    <asp:ListItem Value="a.scheduleOutDate">반출예정일</asp:ListItem>
                    <asp:ListItem Value="a.scheduleInDate">반입예정일</asp:ListItem>
                    <asp:ListItem Value="a.regDate">등록일</asp:ListItem>
                </asp:DropDownList>--%>
                <input id="ckTakeOut" type="checkbox" />
                Chưa mang vào (미반입)<select name="dateType" align="absmiddle">
                    <option >-</option>
                    <option value="d.takeOutTime">Ngày mang ra (반출일)</option>
                    <option value="d.takeInTime">Ngày mang vào (반입일)</option>
                    <option value="a.scheduleOutDate">Ngày mang ra dự định (반출예정일)</option>
                    <option value="a.scheduleInDate">Ngày mang vào dự định (반입예정일)</option>
                    <option value="a.regDate">Ngày đăng ký (등록일)</option>
                </select>
				<%--<input type="text" size="8" name="searchStartDate" value="<%=Request["startDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchStartDate,'yyyy-mm-dd',-1,-1);" />--%>
				<%--<input type="text" size="8" name="searchEndDate" value="<%=Request["endDate"]%>" /> 
				<img src="../../images/icon/calendar.gif" alt="Chọn ngày (날짜선택)" style="cursor:hand" align="absmiddle"  onclick="popUpCalendar(this, document.forms[0].searchEndDate,'yyyy-mm-dd',-1,-1);" />--%>
                <label>From</label>
				<input type="text" size="8" name="searchStartDate" value="<%=Request["startDate"]%>" data-datepicker data-format="yyyy-MM-DD" /> 
			
			      <label>To</label>
            	<input type="text" size="8" name="searchEndDate" value="<%=Request["endDate"]%>" data-datepicker data-format="yyyy-MM-DD" /> 

                <%-- <label> From</label>
                     <asp:TextBox ID="searchStartDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>
                 <label> To </label>
                     <asp:TextBox ID="searchEndDate" runat="server" data-datepicker data-format="yyyy-MM-DD" style="width : 85px" ></asp:TextBox>--%>
<%--					<asp:DropDownList id="keyWord" runat="server" >
                        <asp:ListItem Value="a.takeOutDataCode">반출번호</asp:ListItem>
                        <asp:ListItem Value="i.dep_name">신청부서</asp:ListItem>
                        <asp:ListItem Value="b.displayName">신청자</asp:ListItem>
                        <asp:ListItem Value="h.companyName">반출처</asp:ListItem>
                    </asp:DropDownList>--%>
                <select name="keyWord" align="absmiddle">
                    <option value="a.takeOutDataCode">Mã tài sản ra (반출번호)</option>
                    <option value="i.dep_name">Bộ phận đăng ký (신청부서)</option>
                    <option value="b.displayName">Người đăng ký (신청자)</option>
                    <option value="h.companyName">Địa điêm (반출처)</option>        // nơi gửi đi
                </select>

                <input type="text" name="key" size="20px" value="<%=Request["key"]%>" />
                <%--<asp:TextBox id="key" runat="server" Width="80px"></asp:TextBox>--%>
                <input id="Button3" type="button" value="Tìm kiếm 검색" onclick="searchStart()" />
				<%--<asp:Button ID="Button2" runat="server" Text="검   색" /> --%>                  
                    <asp:Button ID="Button1" runat="server" Text="Tải xuống (다운로드)" OnClick="Button1_Click" TabIndex="1"/>
					<input type="button" value="In (인쇄)" onclick="window.print()" />
			</td>
		</tr>
		</table>
		<table width="100%">
		<tr>
				<td>
				<asp:GridView ID="GridView1" runat="server" AllowPaging="True"
		CellPadding="3"
		PageSize="50" OnRowDataBound="GridView1_RowDataBound1" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="table table-bordered">
		<FooterStyle BackColor="White" ForeColor="#000066" />
		<Columns>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Mã tài sản ra (반출번호)" SortExpression="TakeOutDataCode" >
				<ItemStyle HorizontalAlign="Center" Width="100px" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang ra (반출일)" >
			    <HeaderStyle HorizontalAlign="Center" />
			    <ItemStyle HorizontalAlign="Center"  Width="100px"/>
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Người đăng ký (신청자)" >
			    <HeaderStyle HorizontalAlign="Center" />
			    <ItemStyle HorizontalAlign="Center"  Width="150px"/>
			</asp:BoundField>
			<asp:BoundField DataField="CompanyName" HeaderText="Địa điểm (반출처)" SortExpression="CompanyName" >
				<ItemStyle HorizontalAlign="Left" Width="250px"/>
			</asp:BoundField>
			<asp:BoundField DataField="RecieveName" HeaderText="Người nhận (수령자)" >
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
			<asp:BoundField DataField="TakeOutObjectName" HeaderText="Mục đích (반출목적)" SortExpression="TakeOutObjectName" >
				<ItemStyle HorizontalAlign="Center" Width="120px"/>
			</asp:BoundField>
			<asp:BoundField DataField="ScheduleOutDate" HeaderText="Ngày dự định mang ra (반출 예정일)" Visible="False" >
			    <HeaderStyle HorizontalAlign="Center" />
			    <ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="ScheduleInDate" HeaderText="Ngày dự định mang vào (반입 예정일)" SortExpression="ScheduleInDate" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutDataCode" HeaderText="Ngày mang vào (반입일)" >
			    <HeaderStyle HorizontalAlign="Center" />
			    <ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
            <asp:BoundField DataField="ApprovalState" HeaderText="Tình trạng (상태)" SortExpression="ApprovalState">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TakeOutDataCode" HeaderText="Xử lý tài sản ra/vào (반출입 처리)" SortExpression="TakeOutDataCode">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
		</Columns>
		<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
		<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
					<RowStyle ForeColor="#000066" />
	</asp:GridView>
					<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectTakeOutDataList" TypeName="HanaMicron.COMS.SQLServerDAL.TakeOutData">
						<SelectParameters>
                            <asp:QueryStringParameter Name="keyWord" QueryStringField="keyWord" Type="String" />
                            <asp:QueryStringParameter Name="key" QueryStringField="key" Type="String" />
                            <asp:QueryStringParameter Name="searchStartDate" QueryStringField="startDate"
                                Type="String" />
                            <asp:QueryStringParameter DefaultValue="" Name="searchEndDate" QueryStringField="endDate"
                                Type="String" />
                            <asp:QueryStringParameter Name="dateType" QueryStringField="dateType" Type="String" />
							<asp:QueryStringParameter Name="requestUserCode" QueryStringField="employeeCode" Type="String" />
                            <asp:Parameter Name="pageType" Type="String" />
                            <asp:QueryStringParameter Name="check" QueryStringField="check" Type="Boolean" />
						</SelectParameters>
					</asp:ObjectDataSource>
				</td>
			</tr>
		</table>
	</td>
	<td width="20" valign="top">&nbsp;</td>
</tr>
</table>
	
</asp:Content>

