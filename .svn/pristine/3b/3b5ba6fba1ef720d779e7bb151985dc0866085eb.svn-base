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
using System.Collections.Generic;
using HanaMicron.COMS.BLL;

public partial class admin_manager_freepassList : System.Web.UI.Page
{

	private Department bll = new Department();
	private Employee bllEmployee = new Employee();
	private Manager bllManager = new Manager();

    protected void Page_Load(object sender, EventArgs e)
	{
		// 관리자 체크
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


		imgError.Visible = false;
		lblError.Visible = false;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	protected void showError(String message)
	{
		imgError.Visible = true;
		lblError.Visible = true;
		lblError.Text = message;
	}

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FreePassUserInfo obj = (FreePassUserInfo)e.Row.DataItem;

            e.Row.Cells[0].Text = obj.Upnid;
            e.Row.Cells[1].Text = obj.DisplayName;
            e.Row.Cells[2].Text = obj.Dep_name;
            e.Row.Cells[3].Text = "<a href='#;' onclick=\"javascript:confirmInsert('inputFreePass.aspx?step=2&Upnid=" + obj.Upnid + "');\">";
            e.Row.Cells[3].Text += "<img src='/COMS/images/icon/write.gif'></a>";
        }
    }

    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {

        if (String.IsNullOrEmpty(managerList.SelectedValue))
        {
            showError("☞ Chọn nhân viên sau đó click (임직원을 선택하신 후에 클릭하여 주시기 바랍니다).");
        }
        else
        {
            ManagerInfo manager = new ManagerInfo();
            manager.Upnid = managerList.SelectedValue;
            int result = bllManager.deleteManager(manager);
            Response.Redirect("managerList.aspx", true);
        }
    }
}
