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
    public String step;
    private Manager bllManager = new Manager();

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
        ManagerInfo manager = new ManagerInfo();
        manager.Upnid = Request.QueryString["Upnid"];
        step = Request.QueryString["step"];
        //step이 1이면 FreePass 등록하기                        step = 1 thì đăng ký FreePass
        if (step.Equals("1"))
        {
            manager.ManagerLevel = -1; // Freepass 등록자        người đăng ký FreePass
            if (bllManager.existsManager(manager))
            {
                Response.Redirect("freepassList.aspx", true);
            }
            else
            {
                int result1 = bllManager.insertManager(manager);
                Response.Redirect("freepassList.aspx", true);
            }
        }
        //step이 2이면 관리자 등록하기                       step =2 thì đăng ký người quản lý
        else if (step.Equals("2"))
        {
            manager.ManagerLevel = 2; // 관리자         người quản lý

            if (bllManager.existsManager(manager))
            {
                Response.Redirect("managerList.aspx", true);
            }
            else
            {
                int result2 = bllManager.insertManager(manager);
                Response.Redirect("managerList.aspx", true);
            }


        }

    }
}
