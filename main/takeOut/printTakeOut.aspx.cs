using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;

public partial class main_takeOut_printTakeOut : System.Web.UI.Page
{
	TakeOutData bll = new TakeOutData();

    public String requestEmployeeDepartmentName;
    public String requestEmployeeDisplayName;
    public String elecApproveCode;
    public String requestEmployeeUpnid;
    public String requestEmployeeTitle;
    public String title;
    public String elecApporveHtml;
    public String takeOutItemListHtml;

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크 check login
        //EmployeeInfo loginEmployee = new EmployeeInfo();
        //loginEmployee = (EmployeeInfo)Session["loginMember"];
        //if (loginEmployee == null)
        //{
        //    Response.Redirect("~/login.aspx", true);
        //}

        if (this.Context.User.Identity.Name == null)
        {
            Response.Redirect("~/login.aspx", true);
        }
        EmployeeInfo requestEmployee = new EmployeeInfo();
        List<ElecStatusInfo> elecApproveInfo = new List<ElecStatusInfo>();
        List<TakeOutItemDataInfo> takeOutItem = new List<TakeOutItemDataInfo>();
 
        Employee bllEmployee = new Employee();
        ElecApprove bllElecApprove = new ElecApprove();
        TakeOutItemData bllTakeOutItem = new TakeOutItemData();
        
        //반출정보 thông tin tài sản ra cổng
		TakeOutDataInfo takeOutDataInfo = bll.selectTakeOutData(Request.QueryString["takeOutDataCode"]);

        // 전자결재
        elecApproveInfo = bllElecApprove.SelectStatus(takeOutDataInfo.ElecApproveCode);

        //반출 항목 hạng mục tài sản ra cổng
        takeOutItem = bllTakeOutItem.selectTakeOutItemDataList(takeOutDataInfo.TakeOutDataCode);

        //요청자 người yêu cầu
        requestEmployee = bllEmployee.selectEmployee(takeOutDataInfo.RequestUserCode);

        requestEmployeeDepartmentName = requestEmployee.Dep_name;
        requestEmployeeDisplayName = requestEmployee.DisplayName;
        requestEmployeeUpnid = requestEmployee.Upnid;
        requestEmployeeTitle = requestEmployee.Title_name;

		// 신청자 보이기
		lblDepartment.Text = takeOutDataInfo.RequestUserDepartment;
		lblUpnid.Text = takeOutDataInfo.RequestUserCode;
		lblDisplayName.Text = takeOutDataInfo.RequestUserDisplayName;
		lblTitle.Text = takeOutDataInfo.RequestUserTitleName;

        if (String.IsNullOrEmpty(requestEmployee.OfficePhoneNumber))
        {
            lblPhone.Text = "-";
        }
        else
        {
            lblPhone.Text = requestEmployee.OfficePhoneNumber;
        }
        
		// 반출 정보 보이기 thông tin tài sản ra cổng
		lblTakeOutDataCode.Text = takeOutDataInfo.TakeOutDataCode;
        lblScheduleOutDate.Text = takeOutDataInfo.ScheduleOutDate;
        lblTakeOutObject.Text = takeOutDataInfo.TakeOutObjectName;
        lblCompanyName.Text = takeOutDataInfo.CompanyName;
        lblReceiveName.Text = takeOutDataInfo.RecieveName;
        lblRequireIN.Text = bll.requireKor(takeOutDataInfo.RequireIN);
                
        if (String.IsNullOrEmpty(takeOutDataInfo.ScheduleInDate))
        {
            lblScheduleDate.Text = "-";
        }
        else
        {
            lblScheduleDate.Text = takeOutDataInfo.ScheduleInDate;
        }

        if (String.IsNullOrEmpty(takeOutDataInfo.ObjectContents))
        {
            lblTakeOutObjectContents.Text = "-";
        }
        else
        {
            lblTakeOutObjectContents.Text = takeOutDataInfo.ObjectContents;
        }

        if (String.IsNullOrEmpty(takeOutDataInfo.DisApprovalCategoryName))
        {
            lblDisApproveName.Text = "-";
        }
        else
        {
            lblDisApproveName.Text = takeOutDataInfo.DisApprovalCategoryName;
        }

        if (String.IsNullOrEmpty(takeOutDataInfo.Note))
        {
            lblNote.Text = "-";
        }
        else
        {
            lblNote.Text = takeOutDataInfo.Note;
        }

        
        // 결재정보 보이기 thông tin phê duyệt
        int count = elecApproveInfo.Count;

        for(int i=0 ; i < count ; i++)
        {
            // 결재의견이 없을때 "-" 채워줌. 셀의 border 때문에...  nếu không có ý kiến phê duyệt thì chèn "-"
            if (String.IsNullOrEmpty(elecApproveInfo[i].UserOpi))
            {
                elecApproveInfo[i].UserOpi = "-";
            }

            elecApporveHtml += "<tr align=\"center\">";
            elecApporveHtml += "<td style=\"border-color:Black;border-style:solid\" rowspan=\"2\">" + bllElecApprove.ElecApproveKor(elecApproveInfo[i].Decision) + "</td>";
            elecApporveHtml += "<td style=\"border-color:Black;border-style:solid\">" + elecApproveInfo[i].UserName + " " + elecApproveInfo[i].UserTitle + "</td>";
            elecApporveHtml += "<td style=\"border-color:Black;border-style:solid\" rowspan=\"2\">" + elecApproveInfo[i].DepName + "</td>";
            elecApporveHtml += "<td style=\"border-color:Black;border-style:solid\" rowspan=\"2\">" + elecApproveInfo[i].UserOpi + "</td>";
            elecApporveHtml += "</tr>";
            elecApporveHtml += "<tr align=\"center\">";
            elecApporveHtml += "<td style=\"border-color:Black;border-style:solid\">" + HanaMicron.COMS.Utility.DateUtility.getDateFormat2(Convert.ToDateTime(elecApproveInfo[i].ViewDate)) + "</td>";
            elecApporveHtml += "</tr>";
        }

        // 반출 항목 보이기 hạng mịc tài sản ra cổng
        int seq = 0;
        for (int i = 0; i < 10; i++) //항목 10개 만듬
        {
            seq = i + 1;
            if (i < takeOutItem.Count) //데이타 있는 만큼 데이타 뿌려줌. Đẩy dữ liệu tương ứng vào ô nhận dữ liệu
            {
                takeOutItemListHtml += "<tr align=\"center\">";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + seq + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].ParentCodeName + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].SubCodeName + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].TakeOutItemName + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].TakeOutItemType + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].UnitName + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + takeOutItem[i].Account + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "</tr>";
            }
            else //데이타 없는 부분 공백으로 채움. Cho khoảng trống vào những ô không có dữ liệu
            {
                takeOutItemListHtml += "<tr align=\"center\">";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">" + seq + "</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "<td style=\"border-color:Black;border-style:solid\">&nbsp;</td>";
                takeOutItemListHtml += "</tr>";
            }

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{

	}
}
