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
			CarDataInfo car = (CarDataInfo)e.Row.DataItem;
			e.Row.Cells[1].ColumnSpan = 2;
			e.Row.Cells[2].Visible = false;

			e.Row.Cells[1].Text = car.Header +" "+ car.Number;

            e.Row.Cells[3].Text = car.CarhandlerInfoList[0].Handler;
            e.Row.Cells[4].Text = car.CompanyName;                      //2021-05-03 반안: 팝업되는 창에 차가 소속된 업체도 표시 요청 (박민수 차장)

			if (car.Reject == 0) e.Row.Cells[5].Text = "Không (아니오)";
			else e.Row.Cells[5].Text = "<span style='color:red'>예</span>";

			if (car.Reject == 0)
			{
				e.Row.Attributes.Add("onclick", "searchEnd('" + car.CarCode + "','" + car.Header + " " + car.Number + "')");
				e.Row.Attributes.Add("style", "cursor:hand");
			}
		}

		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[1].ColumnSpan = 2;
			e.Row.Cells[2].Visible = false;
		}
	}
}