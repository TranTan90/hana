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
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Utility;

public partial class carHandlerList : System.Web.UI.Page
{
    Car bll = new Car();

    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크 check người quản lý
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

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //}

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CarHandlerInfo carHandlerInfo = new CarHandlerInfo();

        carHandlerInfo.CarCode = Convert.ToInt32(Request.QueryString["carCode"]);
        carHandlerInfo.Handler = txthandler.Text;
        carHandlerInfo.Phone = txtphone.Text;

        bll.insertCarHandler(carHandlerInfo);

        Response.Redirect("carHandlerList.aspx?carCode="+carHandlerInfo.CarCode);
    }
   
}
