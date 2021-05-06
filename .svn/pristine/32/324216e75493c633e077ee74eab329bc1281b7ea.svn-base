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

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		// 내방 보안 요원
		Employee bllEmployee = new Employee();
		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx", true);
		}

		VisitDataInfo visitDataInfo = bll.selectVisitData(Request.QueryString["visitDataCode"]);

		// 임직원 정보 보이기
		lblDepartment.Text = visitDataInfo.ReqEmployeeInfo.Dep_name;
		lblUpnid.Text = visitDataInfo.ReqEmployeeInfo.Upnid;
		lblOfficeName.Text = visitDataInfo.OfficeInfo.OfficeName;
		lblDisplayName.Text = visitDataInfo.ReqEmployeeInfo.DisplayName;
        lblTitle.Text = visitDataInfo.ReqEmployeeInfo.Title_name;
		lblPhone.Text = visitDataInfo.ReqEmployeeInfo.MobilePhoneNumber;

		// 내방 정보 보이기
		lblVisitObjectName.Text = visitDataInfo.VisitObjectInfo.VisitObjectName;
		lblVisitObjectContents.Text = visitDataInfo.VisitObjectContents;
		lblInterviewUserName.Text = visitDataInfo.InterviewEmployeeInfo.DisplayName;

		lblOfficeNameDetail.Text = visitDataInfo.OfficeInfo.OfficeName + " " + visitDataInfo.OfficeContents;
		lblCarNumber.Text = visitDataInfo.CarDataInfo.Header + "  " + visitDataInfo.CarDataInfo.Number;
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitorDataInfo obj = (VisitorDataInfo)e.Row.DataItem;
			e.Row.Cells[0].Text=obj.VisitorInfo.VisitorName;

            if (String.IsNullOrEmpty(obj.VisitorInfo.VisitorPassportNumber))
            {
                //e.Row.Cells[1].Text = obj.VisitorInfo.VisitorRegNumber1 + obj.VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***";
                e.Row.Cells[1].Text = obj.VisitorInfo.VisitorRegNumber1;
            }
            else
            {
                e.Row.Cells[1].Text = obj.VisitorInfo.VisitorPassportNumber;
            }
			e.Row.Cells[2].Text = obj.VisitorInfo.VisitorPhone1 + "-" + obj.VisitorInfo.VisitorPhone2 + "-" + obj.VisitorInfo.VisitorPhone3;
			e.Row.Cells[3].Text = obj.VisitDate;
			e.Row.Cells[4].Text = obj.InTime;
			e.Row.Cells[5].Text = obj.OutTime;


			//e.Row.Cells[1].Text = obj.VisitorInfo.VisitorRegNumber1 + " - " + obj.VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***";
			//e.Row.Cells[4].Text = obj.VisitorInfo.VisitorPhone1 + "-" + obj.VisitorInfo.VisitorPhone2 + "-" + obj.VisitorInfo.VisitorPhone3;
		}
	}
}
