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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee=(EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx",true);
		}
    }

	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitDataInfo obj = (VisitDataInfo)e.Row.DataItem;
			e.Row.Cells[0].Text = obj.RegDate.ToString("yyyy.MM.dd");
			e.Row.Cells[1].Text = obj.VisitorDataInfoList[0].VisitDate;
			e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].InTime;
			e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].OutTime;
			e.Row.Cells[4].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorName;
			e.Row.Cells[5].Text = obj.VisitorDataInfoList[0].CompanyInfo.CompanyName;
			e.Row.Cells[6].Text = obj.ReqEmployeeInfo.Dep_name;
			e.Row.Cells[7].Text = obj.ReqEmployeeInfo.DisplayName;
			e.Row.Cells[8].Text = obj.InterviewEmployeeInfo.DisplayName;
			e.Row.Cells[9].Text = obj.VisitObjectInfo.VisitObjectName;

			e.Row.Cells[10].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number;
           

			VisitData bll = new VisitData();

			// 상태
			String approveString = bll.getApproveStringKOR(obj);
			e.Row.Cells[11].Text = approveString;

			e.Row.Cells[12].Text = obj.InSecurityEmployeeInfo.DisplayName;
			e.Row.Cells[13].Text = obj.OutSecurityEmployeeInfo.DisplayName;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 12)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='visitDataView.aspx?visitDataCode=" + obj.VisitDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }
			e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
			e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        
		}

		

	}

    protected void GridViewExcel_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            VisitDataInfo obj = (VisitDataInfo)e.Row.DataItem;
            e.Row.Cells[0].Text = obj.OfficeInfo.OfficeName;
            e.Row.Cells[1].Text = obj.VisitorDataInfoList[0].VisitDate;
            e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorName;
            //e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1 + " - " + obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber2;
            e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1;
            e.Row.Cells[4].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone1 + " " + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone2 + " " + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone3;
            e.Row.Cells[5].Text = obj.VisitorDataInfoList[0].CompanyInfo.CompanyName;
            e.Row.Cells[6].Text = obj.CarDataInfo.CodeName;
            e.Row.Cells[7].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number;
            e.Row.Cells[8].Text = obj.VisitObjectInfo.VisitObjectName;
            e.Row.Cells[9].Text = obj.VisitObjectContents;

            e.Row.Cells[10].Text = obj.VisitorDataInfoList[0].InTime;
            e.Row.Cells[11].Text = obj.VisitorDataInfoList[0].OutTime;
            e.Row.Cells[12].Text = obj.ReqEmployeeInfo.DisplayName;
            e.Row.Cells[13].Text = obj.ReqEmployeeInfo.Upnid;
            e.Row.Cells[14].Text = obj.ReqEmployeeInfo.Title_name;
            e.Row.Cells[15].Text = obj.ReqEmployeeInfo.Dep_name;
            e.Row.Cells[16].Text = obj.ReqEmployeeInfo.MobilePhoneNumber;
            e.Row.Cells[17].Text = obj.InterviewEmployeeInfo.DisplayName;
            e.Row.Cells[18].Text = obj.InterviewEmployeeInfo.Upnid;

            VisitData bll = new VisitData();

            // 상태
            String approveString = bll.getApproveStringKOR(obj);
            e.Row.Cells[19].Text = approveString;

            e.Row.Cells[20].Text = obj.InSecurityEmployeeInfo.DisplayName;
            e.Row.Cells[21].Text = obj.OutSecurityEmployeeInfo.DisplayName;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 13)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='visitDataView.aspx?visitDataCode=" + obj.VisitDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }



    }

	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Visit_Data_List.xls";
		GridViewExportUtil.Export(fileName, this.GridViewExcel);
	}
}
