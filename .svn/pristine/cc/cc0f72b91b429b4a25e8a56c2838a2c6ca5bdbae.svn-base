<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="visitDataView.aspx.cs" Inherits="main_visit_viewVisit" Title="Xem chi tiết (상세 보기)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin người đăng ký (신청자정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Bộ phận (부서명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				ID (사번)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblUpnid" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi làm việc (사업장)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Họ tên (성명)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblDisplayName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Chức vụ (직급)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblTitle" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Liên lạc (연락처)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblPhone" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
	<br />
	<table width="100%" cellpadding="6" cellspacing="1" style="background-color:#CCCCCC">
		<tr>
			<td colspan="6" class="contents_title" style="background-color:#FFFFFF">
				<img src="../../images/basic/icon_02.gif" alt="icon" style="vertical-align:middle">Thông tin khách thăm (내방 정보)
			</td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Mục đích đến (방문 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Chi tiết mục đích (세부 목적)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblVisitObjectContents" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Người đón tiếp (접견자)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblInterviewUserName" runat="server"></asp:Label></td>
			<td style="background-color:#F5F5F5">
				Nơi đón tiếp (접견장소)
			</td>
			<td style="background-color:#FFFFFF">
				<asp:Label ID="lblOfficeNameDetail" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="background-color:#F5F5F5">
				Số xe (차량 번호)
			</td>
			<td style="background-color:#FFFFFF" colspan="3">
				<asp:Label ID="lblCarNumber" runat="server"></asp:Label></td>
		</tr>
	</table>
	<br />
	<br />
	<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
		BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
		CellPadding="4" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound" Width="100%">
		<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
		<Columns>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Họ tên (성명)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Ngày, tháng, năm sinh (생년월일)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Liên lạc (연락처)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Ngày đến (방문일)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Thời gian xử lý vào (입문 처리 시간)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
			<asp:BoundField DataField="VisitorDataCode" HeaderText="Thời gian xử lý ra (출문 처리 시간)">
				<ItemStyle HorizontalAlign="Center" />
				<HeaderStyle HorizontalAlign="center" />
			</asp:BoundField>
		</Columns>
		<RowStyle BackColor="White" ForeColor="#003399" />
		<SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
		<PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
		<HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
	</asp:GridView>
	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectVisitorDataList"
		TypeName="HanaMicron.COMS.BLL.VisitorData">
		<SelectParameters>
			<asp:QueryStringParameter Name="visitDataCode" QueryStringField="visitDataCode" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<br />
	<br />
	
	

	<table width="100%" cellpadding="6" cellspacing="1" id="approveBtnTable" style="display:block">
		<tr>
			<td align="center">
				<input type="button" value="Xác nhận (확인)" onclick="history.go(-1)" />
			</td>
		</tr>
	</table>
</asp:Content>

