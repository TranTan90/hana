<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printTakeOut.aspx.cs" Inherits="main_takeOut_printTakeOut" Title="Giấy chứng nhận mang tài sản ra cổng (반출증)" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Giấy chứng nhận mang tài sản ra cổng (반출증)</title>
    <%--<link rel="stylesheet" href="../../include/css/StyleSheet.css" />--%>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <br />
<table width="650" border="0" cellspacing="0" cellpadding="0" align="center" style="font-size:8pt;font-family:Tahoma;font-weight:bold;table-layout:fixed">
<tr>
    <td width="40%"><img src="/COMS/images/hanamicron.JPG"></td>
    <td rowspan="2"><h1>Giấy chứng nhận mang tài sản ra cổng (반출증)</h1></td>
</tr>
<tr>
    <td height="30">
        Mã chứng nhận (반출번호): <asp:Label ID="lblTakeOutDataCode" runat="server"></asp:Label> 
    </td>
</tr>
<tr>
	<td height="5" colspan="2"></td>
</tr>
<tr>
    <td valign="top" colspan="2">
	<table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-color:Black">
		<tr>
			<td colspan="5" class="contents_title" style="border-color:Black;border-style:solid">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin người đăng ký (신청자정보)
			</td>
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Bộ phận (부서명)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Tên (성명)</td>			
            <td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Chức vụ (직급)</td>			
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">ID (사번)</td>			
            <td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Điện thoại nội bộ (사내전화)</td>			
		</tr>		    
		<tr align="center">
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
		    <td style="border-color:Black;border-style:solid"><asp:Label ID="lblDisplayName" runat="server"></asp:Label></td>
		    <td style="border-color:Black;border-style:solid"><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
		    <td style="border-color:Black;border-style:solid"><asp:Label ID="lblUpnid" runat="server"></asp:Label></td>
		    <td style="border-color:Black;border-style:solid"><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
		<table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-color:Black">
		<tr>
			<td colspan="4" class="contents_title" style="border-color:Black;border-style:solid">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin phê duyệt (결재정보)
			</td>
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" width="7%">Phê duyệt/ thảo luận(결/합)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" width="17%">Tên/Chức vụ (성명/직급)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" width="16%">Bộ phận (부서)</td>			
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Phê duyệt 결재(합의) Ý kiến 의견</td>
		</tr>
        <%=elecApporveHtml%>
	</table>
	<br />
	<table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-color:Black">
		<tr>
			<td colspan="4" class="contents_title" style="border-color:Black;border-style:solid">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">
				Thông tin tài sản ra cổng (반출정보)
			</td>
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" width="20%">Ngày dự định mang ra (반출 예정일)</td>
			<td style="border-color:Black;border-style:solid" width="30%"><asp:Label ID="lblScheduleOutDate" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" width="20%">Ngày dự định mang vào (반입 예정일)</td>
			<td style="border-color:Black;border-style:solid" width="30%"><asp:Label ID="lblScheduleDate" runat="server"></asp:Label></td>	
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Mục đích (반출목적)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblTakeOutObject" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Chi tiết mục đích (반출세부목적)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblTakeOutObjectContents" runat="server"></asp:Label></td>
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Có mang vào hay không (반입여부)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblRequireIN" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Lý do từ chối (불가사유)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblDisApproveName" runat="server"></asp:Label></td>
		</tr>
		<tr align="center">
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Công ty nhận (수령회사)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Người nhận (수령자)</td>
			<td style="border-color:Black;border-style:solid"><asp:Label ID="lblReceiveName" runat="server"></asp:Label></td>
		</tr>
		<tr align="center">
		    <td style="background-color:#F5F5F5;border-color:Black;border-style:solid">Ghi chú (비고)</td>
		    <td colspan="3" align="left" style="border-color:Black;border-style:solid"><asp:Label ID="lblNote" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
	<table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-color:Black">
        <tr>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center" width="6%">STT (순번)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Tài sản lớn (대분류)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Tài sản nhỏ (소분류)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Tên tài sản (품명)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Quy cách (규격/Serial)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Đơn vị  (단위)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Số lượng (수량)</td>
			<td style="background-color:#F5F5F5;border-color:Black;border-style:solid" align="center">Ghi chú (비고)</td>
		</tr>
		<%=takeOutItemListHtml%>
		<tr>
		    <td colspan="8" style="border-color:Black;border-style:solid; height: 40px;">
		    <table width="100%" border="0" cellspacing="0" cellpadding="0">
		        <tr><td height="15">&nbsp;</td></tr>
		        <tr><td> * Chú ý (주의)</td></tr>
                <tr><td> 1. In 2 bản giấy chứng nhận, Sau khi nhận được xác nhận của bảo về thì mang tài sản ra cổng (Bảo vệ lưu 1 bản, Bộ phận phụ trách lưu 1 bản)</td></tr>
		        <tr><td>    (반출증 2부를 출력하여, 정문 보안실의 확인을 받은 후 반출(보관실 보관용 1부, 담당부서 보관용 1부))</td></tr>
                <tr><td style="height: 14px"> 2. Trường hợp mang tài sản vào, nhất định phải nhận được xác nhận của bảo vệ</td></tr>
		        <tr><td style="height: 14px">   (반입여부가 반입필의 경우 반드시 정문 보안실의 확인을 받은 후 반입) </td></tr>
		    </table>
		    </td>
		</tr>
		
	</table>
	<br />
	
	<table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-color:Black">
		<tr>
			<td colspan="2" class="contents_title" style="border-color:Black;border-style:solid">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">
				Bảo vệ xác nhận (보안실 확인)
			</td>
		</tr>
		<tr>
			<td style="border-color:Black;border-style:solid" align="center">
				Xác nhận tài sản ra cổng (반출확인)
			</td>
			<td style="border-color:Black;border-style:solid" align="center">
				Xác nhận tài sản vào cổng (반입확인)
			</td>
		</tr>
		<tr>
			<td style="border-color:Black;border-style:solid">
				Người xác nhận tài sản ra cổng (반출확인자): 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(인)
			</td>
			<td style="border-color:Black;border-style:solid">
				Người xác nhận tài sản vào cổng (반입확인자): 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(인)
			</td>
		</tr>
		<tr>
			<td height="50" style="border-color:Black;border-style:solid">
				&nbsp;
			</td>
			<td style="border-color:Black;border-style:solid">
				&nbsp;
			</td>
		</tr>
	</table>
	<br />
	<br />    
		</td>
<%--	<td width="20" valign="top">&nbsp;</td>--%>
</tr>
</table>
</div>
</form>
<script language="javascript">
    window.print();
</script>
</body>
</html>


