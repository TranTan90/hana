<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true"
    CodeFile="visitorEdit.aspx.cs" Inherits="Default2" Title="Đăng ký/ Sửa khách thăm (내방객 등록/수정)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

function change(){
    var f=document.forms[0];
    var our=document.getElementById('native');
    var other=document.getElementById('foreigner');

    if(f.rbutton[0].checked)
    {
        our.style.display='block';
        other.style.display='none';
    }
    if(f.rbutton[1].checked)
    {
        our.style.display='none';
        other.style.display='block';
    }
    if(f.rbutton[2].checked){
        alert("□Điều kiên đăng ký Free pass \n\n- Khách hàng, cơ quan công vụ \n\n\n□ Lộ trình phê duyệt\n\n- Trưởng phòng phê duyệt → GA Group (박민수 과장) thảo luận) (□ Free pass 신청 기준\n\n- 고객사 및 관공서 내방객\n\n\n□ 결재경로\n\n- 팀장 결재 → 총무그룹(박민수 과장) 합의)")
        our.style.display='none';
        other.style.display='none';
    }
 }
 
function rbcheck(){
    var check=<%=check%>;
    var f=document.forms[0];
    var our=document.getElementById('native');
    var other=document.getElementById('foreigner');
    
    if(check == "0")
    {
    // tắt display để hiện thị hộ chiếu : Phạm Hiền
        f.rbutton[0].checked=true;
        //our.style.display='block';
        //other.style.display='none';
    }
    
    if(check == "1")
    {
        f.rbutton[1].checked=true;
        //our.style.display='none';
        //other.style.display='block';
    }
    if(check == "2")
    {
        f.rbutton[2].checked=true;
       //our.style.display='none';
        //other.style.display='none';
    }
}

    </script>

    <script language="javascript" type="text/javascript" src="../../include/js/default.js"></script>

    <table style="width: 880px; clip: rect(auto auto auto auto)">
        <tr>
            <td colspan="2" style="height: 14px; background-color: #ffffff">
                <table>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h2>
                                <asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;</h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h2 style="font-size:15px">
                                <input name="rbutton" type="radio" value="0" onclick="javascript:change()" checked="CHECKED" />Việt Nam (내국인)
                                <input name="rbutton" type="radio" value="1" onclick="javascript:change()" />Khách nước ngoài (외국인)
                            </h2>
                        </td>
                        <td>
                            <h2 style="font-size:15px">
                                <input name="rbutton" type="radio" value="2" onclick="javascript:change()" />Free
                                pass
                            </h2>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="native" style="width: 100px; height: 30px; background-color: #dcdcdc">
                Tên (이름)</td>
            <td style="height: 26px; background-color: #f5f5f5">
                <asp:TextBox ID="visitorName" runat="server" ValidationGroup="AllValidators"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="visitorName" Display="Dynamic"
                    ErrorMessage="Hãy nhập tên khách thăm (내방객의 이름을 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000" id="native">
            <td style="width: 145px; height: 30px; background-color: #dcdcdc">
               Ngày, tháng, năm sinh<br />(생년월일)</td>
            <td style="height: 24px; background-color: #f5f5f5">
                <asp:TextBox ID="visitorRegNumber1" runat="server" MaxLength="7" ValidationGroup="AllValidators"
                    Width="50px"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server" ControlToValidate="visitorRegNumber1" Display="Dynamic" ErrorMessage="주민등록번호 앞자리를 입력하여 주십시요"
                        ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%>
                        <asp:TextBox ID="visitorRegNumber2"
                            runat="server" MaxLength="7" ValidationGroup="AllValidators" Width="60px" Visible="False"></asp:TextBox><%--<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="visitorRegNumber2" Display="Dynamic"
                                ErrorMessage="주민등록번호를 입력하여 주십시요" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr style="color: #000000" id="foreigner">
            <td style="width: 100px; height: 30px; background-color: #dcdcdc">
                Số hộ chiếu (여권번호)</td>
            <td style="height: 24px; background-color: #f5f5f5">
                <asp:TextBox ID="visitorPassportNumber" runat="server" MaxLength="7" ValidationGroup="AllValidators"
                    Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 30px; background-color: #dcdcdc">
                Số điện thoại (전화번호)</td>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="phone1" runat="server" MaxLength="4" ValidationGroup="AllValidators"
                    Width="40px"></asp:TextBox>-<asp:TextBox ID="phone2" runat="server" MaxLength="4"
                        ValidationGroup="AllValidators" Width="40px"></asp:TextBox>-<asp:TextBox ID="phone3"
                            runat="server" MaxLength="4" ValidationGroup="AllValidators" Width="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 30px; background-color: #dcdcdc">
                Công ty (업체)</td>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="companyName" runat="server" ReadOnly="True" ValidationGroup="AllValidators"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/searchKor.gif"
                    OnClientClick='newWin("../company/searchCompany.aspx","700","500"); return false;'
                    OnClick="ImageButton1_Click" ImageAlign="Middle" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 95px; background-color: #dcdcdc">
                Lý do từ chối thăm<br />(방문거부 사유)</td>
            <td style="height: 95px; background-color: #f5f5f5">
                <asp:CheckBox ID="reject" runat="server" ValidationGroup="AllValidators" />
                (Check nếu đăng ký từ chối thăm. (체크 하셔야 방문 거부자로 등록 됩니다))<br />
                <asp:TextBox ID="rejectContent" runat="server" Height="78px" TextMode="MultiLine"
                    ValidationGroup="AllValidators" Width="505px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc">
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
               <span style="position:absolute" ><a href="#" onclick="history.go(-1);">
                    <img alt="Quay lại (돌아가기)" src="../../images/icon/cancel.gif" style="border-top-style: none;
                        border-right-style: none; border-left-style: none; border-bottom-style: none" /></a></span></td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
rbcheck();
    </script>

    <asp:HiddenField ID="mode" runat="server" />
    <asp:HiddenField ID="companyCode" runat="server" />
</asp:Content>
