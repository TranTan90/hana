<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="unitEdit.aspx.cs" Inherits="_Default" Title="Quản lý tên tòa nhà (건물명 관리)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 670px; clip: rect(auto auto auto auto);">
        <tr>
            <td colspan="2" style="background-color: #ffffff;">
                <asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 145px; background-color: #dcdcdc; height: 30px;" >
				Tên (이름)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="txtCodeName" runat="server" ValidationGroup="AllValidators"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodeName" ErrorMessage="Hãy nhập tên (이름을 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 145px; background-color: #dcdcdc; height: 30px;" >
				Có sử dụng hay không<br />(사용유무)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="txtStatus" runat="server" ValidationGroup="AllValidators"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStatus" ErrorMessage="Hãy nhập thông tin sử dụng (사용유무를 입력해주세요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
                <span style="color: #ff0066">(Chỉ nhập Y hoặc N (Y, N으로만 입력))</span></td>
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

