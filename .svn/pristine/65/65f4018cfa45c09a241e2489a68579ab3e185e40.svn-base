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

		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx", true);
		}

		Company bll = new Company();
		Int32 totalCount = bll.getCompanyTotal(keyWord.Text, key.Text,1,"");
		Label1.Text = totalCount.ToString();
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			CompanyInfo obj = (CompanyInfo)e.Row.DataItem;
			e.Row.Cells[1].Text = obj.RegNumber1 + "-" + obj.RegNumber2 + "-" + obj.RegNumber3;

			e.Row.Cells[1].ColumnSpan = 3;
			e.Row.Cells[2].Visible = false;
			e.Row.Cells[3].Visible = false;

			e.Row.Cells[4].Text = obj.Phone1 + "-" + obj.Phone2 + "-" + obj.Phone3;
			e.Row.Cells[4].ColumnSpan = 3;
			e.Row.Cells[5].Visible = false;
			e.Row.Cells[6].Visible = false;

			HyperLink colModify = (HyperLink)e.Row.Cells[12].Controls[0];
			colModify.NavigateUrl = "companyEdit.aspx?companyCode=" + obj.CompanyCode + "&mode=modify";
			colModify.ImageUrl = "~/images/icon/edit.gif";

			HyperLink colDelete = (HyperLink)e.Row.Cells[13].Controls[0];
			colDelete.NavigateUrl = "#";
			colDelete.Attributes.Add("onclick", "return confirmDelete('companyDelete.aspx?companyCode=" + obj.CompanyCode + "');");
			colDelete.ImageUrl = "~/images/icon/delete.gif";

			for (int i = 0; i < e.Row.Cells.Count; i++)
			{
				if (i < 12)
				{
					e.Row.Cells[i].Attributes.Add("onclick", "window.location='companyView.aspx?companyCode=" + obj.CompanyCode + "';");
					e.Row.Cells[i].Attributes.Add("style", "cursor:hand");
				}
			}
		}
	}
	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[1].ColumnSpan = 3;
			e.Row.Cells[2].Visible = false;
			e.Row.Cells[3].Visible = false;

			e.Row.Cells[4].ColumnSpan = 3;
			e.Row.Cells[5].Visible = false;
			e.Row.Cells[6].Visible = false;
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Company_List.xls";
		GridViewExportUtil.Export(fileName, this.GridView2);
	}
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CompanyInfo obj = (CompanyInfo)e.Row.DataItem;
            e.Row.Cells[2].Text = obj.RegNumber1 + "-" + obj.RegNumber2 + "-" + obj.RegNumber3;

            e.Row.Cells[2].ColumnSpan = 3;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;

            e.Row.Cells[5].Text = obj.Phone1 + "-" + obj.Phone2 + "-" + obj.Phone3;
            e.Row.Cells[5].ColumnSpan = 3;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].ColumnSpan = 3;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;

            e.Row.Cells[5].ColumnSpan = 3;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }
}
