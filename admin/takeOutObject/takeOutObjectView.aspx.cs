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

public partial class admin_car_carCategoryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void DetailsView1_ItemCreated(object sender, EventArgs e)
	{
		DetailsView1.Rows[3].Cells[1].Attributes.Add("align", "center");
		DetailsView1.Rows[3].Cells[0].Visible = false;
		DetailsView1.Rows[3].Cells[1].ColumnSpan = 2;

		HyperLink colCancel = (HyperLink)DetailsView1.Rows[3].Cells[1].Controls[0];
		colCancel.ImageUrl = "~/images/icon/cancel.gif";
		colCancel.NavigateUrl = "javascript:history.go(-1)";
	}
}
