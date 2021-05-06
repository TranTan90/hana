<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visitDataSend.aspx.cs" Inherits="elecApprove_visitDataSend" EnableViewStateMac="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Không có tiêu đề (제목 없음)</title>
</head>
<body>
    <form id="form1" target="dumy" action="http://daum.net" method="post">
    <div>
		<input type="hidden" name="form_code" value="<%=form_code%>" />
		<input type="hidden" name="doc_code" value="<%=Request["elecApproveCode"]%>" />
		<input type="hidden" name="doc_title" value="[내방신청]<%=loginEmploeeDepartmentName%> <%=loginEmploeeDisplayName%>" />
		<input type="hidden" name="doc_term" value="<%=doc_term%>" />
		<input type="hidden" name="sec_level" value="<%=sec_level%>" />
		<input type="hidden" name="attach_flag" value="<%=attach_flag%>" />
		<input type="hidden" name="Attach_str" value="<%=attach_str%>" />
		<input type="hidden" name="act_type" value="N" />
		<input type="hidden" name="EndAct_URL" value="http://coms.hmicron.com/COMS/elecApprove/updateVisitApproveState.aspx" />
		<input type="hidden" name="user_id" value="<%=user_id%>" />
		<input type="hidden" name="user_Title" value="<%=user_Title %>" />
		<input type="hidden" name="user_depName" value="<%=user_depName %>" />
		<input type="hidden" name="user_name" value="<%=user_name %>" />
		<textarea id="TextArea1" cols="60" name="doc_content" rows="40" style="display:none"><%=elecApproveContents%></textarea></div>
    </form>
<iframe name="dumy" width="1024" height="768"></iframe>
<script language="javascript">
// 전자 결재 관련 phê duyệt điện tử
var approveServerPath='<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH
var approveServerPort='<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT
var formCode='<%=ConfigurationManager.AppSettings["elecApproveFormCode"]%>'; // 전자결재 form code

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;

var f=document.forms[0];
f.action=approveServerURL + "/Elec_Legacy/Elec_legacy_docsview_save_utf8.asp";
f.submit();
window.location.href="../main/visit/listVisit.aspx?employeeCode=<%=loginEmployeeUpnid%>";
</script>
</body>
</html>
