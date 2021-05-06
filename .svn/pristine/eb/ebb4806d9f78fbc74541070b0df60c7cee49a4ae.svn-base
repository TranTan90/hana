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

public partial class main_elecApprove_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크  check login
        EmployeeInfo loginEmployee = new EmployeeInfo();
        VisitData bllVisit = new VisitData();
        TakeOutData bllTakeOut = new TakeOutData();

        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        if (loginEmployee.ManagerLevel < 1)
        {
            Response.Redirect("~/login.aspx", true);
        }
        		
		if(Request.QueryString["mode"].Equals("takeOut"))
        {
            int result = bllTakeOut.updateApprove(Request.QueryString["takeOutDataCode"],Request.QueryString["status"],"");
            Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "takeOutDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + Request.QueryString["key"]));
		}
        else if(Request.QueryString["mode"].Equals("visit"))
        {
            int result = bllVisit.updateApprove(Request.QueryString["visitDataCode"], Request.QueryString["status"], "");
            Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "visitDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + Request.QueryString["key"] + "&page=" + Request.QueryString["page"]));
		}		
    }
}
