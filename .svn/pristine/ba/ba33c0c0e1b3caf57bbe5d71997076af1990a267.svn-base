<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="carDataEdit.aspx.cs" Inherits="_Default" Title="Người quản lý xe (차량 관리자)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../../include/js/calendar.js"></script>
<script language="javascript" type="text/javascript">

// 차량번호 숫자 체크  check số xe
function numCheck(){
    var f=document.forms[0];
    
    if(isNaN(f.<%=number.ClientID%>.value)){
        alert('Chỉ nhập số (숫자만 입력하여 주세요)');
        f.<%=number.ClientID%>.focus();
        f.<%=number.ClientID%>.value='';
        return false;
        }
}

// save <-----------------------------------------------------------------------
function save(){	
	var f=document.forms[0];
		f.submit();
}

// 업체 검색 완료   hoàn thành tìm kiếm công ty
function addNameID(companyName,companyCode){
    var f=document.forms[0];
	f.<%=companyName.ClientID%>.value=companyName;    
    f.<%=companyCode.ClientID%>.value=companyCode;

    //document.forms[0].companyName.value=companyName;
	//document.forms[0].companyCode.value=companyCode;
}

</script>

    <script language="javascript" type="text/javascript" src="../../include/js/default.js"></script>

    <table style="width: 670px; clip: rect(auto auto auto auto);">
        <tr>
            <td colspan="2" style="height: 14px; background-color: #ffffff;">
                <h2><asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:Label>&nbsp;</h2></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
                Loại xe (차종)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:DropDownList ID="carCategoryCode" runat="server" DataSourceID="ObjectDataSource1" DataTextField="CodeName" DataValueField="CarCategoryCode">
                </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCarCategoryList"
					TypeName="HanaMicron.COMS.BLL.Car">
					<SelectParameters>
						<asp:Parameter Name="txtKey" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
                Số xe (차량번호)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="header" runat="server" ValidationGroup="AllValidators" Width="43px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="header"
                    Display="Dynamic" ErrorMessage="Nhập ký tự trước của biển số (차량번호 앞자리를 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="number" runat="server" ValidationGroup="AllValidators" Width="97px" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="number" ErrorMessage="Nhập ký tự sau của biển số (차량번호 뒷자리를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
                Phân loại (구분)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:DropDownList ID="carType" runat="server">
                    <asp:ListItem Value="1">Xe giao hàng (납품차)</asp:ListItem>
                    <asp:ListItem Value="2">Xe nhân viên (임직원차)</asp:ListItem>
                    <asp:ListItem Value="3">Xe công vụ (업무차)</asp:ListItem>
                    <asp:ListItem Value="4">Xe khách hàng (내방객차)</asp:ListItem>
                    <asp:ListItem Value="5">Khác (기타)</asp:ListItem>
                </asp:DropDownList>
			</td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
                Tên công ty<br />(업체명)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="companyName" runat="server" ValidationGroup="AllValidators" Width="180px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/searchKor.gif"
                    OnClientClick='newWin("../company/searchCompany.aspx","700","500"); return false;'
                    OnClick="ImageButton1_Click" ImageAlign="Middle" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="number" ErrorMessage="Hãy nhập tên công ty (업체명을 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td  style="width: 100px; height: 30px; background-color: #dcdcdc">
                Từ chối thăm<br />(방문 거부)</td>
            <td style="height: 30px; background-color: #f5f5f5">
                <asp:CheckBox ID="reject" runat="server" />(Check phần này nếu đăng ký từ chối thăm (체크 하시면 방문 거부자에 등록 됩니다).)<br />
                <asp:TextBox ID="rejectContent" runat="server" Height="100px" Width="429px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc;" align="center">
                </td>
            <td style="background-color: #f5f5f5">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators" ForeColor="DarkBlue" />
                
                </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td colspan="2"><iframe src="carHandlerList.aspx?carCode=<%=carCode%>" width="1300" height="400"></iframe></td></tr>
        <tr>
            <td style="height: 26px; background-color: #ffffff;" align="center" colspan="2">
        		<img src="../../images/icon/write.gif" style="cursor:hand" onclick="save()" alt="Đăng ký (등록하기)" />
    			<img src="../../images/icon/cancel.gif" style="cursor:hand" onclick="history.go(-1)" alt="Hủy bỏ (취소하기)" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="mode" runat="server" />    
    <asp:HiddenField ID="companyCode" runat="server" />
    
</asp:Content>

