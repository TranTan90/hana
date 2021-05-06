<%@ Page Language="C#" AutoEventWireup="true" CodeFile="deleteVisit.aspx.cs" Inherits="main_visit_deleteVisit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Không có tiêu đề (제목 없음)</title>
<script language="javascript">
    // 전자 결재 관련 quản ký phê duyệt điện tử
var approveServerPath='<%=ConfigurationManager.AppSettings["elecApproveServerPath"]%>'; // 전자결재 서버 PATH
var approveServerPort='<%=ConfigurationManager.AppSettings["elecApproveServerPort"]%>'; // 전자결재 서버 PORT
var formCode='<%=ConfigurationManager.AppSettings["elecApproveFormCode"]%>'; // 전자결재 form code

if(approveServerPort) approveServerURL=approveServerPath + ":" + approveServerPort;
else approveServerURL=approveServerPath;

</script>
</head>
<body>

	<!--
	<object id="smartClient" classid="../../elecApprove/ElecApprove.dll#ElecApprove.ElecDelete" width="0px" height="0px">
	<param name="DocCode" value="<%=doc_code%>" />
	<param name="EmployeeCode" value="<%=employeeCode%>" />
	</object>
	-->
	<iframe id="dumy" width="0" height="0" src="approveServerURL+"/Elec_Legacy/Legacy/Elec_line_Step1_Delete.asp?doc_code=<%=doc_code%>"></iframe>
<script language="javascript">
alert('Đã xóa (삭제하였습니다)');
//window.location='listVisit.aspx';
</script>
</body>
</html>