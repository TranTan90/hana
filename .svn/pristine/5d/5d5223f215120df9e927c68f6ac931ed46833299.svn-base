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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Employee bll=new Employee();
		//  로그인 체크 check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (Response.Cookies["ssoID"] != null ||
                    string.IsNullOrEmpty(Response.Cookies["ssoID"].Value) == false)
        {
            String id = Response.Cookies["ssoID"].Value;
            if (id != null)
            {
                loginEmployee = bll.selectEmployee(id);
                Response.Redirect("main/visit/inputVisit.aspx?mode=write/"+id);
            }
            else
            {
            //    Response.Redirect("~/main/visit/listVisit.aspx" + id, true);
            //     Response.Redirect("/COMS/main/visit/listVisit.aspx");
            }
        }
        

        


		if (loginEmployee == null)
		{
			Response.Redirect("/COMS/login.aspx");
		}
		else
		{
			// 관리자 이면 // nếu là người quản lý
			if (loginEmployee.ManagerLevel == 2)
			{
				Response.Redirect("~/admin/Default.aspx", true);
			}
			else
			{
				// 내방 결재자 이면 // nếu là người phê duyệt khách thăm
				//if (bll.existsApprovor(loginEmployee.Upnid, "1", "0"))
				//{
				//    Response.Redirect("~/main/approve/visitDataList.aspx?employeeCode="+loginEmployee.Upnid, true);
				//}

				// 반출 결재자 이면 // nếu là người phê duyệt tài sản ra vào
				//if (bll.existsApprovor(loginEmployee.Upnid, "0", "1"))
				//{
				//    Response.Redirect("~/main/approve/takeOutDataList.aspx?employeeCode="+loginEmployee.Upnid, true);
				//}

				// 보안 요원이면  // nếu là nhân viên bảo an
				if (loginEmployee.ManagerLevel == 1)
				{
					Response.Redirect("~/main/security/visitDataList.aspx", true);
				}

				// 직원이면  // nếu là nhân viên
                //Response.Redirect("main/visit/listVisit.aspx?employeeCode="+loginEmployee.Upnid);
                //Response.Redirect("main/visit/inputVisit.aspx?mode=write");
                Response.Redirect("/COMS/main/visit/listVisit.aspx");
			}
		}
		
    }
}
