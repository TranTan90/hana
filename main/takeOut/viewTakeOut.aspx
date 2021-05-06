<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTakeOut.aspx.cs" Inherits="main_visit_viewVisit" Title="Xem chi tiết (상세 보기)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script id="approveLine"></script>
<script language="javascript">

// 전자 결재 관련 Quản lý phê duyệt điện tử
    var approveServerPath = '<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH / server PATH
    var approveServerPort = '<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT / server PORT
    var formCode = '<%=ConfigurationManager.AppSettings["elecApproveFormCode"]%>'; // 전자결재 form code / 

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;

//SelectAllLine
// 지정된 결재 라인 보여주기 xem dòng chỉ định phê duyệt
// hananet 의 전자결재의 외부Interface Javascript 를 활용한다.
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

// 결재 상태 보기 Xem trạng thái phê duyệt
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

// 결재상신 선택 새창열기 
function approveSelect() {
    alert("Cần chọn luồng phê duyệt khi đăng ký tài sản ra cổng.\nLuồng phê duyệt điện tử: Quản lý/ Trưởng bộ phận --> Trưởng phòng GA.\n (□ 반출 신청 시 전자결재선을 필히 준수 해 주시기 바랍니다.\n전자결재선: 해당부서 그룹장 결재→총무그룹(박민수 차장) 합의)")

    var f = document.forms[0];
    alert(f + " / " + formCode)
    var approveDocCode = f.elecApproveCode.value; // 문서 코드 code tài liệu
    var url = "http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=V2_TAKE_NEW&TABLE_KEY=" + approveDocCode;
    //var url = "http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=IF_TAKE_NEW&TABLE_KEY=" + approveDocCode;
    //var url ="http://hananet.hanamicron.co.kr/ekp/user.do?cmd=goEappWrite&EMP_CODE=<%=loginEmployeeUpnid%>&CMP_ID=C100120730&ELEC_APP_CODE="+approveDocCode+"&FORM_ID=EF134741884097010";
    //var strOpt = 'dialogHeight:510px;dialogWidth:650px;leftmargin:30px;marginwidth:30px;dialogTop:'+(screen.height-420)/2+'px; dialogLeft:'+(screen.width-675)/2+'px; center: yes; help: no; resizable: no; scrollbars: yes; status: no;';  // ModalDialog 창 크기 및 특징 지정
    //window.open(url,'elec_app', strOpt);
    //window.open(url,'elec_app', 'scrollbars=yes');
    window.open(url, 'elec_app', 'scrollbars=yes, width=1024, height=768');
    //window.location='/COMS/main/visit/listVisit.aspx';

}

// 반입일자 연장신청 결재상신 선택 새창열기 
function reApproveSelect(){
	var f=document.forms[0];
	var approveDocCode=f.elecApproveCode.value; // 문서 코드

	var url = "http://gw.hanamicron.co.kr/ekp/view/openapi/IF_EAP_001_goWrite?USER_ID=<%=loginEmployeeUpnid%>&INTRLCK_CD_VAL=MCR_IF_TAKE0007&TABLE_KEY=" + approveDocCode;
	
	//var url ="http://hananet.hanamicron.co.kr/ekp/user.do?cmd=goEappWrite&EMP_CODE=<%=loginEmployeeUpnid%>&CMP_ID=C100120730&ELEC_APP_CODE="+approveDocCode+"&FORM_ID=EF145817846156454";
	//var strOpt = 'dialogHeight:510px;dialogWidth:650px;leftmargin:30px;marginwidth:30px;dialogTop:'+(screen.height-420)/2+'px; dialogLeft:'+(screen.width-675)/2+'px; center: yes; help: no; resizable: no; scrollbars: yes; status: no;';  // ModalDialog 창 크기 및 특징 지정
    //window.open(url,'elec_app', strOpt);
    //window.open(url,'elec_app', 'scrollbars=yes');
    window.open(url, 'elec_app', 'scrollbars=yes, width=1024, height=768');
   //window.location='/COMS/main/visit/listVisit.aspx';
 
}
// 상신 문의
function confirmSave(){
	if(document.getElementById("lbCon").innerHTML.length < 1){
		alert('[Thông báo] Hãy đăng ký thông tin phê duyệt ([알림]결재정보를 등록하여 주십시오)');
		return false;
	}else{
		/*
		if(confirm('[알림]한번 상신된 결재는 되돌릴 수 없습니다.\n신중하게 결정하여 주십시오\n\n[결재를 상신하시겠습니까?]')){
			document.forms[0].action='../../elecApprove/ElecApproveSend.aspx?elecApproveType=takeOut';
			document.forms[0].submit();
		*/	
	    // 2011-09-21 김민우 : 결재 상신 후 뒤로가기 버튼 클릭 시 상신 정보 사라지는 버그 수정(새창을 호출함)
    if (confirm('[Thông báo] Khi cấp trên phê duyệt thì không thu hồi lại được. \n Hãy quyết định thận trọng \n\n[Bạn có gửi phê duyệt không?] ([알림]한번 상신된 결재는 되돌릴 수 없습니다.\n신중하게 결정하여 주십시오\n\n[결재를 상신하시겠습니까?])')) {
			document.forms[0].action='../../elecApprove/ElecApproveSend.aspx?elecApproveType=takeOut';
			//window.open("_blank","approve","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizeable=no,width=1,height=1,top=0,left=1000000");
			//document.forms[0].target='approve';
			document.forms[0].submit();
			// if visit or takeOut location
			//window.location.href = '/COMS/main/takeOut/listTakeOut.aspx';
		}
	}
}

// 결재 라인 가져오기
function ElecLineSelectAll(docCode){
	document.getElementById('smartClient').ElecLineSelectAll(docCode);
}
function goReplace(str) { location.replace(str); }

// 반출증 출력하기
function printTakeOut(){
    var f=document.forms[0];
    var takeOutCode=f.takeOutDataCode.value;
    
//    window.location="printTakeOut.aspx?takeOutDataCode="+takeOutCode;
    newWinByNameByScroll('printTakeOut.aspx?takeOutDataCode='+takeOutCode,'printTakeOut',1024,768);
}
function printAlert(){
    alert('Hãy xuất thông tin phê duyệt điện tử ở GruopWare (그룹웨어에서 전자결재 정보를 출력하시기 바랍니다).');
}

function btnElecApproveLine_onclick() {

}

var modal = document.getElementById("imagemodal");
var img = document.getElementById("");

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
			<td class="contents_title">Xem chi tiết đăng ký tài sản ra cổng (반출 신청 내역 상세보기)</td>
			<td align="right" class="location">HOME &gt; Chi tiết đăng ký (신청 내역 상세보기)</td>
		</tr>
		<tr>
			<td colspan="3" class="title_line"></td>
		</tr>
	</table>
	<!--################################ 타이틀, 현재위치 끝 ################################--></td>
</tr>
<tr>
	<td height="20"></td>
</tr>
<tr>
    <td style="font-size:large">
        Mã tài sản ra cổng (반출번호): <asp:Label ID="lblTakeOutDataCode" runat="server"></asp:Label> 
    </td>
</tr>
<tr>
	<td height="5"></td>
</tr>
<tr>
    <td valign="top">
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin người đăng ký (신청자정보)
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
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin phê duyệt (결재정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5;" width="150">
				Tiêu đề dự thảo (기안제목)
			</td>
			<td style="background-color:#FFFFFF;">
				[Đăng ký tài sản ra cổng (반출신청)] <%=reqEmploeeDisplayName%>
			</td>
			<td style="background-color:#F5F5F5;">
				Mức bảo an(Thời hạn lưu trữ) (보안등급(보존년한))
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
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" border="0">
		<tr>
			<td bgcolor="#FFFFFF" align="center">
				<input type="button" value="Xem trạng thái phê duyệt (결재상태 보기)" style="cursor:hand" onclick="showApproveStatus(document.forms[0].elecApproveCode.value)" runat="server" id="btnElectStatus" />
				<input type="button" value="Xuất giấy chứng nhận mang tài sản ra cổng (반출증 출력)" style="cursor:hand" onclick="printAlert()" runat="server" id="btnPrint" />
				<input type="button" value="Đăng ký gia hạn ngày mang tài sản vào công ty (반입일자 연장신청)" style="cursor:hand" onclick="reApproveSelect()" runat="server" id="btnReElecApproveLine" />
				<input type="button" value="Gửi phê duyệt (결재상신)" style="cursor:hand" onclick="approveSelect()" runat="server" id="btnElecApproveLine"  />
				<!--<input type="button" value="결재상신" style="cursor:hand" onclick="confirmSave()" id="btnApproveStart" runat="server"/>-->
				<input type="button" value="Quay lại (돌아가기)" style="cursor:hand" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
	<input type="hidden" name="elecApproveCode" value="<%=elecApproveCode%>" />
	<input type="hidden" name="takeOutDataCode" value="<%=Request["takeOutDataCode"]%>" />
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">
				Thông tin tài sản ra cổng (반출정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Ngày dự định mang ra (반출 예정일)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblScheduleOutDate" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Ngày dự định mang vào (반입 예정일)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblScheduleDate" runat="server"></asp:Label>
			</td>	
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Mục đích mang ra (반출목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTakeOutObject" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Chi tiết mục đích mang ra (반출세부목적)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblTakeOutObjectContents" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Lộ trình mang ra (반출경로)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTakeOutPathStart" runat="server"></asp:Label> ☞ <asp:Label ID="lblTakeOutPathEnd" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Nơi mang ra (반출처)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblCompanyName" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Người nhận (수령자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblReceiveName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Có mang vào hay không (반입여부)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblRequireIN" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Lý do không thể mang vào (불가사유)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisApproveName" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Lý do chi tiết (불가세부사유)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisApproveDetail" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Biển số xe (차량 번호)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblCarNumber" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Thời gian mang ra (반출시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOutTime" runat="server"></asp:Label>
			</td>
			<td style="background-color:#F5F5F5">
				Thời gian mang vào (반입시간)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblINTime" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
		    <td style="background-color:#F5F5F5">
		        Ghi chú (비 고)
		    </td>
		    <td  colspan="5" style="background-color:#FFFFFF">
		        <asp:Label ID="lblNote" runat="server"></asp:Label>
		    </td>
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
			<asp:BoundField DataField="SubCodeName" HeaderText="Tài sản nhỏ (소분류)" SortExpression="SubCodeName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutItemName" HeaderText="Tên tài sản (품명)" SortExpression="TakeOutItemName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="TakeOutItemType" HeaderText="Quy cách (규격/Serial No)" SortExpression="TakeOutItemType" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="UnitName" HeaderText="Đơn vị (단위)" SortExpression="UnitName" >
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Account" HeaderText="Số lượng (수량)" SortExpression="Account" >
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
	<div  id="imagemodal" class="imagetakeout">
    
    <table>
    <td>
      <asp:Image ID="viewimage1" runat="server"  Height="250px" Width="250px"  data-lightense-padding="400" />
   
    </td>
   <td>
       <asp:Image ID="viewimage2" runat="server"  Height="250px" Width="250px" data-lightense-padding="400" />

   </td> 
   
       
    <td>
     <asp:Image ID="viewimage3" runat="server"  Height="250px" Width="250px" data-lightense-padding="400"  />
    </td>
    
    </table>
    
    </div>
	

	<table width="100%" cellpadding="6" cellspacing="1" id="approveBtnTable" style="display:block">
		<tr>
			<td align="center">
				<input type="button" value="Xác nhận (확인)" onclick="goReplace('listTakeOutTeam.aspx')" />
			</td>
		</tr>
	</table>
		</td>
	<td width="20" valign="top">&nbsp;</td>
</tr>
</table>
<%--<script src="../../include/js/lightense.js"></script>

    <script type="text/javascript">
        window.addEventListener("load", function(){Lightense("img")}, false);
    </script>--%>
</asp:Content>

