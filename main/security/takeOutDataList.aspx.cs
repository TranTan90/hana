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

public partial class main_visit_listVisit : System.Web.UI.Page
{
	TakeOutData bll = new TakeOutData();
    string stKeyWord = null;
    string stKey = null;

    protected void Page_Load(object sender, EventArgs e)
    {        
		// 로그인 체크    check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

        if (loginEmployee.ManagerLevel < 1)
        {
            Response.Redirect("~/login.aspx", true);
        }               

        // 반출입 처리 후 과거 검색 조건이 있으면 해당 데이터 출력 (2009.09.21 임종우)    // sau khi hoàn thành tài sản ra vào nếu có điều kiện tìm kiếm thì xuất dữ liệu

        //if (Request.QueryString["dataType"] != null)
        //{
        //    dateType.SelectedValue = Request.QueryString["dataType"];
        //}

        //stKeyWord = Request.QueryString["keyWord"];
        //stKey = Request.QueryString["key"];

        //stKeyWord = keyWord.SelectedValue;
        //stKey = key.Text;

        //if (stKeyWord != null)
        //{
        //    keyWord.SelectedValue = stKeyWord;
        //}

        //if (stKey != null)
        //{
        //    key.Text = stKey;
        //}
    }
	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TakeOutDataInfo obj = (TakeOutDataInfo)e.Row.DataItem;

            e.Row.Cells[1].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeOutTime); //반출일 ngày mang ra
            e.Row.Cells[2].Text = obj.RequestUserDisplayName; //신청자  người đăng ký 
            e.Row.Cells[3].Text = StringUtil.GetShortString(obj.CompanyName, 100, "..."); //반출처   địa điểm mang ra
            e.Row.Cells[4].Text = StringUtil.GetShortString(obj.RecieveName, 50, "..."); //수령자 người nhận
            e.Row.Cells[5].Text = bll.requireKor(obj.RequireIN); // 반입여부
            e.Row.Cells[6].Text = StringUtil.GetShortString(obj.TakeOutItemDataList[0].TakeOutItemName,18,"..."); //반출항목  hạng mục tài sản ra
            
            //반입일 표시  hiển thị ngày mang vào
            if (obj.RequireIN == 2)
            {
                e.Row.Cells[10].Text = "Không thể mang vào 반입불가";
            }
            else
            {
                e.Row.Cells[10].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeINTime); //반입일 ngày mang vào
            }

            e.Row.Cells[11].Text = bll.getApproveStringKOR(obj); //결재상태 tình trạng phê duyệt

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 12)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='../takeOut/viewTakeOut.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }

            if (obj.ApprovalState == 2) //결재상태(결재완료)  tình trạng phê duyệt (hoàn thành phê duyệt )
            {
                //stKeyWord = Request.Form["keyWord"];
                //stKey = Request.Form["key"];

                if (obj.TakeOutItemDataList[0].TakeOutTime == "-") //반출시간데이터 유무 확인
                {
                    //HyperLink colINTime = (HyperLink)e.Row.Cells[11].Controls[0];
                    //colINTime.NavigateUrl = "javascript:confirmMove('반출 처리 하시겠습니까?','takeOutTimeUpdate.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "&mode=outTime')";
                    //colINTime.Text = "<span style=\"color:blue\">반출 처리</span>";
                    //if (Convert.ToDateTime(obj.ScheduleOutDate) >= DateTime.Now.Date) // 반출예정일 지나지 않은것만 반출처리
                    //{
                    e.Row.Cells[12].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý tài sản ra cổng không? (일괄 반출 처리 하시겠습니까?)','takeOutTimeUpdate.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "&keyWord=" + Request["keyWord"] + "&key=" + Request["key"] + "&mode=outTime')\">";
                        //e.Row.Cells[12].Text = "<a href='#;' onClick=\"javascript:confirmMove('일괄 반출 처리 하시겠습니까?','takeOutTimeUpdate.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "&mode=outTime')\">";
                        e.Row.Cells[12].Text += "<span style=\"color:blue\">Xử lý mang ra (반출 처리)</span></a>";
                    //}
                }
                else
                {
                    if (obj.RequireIN == 1 && obj.TakeOutItemDataList[0].TakeINTime == "-") //반입필  Cần mang vào
                    {
                        e.Row.Cells[12].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý vào cổng không? (반입 처리 하시겠습니까?)','takeOutTimeUpdate.aspx?takeOutItemDataCode=" + obj.TakeOutItemDataList[0].TakeOutItemDataCode + "&keyWord=" + Request["keyWord"] + "&key=" + Request["key"] + "&mode=inTime')\">";
                        //e.Row.Cells[12].Text = "<a href='#;' onClick=\"javascript:confirmMove('반입 처리 하시겠습니까?','takeOutTimeUpdate.aspx?takeOutItemDataCode=" + obj.TakeOutItemDataList[0].TakeOutItemDataCode + "&mode=inTime')\">";
                        e.Row.Cells[12].Text += "<span style=\"color:red\">Xử lý mang vào (반입 처리)</span></a>";
                    }
                    else
                    {
                        e.Row.Cells[12].Text = "<span style=\"color:blue\">Kết thúc (종료)</span></a>";
                    }
                }

            }
            // 2017-09-06-임종우 : 그룹웨어 Interface 오류가 많아 수동으로 결재승인 처리 로직 추가. 결재상신중이면 강제 결재 승인 가능하도록 추가.
            else if (obj.ApprovalState == 1)
            {                
                e.Row.Cells[12].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý phê duyệt điện tử không? (결재 승인 처리 하시겠습니까?)','elecApproveUpdate.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "&status=2" + "&keyWord=" + Request["keyWord"] + "&key=" + Request["key"] + "&mode=takeOut')\">";                
                e.Row.Cells[12].Text += "<span style=\"color:Green\">Đồng ý phê duyệt (결재 승인)</span></a>";
            }
            else
            {
                e.Row.Cells[12].Text = "";
            }
                        
            //반입예정일이 지난 것들 색상 표시
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
