<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElecApproveSend.aspx.cs" Inherits="elecApprove_ElecApproveSend" EnableViewStateMac="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Không có tiêu đề (제목 없음)</title>
    <script language="javascript" type="text/javascript">
    function onLoadProc(){
    var type='<%=elecApproveType%>';
    alert('Đã gửi phê duyệt (결재를 상신하였습니다).');

    if(type=='visit'){
        window.location='/COMS/main/visit/listVisit.aspx';
    }
    else if(type=='secCard')
    {
        window.location='/COMS/main/securityCard/listSecCard.aspx';
    }
    else
    {
        window.location='/COMS/main/takeOut/listTakeOut.aspx';
    }
    //self.close();
        
    }
    </script>
<script> 
window.history.forward(1); 
</script> 

</head>
<body>
    <form id="form1" runat="server">
    <div>

    <!--
    //private String docCode = String.Empty; // 문서 번호         mã số/ số tài liệu
	//private String formCode = String.Empty; // 문서 양식 번호   mã số/ số mẫu tài liệu
	//private String docTitle = String.Empty; // 기안 제목        tiêu đề dự án/ bản thảo
	//private String contents = String.Empty; // 결재 내용 HTML   Nội dung phê duyệt html 
	//private String employeeCode = String.Empty; // 사번         ID
	//private String employeeTitle = String.Empty; // 직급        Chức vụ
	//private String employeeDepName = String.Empty; // 부서      Bộ phận
	//private String employeeName = String.Empty; // 이름        Tên
	//private String formTerm = String.Empty; // 보존 연한       thời hạn lưu trữ
	//private String secLevel = String.Empty; // 대외비
	//private String attachFlag = String.Empty; // 첨부파일 존재 여부

	-->
		
    <object id="smartClient" classid="ElecApprove.dll#ElecApprove.ElecSubmit" width="0px" height="0px">
	<param name="DocCode" value="<%=Request["elecApproveCode"]%>" />
	<param name="FormCode" value="<%=form_code%>" />
	<param name="DocTitle" value="<%=doc_title%><%=loginEmploeeDepartmentName%> <%=loginEmploeeDisplayName%>" />
	<param name="Contents" value="<%=elecApproveContents%>" />
	<param name="EmployeeCode" value="<%=user_id%>" />
	<param name="EmployeeTitle" value="<%=user_Title %>" />
	<param name="EmployeeDepName" value="<%=user_depName %>" />
	<param name="EmployeeName" value="<%=user_name %>" />
	<param name="FormTerm" value="<%=doc_term%>" />
	<param name="SecLevel" value="<%=sec_level%>" />
	<param name="AttachFlag" value="<%=attach_flag%>" />
	<param name="CategoryCode" value="<%=elecCategoryCode%>" />
	<param name="AttachString" value="<%=attach_str%>" />
	</object>
	
    </div>
    </form>
    
    <script language="javascript" type="text/javascript">
        onLoadProc();
    </script>
</body>
</html>
