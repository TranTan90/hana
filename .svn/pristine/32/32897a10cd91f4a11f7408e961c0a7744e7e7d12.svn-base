<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visitorEdit.aspx.cs" Inherits="main_visit_visitorEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Đăng ký khách thăm (내방객 등록)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" />
    <script language="javascript" type="text/javascript">
    // ajax ready?
        var request = false;
        try {
	        request = new XMLHttpRequest();
        } catch (trymicrosoft) {
	        try {
		        request = new ActiveXObject("Msxml2.XMLHTTP");
	        } catch (othermicrosoft) {
		        try {
			        request = new ActiveXObject("Microsoft.XMLHTTP");
		        } catch (failed) {
			        request = false;
		        }
	        }
        }
        if (!request) alert("Error initializing XMLHttpRequest!");

        function change(){
            var f=document.form1;
            var our=document.getElementById('native');
            var other=document.getElementById('foreigner');

            if(f.rbutton[0].checked){
            our.style.display='block';
            other.style.display='none';
            }
            if(f.rbutton[1].checked){
            our.style.display='none';
            other.style.display='block';
            }
            if(f.rbutton[2].checked){
                alert("□tiêu chuẩn đăng ký Free pass\n\n - Khách hàng và Khách thăm công sở\n\n\n□ Lộ trình phê duyệt\n\n- Team leader approval → GA Group(박민수 과장) (Thảo luận  □Free pass 신청 기준\n\n- 고객사 및 관공서 내방객\n\n\n□ 결재경로\n\n- 팀장 결재 → 총무그룹(박민수 과장) 합의)")
            our.style.display='none';
            other.style.display='none';
            }
        }
        
        function save(){
            var f=document.form1;
            if(checkForm(document.form1)){
                f.submit();

             }
        }
        
        function checkForm(f){
            var visitorName = document.getElementById('visitorName');
            var visitorRegNumber1 = document.getElementById('visitorRegNumber1');
            var visitorRegNumber2 = document.getElementById('visitorRegNumber2');
            var visitorPassportNumber = document.getElementById('visitorPassportNumber');
            var companyName = document.getElementById('companyName');
            
            if(!f.visitorName.value){
                alert('Nhập tên khách thăm (내방객의 이름을 입력하여 주십시요)');
                f.visitorName.focus();
                return false;
            }
            
            if(f.rbutton[0].checked){
                if(!f.visitorRegNumber1.value){
                    //alert('주민등록번호 앞자리를 입력하여 주십시요');
                    alert('Nhập ngày, tháng, năm sinh (생년월일을 입력하여 주십시요)');
                    f.visitorRegNumber1.focus();
                    return false;
                }
                /*
                if(!f.visitorRegNumber2.value){
                    alert('주민등록번호를 입력하여 주십시요');
                    f.visitorRegNumber2.focus();
                    return false;
                }
                */
            }
            
//            if(f.rbutton[1].checked){
//                if(!f.visitorPassportNumber.value){
//                    alert('여권번호를 입력하여 주십시요');
//                    f.visitorPassportNumber.focus();
//                    return false;
//                }
//            }
            
            if(!f.companyName.value){
                alert('Chọn công ty (업체를 선택하여 주십시요)');
                f.companyName.focus();
                return false;
            }
            
            return true;
        
        }
        
        function enterKeyPress(){
            if(window.event.keyCode == 13){
                window.event.returnValue = false
            }
        }
        
    </script>
</head>
<body onload="change()" onkeypress="enterKeyPress()">
    <form id="form1" runat="server">
    <div>

		<script language="javascript" src="../../include/js/default.js" type="text/javascript"></script>

		<table style="width: 670px; clip: rect(auto auto auto auto)">
			<tr>
				<td colspan="2" style="height: 14px; background-color: #ffffff">
				<table>
				    <tr><td>&nbsp;</td></tr>
				    <tr>
				        <td colspan="2">
				            <h2><asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:Label>&nbsp;</h2>
			            </td>
		            </tr>
		            <tr>
		                <td>
                            <h2>
                                <input name="rbutton" type="radio"value="0" onclick="javascript:change()" checked="CHECKED"/>Việt Nam (내국인)
                                <input name="rbutton" type="radio"value="1" onclick="javascript:change()" />Người ngoại quốc (외국인)
                            </h2>
                        </td>
                        <td>
                            <h2>
                            <asp:Panel ID="PanelFreepass" runat="server" Visible="false">
                                    <input name="rbutton" type="radio"value="2" onclick="javascript:change()" />Free pass
                            </asp:Panel>
                            </h2>
                        </td>
                    </tr>
                </table>
				</td>
			</tr>
            <%--2021-05-03 반안
            내방객 등록
             -> 이름, 생년월일, 여권번호 표시하는 부분의 줄바꿈
             -> 여권번호 입력 셀의 입력DIGIT 확대 필요, 여권번호는 9자리 인데 다 입력이 안됨
            --%>
			<tr>
				<td align="center" style="width: 130px; height: 30px; background-color: #dcdcdc">
					Tên <br/> (이름)</td>
				<td style="height: 26px; background-color: #f5f5f5">
					<asp:TextBox ID="visitorName" runat="server" ValidationGroup="AllValidators" style="ime-mode:active"></asp:TextBox>
					<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="visitorName" Display="Dynamic" ErrorMessage="내방객의 이름을 입력하여 주십시요" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%>
						<br />※ Vì yêu cầu sửa tên liên tục nên đang xảy ra lỗi.
						<br />※ Bỏ qua chức vụ và nhập chính xác tên.
                        <br />※ 성명 수정을 요청하는 건이 계속해서 발생하고 있습니다.
						<br />※ 직급은 생략하시고 성명을 정확히 기재해 주시기 바랍니다
						</td>
			</tr>
			<tr style="color: #636363" id="native">
				<td align="center" style="width: 130px; height: 30px; background-color: #dcdcdc">
                    Ngày, tháng, năm sinh <br/> (생년월일)</td>
				<td style="height: 24px; background-color: #f5f5f5">
					<asp:TextBox ID="visitorRegNumber1" runat="server" MaxLength="6" ValidationGroup="AllValidators"
						Width="50px"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
							runat="server" ControlToValidate="visitorRegNumber1" Display="Dynamic" ErrorMessage="주민등록번호 앞자리를 입력하여 주십시요"
							ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%><asp:TextBox ID="visitorRegNumber2"
								runat="server" MaxLength="7" ValidationGroup="AllValidators" Width="60px" Visible="False"></asp:TextBox>&nbsp;
                    (EX: 831212)<%--<asp:RequiredFieldValidator
									ID="RequiredFieldValidator3" runat="server" ControlToValidate="visitorRegNumber2"
									Display="Dynamic" ErrorMessage="주민등록번호를 입력하여 주십시요" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%></td>
			</tr>
			<tr style="color: #636363" id="foreigner">
				<td align="center" style="width: 130px; height: 30px; background-color: #dcdcdc">
					Số hộ chiếu <br/> (여권번호)</td>
				<td style="height: 24px; background-color: #f5f5f5">
					<asp:TextBox ID="visitorPassportNumber" runat="server" MaxLength="9" ValidationGroup="AllValidators" Width="126px"></asp:TextBox>
					(Có thể bỏ qua (생략 가능))
						<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
							runat="server" ControlToValidate="visitorPassportNumber" Display="Dynamic" ErrorMessage="여권번호를 입력하여 주십시요"
							ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%>
				</td>
			</tr>
            <%--반안: 전화번호 11자리로 변경--%>
			<tr style="color: #636363">
				<td align="center" style="width: 130px; height: 30px; background-color: #dcdcdc">
					Số điện thoại <br/> (전화번호)</td>
				<td style="background-color: #f5f5f5">
					<asp:TextBox ID="phone1" runat="server" MaxLength="4" ValidationGroup="AllValidators"
						Width="40px"></asp:TextBox>-<asp:TextBox ID="phone2" runat="server" MaxLength="3"
							ValidationGroup="AllValidators" Width="40px"></asp:TextBox>-<asp:TextBox ID="phone3"
								runat="server" MaxLength="4" ValidationGroup="AllValidators" Width="40px"></asp:TextBox>
				</td>
			</tr>			
			<tr>
				<td align="center" style="width: 130px; height: 30px; background-color: #dcdcdc">
					Công ty <br/> (업체)</td>
				<td style="background-color: #f5f5f5">
					<asp:TextBox ID="companyName" runat="server" ReadOnly="True" ValidationGroup="AllValidators"></asp:TextBox>
					<asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="~/images/icon/searchKor.gif"
						OnClick="ImageButton1_Click" OnClientClick='newWinByNameByScroll("../company/searchCompany.aspx","bbb","700","500"); return false;' />
					<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="companyName" Display="Dynamic" ErrorMessage="업체를 선택하여 주십시요" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%></td>
			</tr>
			<tr>
				<td align="center" style="width: 130px; background-color: #dcdcdc">
				</td>
				<td style="background-color: #f5f5f5">
<%--					<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="DarkBlue"
						ValidationGroup="AllValidators" />--%>
				</td>
			</tr>
			<tr>
				<td align="center" colspan="2" style="height: 26px; background-color: #ffffff">
				 <%--   <img src="../../images/icon/write.gif" style="cursor:hand" onclick="save()" alt="Đăng ký (등록하기)" />--%> 
					 <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/icon/write.gif"
						ValidationGroup="AllValidators" />
					<a href="#" onclick="history.go(-1);">
					<img alt="Quay lại (돌아가기)" src="../../images/icon/cancel.gif" style="border-top-style: none;
							border-right-style: none; border-left-style: none; border-bottom-style: none" /></a></td>
			</tr>
		</table>
		<asp:HiddenField ID="mode" runat="server" />
		<asp:HiddenField ID="companyCode" runat="server" />
        <asp:HiddenField ID="visitorCode" runat="server" />
        <asp:HiddenField ID="reject" runat="server" />
        
    </div>
        <asp:HiddenField ID="rejectContent" runat="server" />
    </form>
</body>
</html>
