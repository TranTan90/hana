<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="companyEdit.aspx.cs" Inherits="_Default" Title="Sửa/ đăng ký công ty (업체 등록/수정)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 670px; clip: rect(auto auto auto auto);">
        <tr>
            <td colspan="2" style="height: 14px; background-color: #ffffff;">
                <h2><asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>&nbsp;</h2></td>
        </tr>
        <tr>
            <td style="width: 145px; background-color: #dcdcdc; height: 30px;">
                Tên công ty (회사명)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="companyName" runat="server" ValidationGroup="AllValidators"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="companyName" ErrorMessage="Hãy nhập tên công ty (회사명을 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 145px; background-color: #dcdcdc; height: 30px;">
                Mã đăng ký kinh doanh<br />(사업자 등록번호)</td>
            <td style="background-color: #f5f5f5; height: 24px;">
                <asp:TextBox ID="regNumber1" runat="server" MaxLength="3" ValidationGroup="AllValidators" Width="50px"></asp:TextBox>-
                <asp:TextBox ID="regNumber2" runat="server" MaxLength="2" ValidationGroup="AllValidators" Width="40px"></asp:TextBox>-
                <asp:TextBox ID="regNumber3" runat="server" MaxLength="5" ValidationGroup="AllValidators" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="regNumber1" ErrorMessage="Hãy nhập mã đăng ký kinh doanh (사업자 등록번호를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="regNumber2" ErrorMessage="Hãy nhập mã đăng ký kinh doanh (사업자 등록번호를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="regNumber3" ErrorMessage="Hãy nhập mã đăng ký kinh doanh (사업자 등록번호를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
                Số điện thoại (전화번호)</td>
            <td style="background-color: #f5f5f5;">
                <asp:TextBox ID="phone1" runat="server" ValidationGroup="AllValidators" Width="40px" MaxLength="4"></asp:TextBox>-<asp:TextBox ID="phone2" runat="server" ValidationGroup="AllValidators" Width="40px" MaxLength="4"></asp:TextBox>-<asp:TextBox ID="phone3" runat="server" ValidationGroup="AllValidators" Width="40px" MaxLength="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;">
                Tên người đại diện<br />(대표자 명)</td>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="masterName" runat="server" ValidationGroup="AllValidators"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;">
               Địa chỉ (주소)</td>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="address" runat="server" ValidationGroup="AllValidators" Width="354px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address" ErrorMessage="Hãy nhập địa chỉ (주소를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" >
               사업장관리번호</td>                                                                                                                <%-- fdsfdsf--%>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="companyManagementNo" runat="server" ValidationGroup="AllValidators" Width="160px" MaxLength="12"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;">
               사업개시번호</td>                                                                                                                  <%-- dsfsdfdsf--%>
            <td style="background-color: #f5f5f5">
                <asp:TextBox ID="companyStartNo" runat="server" ValidationGroup="AllValidators" Width="160px" MaxLength="9"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc;" align="center">
                </td>
            <td style="background-color: #f5f5f5">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators" ForeColor="DarkBlue" />
                
                </td>
        </tr>
        <tr>
            <td style="height: 26px; background-color: #ffffff;" align="center" colspan="2">
                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/icon/write.gif"
                    ValidationGroup="AllValidators" />
                <span style="position:absolute"><a href="#" onclick="history.go(-1);"><img src="../../images/icon/cancel.gif" alt="Quay lại (돌아가기)" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" /></a></span></td>
        </tr>
    </table>
    <asp:HiddenField ID="mode" runat="server" />
</asp:Content>

