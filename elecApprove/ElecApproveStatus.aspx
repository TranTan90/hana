<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElecApproveStatus.aspx.cs" Inherits="elecApprove_ElecLine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tình trạng tiến hành phê duyệt (결재 진행 상황)</title>
    <link rel="stylesheet" href="/COMS/include/css/StyleSheet.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <object id="smartClient" classid="ElecApprove.dll#ElecApprove.ElecLineStatus" width="840px" height="180px">
	<param name="DocCode" value="<%=Request.QueryString["doc_code"]%>" />
	</object>
    </div>
    </form>
</body>
</html>
