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

public partial class _Default : System.Web.UI.Page
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

		Car bll = new Car();
		int total = bll.getCarCategoryTotal(key.Text);
		Label1.Text = total.ToString();
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{	
			CarCategoryInfo obj = (CarCategoryInfo)e.Row.DataItem;

			HyperLink col2 = (HyperLink)e.Row.Cells[2].Controls[0];
			col2.NavigateUrl = "carCategoryEdit.aspx?carCategoryCode=" + obj.CarCategoryCode + "&mode=modify";
			col2.ImageUrl = "~/images/icon/edit.gif";

			HyperLink col3 = (HyperLink)e.Row.Cells[3].Controls[0];
			col3.NavigateUrl = "#";
			col3.Attributes.Add("onclick", "return confirmDelete('carCategoryDelete.aspx?carCategoryCode=" + obj.CarCategoryCode + "');");
			col3.ImageUrl = "~/images/icon/delete.gif";

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 2)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='carCategoryView.aspx?carCategoryID=" + obj.CarCategoryCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand");
                }
            }
		}
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Car_Category.xls";
		GridViewExportUtil.Export(fileName, this.GridView1);
	}
}
