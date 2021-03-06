<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="viewVisitManager.aspx.cs" Inherits="main_visit_viewVisit" Title="xem chi tiết (상세 보기)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script id="approveLine"></script>
    <script language="javascript">

// 전자 결재 관련 quản lý phê duyệt điện  tử
var approveServerPath='<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH
var approveServerPort='<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT
var formCode='<%=ConfigurationManager.AppSettings["elecApproveFormCode"]%>'; // 전자결재 form code

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;

//SelectAllLine
// 지정된 결재 라인 보여주기  // xem đường phê duyệt được chỉ định
// hananet 의 전자결재의 외부Interface Javascript 를 활용한다. // ứng dụng Interface Javascript để phê duyệt điện tử bên ngoài của hananet
// <label id="strDeci"></label>
// <label id="strRef"></label>
// 이 필수로 존재해야 하며 doc_code 를 넘겨주어야 한다.
function showApproveLine(strReturn){
	strCon = strReturn.substring(0,strReturn.indexOf(";"));
	strRef = strReturn.substring(strReturn.indexOf(";")+1,strReturn.length);
	
	document.getElementById('lbCon').innerText = strCon;
	document.getElementById('lbRef').innerText = strRef;
	
	//alert(strReturn);
	if(strReturn.length > 1)  document.getElementById("approveLineRow").style.display='block';
}

// 결재 상태 보기 xem trạng thái phê duyệt
function showApproveStatus(strDoc_code) {
	//strDoc_code 는 doc_code  입니다.
////	var strOpt = 'dialogHeight:260px; dialogWidth:608px; leftmargin:30px; marginwidth:30px; dialogTop:'+(screen.height-250)/2+'px; dialogLeft:'+(screen.width-620)/2+'px;   center: yes; help: no; resizable: no; scroll: auto; status: no;';   
////	var url = approveServerURL + '/Elec_legacy/Elec_status/Elec_status.asp?doc_code='+strDoc_code;
////	strReturn = window.showModalDialog(url, 'Elec_status', strOpt);
	var strOpt = 'dialogHeight:225px; dialogWidth:848px; leftmargin:0px; marginwidth:0px; dialogTop:'+(screen.height-180)/2+'px; dialogLeft:'+(screen.width-620)/2+'px;   center: yes; help: no; resizable: no; scroll: auto; status: no;';
	var url = '../../elecApprove/ElecApproveStatus.aspx?doc_code='+strDoc_code;
	strReturn = window.showModalDialog(url, 'Elec_status', strOpt);
	return;
}
function callGw(){
  alert("TEST");
}

// 결재상신 선택 새창열기  gửi phê duyệt
function approveSelect(){
	var f=document.forms[0];
	var approveDocCode=f.elecApproveCode.value; // 문서 코드
	var visit=<%=visit%>;
	if(visit==1){
	alert('[Thông báo]Trường hợp đăng ký khách thăm dài hạn phải thảo luận với bộ phận Hành Chính ([알림]장기내방신청의 경우 총무그룹(박민수 과장)의 합의를 득해야 합니다).');
	}
	
    // 2019-07-12-임종우 : 장기내방 양식변경으로 URL 수정 Sửa URL bằng cách thay đổi kiểu cách đăng ký dài hạn
	  var url ="http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=IF_VISIT_V2_F001&TABLE_KEY="+approveDocCode;
    //var url ="http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=IF_VISIT_NEW_001&TABLE_KEY="+approveDocCode;
    //var url ="http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=MCR_IF_VS0001&TABLE_KEY="+approveDocCode;
    //var url ="http://hananet.hanamicron.co.kr/ekp/user.do?cmd=goEappWrite&EMP_CODE=<%=loginEmployeeUpnid%>&CMP_ID=C100120730&ELEC_APP_CODE="+approveDocCode+"&FORM_ID=EF134551455158421";
	//var strOpt = 'dialogHeight:510px;dialogWidth:650px;leftmargin:30px;marginwidth:30px;dialogTop:'+(screen.height-420)/2+'px; dialogLeft:'+(screen.width-675)/2+'px; center: yes; help: no; resizable: no; scrollbars: yes; status: no;';  // ModalDialog 창 크기 및 특징 지정    
    //window.open(url,'elec_app', strOpt);
    //window.open(url,'elec_app', 'scrollbars=yes');
    window.open(url,'elec_app', 'scrollbars=yes, width=1024, height=768');

    //window.location='/COMS/main/visit/listVisit.aspx';
 
}

// 김민우 - 전자결재 방식 변경으로 사용 안함 Không sử dụng thay đổi cách thức phê duyệt điện tử
// 상신 문의 Hỏi ý kiến
function confirmSave(){
    var visit=<%=visit%>;
    var checkString = document.getElementById("lbCon").innerHTML;

	if(document.getElementById("lbCon").innerHTML.length < 1){
		alert('[Thông báo] Hãy đăng ký thông tin phê duyệt ([알림]결재정보를 등록하여 주십시오)');
		return false;
	}else if(visit==1&&checkString.indexOf("[합]이규형(차장)") < 0){
	    alert('[Thông báo] Trường hợp đănh ký khách thăm dài hạn phải thảo luận với bộ phận Hành Chính ([알림]장기내방신청의 경우 총무그룹(박민수 과장)의 합의를 득해야 합니다).');
	    return false;	
	}else{
		// 2011-09-21 김민우 : 결재 상신 후 뒤로가기 버튼 클릭 시 상신 정보 사라지는 버그 수정(새창을 호출함)  // Sau khi gửi phê duyệt, click nút ấn chuyển tiếp
		if(confirm('[Thông báo] Khi đã gửi phê duyệt thì không thể thu hồi được. \nHãy quyết định thận trọng\n\n[Có chắc chắn gửi phê duyệt không?] ([알림]한번 상신된 결재는 되돌릴 수 없습니다.\n신중하게 결정하여 주십시오\n\n[결재를 상신하시겠습니까?])')){
			document.forms[0].action='../../elecApprove/ElecApproveSend.aspx?elecApproveType=visit';
			//window.open("_blank","approve","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizeable=no,width=1,height=1,top=0,left=1000000");
			//document.forms[0].target='approve';
			document.forms[0].submit();
			// if visit or takeOut location
			//window.location.href = '/COMS/main/visit/listVisit.aspx';
		}
	}
}

// 결재 라인 가져오기 mang theo đường phê duyệt
function ElecLineSelectAll(docCode){
	document.getElementById('smartClient').ElecLineSelectAll(docCode);
}

function longvisitdisplay(){
    var f=document.forms[0];
    var visit=<%=visit%>;
    var longVisit=document.getElementById("longVisit");
    
    if(visit==1){
        longVisit.style.display="table-row;";
    }else{
        longVisit.style.display="none";
    }    
}
    </script>
    <script event="SelectAllLine(approveLine)" for="smartClient">
	showApproveLine(approveLine);
<<<<<<< .mine
    </script>
    <object id="smartClient" classid="../../elecApprove/ElecApprove.dll#ElecApprove.ElecLineSelect"
        width="0px" height="0px">
        <param name="ParamElecDocCode" value="<%=elecApproveCode%>" />
    </object>
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
                            Xem chi tiết đăng ký 신청 (내역 상세보기)
                        </td>
                        <td align="right" class="location">
                            HOME &gt;Xem chi tiết đăng ký (신청 내역 상세보기)
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
                <table width="100%" cellpadding="6" cellspacing="1" style="background-color: #CCCCCC"
                    class="table table-bordered">
                    <tr>
                        <td colspan="6" class="contents_title" style="background-color: #FFFFFF">
                            <img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align: middle">Thông
                            tin người đăng ký 신청자정보
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5" width="150">
                            Bộ phận (부서명)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            ID (사번)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblUpnid" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            Nơi làm việc (사업장)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblOfficeName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5">
                            Tên (성명)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            Chức vụ (직급)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            Liên lạc (연락처)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" cellpadding="6" cellspacing="1" border="0" style="background-color: #CCCCCC"
                    class="table table-bordered">
                    <tr>
                        <td colspan="6" class="contents_title" style="background-color: #FFFFFF">
                            <img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align: middle">Thông
                            tin phê duyệt (결재정보)
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5;" width="150">
                            Tiêu đề dự thảo (기안제목)
                        </td>
                        <td style="background-color: #FFFFFF;">
                            <%=title%><%=reqEmploeeDisplayName%>
                        </td>
                        <td style="background-color: #F5F5F5;">
                            Mức bảo an [Thời hạn lưu trữ] (보안등급 [보존년한])
                        </td>
                        <td style="background-color: #FFFFFF;">
                            대내비(1 năm 1년)
                        </td>
                    </tr>
                    <tr id="approveLineRow" style="display: none">
                        <td style="background-color: #F5F5F5" width="15%">
                            Luồng phê duyệt (결재선)
                        </td>
                        <td style="background-color: #FFFFFF" width="35%">
                            <label id="lbCon">
                            </label>
                        </td>
                        <td style="background-color: #F5F5F5" width="15%">
                            Người thông báo (통보자)
                        </td>
                        <td style="background-color: #FFFFFF" width="35%">
                            <label id="lbRef">
                            </label>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" cellpadding="6" cellspacing="1" border="0">
                    <tr>
                        <td bgcolor="#FFFFFF" align="center">
                            <input type="button" value="Xem trạng thái phê duyệt (결재상태 보기)" style="cursor: hand"
                                onclick="showApproveStatus(document.forms[0].elecApproveCode.value)" runat="server"
                                id="btnElectStatus" />
                            <input type="button" value="Gửi phê duyệt (결재상신)" style="cursor: hand" onclick="approveSelect()"
                                runat="server" id="btnElecApproveLine" />
                            <!--<input type="button" value="Gửi phê duyệt 결재상신" onClick="confirmSave()" id="btnApproveStart" runat="server"/>-->
                            <input type="button" value="Quay lại (돌아가기)" onclick="history.go(-1)" />
                        </td>
                    </tr>
                </table>
                <input type="hidden" name="elecApproveCode" value="<%=elecApproveCode%>" />
                <input type="hidden" name="visitDataCode" value="<%=Request["visitDataCode"]%>" />
                <br />
                <table width="100%" cellpadding="6" cellspacing="1" style="background-color: #CCCCCC"
                    class="table table-bordered">
                    <tr>
                        <td colspan="4" class="contents_title" style="background-color: #FFFFFF">
                            <img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align: middle">Thông
                            tin khách thăm (내방 정보)
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5" width="150">
                            Mục đích thăm (방문 목적)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblVisitObjectName" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            Mục đích chi tiết (세부 목적)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblVisitObjectContents" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5">
                            Người cần gặp (접견자)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblInterviewUserName" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #F5F5F5">
                            Nơi gặp (접견장소)
                        </td>
                        <td style="background-color: #FFFFFF">
                            <asp:Label ID="lblOfficeNameDetail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #F5F5F5">
                            Số xe (차량 번호)
                        </td>
                        <td style="background-color: #FFFFFF" colspan="3">
                            <asp:Label ID="lblCarNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlSecurity" runat="server">
                        <tr>
                            <td style="background-color: #F5F5F5">
                                Thời gian vào (입문시간)
                            </td>
                            <td style="background-color: #FFFFFF">
                                <asp:Label ID="lblInTime" runat="server"></asp:Label>
                            </td>
                            <td style="background-color: #F5F5F5">
                                Thời gian ra (출문시간)
                            </td>
                            <td style="background-color: #FFFFFF">
                                <asp:Label ID="lblOutTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="longVisit" style="display: none">
                            <td style="background-color: #F5F5F5">
                                Thời hạn thăm dài hạn (장기내방기간)
                            </td>
                            <td style="background-color: #FFFFFF" colspan="3">
                                <asp:Label ID="lblLongVisit" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
                <br />
                <%--<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
||||||| .r183
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
			<td class="contents_title">Xem chi tiết đăng ký 신청 (내역 상세보기)</td>
			<td align="right" class="location">HOME &gt;Xem chi tiết đăng ký (신청 내역 상세보기)</td>
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
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin người đăng ký 신청자정보
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5" width="150">
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
	<table width="100%" cellpadding="6" cellspacing="1" border="0" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin phê duyệt (결재정보)
			</td>
		</tr>
		
		<tr>
			<td style="background-color:#F5F5F5;" width="150">
				Tiêu đề dự thảo (기안제목)
			</td>
			<td style="background-color:#FFFFFF;">
				<%=title%><%=reqEmploeeDisplayName%>
			</td>
			<td style="background-color:#F5F5F5;">
				Mức bảo an [Thời hạn lưu trữ] (보안등급 [보존년한])
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
				Người thông báo (통보자)
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
				<input type="button" value="Xem trạng thái phê duyệt (결재상태 보기)" style="cursor:hand" onclick="showApproveStatus(document.forms[0].elecApproveCode.value)" runat="server" id="btnElectStatus" />
				<input type="button" value="Gửi phê duyệt (결재상신)" style="cursor:hand" onclick="approveSelect()" runat="server" id="btnElecApproveLine"/>
				<!--<input type="button" value="Gửi phê duyệt 결재상신" onClick="confirmSave()" id="btnApproveStart" runat="server"/>-->
				<input type="button" value="Quay lại (돌아가기)" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
	<input type="hidden" name="elecApproveCode" value="<%=elecApproveCode%>" />
	<input type="hidden" name="visitDataCode" value="<%=Request["visitDataCode"]%>" />
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="4" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin khách thăm (내방 정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5" width="150">
				Mục đích thăm (방문 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Mục đích chi tiết (세부 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectContents" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Người cần gặp (접견자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblInterviewUserName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi gặp (접견장소)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeNameDetail" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Số xe (차량 번호)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblCarNumber" runat="server"></asp:Label></td>
		</tr>
		<asp:Panel ID="pnlSecurity" runat="server">
		<tr>
			<td style="background-color:#F5F5F5">
				Thời gian vào (입문시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblInTime" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Thời gian ra (출문시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOutTime" runat="server"></asp:Label></td>
		</tr>
		<tr id="longVisit" style="display:none">
			<td style="background-color:#F5F5F5">
				Thời hạn thăm dài hạn (장기내방기간)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblLongVisit" runat="server"></asp:Label></td>
		</tr>
		</asp:Panel>
	</table>
	<br />
	
	<%--<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
=======
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
			<td class="contents_title">Xem chi tiết đăng ký 신청 (내역 상세보기)</td>
			<td align="right" class="location">HOME &gt;Xem chi tiết đăng ký (신청 내역 상세보기)</td>
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
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin người đăng ký 신청자정보
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5" width="150">
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
	<table width="100%" cellpadding="6" cellspacing="1" border="0" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin phê duyệt (결재정보)
			</td>
		</tr>
		
		<tr>
			<td style="background-color:#F5F5F5;" width="150">
				Tiêu đề dự thảo (기안제목)
			</td>
			<td style="background-color:#FFFFFF;">
				<%=title%><%=reqEmploeeDisplayName%>
			</td>
			<td style="background-color:#F5F5F5;">
				Mức bảo an [Thời hạn lưu trữ] (보안등급 [보존년한])
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
				Người thông báo (통보자)
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
				<input type="button" value="Xem trạng thái phê duyệt (결재상태 보기)" style="cursor:hand" onclick="showApproveStatus(document.forms[0].elecApproveCode.value)" runat="server" id="btnElectStatus" />
				<input type="button" value="Gửi phê duyệt (결재상신)" style="cursor:hand; color:Blue" onclick="approveSelect()" runat="server" id="btnElecApproveLine"/>
				<!--<input type="button" value="Gửi phê duyệt 결재상신" onClick="confirmSave()" id="btnApproveStart" runat="server"/>-->
				<input type="button" value="Quay lại (돌아가기)" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
	<input type="hidden" name="elecApproveCode" value="<%=elecApproveCode%>" />
	<input type="hidden" name="visitDataCode" value="<%=Request["visitDataCode"]%>" />
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="4" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin khách thăm (내방 정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5" width="150">
				Mục đích thăm (방문 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Mục đích chi tiết (세부 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectContents" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Người đón tiếp (접견자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblInterviewUserName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi đón tiếp (접견장소)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeNameDetail" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Số xe (차량 번호)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblCarNumber" runat="server"></asp:Label></td>
		</tr>
		<asp:Panel ID="pnlSecurity" runat="server">
		<tr>
			<td style="background-color:#F5F5F5">
				Thời gian vào (입문시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblInTime" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Thời gian ra (출문시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOutTime" runat="server"></asp:Label></td>
		</tr>
		<tr id="longVisit" style="display:none">
			<td style="background-color:#F5F5F5">
				Thời hạn thăm dài hạn (장기내방기간)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblLongVisit" runat="server"></asp:Label></td>
		</tr>
		</asp:Panel>
	</table>
	<br />
	
	<%--<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
>>>>>>> .r192
	<tr>
		<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
			<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle"> Tệp đính kèm (첨부 파일)
		</td>
	</tr>
	<tr>
		<td style="background-color:#F5F5F5" width="150">
			Tệp tin 1 (파일1)
		</td>
		<td style="background-color:#FFFFFF">
			<asp:Label ID="lblUserFile1" runat="server"></asp:Label></td>
	</tr>
	<tr>
		<td style="background-color:#F5F5F5">
			Tệp tin 2 (파일2)
		</td>
		<td style="background-color:#FFFFFF">
			<asp:Label ID="lblUserFile2" runat="server"></asp:Label></td>
	</tr>
	<tr>
		<td style="background-color:#F5F5F5">
			Tệp tin 3 (파일3)
		</td>
		<td style="background-color:#FFFFFF">
			<asp:Label ID="lblUserFile3" runat="server"></asp:Label></td>
	</tr>
	</table>--%>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound"
                    Width="100%">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <Columns>
                        <asp:BoundField HeaderText="Tên (성명)" SortExpression="VisitorName">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ngày, tháng, năm sinh (생년월일)" SortExpression="VisitorRegNumber1">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <%--			<asp:BoundField HeaderText="여권번호" SortExpression="VisitorPassportNumber">
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>--%>
                        <asp:BoundField HeaderText="Tên công ty (업체명)" SortExpression="CompanyName">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Liên lạc (연락처)" SortExpression="VisitorPhone1">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectVisitorDataList"
                    TypeName="HanaMicron.COMS.BLL.VisitorData">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="visitDataCode" QueryStringField="visitDataCode" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <br />
                <table width="100%" cellpadding="6" cellspacing="1" id="approveBtnTable" style="display: block">
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20" valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        function completeLoad() {
            if (document.readyState == 'complete') {
                ElecLineSelectAll('<%=elecApproveCode%>');
                clearTimeout(loadScript);
            } else {
                loadScript = setTimeout('completeLoad()', 100);
            }
        }

        //completeLoad();  --2019-01-22-임종우 : SmartClient 사용 안하기에 주석처리
        longvisitdisplay();
    </script>
</asp:Content>
