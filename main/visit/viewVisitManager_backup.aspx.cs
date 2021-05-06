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
	VisitData bll = new VisitData();
    VisitorData bllVisitorData = new VisitorData();

	public String loginEmploeeDepartmentName;
	public String loginEmploeeDisplayName;
	public String elecApproveCode;
	public String loginEmployeeUpnid;
	public String loginEmployeeTitle;

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크    check login
		if (this.Context.User.Identity.Name == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
		EmployeeInfo loginEmployee = new EmployeeInfo();
		Employee bllEmployee = new Employee();
		loginEmployee = bllEmployee.selectEmployee(this.Context.User.Identity.Name);

		loginEmploeeDepartmentName = loginEmployee.Dep_name;
		loginEmploeeDisplayName = loginEmployee.DisplayName;
		loginEmployeeUpnid = loginEmployee.Upnid;
		loginEmployeeTitle = loginEmployee.Title_name;

        VisitDataInfo visitDataInfo = bll.selectVisitData(Request.QueryString["visitDataCode"]);
        VisitorDataInfo visitorDataInfo = bllVisitorData.selectVisitorData(Request.QueryString["visitorDataCode"]);

		// 임직원 정보 보이기 xem nhân viên
		lblDepartment.Text = visitDataInfo.ReqEmployeeInfo.Dep_name;
		lblUpnid.Text = visitDataInfo.ReqEmployeeInfo.Upnid;
		lblOfficeName.Text = visitDataInfo.ReqEmployeeInfo.OfficeName;
		lblDisplayName.Text = visitDataInfo.ReqEmployeeInfo.DisplayName;
		lblTitle.Text = visitDataInfo.ReqEmployeeInfo.Title_name;
		lblPhone.Text = visitDataInfo.ReqEmployeeInfo.MobilePhoneNumber;

		// 입문 출문 시간 보이기 (보안실 or Admin) thời gian vào/ ra (bảo an, admin)
		// 보안 요원 체크 check yêu cầu bảo an
		if (loginEmployee.ManagerLevel < 0) pnlSecurity.Visible = false;
		else pnlSecurity.Visible = true;

		// 내방 정보 보이기   xem thông tin khách thăm
		lblVisitObjectName.Text = visitDataInfo.VisitObjectInfo.VisitObjectName;
		lblVisitObjectContents.Text = visitDataInfo.VisitObjectContents;
		lblInterviewUserName.Text = visitDataInfo.InterviewEmployeeInfo.DisplayName;

		// 결재 코드
		elecApproveCode = visitDataInfo.ElecApproveCode;

		// 결재라인 가져오기
		HtmlGenericControl body = Master.FindControl("body") as HtmlGenericControl;
		if (body != null) body.Attributes["onload"] = ShowApproveLine();

		lblOfficeNameDetail.Text = visitDataInfo.OfficeInfo.OfficeName + " " + visitDataInfo.OfficeContents;
		lblCarNumber.Text = visitDataInfo.CarDataInfo.Header + "  " + visitDataInfo.CarDataInfo.Number + " " + visitDataInfo.CarDataInfo.CarCode;

		//// 내방객의 입문 시간
        //if (String.IsNullOrEmpty(visitorDataInfo.InTime)) lblInTime.Text = "";
        //else lblInTime.Text = visitorDataInfo.InTime.ToString();
        lblInTime.Text = visitorDataInfo.InTime;

		//// 내방객의 출문 시간이 없다면
		//if (visitDataInfo.OutTime.Year == 1) lblOutTime.Text = "";
		//else lblOutTime.Text = visitDataInfo.OutTime.ToString();
        lblOutTime.Text = visitorDataInfo.OutTime;

		// 첨부 파일 정보  thông tin tệp đính kèm
		if (!String.IsNullOrEmpty(visitDataInfo.UserFile1))
		{
			String[] arrUserFile1 = visitDataInfo.UserFile1.Split('|');
			lblUserFile1.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + arrUserFile1[0] + "' target='_blank'>" + arrUserFile1[0] + "</a>";
		}

		if (!String.IsNullOrEmpty(visitDataInfo.UserFile2))
		{
			String[] arrUserFile2 = visitDataInfo.UserFile2.Split('|');
			lblUserFile2.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + arrUserFile2[0] + "' target='_blank'>" + arrUserFile2[0] + "</a>";
		}

		if (!String.IsNullOrEmpty(visitDataInfo.UserFile3))
		{
			String[] arrUserFile3 = visitDataInfo.UserFile3.Split('|');
			lblUserFile3.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + arrUserFile3[0] + "' target='_blank'>" + arrUserFile3[0] + "</a>";
		}


		// 결재 상신 전이라면
		if (visitDataInfo.ApprovalState == 0)
		{
			// 결재라인 변경 이미지
			btnElecApproveLine.Visible = true;

			// 결재 상신 버튼
			btnApproveStart.Visible = true;
		}
		else
		{
			btnApproveStart.Visible = false;
			btnElecApproveLine.Visible = false;
		}

    }

	private string ShowApproveLine()
	{
		return "showApproveLine();";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{

		if (e.Row.RowType == DataControlRowType.DataRow)
		{

			VisitorDataInfo obj = (VisitorDataInfo)e.Row.DataItem;

			e.Row.Cells[0].Text = obj.VisitorInfo.VisitorName;

            if (String.IsNullOrEmpty(obj.VisitorInfo.VisitorPassportNumber))
            {
                //e.Row.Cells[1].Text = obj.VisitorInfo.VisitorRegNumber1 + obj.VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***";
                e.Row.Cells[1].Text = obj.VisitorInfo.VisitorRegNumber1;
            }
            else
            {
                e.Row.Cells[1].Text = obj.VisitorInfo.VisitorPassportNumber;
            }
            //e.Row.Cells[2].Text = obj.VisitorInfo.VisitorPassportNumber;
			e.Row.Cells[2].Text = obj.CompanyInfo.CompanyName;
			e.Row.Cells[3].Text = obj.VisitorInfo.VisitorPhone1 + "-" + obj.VisitorInfo.VisitorPhone2 + "-" + obj.VisitorInfo.VisitorPhone3;

			//e.Row.Cells[1].Text = obj.VisitorRegNumber1 + " - " + obj.VisitorRegNumber2.Substring(0,4)+"***";
			//e.Row.Cells[4].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;
		}
	}

	protected void btnApproveStart_Click(object sender, EventArgs e)
	{
		VisitDataInfo obj = bll.selectVisitData(Request.QueryString["visitDataCode"]);
		String elecApproveContents=bll.MakeElecApproveContents(obj);
	}
}
