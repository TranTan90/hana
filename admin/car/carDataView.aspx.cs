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
using HanaMicron.COMS.Utility;
using HanaMicron.COMS.Model;

public partial class admin_car_carCategoryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void DetailsView1_DataBound(object sender, EventArgs e)
	{
		CarDataInfo carDataInfo = (CarDataInfo)DetailsView1.DataItem;

        DetailsView1.Rows[4].Cells[1].Text = carDataInfo.CarhandlerInfoList[0].Handler;
        DetailsView1.Rows[5].Cells[1].Text = carDataInfo.CarhandlerInfoList[0].Phone;
		DetailsView1.Rows[11].Cells[1].Attributes.Add("align", "center");
		DetailsView1.Rows[11].Cells[0].Visible = false;
		DetailsView1.Rows[11].Cells[1].ColumnSpan = 2;



		HyperLink colCancel = (HyperLink)DetailsView1.Rows[11].Cells[1].Controls[0];
		colCancel.ImageUrl = "~/images/icon/cancel.gif";
		colCancel.NavigateUrl = "javascript:history.go(-1)";

		DetailsView1.Rows[9].Cells[1].Text = StringUtil.ConvertToHtml(carDataInfo.RejectContent);
		//DetailsView1.Rows[6].Cells[1].Text = "1111333";
	}
}
