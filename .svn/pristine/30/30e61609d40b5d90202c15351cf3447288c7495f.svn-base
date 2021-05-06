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
		VisitorInfo obj = (VisitorInfo)DetailsView1.DataItem;

		DetailsView1.Rows[4].Visible = false;

		DetailsView1.Rows[6].Visible = false;
		DetailsView1.Rows[7].Visible = false;

        if (String.IsNullOrEmpty(obj.VisitorPassportNumber))
        {
            //DetailsView1.Rows[3].Cells[1].Text = obj.VisitorRegNumber1 + "-" + obj.VisitorRegNumber2;
            DetailsView1.Rows[3].Cells[1].Text = obj.VisitorRegNumber1;
        }
        else
        {
            DetailsView1.Rows[3].Cells[1].Text = obj.VisitorPassportNumber;
        }

		DetailsView1.Rows[5].Cells[1].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;

		DetailsView1.Rows[11].Cells[1].Attributes.Add("align", "center");
		DetailsView1.Rows[11].Cells[0].Visible = false;
		DetailsView1.Rows[11].Cells[1].ColumnSpan = 2;

		HyperLink colCancel = (HyperLink)DetailsView1.Rows[11].Cells[1].Controls[0];
		colCancel.ImageUrl = "~/images/icon/cancel.gif";
		colCancel.NavigateUrl = "javascript:history.go(-1)";

		if (obj.Reject == 0) DetailsView1.Rows[8].Cells[1].Text = "Không (아니오)";
		else DetailsView1.Rows[8].Cells[1].Text = "<span style=\"color:red\">예</span>";

		DetailsView1.Rows[9].Cells[1].Text = StringUtil.ConvertToHtml(obj.RejectContent);

        Label1.Text = "Xem chi tiết khách thăm (내방객 상세보기):" + obj.VisitorName;   // 표시 순서 바꿈 (Thay đổi thứ tự hiển thị)  xem chi tiết: visitorName
        // obj.VisitorName + "Xem chi tiết khách thăm (내방객 상세보기)"; 원래 code
	}
}
