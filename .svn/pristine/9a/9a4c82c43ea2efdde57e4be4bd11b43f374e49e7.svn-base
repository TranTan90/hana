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
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;

public partial class main_visit_viewVisit : System.Web.UI.Page
{
    TakeOutData bll = new TakeOutData();

    public String loginEmploeeDepartmentName;
    public String loginEmploeeDisplayName;
    public String reqEmploeeDisplayName;
    public String elecApproveCode;
    public String loginEmployeeUpnid;
    public String loginEmployeeTitle;
    public String title;
   


    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크
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
        EmployeeInfo loginEmployee = new EmployeeInfo();
        EmployeeInfo requestEmployee = new EmployeeInfo();
        Employee bllEmployee = new Employee();
        loginEmployee = bllEmployee.selectEmployee(this.Context.User.Identity.Name);

        loginEmploeeDepartmentName = loginEmployee.Dep_name;
        loginEmploeeDisplayName = loginEmployee.DisplayName;
        loginEmployeeUpnid = loginEmployee.Upnid;
        loginEmployeeTitle = loginEmployee.Title_name;

        TakeOutDataInfo takeOutDataInfo = bll.selectTakeOutData(Request.QueryString["takeOutDataCode"]);

        //요청자
        requestEmployee = bllEmployee.selectEmployee(takeOutDataInfo.RequestUserCode);

        // 신청자 보이기 -Hiển thị người đăng ký
        lblDepartment.Text = takeOutDataInfo.RequestUserDepartment;
        lblUpnid.Text = takeOutDataInfo.RequestUserCode;
        lblOfficeName.Text = takeOutDataInfo.RequestUserOfficeName;
        lblDisplayName.Text = takeOutDataInfo.RequestUserDisplayName;
        lblTitle.Text = takeOutDataInfo.RequestUserTitleName;
        lblPhone.Text = requestEmployee.MobilePhoneNumber;

        // 결재 정보의 기안제목 신청자로 변경 (2009.08.27 임종우)
        reqEmploeeDisplayName = takeOutDataInfo.RequestUserDisplayName;

        // 반출 정보 보이기 -Hiển thị thông tin xuất
        lblTakeOutDataCode.Text = takeOutDataInfo.TakeOutDataCode;
        lblScheduleDate.Text = takeOutDataInfo.ScheduleInDate;
        lblScheduleOutDate.Text = takeOutDataInfo.ScheduleOutDate;
        lblTakeOutObject.Text = takeOutDataInfo.TakeOutObjectName;
        lblTakeOutObjectContents.Text = takeOutDataInfo.ObjectContents;
        lblTakeOutPathStart.Text = takeOutDataInfo.TakeOutPathStartName;
        lblTakeOutPathEnd.Text = takeOutDataInfo.TakeOutPathEndName;
        lblCompanyName.Text = takeOutDataInfo.CompanyName;
        lblReceiveName.Text = takeOutDataInfo.RecieveName;
        lblRequireIN.Text = bll.requireKor(takeOutDataInfo.RequireIN);
        lblOutTime.Text = takeOutDataInfo.TakeOutItemDataList[0].TakeOutTime;
        lblINTime.Text = takeOutDataInfo.TakeOutItemDataList[0].TakeINTime;
        lblNote.Text = takeOutDataInfo.Note;

        viewimage1.Visible = false;
        viewimage2.Visible = false;
        viewimage3.Visible = false;

        if (takeOutDataInfo.UserFile1.Length > 0)
        {
            viewimage1.Visible = true;

            viewimage1.ImageUrl = "~/image/" + takeOutDataInfo.UserFile1.ToString();
        }
        if (takeOutDataInfo.UserFile2.Length > 0)
        {
            viewimage2.Visible = true;
            viewimage2.ImageUrl = "~/image/" + takeOutDataInfo.UserFile2.ToString();
        }
        if (takeOutDataInfo.UserFile3.Length > 0)
        {
            viewimage3.Visible = true;
            viewimage3.ImageUrl = "~/image/" + takeOutDataInfo.UserFile3.ToString();
        }
        // 결재 코드
        elecApproveCode = takeOutDataInfo.ElecApproveCode;
        // 반입필이면 반입불가사유 안보임.
        if (takeOutDataInfo.RequireIN == 1)
        {
            lblDisApproveName.Text = string.Empty;
            lblDisApproveDetail.Text = string.Empty;
        }
        else
        {
            lblDisApproveName.Text = takeOutDataInfo.DisApprovalCategoryName;
            lblDisApproveDetail.Text = takeOutDataInfo.DisApprovalCategoryDetail;
        }

        lblCarNumber.Text = takeOutDataInfo.CarNumber;
        //lblINTime.Text = bll.timeKor(takeOutDataInfo.TakeINTime);
        //lblOutTime.Text = bll.timeKor(takeOutDataInfo.TakeOutTime);

        // 결재 상신 전이라면
        if (takeOutDataInfo.ApprovalState == 0)
        {
            // 결재라인 변경 이미지
            btnElecApproveLine.Visible = true;

            // 결재 상신 버튼
            btnApproveStart.Visible = true;

            // 결재 상태 보기
            btnElectStatus.Visible = false;

            // 반출증 출력
            btnPrint.Visible = false;

            // 반입일자 연장 신청
            btnReElecApproveLine.Visible = false;

        }
        else if (takeOutDataInfo.ApprovalState == 2) // 결재완료시
        {
            btnElectStatus.Visible = false;
            btnApproveStart.Visible = false;
            btnElecApproveLine.Visible = false;
            btnPrint.Visible = true;

            // 반출예정일이 지난 것들 반입일자 연장 신청 표시 --> 반입예정일 7일전부터 연장 표시로 변경
            if (takeOutDataInfo.RequireIN == 1 && takeOutDataInfo.TakeOutItemDataList[0].TakeINTime == "-" && takeOutDataInfo.TakeOutItemDataList[0].TakeOutTime != "-")
            {
                if (Convert.ToDateTime(takeOutDataInfo.ScheduleInDate) < DateTime.Now.AddDays(7))
                {
                    btnReElecApproveLine.Visible = true;
                }
                else
                {
                    btnReElecApproveLine.Visible = false;
                }
            }
            else
            {
                btnReElecApproveLine.Visible = false;
            }
        }
        else // 그 외에
        {
            btnElectStatus.Visible = false;
            btnApproveStart.Visible = false;
            btnElecApproveLine.Visible = false;
            btnPrint.Visible = false;
            btnReElecApproveLine.Visible = false;
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
