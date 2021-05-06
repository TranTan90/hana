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
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Utility;

public partial class main_takeOut_listTakeOutTeam : System.Web.UI.Page
{
	TakeOutData bll = new TakeOutData();
    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크 check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
    }

	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TakeOutDataInfo obj = (TakeOutDataInfo)e.Row.DataItem;

            e.Row.Cells[1].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeOutTime); //반출일 ngày mang ra
            e.Row.Cells[2].Text = obj.RequestUserDisplayName; //신청자 người đăng ký
            e.Row.Cells[3].Text = StringUtil.GetShortString(obj.CompanyName, 50, "..."); //반출처 địa điểm
            e.Row.Cells[4].Text = StringUtil.GetShortString(obj.RecieveName, 50, ""); //수령자 người nhận
            e.Row.Cells[5].Text = bll.requireKor(obj.RequireIN); //반입여부 có/không vào cổng
            e.Row.Cells[6].Text = StringUtil.GetShortString(obj.TakeOutItemDataList[0].TakeOutItemName,18,"..."); //반출항목 hamgj mục ra

            //반입일 표시 hiển thị ngày vào
            if (obj.RequireIN == 2)
            {
                e.Row.Cells[9].Text = "Không đồng ý (반입불가)";
            }
            else
            {
                e.Row.Cells[9].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeINTime); //반입일 Ngày vào
            }

            e.Row.Cells[10].Text = bll.getApproveStringKOR(obj);

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 10)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='viewTakeOut.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }

            //반입예정일이 지난 것들 색상 표시 hiển thị màu sắc quá hạn ngày dự định vào
            if (obj.RequireIN == 1 && obj.TakeOutItemDataList[0].TakeINTime == "-" && obj.TakeOutItemDataList[0].TakeOutTime != "-")
            {
                if (Convert.ToDateTime(obj.ScheduleInDate) < DateTime.Now.Date)
                {
                    e.Row.Attributes.Add("style", "background-color:#FFF7A2;");
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFF7A2'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                }
            }
            else
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

        }
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "TakeOut_List.xls";
		GridViewExportUtil.Export(fileName, this.GridView1);
	}
}
