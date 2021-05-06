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
		// 관리자 체크 check người quản lý
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ISAdmin == false)
		{
			Response.Redirect("~/login.aspx", true);
		}

        //String carHandlerCode = Request.QueryString["carHandlerCode"];

        String carCode = Request.QueryString["carCode"];

		Car bll = new Car();
        //int result = bll.deleteCarHandler(Convert.ToInt32(carHandlerCode));
        int result = bll.deleteCarData(Convert.ToInt16(carCode));

        Response.Redirect("carDataList.aspx");

    }
}
