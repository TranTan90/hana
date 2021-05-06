<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inputSecCard.aspx.cs" Inherits="main_security_inputSecCard" Title="Đăng ký thẻ bảo an (보안카드 신청)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<script language="javascript" type="text/javascript">
// ajax ready?
var request = false;

try {
	request = new XMLHttpRequest();
} catch (trymicrosoft) {
	try {
		request = new ActiveXObject("Msxml2.XMLHTTP");
	} catch (othermicrosoft) {
		try {
			request = new ActiveXObject("Microsoft.XMLHTTP");
		} catch (failed) {
			request = false;
		}
	}
}
if (!request) alert("Error initializing XMLHttpRequest!");

// 입력 검사 & 결재선 새창    nhập kiểm tra & luồng phê duyệt
function approveChoice(){
	var f=document.forms[0];
	if(checkForm(document.forms[0])){
		f.submit();
	}
}

// 입력 검사  nhập kiểm tra
function checkForm(f){

   	if(!f.<%=inOfficePhone.ClientID%>.value){
		alert('Nhập số điện thoại nội bộ (내선번호를 입력하여 주십시오)');
		f.inOfficePhone.focus();
		return false;
	}
	
	if(!f.<%=comment.ClientID%>.value){
	        alert('Nhập lý do ra/ vào (출입사유를 입력하여 주십시오)');
	        f.<%=comment.ClientID%>.focus();
	        return false;
	}
	
	if(!f.<%=txtStartDate.ClientID%>.value){
	        alert('Chọn ngày bắt đâu (시작일을 선택하여 주십시오)');
	        f.<%=txtStartDate.ClientID%>.focus();
	        return false;
	}
	
	if(!f.<%=txtEndDate.ClientID%>.value){
	        alert('Chọn ngày kết thúc (종료일을 선택하여 주십시오)');
	        f.<%=txtEndDate.ClientID%>.focus();
	        return false;
	}
	
	if(f.gubunFlag[0].checked==false && f.gubunFlag[1].checked==false){
			alert('Đăng ký mới hoặc chọn thay đổi (신규등록 or 변경을 선택하여 주십시오).');
			 return false;		
		}
	
	return true;
	
}

</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td style="width: 1466px"><!--################################ 타이틀, 현재위치 시작 ################################-->
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td height="4" colspan="3"></td>
		</tr>
		<tr>
			<td width="26" height="35"><img
				src="/COMS/images/basic/icon_02.gif" width="25" height="20"></td>
			<td class="contents_title">Đăng ký quyền hạn ra vào (출입권한 신청)</td>
			<td align="right" class="location">HOME &gt;Đăng ký quyền hạn ra vào (출입권한 신청)</td>
		</tr>
		<tr>
			<td colspan="3" class="title_line"></td>
		</tr>
	</table>
	<!--################################ 타이틀, 현재위치 끝 ################################--></td>

     <%-- chỉnh sửa giao diện cho chữ tiếng hàn xuống dòng
        phạm thị thu hiền 29/01/2021
    --%>
</tr>
<tr>
	<td height="10" style="width: 1466px"></td>
</tr>
<tr>
	<td valign="top" style="width: 1466px">
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="title" style="background-color:#FFFFFF">Thông tin người đăng ký (신청자정보)</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Bộ phận<br />(부서명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				ID<br />(사번)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblUpnid" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi làm việc<br />(사업장)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Tên<br />(성명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisplayName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Chức vụ<br />(직급)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTitle" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Liên lạc<br />(연락처)
			</td>
			<td style="background-color:#FFFFFF">
			    <asp:TextBox ID="inOfficePhone" runat="server" CssClass="input" Width="108px"></asp:TextBox>
			    
			</td>
		</tr>
	</table>
	<br>
	<table width="100%" cellpadding="3" cellspacing="1" border="0" style="background-color:#CCCCCC">
        <tr>
            <td style="background-color:#F5F5F5; width: 152px;" colspan='2'>
            <input type="radio" name="gubunFlag" value="1" onclick="javascript:change()" <%=ckRequire1%>/>Đăng ký mới (신규등록)
            <input type="radio" name="gubunFlag" value="2" onclick="javascript:change()" <%=ckRequire2%>/>Thay đổi (변경)
            
            </td>
	    </tr>
		<tr>
			<td style="background-color:#F5F5F5; height: 101px; width: 152px;">
                Lý do ra cổng<br />(출입 사유)</td>
            <td cellpadding="2" style="background-color:#FFFFFF; height: 101px; width: 1464px;">
                &nbsp;<asp:TextBox ID="comment" runat="server" Height="73px" Width="1406px" TextMode="MultiLine"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5;" width="100" id="longVisitDate1">
				Thời hạn<br />(기간)&nbsp;</td>
			<td style="background-color:#FFFFFF; width: 1464px;" id="longVisitDate2">
                &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="input" Width="70px"></asp:TextBox>
				<img src= "../../images/icon/calendar.gif" alt="Chọn lịch (달력 선택)" align="absmiddle" style="cursor:hand" onclick='popUpCalendar(this, <%=txtStartDate.ClientID%>, "yyyy-mm-dd",500,200,true);' />
                ~
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="input" Width="70px"></asp:TextBox>
				<img src= "../../images/icon/calendar.gif" alt="Chọn lịch (달력 선택)" align="absmiddle" style="cursor:hand" onclick='popUpCalendar(this, <%=txtEndDate.ClientID%>, "yyyy-mm-dd",500,200,true);' /></td>
		</tr>
	</table>

<%--	<input type="hidden" name="approvalUserCode" />--%>
    <input type="hidden" name="elecApproveCode" value="<%=approveDocCode%>" />
	<input type="hidden" name="parentTakeOutItemCategoryCodes" />
	<input type="hidden" name="subTakeOutItemCategoryCodes" />
	<input type="hidden" name="takeOutItemNames" />
	<input type="hidden" name="takeOutItemNameTypes" />
	<input type="hidden" name="takeOutItemAccounts" />
	<input type="hidden" name="takeOutUnits" />
	<input type="hidden" name="gubunhiddenflag" />
	<asp:HiddenField id="hiddenflag" runat="server"></asp:HiddenField>
	
	<table width="100%">
		<tr><td align="center">
			<img src="../../images/icon/write.gif" style="cursor:hand" onclick="approveChoice()" alt="Đăng ký (등록하기)" />
			<img src="../../images/icon/cancel.gif" style="cursor:hand" onclick="history.go(-1)" alt="Hủy (취소하기)" /></td></tr>
	</table>
	
	</td>
	<td width="20" valign="top">&nbsp;</td>
</tr>
</table>

<script language="javascript" type="text/javascript">
function change(){
    
    if(document.forms[0].gubunFlag[0].checked==true)
    {
        document.forms[0].<%=hiddenflag.ClientID%>.value = "1";
    }
    else if(document.forms[0].gubunFlag[1].checked==true)
    {
        document.forms[0].<%=hiddenflag.ClientID%>.value = "2";
    }
}
change();
</script>
</asp:Content>