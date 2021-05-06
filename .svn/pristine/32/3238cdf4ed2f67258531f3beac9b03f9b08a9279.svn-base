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
		CompanyInfo companyInfo = (CompanyInfo)DetailsView1.DataItem;

		DetailsView1.Rows[4].Visible = false;
		DetailsView1.Rows[5].Visible = false;

		DetailsView1.Rows[7].Visible = false;
		DetailsView1.Rows[8].Visible = false;

		DetailsView1.Rows[3].Cells[1].Text = companyInfo.Phone1 + "-" + companyInfo.Phone2 + "-" + companyInfo.Phone3;
		DetailsView1.Rows[6].Cells[1].Text = companyInfo.RegNumber1 + "-" + companyInfo.RegNumber2 + "-" + companyInfo.RegNumber3;

		DetailsView1.Rows[14].Cells[1].Attributes.Add("align", "center");
		DetailsView1.Rows[14].Cells[0].Visible = false;
		DetailsView1.Rows[14].Cells[1].ColumnSpan = 2;

		HyperLink colCancel = (HyperLink)DetailsView1.Rows[14].Cells[1].Controls[0];
		colCancel.ImageUrl = "~/images/icon/cancel.gif";
		colCancel.NavigateUrl = "javascript:history.go(-1)";

        Label1.Text = "Xem chi tiết (상세보기): " + companyInfo.CompanyName; // thay đổi thứ tự hiển thị. 표시 순서 바꿈: 상세보기: 회사명 2021-03-06: V22005001
        //원래 줄: companyInfo.CompanyName +"Xem chi tiết (상세보기)";  표시: 회사명_상세보기
	}
}
