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

public partial class company_companyDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx", true);
		}

		TakeOutPathStart bll = new TakeOutPathStart();
		TakeOutPathStartInfo takeOutPathStartInfo = new TakeOutPathStartInfo();
		takeOutPathStartInfo.TakeOutPathStartCode = Convert.ToInt32(Request.QueryString["takeOutPathStartCode"]);

		int result = bll.deleteTakeOutPathStart(takeOutPathStartInfo);

		Response.Redirect("takeOutPathStartList.aspx", true);
    }
}
