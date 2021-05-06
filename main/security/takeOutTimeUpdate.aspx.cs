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

public partial class main_visit_timeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크  check login
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        if (loginEmployee.ManagerLevel < 1)
        {
            Response.Redirect("~/login.aspx", true);
        }
		TakeOutItemData bll = new TakeOutItemData();
		if(Request.QueryString["mode"].Equals("inTime")){
            int result = bll.updateInTime(Request.QueryString["takeOutItemDataCode"], loginEmployee.Upnid);
		}else if(Request.QueryString["mode"].Equals("outTime")){
			int result = bll.updateOutTime(Request.QueryString["takeOutDataCode"],loginEmployee.Upnid);
		}

		Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "takeOutDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + Request.QueryString["key"]));
    }
}
