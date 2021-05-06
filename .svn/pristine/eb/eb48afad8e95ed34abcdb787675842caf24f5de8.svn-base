<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElecLine.aspx.cs" Inherits="elecApprove_ElecLine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chỉ định luồng phê duyệt (결재선 지정)</title>
    <link rel="stylesheet" href="/COMS/include/css/StyleSheet.css" type="text/css" />
    <script language="javascript" type="text/javascript">
    approveLineTemp="";
    </script>
    <script event="UmcParamClick(approveLine)" for="smartClient">
		//alert(approveLine);
		
		window.returnValue = approveLine;
		approveLineTemp=approveLine;
		window.close();
	</script>
	
	<script event="UmcClick()" for="smartClient">
		window.close();
	</script>
	
	<script language="javascript" type="text/javascript">
	function checkClose(){
		//alert(approveLineTemp.length);
		if(approveLineTemp.length <= 1){
			document.getElementById('smartClient').btnClose_Click();
		}
	}
	</script>
</head>
<body onunload="checkClose()">
    <form id="form1" runat="server">
    <div>
		
    <object id="smartClient" classid="ElecApprove.dll#ElecApprove.ElecLine" width="741px" height="446px">
	<param name="ParamEmployeeCode" value="<%=Request.QueryString["employeeCode"]%>" />
	<param name="ParamElecDocCode" value="<%=Request.QueryString["docCode"]%>" />
	</object>
    </div>
    </form>
</body>
</html>
