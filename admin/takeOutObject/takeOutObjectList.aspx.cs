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
    }


	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TakeOutObjectInfo obj = (TakeOutObjectInfo)e.Row.DataItem;

			HyperLink colModify = (HyperLink)e.Row.Cells[2].Controls[0];
			colModify.NavigateUrl = "takeOutObjectEdit.aspx?takeOutObjectCode=" + obj.TakeOutObjectCode + "&mode=modify";
			colModify.ImageUrl = "~/images/icon/edit.gif";

			HyperLink colDelete = (HyperLink)e.Row.Cells[3].Controls[0];
			colDelete.NavigateUrl = "#";
			colDelete.Attributes.Add("onclick", "return confirmDelete('takeOutObjectDelete.aspx?takeOutObjectCode=" + obj.TakeOutObjectCode + "');");
			colDelete.ImageUrl = "~/images/icon/delete.gif";

			for (int i = 0; i < e.Row.Cells.Count; i++)
			{
				if (i < 2)
				{
					e.Row.Cells[i].Attributes.Add("onclick", "window.location='takeOutObjectView.aspx?takeOutObjectCode=" + obj.TakeOutObjectCode + "';");
					e.Row.Cells[i].Attributes.Add("style", "cursor:hand");
				}
			}
		}
	}
}
