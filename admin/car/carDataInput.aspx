<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="carDataInput.aspx.cs" Inherits="carDataInput" Title="Người quản lý xe (차량 관리자)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="/COMS/include/js/calendar.js"></script>
<script language="javascript" type="text/javascript">
var no=1; // 표시 이름 hiển thị tên
var displayCellCount=<%=displayCellCount%>; // 표시 해야 할 내방객 목록 수 (수정 시 Database 의 정보)   phải hiển thị số mục lục khách thăm (sửa ở thông tin của database)
var defaultCellCount=2; // 초기 내방객 목록 Default Count

// 차량번호 숫자 체크 check số xe (chỉ số)
function numCheck(){
    var f=document.forms[0];
    
    if(isNaN(f.<%=number.ClientID%>.value)){
        alert('Chỉ nhập số (숫자만 입력하여 주세요)');
        f.<%=number.ClientID%>.focus();
        f.<%=number.ClientID%>.value='';
        return false;
        }
}

// 운전자 추가 thêm lái xe
function insertRow(){
	var target=document.getElementById("handlerList");
	
	var newRow = target.insertRow(target.rows.length);
	
	var newCell = newRow.insertCell(0);
	newCell.innerHTML=no;
	var cell=document.createElement("input");
	cell.setAttribute('name','carHandlerCode');
	cell.setAttribute('type','hidden');
	newCell.appendChild(cell);
	
	newCell = newRow.insertCell(1);
	var cell=document.createElement("input");
	cell.setAttribute('name','chk');
	cell.setAttribute('type','checkbox');
	newCell.appendChild(cell);
	
	newCell = newRow.insertCell(2);
	var cell=document.createElement("input");
	cell.setAttribute('name','handlerName');
	cell.setAttribute('type','text');
	cell.setAttribute('class','input');
	cell.setAttribute('size','20');
	newCell.appendChild(cell);	

	newCell = newRow.insertCell(3);
	var cell=document.createElement("input");
	cell.setAttribute('name','phone');
	cell.setAttribute('type','text');
	cell.setAttribute('class','input');
	cell.setAttribute('size','15');
	newCell.appendChild(cell);

	no++;

}

// 운전자 선택 삭제  lựa chọn xóa lái xe
function deleteRow(){
	var target=document.getElementById("handlerList");
	for(var io=target.rows.length-1;io > 0;io--){
		if(target.rows[io].cells[1].children[0].checked){
			target.deleteRow(io);	
		}
	}
	//alert(target.rows.cells[2])
}


// save <-----------------------------------------------------------------------
function save(){	
	var f=document.forms[0];
		f.submit();
}

// 업체 검색 완료  hoàn thành tìm kiếm công ty 
function addNameID(companyName,companyCode){
    var f=document.forms[0];
	f.<%=companyName.ClientID%>.value=companyName;    
    f.<%=companyCode.ClientID%>.value=companyCode;

    //document.forms[0].companyName.value=companyName;
	//document.forms[0].companyCode.value=companyCode;
}

</script>
    <table style="width: 670px; clip: rect(auto auto auto auto);">
        <tr>
            <td colspan="2" style="height: 14px; background-color: #ffffff;">
                <h2><asp:Label ID="lableCodeName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:Label>&nbsp;</h2></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" align="center">
                Loại xe<br />(차종)</td>
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
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" align="center">
                Số xe<br />(차량번호)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="header" runat="server" ValidationGroup="AllValidators" Width="43px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="header"
                    Display="Dynamic" ErrorMessage="Nhập ký tự trước của biển số (차량번호 앞자리를 입력하여 주십시요)" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="number" runat="server" ValidationGroup="AllValidators" Width="97px" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="number" ErrorMessage="Nhập ký tự sau của biển số (차량번호 뒷자리를 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" align="center">
                Phân loại<br />(구분)</td>
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
            <td style="width: 100px; background-color: #dcdcdc; height: 30px;" align="center">
                Tên công ty<br />(업체명)</td>
            <td style="background-color: #f5f5f5; height: 26px;">
                <asp:TextBox ID="companyName" runat="server" ValidationGroup="AllValidators"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon/searchKor.gif"
                    OnClientClick='newWin("../company/searchCompany.aspx","700","500"); return false;'
                    OnClick="ImageButton1_Click" ImageAlign="Middle" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="number" ErrorMessage="Nhập tên công ty (업체명을 입력하여 주십시요)" ValidationGroup="AllValidators" Display="Dynamic">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="center" style="width: 100px; height: 30px; background-color: #dcdcdc">
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
        <tr><td>&nbsp</td></tr>
        <tr>
            <td colspan="2">
            	<table width="800" style="background-color:#cccccc" cellpadding="6" cellspacing="1" >
		        <tr style="background-color:#FFFFFF">
			        <td class="title" style="height: 29px"><strong>Thông tin lái xe (운전자 정보)</strong></td>
			        <td align="right" style="height: 29px">
				        <input id="Button1" type="button" value="Thêm 추가" onclick="insertRow()" />
				        <input id="Button2" type="button" value="Xóa 삭제" onclick="deleteRow()" /></td>
		        </tr>
		        <tr>
			        <td colspan="2" style="background-color:#FFFFFF">
				        <table id="handlerList" style="width: 100%" border="0">
				        <tr>
					        <td style="height: 21px">STT (순번)</td>
					        <td style="height: 21px">Lựa chọn (선택)</td>
					        <td style="height: 21px">Tên (성명)</td>
					        <td style="height: 21px">Liên lạc (연락처)</td>
				        </tr>
				        </table>
			        </td>
		        </tr>
	            </table>
	        </td>
        </tr>
        <tr>
            <td style="height: 26px; background-color: #ffffff;" align="center" colspan="2">
            			<img src="../../images/icon/write.gif" style="cursor:hand" onclick="save()" alt="Đăng ký (등록하기)" />
			<img src="../../images/icon/cancel.gif" style="cursor:hand" onclick="history.go(-1)" alt="Hủy bỏ (취소하기)" />
      <%--          <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/icon/write.gif"
                    ValidationGroup="AllValidators" />
                --%><%--<a href="#" onclick="history.go(-1);"><img src="../../images/icon/cancel.gif" alt="Quay lại 돌아가기" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" /></a>--%>
                </td>
        </tr>
    </table>
    <asp:HiddenField ID="mode" runat="server" />
    <asp:HiddenField ID="companyCode" runat="server" />

<script language="javascript" type="text/javascript">

var carHandlerCode=new Array();
var handler=new Array();
var handlerPhone=new Array();

<%=arryCarHandlerList%>

//로딩하면서 초기 화면에 뿌리기 
function display(displayCellCount){ 
    if(!displayCellCount) displayCellCount=defaultCellCount;
    for(var cellCount=0;cellCount<displayCellCount;cellCount++){
	    insertRow();
    }
}

function dataBind(){
    var target=document.getElementById("handlerList");
    for(var i=0;i<carHandlerCode.length+1;i++){
	    var rowCount=i+1;
	    if(carHandlerCode[i]){
	        target.rows[rowCount].cells[0].children[0].value=carHandlerCode[i];
		    target.rows[rowCount].cells[2].children[0].value=handler[i];
		    target.rows[rowCount].cells[3].children[0].value=handlerPhone[i];			
	    }
    }
}

display(displayCellCount);
dataBind();
</script>
</asp:Content>

