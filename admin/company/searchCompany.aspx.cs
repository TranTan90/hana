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

		if (loginEmployee.ISAdmin == false)
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


			e.Row.Style.Add("cursor", "hand");
			e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
			e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
			
			e.Row.Attributes.Add("onclick", "selectIt('" + obj.CompanyName + "','" + obj.CompanyCode + "')");
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
}
