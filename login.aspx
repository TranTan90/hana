<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" Title="Yêu cầu đăng nhập (로그인이 필요합니다)." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
            </div>
            <div class="col">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 670px">
                            <table style="width: 100%">
                                <tr class="mb-3">
                                    <td class="contents_title " colspan="1">
                                    </td>
                                    <td colspan="2" class="contents_title " align="center" style="font-family:Arial; font-size:25px;">
                                        ACCOUNT LOGIN <br/> (로그인이 필요합니다)
                                    <br />
                                     
                                    </td>
                                                                  
                                </tr>
                                <br />
                                <br />
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 150px">
                                        ID (사번)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUpnid" runat="server" OnTextChanged="txtUpnid_TextChanged" CssClass="form-control col-7 mb-2"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUpnid" Display="Dynamic"
                                            ErrorMessage="Hãy nhập chính xác ID (사번을 정확히 입력하여 주십시요)">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 150px">
                                        Mật khẩu (비밀번호)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUpnpw" runat="server" TextMode="Password" OnTextChanged="txtUpnpw_TextChanged"
                                            CssClass="form-control col-7"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                runat="server" ControlToValidate="txtUpnpw" Display="Dynamic" ErrorMessage="Hãy nhập chính xác mật khẩu (비밀번호를 입력하여 주십시요)">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="1">
                                    </td>
                                    <td colspan="1" style="width: 150px">
                                        Lưu đăng nhập
                                        <br />
                                        (아이디 기억)
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkPersistCookie" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="1">
                                    </td>
                                    <td align="center" colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="DarkBlue" />
                                        <br />
                                        <asp:Button ID="submit" runat="server" CssClass="button btn btn-primary" OnClick="submit_Click" Text="Đăng nhập (로그인)" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col">
            </div>
        </div>
    </div>
</asp:Content>
