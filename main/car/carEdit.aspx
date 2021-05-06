<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carEdit.aspx.cs" Inherits="main_visit_visitorEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">
// 차량번호 숫자 체크  check số xe (chỉ số)
function numCheck(){
    var f=document.forms[0];
    
    if(isNaN(f.<%=number.ClientID%>.value)){
        alert('Chỉ nhập số (숫자만 입력하여 주세요)');
        f.<%=number.ClientID%>.focus();
        f.<%=number.ClientID%>.value='';
        return false;
        }
}

// 업체 검색 완료 hoàn thành tìm kiếm công ty
function addNameID(companyName,companyCode){
    var f=document.forms[0];
	f.<%=companyName.ClientID%>.value=companyName;    
    f.<%=companyCode.ClientID%>.value=companyCode;

    //document.forms[0].companyName.value=companyName;
	//document.forms[0].companyCode.value=companyCode;
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Đăng ký khách thăm (내방객 등록)</title>
    <link rel="stylesheet" href="../../include/css/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

		<script language="javascript" src="../../include/js/default.js" type="text/javascript"></script>

		<table style="width: 100%; clip: rect(auto auto auto auto)">
			<tr>
				<td colspan="2" style="height: 14px; background-color: #ffffff">
					<h2>
						<asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:Label>&nbsp;</h2>
				</td>
			</tr>
			<tr>
				<td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
					Loại xe <br /> (차 종)</td>
				<td style="height: 26px; background-color: #f5f5f5">
					<asp:DropDownList ID="carCategoryCode" runat="server" DataSourceID="ObjectDataSource1"
						DataTextField="CodeName" DataValueField="CarCategoryCode">
					</asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCarCategoryList"
						TypeName="HanaMicron.COMS.BLL.Car">
						<SelectParameters>
							<asp:Parameter Name="txtKey" Type="String" DefaultValue="A" />
						</SelectParameters>
					</asp:ObjectDataSource>
				</td>
			</tr>
			<tr>
				<td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
					Số xe <br /> (차량번호)</td>  <%--sửa giới hạn số nhập khi nhập biển số xe --%>
				<td style="height: 26px; background-color: #f5f5f5">
					<asp:TextBox ID="header" runat="server" ValidationGroup="AllValidators" Width="90px" MaxLength="4"></asp:TextBox> 
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="header"
						Display="Dynamic" ErrorMessage="Hãy nhập số trước của biển số xe (차량번호 앞자리를 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
					<asp:TextBox ID="number" runat="server" ValidationGroup="AllValidators" Width="50px" MaxLength="5"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="number"
						Display="Dynamic" ErrorMessage="Hãy nhập số sau của biển số xe (차량번호 뒷자리를 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                    (Ví dụ (예): 98A&nbsp; 12345)</td>
			</tr>
			<tr>
			    <td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
					Tên công ty <br /> (업체명)</td>
                <td style="background-color: #f5f5f5; height: 26px;">
                    <asp:TextBox ID="companyName" runat="server" ValidationGroup="AllValidators"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/searchKor.gif"
                        OnClientClick='newWin("../company/searchCompany.aspx","1000","500"); return false;'
                        OnClick="ImageButton1_Click" ImageAlign="Middle" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="number" ErrorMessage="Hãy nhập tên công ty (업체명을 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>

				<%--<td style="height: 26px; background-color: #f5f5f5">
					<asp:TextBox ID="company" runat="server" ValidationGroup="AllValidators" Width="149px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="company"
                        Display="Dynamic" ErrorMessage="업체명을 입력하여 주십시요" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator></td>--%>
			</tr>
			<tr>
				<td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
					Lái xe <br /> (운전자)</td>
				<td style="height: 26px; background-color: #f5f5f5">
					<asp:TextBox ID="handler" runat="server" ValidationGroup="AllValidators" Width="149px"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="handler"
                        Display="Dynamic" ErrorMessage="Hãy nhập lái xe (운전자를 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td align="center" style="width: 100px; background-color: #dcdcdc">
				</td>
				<td style="background-color: #f5f5f5">
					<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="DarkBlue"
						ValidationGroup="AllValidators" />
				</td>
			</tr>
			<tr>
				<td align="center" colspan="2" style="height: 26px; background-color: #ffffff">
					<asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/icon/write.gif"
						ValidationGroup="AllValidators" />
					<a href="#" onclick="self.close()">
						<img alt="Quay lại (돌아가기)" src="../../images/icon/cancel.gif" style="border-top-style: none;
							border-right-style: none; border-left-style: none; border-bottom-style: none" /></a></td>
			</tr>
		</table>
		<asp:HiddenField ID="mode" runat="server" />    
        <asp:HiddenField ID="companyCode" runat="server" />    
    </div>
    </form>
</body>
</html>
