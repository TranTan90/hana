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
using System.Collections.Generic;

public partial class main_visit_deleteVisit : System.Web.UI.Page
{

	public String doc_code;
	public String employeeCode;
    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크  check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
		employeeCode = loginEmployee.Upnid;
		VisitData bllVisitData = new VisitData();
		VisitorData bllVisitorData = new VisitorData();

		VisitDataInfo visitDataInfo = new VisitDataInfo();
		VisitorDataInfo visitorDataInfo = new VisitorDataInfo();

		visitDataInfo = bllVisitData.selectVisitData(Request.QueryString["visitDataCode"]);

		// 내방객 정보 삭제  xóa thông tin khách đến thăm
		List<VisitorDataInfo> list = bllVisitorData.selectVisitorDataList(Request.QueryString["visitDataCode"]);
		for (int i = 0; i < list.Count; i++)
		{
			VisitorDataInfo subVisitor = (VisitorDataInfo)list[i];
			int resultDel = bllVisitorData.deleteVisitorData(subVisitor);
		}

		// 첨부 파일 삭제 xóa file đính kèm
		if (!String.IsNullOrEmpty(visitDataInfo.UserFile1))
		{
			bllVisitData.DeleteUserFile(Request.QueryString["visitDataCode"], "1", bllVisitData.GetFileName(visitDataInfo.UserFile1));
		}

		if (!String.IsNullOrEmpty(visitDataInfo.UserFile1))
		{
			bllVisitData.DeleteUserFile(Request.QueryString["visitDataCode"], "2", bllVisitData.GetFileName(visitDataInfo.UserFile3));
		}

		if (!String.IsNullOrEmpty(visitDataInfo.UserFile1))
		{
			bllVisitData.DeleteUserFile(Request.QueryString["visitDataCode"], "3", bllVisitData.GetFileName(visitDataInfo.UserFile3));
		}

		// 내방 정보 삭제 xóa thông tin đến thăm
		int result = bllVisitData.deleteVisitData(visitDataInfo);

		// 결재코드 code phê duyệt
		doc_code = visitDataInfo.ElecApproveCode;

		Response.Redirect("listVisit.aspx",true);
    }
}
