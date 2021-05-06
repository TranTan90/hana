<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GenericErrorPage.aspx.cs" Inherits="GenericErrorPage" Title="System Error " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table>
	<tr>
		<td>
			<asp:Image ID="Image1" runat="server" ImageUrl="images/icon/error01.gif"></asp:Image>
		</td>
		<td>
			<h2>System Error</h2>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center">
        	Đã xuất hiện lỗi.<br />
			Lỗi này hiện tại chưa thể khắc phục được.<br />
			Hãy gửi mail cho người quản lý hệ thống về nội dung lỗi.<br />
			오류가 발생하였습니다.<br />
			현재 발생한 오류는 복구 할 수 없는 오류입니다.<br />
			System 관리자에게 오류 내용을 메일로 발송하였습니다.<br />
		</td>
	</tr>
</table>

</asp:Content>


