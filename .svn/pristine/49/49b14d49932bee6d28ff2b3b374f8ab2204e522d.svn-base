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
using System.Collections.Generic;

public partial class main_secCard_listSecCard : System.Web.UI.Page
{

    private SecCardData bll = new SecCardData();
    public int secCardFlag;
    public String checkAdmin;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 관리자 체크 
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        if (loginEmployee.ISAdmin == true)
        {
            sisAdmin.Value = "admin";
   
        }


    }
    
    protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "secCardData_List.xls";
		GridViewExportUtil.Export(fileName, this.GridView1);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
            SecCardDataInfo obj = (SecCardDataInfo)e.Row.DataItem;
          
			//// 결재 상태 tình trạng phê duyệt
			String approveString = bll.getApproveStringKOR(obj);

			// 결재 상신중일 경우 결재 상태 보기 xem tình trạng phê duyệt trong trường hợp gửi phê duyệt

            if (obj.Flag == 1)
            {
                e.Row.Cells[1].Text = "Mới (신규)";
            }
            else
            {
                e.Row.Cells[1].Text = "Thay đổi (변경)";
            }
            
            if (obj.ApprovalState == 1)
			{
				e.Row.Cells[6].Text = "<a href=\"#;\" onclick=\"showApproveStatus('" + obj.ElecApproveCode + "')\">" + approveString + "</a>";
			}
			else
			{
				e.Row.Cells[6].Text = approveString;
			}

			// 반려 일 경우 삭제
			if (obj.ApprovalState == 3)
			{
                e.Row.Cells[8].Text = "<a href='#;' onclick=\"javascript:confirmDelete('deleteSecCard.aspx?secCardDataCode=" + obj.SecDataCode + "');\">";
				e.Row.Cells[8].Text += "<img src='/COMS/images/icon/delete.gif'></a>";
			}

			// 임시저장일 경우 수정과 삭제 보이기
			if (obj.ApprovalState == 0)
			{
                e.Row.Cells[7].Text = "<a href='inputSecCard.aspx?secCardDataCode=" + obj.SecDataCode + "&mode=modify'>";
				e.Row.Cells[7].Text += "<img src='/COMS/images/icon/edit.gif'></a>";
                e.Row.Cells[8].Text = "<a href='#;' onclick=\"javascript:confirmDelete('deleteSecCard.aspx?secCardDataCode=" + obj.SecDataCode + "&elecApproveCode=" + obj.ElecApproveCode + "');\">";
				e.Row.Cells[8].Text += "<img src='/COMS/images/icon/delete.gif'></a>";
			}
            
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 7)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='viewSecCardManager.aspx?secCardDataCode=" + obj.SecDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }
			e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
			e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            
           
		}
	}
}
