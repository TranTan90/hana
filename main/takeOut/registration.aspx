<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="main_takeOut_registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 670px; clip: rect(auto auto auto auto);">
            <tr>
                <td style="width: 145px; background-color: #dcdcdc; height: 30px; font-weight: bold;">
                    Tên công ty<br />
                    (회사명)
                </td>
                <td style="background-color: #f5f5f5; height: 30px;">
                    <asp:TextBox ID="companyName" runat="server" ValidationGroup="AllValidators"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="companyName" ErrorMessage="Hãy nhập tên công ty (회사명을 입력하여 주십시요)"
                        ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #dcdcdc; height: 30px; font-weight: bold;">
                    Số đăng ký kinh doanh<br />
                    (사업자 등록번호)
                </td>
                <td style="background-color: #f5f5f5; height: 24px;">
                    <asp:TextBox ID="regNumber1" runat="server" MaxLength="3" ValidationGroup="AllValidators"
                        Width="50px"></asp:TextBox>-
                    <asp:TextBox ID="regNumber2" runat="server" MaxLength="2" ValidationGroup="AllValidators"
                        Width="40px"></asp:TextBox>-
                    <asp:TextBox ID="regNumber3" runat="server" MaxLength="5" ValidationGroup="AllValidators"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="regNumber1"
                        Display="Dynamic" ErrorMessage="Hãy nhập số đăng ký kinh doanh (사업자등록 번호를 입력하여 주십시요)"
                        Height="14px" ValidationGroup="AllValidators" Width="1px">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="regNumber2"
                        Display="Dynamic" ErrorMessage="Hãy nhập số đăng ký kinh doanh (사업자등록 번호를 입력하여 주십시요)"
                        Height="14px" ValidationGroup="AllValidators" Width="1px">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="regNumber3"
                        Display="Dynamic" ErrorMessage="Hãy nhập số đăng ký kinh doanh (사업자등록 번호를 입력하여 주십시요)"
                        Height="14px" ValidationGroup="AllValidators" Width="1px">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #dcdcdc; height: 30px; font-weight: bold;">
                    Số điện thoại<br />
                    (전화번호)
                </td>
                <td style="background-color: #f5f5f5;">
                    <%--2021-03-24 Nguyen Van An: phonenumber 12number -> 10number  --%>
                    <asp:TextBox ID="phone1" runat="server" ValidationGroup="AllValidators" Width="40px"
                        MaxLength="4"></asp:TextBox>-<asp:TextBox ID="phone2" runat="server" ValidationGroup="AllValidators"
                            Width="40px" MaxLength="3"></asp:TextBox>-<asp:TextBox ID="phone3" runat="server"
                                ValidationGroup="AllValidators" Width="40px" MaxLength="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #dcdcdc; height: 30px; font-weight: bold;">
                    Người đại diện<br />
                    (대표자명)
                </td>
                <td style="background-color: #f5f5f5">
                    <asp:TextBox ID="masterName" runat="server" ValidationGroup="AllValidators"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #dcdcdc; height: 32px; font-weight: bold;">
                    Địa chỉ<br />
                    (주소)
                </td>
                <td style="background-color: #f5f5f5; height: 32px;">
                    <asp:TextBox ID="address" runat="server" ValidationGroup="AllValidators" Width="354px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="address"
                        Display="Dynamic" ErrorMessage="Hãy nhập địa chỉ (주소를 입력하여 주십시요)" Height="14px"
                        ValidationGroup="AllValidators" Width="1px">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #dcdcdc;" align="center">
                </td>
                <td style="background-color: #f5f5f5">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators"
                        ForeColor="DarkBlue" />
                </td>
            </tr>
            <tr>
                <td style="height: 26px; background-color: #ffffff;" align="center" colspan="2">
                    * Trường hợp nhập thông tin cơ bản của công ty đến thăm không được chấp nhận.
                    <br />
                    (내방 업체의 기초정보를 오기입할 경우 승인이 불가합니다.)<br />
                    (Liên hệ: GA Gruop ParkMinSu(1130) (문의: 총무그룹 박민수 차장(1130)))
                </td>
            </tr>
            <tr>
                <td style="height: 26px; background-color: #ffffff;" align="center" colspan="2">
                    <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/icon/write.gif"
                        ValidationGroup="AllValidators" />
                    <a href="#" onclick="history.go(-1);">
                        <img src="../../images/icon/cancel.gif" alt="Quay lại (돌아가기)" style="border-style: none;
                            height: 25px;" /></a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
