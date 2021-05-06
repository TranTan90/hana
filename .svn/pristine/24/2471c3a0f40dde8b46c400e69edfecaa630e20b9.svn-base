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

public partial class main_visit_searchEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			EmployeeInfo employee=(EmployeeInfo)e.Row.DataItem;
			e.Row.Attributes.Add("onclick", "searchEnd('" + employee.Upnid + "','" + employee .DisplayName+ "')");
			e.Row.Attributes.Add("style", "cursor:hand");
		}
	}
}