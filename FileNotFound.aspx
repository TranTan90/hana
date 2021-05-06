<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FileNotFound.aspx.cs" Inherits="FileNotFound" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
	<tr>
		<td>
			&nbsp;<img src="images/icon/error.gif" alt="" /></td>
		<td>
			<h2>Page Not Found</h2>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center">
            Không thể tìm tệp tin yêu cầu.<br />
            Hãy kiểm tra địa chỉ nhập có chính xác hay không.<br />
            Hãy click <a href="/COMS/Default.aspx">Ở đây</a> để chuyển đến main.<br />
            <br />
			요청하신 파일을 찾을 수 없습니다.<br />
			주소를 정확히 입력하셨는지 다시 한번 확인하여 주시기 바랍니다.<br />
			<br />
			<a href="/COMS/Default.aspx">여기</a>를 클릭하여 메인으로 이동하십시오.<br />
		</td>
	</tr>
</table>
</asp:Content>

