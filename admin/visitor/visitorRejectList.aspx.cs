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
		// 관리자 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee=(EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ISAdmin == false)
		{
			Response.Redirect("~/login.aspx",true);
		}


		Visitor bll = new Visitor();
		Int32 totalCount = bll.totalVisitor(keyWord.Text, key.Text,true);
		Label1.Text = totalCount.ToString();
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitorInfo obj = (VisitorInfo)e.Row.DataItem;
			e.Row.Cells[2].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;

			e.Row.Cells[2].ColumnSpan = 3;
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;

            if (String.IsNullOrEmpty(obj.VisitorPassportNumber))
            {
                e.Row.Cells[5].Text = obj.VisitorRegNumber1 + "-" + obj.VisitorRegNumber2;
            }
            else
            {
                e.Row.Cells[5].Text = obj.VisitorPassportNumber;
            }

			e.Row.Cells[5].ColumnSpan = 2;
			e.Row.Cells[6].Visible = false;

			HyperLink colModify = (HyperLink)e.Row.Cells[8].Controls[0];
			colModify.NavigateUrl = "visitorEdit.aspx?visitorCode=" + obj.VisitorCode + "&mode=modify";
			colModify.ImageUrl = "~/images/icon/edit.gif";

			HyperLink colDelete = (HyperLink)e.Row.Cells[9].Controls[0];
			colDelete.NavigateUrl = "#";
			colDelete.Attributes.Add("onclick", "return confirmDelete('visitorDelete.aspx?visitorCode=" + obj.VisitorCode + "');");
			colDelete.ImageUrl = "~/images/icon/delete.gif";

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 8)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='visitorView.aspx?visitorCode=" + obj.VisitorCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }
		}
	}
	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[2].ColumnSpan = 3;
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;

			e.Row.Cells[5].ColumnSpan = 2;
			e.Row.Cells[6].Visible = false;
		}

	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Visitor.xls";
		GridViewExportUtil.Export(fileName, this.GridView1);
	}
}
