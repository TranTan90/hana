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
		// 로그인 체크 check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
	
        SecCardData bll = new SecCardData();
        
        int result = bll.deleteSecCardData(Request.QueryString["secCardDataCode"]);

		Response.Redirect("listSecCard.aspx",true);
    }
}
