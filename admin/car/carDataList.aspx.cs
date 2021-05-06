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
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Utility;

public partial class _Default : System.Web.UI.Page
{
    Car bll = new Car();

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

		Car bll=new Car();
		int total=bll.getCarDataTotal(key.Text);
		Label1.Text = total.ToString();

        //WebCombo1.Rows.Add(new UltraGridRow();
        
        
        //WebCombo1.DataSource = bll.getCarDataList("");
        //WebCombo1.DataValueField = "Handler";
        //WebCombo1.DataTextField = "Handler";
        //WebCombo1.DisplayValue = "운전자 선택";
        //WebCombo1.DataBind();
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			CarDataInfo obj = (CarDataInfo)e.Row.DataItem;

            e.Row.Cells[0].Text = obj.CodeName;

			e.Row.Cells[1].ColumnSpan = 2;
			e.Row.Cells[2].Visible = false;

			e.Row.Cells[1].Text = obj.Header +" "+ obj.Number;

            e.Row.Cells[3].Text = bll.getCarTypeKor(obj.CarType);           
            e.Row.Cells[6].Text = obj.CarhandlerInfoList[0].Handler;
            e.Row.Cells[7].Text = obj.CarhandlerInfoList[0].Phone;
			
            if (obj.Reject == 0) e.Row.Cells[8].Text = "Không 아니오";
			else e.Row.Cells[8].Text = "예";

			HyperLink col6 = (HyperLink)e.Row.Cells[10].Controls[0];
			col6.NavigateUrl = "carDataEdit.aspx?type=carCode&code="+ obj.CarCode+"&mode=modify";
			col6.ImageUrl = "~/images/icon/edit.gif";

			HyperLink col7 = (HyperLink)e.Row.Cells[11].Controls[0];
			col7.NavigateUrl = "#";
			col7.Attributes.Add("onclick", "return confirmDelete('carDataDelete.aspx?carCode=" + obj.CarCode + "');");
			col7.ImageUrl = "~/images/icon/delete.gif";

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 10)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='carDataView.aspx?type=carHandlerCode&code=" + obj.CarhandlerInfoList[0].CarHandlerCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand");
                }
            }
		}

		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[1].ColumnSpan = 2;
			e.Row.Cells[2].Visible = false;
		}
	}

    protected void GridViewExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CarDataInfo obj = (CarDataInfo)e.Row.DataItem;

            e.Row.Cells[0].Text = obj.CodeName;

            e.Row.Cells[1].ColumnSpan = 2;
            e.Row.Cells[2].Visible = false;

            e.Row.Cells[1].Text = obj.Header + " " + obj.Number;

            e.Row.Cells[3].Text = bll.getCarTypeKor(obj.CarType);
            e.Row.Cells[6].Text = obj.CarhandlerInfoList[0].Handler;
            e.Row.Cells[7].Text = obj.CarhandlerInfoList[0].Phone;

            if (obj.Reject == 0) e.Row.Cells[8].Text = "Không (아니오)";
            else e.Row.Cells[8].Text = "Vâng (예)";
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].ColumnSpan = 2;
            e.Row.Cells[2].Visible = false;
        }
    }

	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Car_Data.xls";
		GridViewExportUtil.Export(fileName, this.GridViewExcel);
	}
}
