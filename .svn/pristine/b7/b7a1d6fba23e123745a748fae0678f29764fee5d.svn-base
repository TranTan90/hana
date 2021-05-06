<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewSecCardManager.aspx.cs" Inherits="main_secCard_viewSecCard" Title="Xem chi tiết (상세 보기)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script id="approveLine"></script>
<script language="javascript">

// 전자 결재 관련 liên quan đến phê duyệt điện tử
var approveServerPath='<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH
var approveServerPort='<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT
var formCode='<%=ConfigurationManager.AppSettings["elecApproveFormCode"]%>'; // 전자결재 form code

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;

//SelectAllLine
// 지정된 결재 라인 보여주기
// hananet 의 전자결재의 외부Interface Javascript 를 활용한다.
// <label id="strDeci"></label>
// <label id="strRef"></label>
// 이 필수로 존재해야 하며 doc_code 를 넘겨주어야 한다.
function showApproveLine(strReturn){
	strCon = strReturn.substring(0,strReturn.indexOf(";"));
	strRef = strReturn.substring(strReturn.indexOf(";")+1,strReturn.length);
	document.getElementById('lbCon').innerText = strCon;
	document.getElementById('lbRef').innerText = strRef;
	if(strReturn.length > 1)  document.getElementById("approveLineRow").style.display='block';
}

// 결재 상태 보기  xem tình trạng phê duyệt
function showApproveStatus(strDoc_code) {
	var strOpt = 'dialogHeight:225px; dialogWidth:848px; leftmargin:0px; marginwidth:0px; dialogTop:'+(screen.height-180)/2+'px; dialogLeft:'+(screen.width-620)/2+'px;   center: yes; help: no; resizable: no; scroll: auto; status: no;';
	var url = '../../elecApprove/ElecApproveStatus.aspx?doc_code='+strDoc_code;
	strReturn = window.showModalDialog(url, 'Elec_status', strOpt);
	return;
}

// 결재라인 선택 새창열기 
function approveSelect(){
	var f=document.forms[0];
	
	var approveServerURL; // 서버 URL
	var approveDocCode=f.elecApproveCode.value; // 문서 코드
	
	// 전자결재 경로 Lộ trình phê duyệt điện tử
	if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
	else approveServerURL=approveServerPath;
	
	var url="/COMS/elecApprove/ElecLine.aspx?docCode="+approveDocCode+"&formCode="+formCode+"&actType=new&employeeCode=<%=loginEmployeeUpnid%>&employeeTitleName=<%=loginEmployeeTitle%>&employeeDepartName=<%=loginEmploeeDepartmentName%>";
	var strOpt = 'dialogHeight:510px;dialogWidth:650px;leftmargin:30px;marginwidth:30px;dialogTop:'+(screen.height-420)/2+'px; dialogLeft:'+(screen.width-675)/2+'px; center: yes; help: no; resizable: no; scroll: no; status: no;';  // ModalDialog 창 크기 및 특징 지정
	
	strReturn=window.showModalDialog(url, 'line_asign', strOpt);
	
	if(strReturn != null) showApproveLine(strReturn);
}

// 상신 문의 
function confirmSave(){
    var checkString = document.getElementById("lbCon").innerHTML;

	if(document.getElementById("lbCon").innerHTML.length < 1){
		alert('[Thông báo] Hãy đăng ký thông tin phê duyệt ([알림]결재정보를 등록하여 주십시오)');
		return false;
	}else{
    if (confirm('[Thông báo] Khi đã gửi phê không thể thu hồi lại. Hãy quyết định thận trọng. [Gửi phê duyệt?] ([알림] 한번 상신된 결재는 되돌릴 수 없습니다.\n신중하게 결정하여 주십시오\n\n[결재를 상신하시겠습니까?])')) {
			document.forms[0].action='../../elecApprove/ElecApproveSend.aspx?elecApproveType=secCard';
			document.forms[0].submit();
		}
	}
}

// 결재 라인 가져오기
function ElecLineSelectAll(docCode){
	document.getElementById('smartClient').ElecLineSelectAll(docCode);
}

</script>
<script event="SelectAllLine(approveLine)" for="smartClient">
	showApproveLine(approveLine);
</script>

<object id="smartClient" classid="../../elecApprove/ElecApprove.dll#ElecApprove.ElecLineSelect" width="0px" height="0px">
<param name="ParamElecDocCode" value="<%=elecApproveCode%>" />

</object>
	
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td><!--################################ 타이틀, 현재위치 시작 ################################-->
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td height="4" colspan="3"></td>
		</tr>
		<tr>
			<td width="26" height="35"><img
				src="/COMS/images/basic/icon_02.gif" width="25" height="20"></td>
			<td class="contents_title">Xem chi tiết đăng ký quyền hạn ra/ vào (출입권한 신청 내역 상세보기)</td>
			<td align="right" class="location">HOME &gt;Xem chi tiết đăng ký quyền hạn ra/ vào (출입권한 신청 내역 상세보기)</td>
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
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin đăng ký (신청자정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5" width="150">
				Bộ phận (부서명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				ID (사 번)
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
				chức vụ (직급)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTitle" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Liên lạc (연락처)
			</td>
			<td style="background-color:#FFFFFF">
			    <asp:Label ID="lblOfficePhone" runat="server"></asp:Label>
		    </td>
		</tr>
	</table>
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" border="0" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin phê duyệt (결재정보)
			</td>
		</tr>
		
		<tr>
			<td style="background-color:#F5F5F5;" width="150">
				Tiêu đề (기안제목)
			</td>
			<td style="background-color:#FFFFFF;">
				[Đơn đăng ký thẻ(card leader) ra/ vào (출입(카드리더기) 등록 신청서)]<%=reqEmploeeDisplayName%>
			</td>
			<td style="background-color:#F5F5F5;">
				Mức độ bảo an (보안등급(Thời hạn lưu trữ 보존년한))
			</td>
			<td style="background-color:#FFFFFF;">
				대내비(1 năm 1년)</td>
		</tr>
		<tr id="approveLineRow" style="display:none">
			<td style="background-color:#F5F5F5" width="15%">
				Luồng phê duyệt (결재선)
			</td>
			<td style="background-color:#FFFFFF" width="35%">
				<label id="lbCon"></label>
			</td>
			<td style="background-color:#F5F5F5" width="15%">
				Thông báo (통보자)
			</td>
			<td style="background-color:#FFFFFF" width="35%">
				<label id="lbRef"></label>
			</td>
		</tr>
	</table>
	<br />
	
	<table width="100%" cellpadding="6" cellspacing="1" border="0">
		<tr>
			<td bgcolor="#FFFFFF" align="center">
				<input type="button" value="Xem tình trạng phê duyệt (결재상태 보기)" style="cursor:hand" onclick="showApproveStatus(document.forms[0].elecApproveCode.value)" runat="server" id="btnElectStatus" />
				<input type="button" value="Chỉ định phê duyệt (결재지정)" style="cursor:hand" onclick="approveSelect()" runat="server" id="btnElecApproveLine"/>
				<input type="button" value="Gửi phê duyệt (결재상신)" onClick="confirmSave()" id="btnApproveStart" runat="server"/>
				<input type="button" value="Quay lại (돌아가기)" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
	<input type="hidden" name="elecApproveCode" value="<%=elecApproveCode%>" />
	<input type="hidden" name="secCardDataCode" value="<%=Request["secCardDataCode"]%>" />
	<br />
	
	<table width="100%" border="0" style="background-color:#CCCCCC">
		<tr>
			<td colspan="2" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin đăng ký thẻ bảo an (보안카드 신청 정보)
			</td>
		</tr>
		 <tr>
            <td style="background-color:#F5F5F5; width: 152px;" colspan='2'>
                <asp:RadioButton ID="rbNew" runat="server" GroupName="rbGroup" Text="Đăng ký mới (신규등록)" />
                <asp:RadioButton ID="rbChange" runat="server" GroupName="rbGroup" Text="Thay đổi (변경)" /></td>
	    </tr>
		<tr>
			<td style="background-color:#F5F5F5; height: 101px; width: 152px;">
                Lý do ra/ vào (출입 사유)</td>
            <td style="background-color:#FFFFFF; height: 101px; width: 1464px;">
                &nbsp;<asp:TextBox ID="comment" runat="server" Height="73px" Width="1406px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5;" width="100" >
				Thời hạn (기간)&nbsp;</td>
			<td style="background-color:#FFFFFF; width: 1464px;">
                &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="input" Width="70px" ReadOnly="True"></asp:TextBox>
			    ~
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="input" Width="70px" ReadOnly="True"></asp:TextBox>
			</td>
		</tr>
	</table>
	</td>
	<td width="20" valign="top">&nbsp;</td>
</tr>
</table>
<br />
<strong>
▶ Lộ trình phê duyệt: đăng ký (kế hoặch) → Trưởng bộ phận của người đăng ký (Phê duyệt) → Quản lý bộ phận của khu vực bảo an (Thảo luận) → Phòng hành chính: bộ phận bảo an (Thông báo)<br />
Tôi đã nhận được giấy phép ra vào, Sẽ thực hiện nội dung sau và lập bản cảm kết<br />
1. Không cho mượn hoặc sử dụng thẻ nhân viên của người khác ra vào công ty.<br />
2. Báo cho bộ phận Hành Chính để yêu cầu hủy đăng ký ra vào trong trường hợp không cần vào khu vực đó do chuyển bộ phận hoặc thay đổi công việc phụ trách<br />
3. Không làm rò rỉ hoặc tiết lộ bí mật kinh doanh, quyền sở hữu trí tuệ hay các hạng mục bảo an khác ra bên ngoài<br />
4. Không được chụp ảnh trong khu vực kiểm tra, trường hợp cần chụp ảnh trong công việc phải được sự đồng ý của trưởng phòng Hành Chính <br />
Cam kết hiểu và tuân thủ đầy đủ những nội dung ở trên. Nếu thực hiện sai và gây tổn hại đến công ty sẽ bồi thường thiệt hại và chịu trách nhiệm hình sự, dân sự. <br />
<br />
▶ 결재경로 : 등록 신청자(입안) → 신청자 부서 팀장 or 파트장(결재) → 출입지역 관리부서 팀장 or 파트장(합의) → 총무팀 보안담당자(통보)
<br />
     
     상기 본인은 출입허가를 득함에 있어서 다음 사항을 이행하기로 하고 서약서를 작성합니다.
<br />
     1. 자신의 사원증(출입증)을 타인에게 대여, 양도하거나 타인의 사원증을 사용하여 출입하지 않는다.
<br />
     2. 부서이동 또는 담당업무 변경으로 해당 구역에 대한 출입이 불필요한 경우 보안담당자 에게 연락하여, 출입등록 취소를 요청한다.
<br />
     3. 보안사항, 영업비밀 및 기타 지적재산권 등을 업무와 무관하게 외부로 유출 하거나, 유출 가능성이 있는 일체의 행위를 하지 않는다.
<br />
     4. 통제구역 내 사진촬영은 할 수 없으며, 업무상 사진촬영이 필요할 경우 총무부서의 허가를 득해야 한다.
<br />
    상기 사항을 충분히 이해하고 준수할 것이며, 만일 이를 이행치 않아 회사에 손해를 입힌
    경우 즉각적인 손해배상은 물론, 모든 민.형사상의 책임을 질 것을 任意 서약합니다.
</strong>

<script language="javascript" type="text/javascript">
function completeLoad(){
	if(document.readyState=='complete'){
		ElecLineSelectAll('<%=elecApproveCode%>');
		clearTimeout(loadScript);
	}else{
		loadScript=setTimeout('completeLoad()', 100); 
	}
}

completeLoad();

</script>

</asp:Content>