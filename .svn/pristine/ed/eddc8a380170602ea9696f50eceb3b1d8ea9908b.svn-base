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
using HanaMicron.COMS.Model;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Utility;
using System.Collections.Generic;
using System.Globalization;

public partial class main_visit_listVisit : System.Web.UI.Page
{

	private VisitData bll = new VisitData();
    string a = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CultureInfo ciLang = new CultureInfo("en-EN");
        Resources.resLanguage.Culture = ciLang;

    }


	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[1].ColumnSpan = 2;
			e.Row.Cells[2].Visible = false;

			e.Row.Cells[5].ColumnSpan = 2;
			e.Row.Cells[6].Visible = false;

			e.Row.Cells[7].ColumnSpan = 3;
			e.Row.Cells[8].Visible = false;
			e.Row.Cells[9].Visible = false;
			e.Row.Cells[10].Visible = false;
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "VsitData_List.xls";
		GridViewExportUtil.Export(fileName, this.GridView1);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitDataInfo obj = (VisitDataInfo)e.Row.DataItem;

			e.Row.Cells[1].Text = obj.VisitorDataInfoList[0].VisitDate;// 예약일 ngày hẹn
			e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorName;// 내방객 이름 tên khách đến thăm
			e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].CompanyInfo.CompanyName; // 회사명 tên công ty
			e.Row.Cells[4].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone1 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone2 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone3; // 전화번호 sđt
			e.Row.Cells[5].Text = obj.ReqEmployeeInfo.Dep_name; // 신청부서 bộ phận đăng ký
			e.Row.Cells[6].Text = obj.ReqEmployeeInfo.DisplayName; // 신청자 người đăng ký
			e.Row.Cells[7].Text = obj.InterviewEmployeeInfo.DisplayName; // 접견자  người đón tiếp
			e.Row.Cells[8].Text = obj.VisitObjectInfo.VisitObjectName; // 방문목적 mục đích đến
			e.Row.Cells[9].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number; // 차량번호 số xe
            e.Row.Cells[10].Text = bll.getApproveStringKOR(obj);

			//// 결재 상태 trạng thái phê duyệt
			String approveString = bll.getApproveStringKOR(obj);

			// 결재 상신중일 경우 결재 상태 보기 xem trạng thái phê duyệt khi gửi phê duyệt
			if (obj.ApprovalState == 1)
			{
				e.Row.Cells[10].Text = "<a href=\"#;\" onclick=\"showApproveStatus('" + obj.ElecApproveCode + "')\">" + approveString + "</a>";
			}
			else
			{
				e.Row.Cells[10].Text = approveString;
			}

			// 반려 일 경우 삭제 xóa trường hợp hoàn lại
			if (obj.ApprovalState == 3)
			{
				e.Row.Cells[12].Text = "<a href='#;' onclick=\"javascript:confirmDelete('deleteVisit.aspx?visitDataCode=" + obj.VisitDataCode + "');\">";
				e.Row.Cells[12].Text += "<img src='/COMS/images/icon/delete.gif'></a>";
			}

			// 임시저장일 경우 수정과 삭제 보이기  sửu và xóa trường hợp lưu tạm thời
			if (obj.ApprovalState == 0)
			{
				e.Row.Cells[11].Text = "<a href='inputVisit.aspx?visitDataCode=" + obj.VisitDataCode + "&mode=modify'>";
				e.Row.Cells[11].Text += "<img src='/COMS/images/icon/edit.gif'></a>";

				e.Row.Cells[12].Text = "<a href='#;' onclick=\"javascript:confirmDelete('deleteVisit.aspx?visitDataCode=" + obj.VisitDataCode + "');\">";
				e.Row.Cells[12].Text += "<img src='/COMS/images/icon/delete.gif'></a>";
			}

			// 링크 걸기 
			for (int i = 0; i < e.Row.Cells.Count; i++)
			{
				if (i < 10)
				{
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='viewVisitManager.aspx?visitDataCode=" + obj.VisitDataCode + "&visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "';");
                 	e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
				}
			}

			e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
			e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
		}
	}
}
