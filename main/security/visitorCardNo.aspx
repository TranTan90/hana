<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visitorCardNo.aspx.cs" Inherits="main_visit_visitorEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Đăng ký Card No khách thăm (내방객 Card No 등록)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" />
    <script language="javascript" type="text/javascript">
   
        function save(){
            var f = document.getElementById("form1")
            if(checkForm(document.form1)){
                f.submit();

             }
        }
        
        function checkForm(f){
            var cardNo = document.getElementById("cardNo");

//            if (!f.cardNo.value)
            if(document.getElementById("cardNo").value)
            {
                alert('Hãy nhập Card No khách thăm (내방객 Card No 입력하여 주십시요)');
                f.cardNo.focus();
                return false;
            }
            return true;
        
        }
        
        function enterKeyPress(){
            if(window.event.keyCode == 30){
                window.event.returnValue = false
            }
        }
        
    </script>
</head>
<!--<body onload="change()" onkeypress="enterKeyPress()">-->
<body onkeypress="enterKeyPress()">
    <form id="form1" runat="server">
    <div>
		<script language="javascript" src="../../include/js/default.js" type="text/javascript"></script>
		<table style="width: 300px; clip: rect(auto auto auto auto)">
			<tr>
				<td colspan="2" style="height: 30px; background-color: #ffffff">
                    Đăng ký Card No khách thăm (내방객 Card No 등록)</td>
			</tr>
			<tr>
				<td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
                    Card No</td>
				<td style="height: 26px; background-color: #f5f5f5">
					<asp:TextBox ID="cardNo" runat="server" ValidationGroup="AllValidators" style="ime-mode:active"></asp:TextBox>
						</td>
			</tr>
			<tr>
				<td align="center" colspan="2" style="height: 26px; background-color: #ffffff">
				    <img src="../../images/icon/write.gif" style="cursor:hand" onclick="save()" alt="Đăng ký (등록하기)" />
					<a href="#" onclick="window.close();">
					<img alt="Quay lại (돌아가기)" src="../../images/icon/close.gif" style="border-top-style: none;
							border-right-style: none; border-left-style: none; border-bottom-style: none" /></a></td>
			</tr>
		</table>
		<asp:HiddenField ID="mode" runat="server" />
        &nbsp; &nbsp;
        
    </div>
    </form>
</body>
</html>
