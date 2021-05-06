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

public partial class main_security_longVisitDataList : System.Web.UI.Page
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크  check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
		
		// 보안 요원 체크 check nhân viên bảo an 
		if (loginEmployee.ManagerLevel < 0)
		{
			Response.Redirect("~/login.aspx", true);
		}

		//VisitData bll = new VisitData();
		//GridView1.DataSource = bll.selectVisitDataList(ddlKeyWord.Text, txtKey.Text, txtStartDate.Text, txtEndDate.Text, "", "");
		//GridView1.DataBind();

		if (!Page.IsPostBack)
		{
            if (!String.IsNullOrEmpty(Request.QueryString["page"])) GridView1.PageIndex = Convert.ToInt32(Request.QueryString["page"]);
			if (!String.IsNullOrEmpty(Request.QueryString["keyWord"])) ddlKeyWord.SelectedValue = Request.QueryString["keyWord"];
			if (!String.IsNullOrEmpty(Request.QueryString["key"])) txtKey.Text = Request.QueryString["key"];
		}

    }

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitDataInfo obj = (VisitDataInfo)e.Row.DataItem;
            e.Row.Cells[0].Text = "<input type='checkbox' name='selectCheck' value='" + obj.VisitorDataInfoList[0].VisitorDataCode + "'>";
            //e.Row.Cells[0].Text = obj.VisitorDataInfoList[0].VisitDate;
            e.Row.Cells[1].Text = obj.StartDate.Substring(0,10) + " ~ " + obj.EndDate.Substring(0,10);
			e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorName;

            if (String.IsNullOrEmpty(obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber))
            {
                //e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***";
                e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1;
            }
            else
            {
                e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber;
            }
			e.Row.Cells[4].Text = obj.VisitorDataInfoList[0].CompanyInfo.CompanyName;
			e.Row.Cells[5].Text = obj.ReqEmployeeInfo.Dep_name;
			e.Row.Cells[6].Text = obj.InterviewEmployeeInfo.DisplayName;
			e.Row.Cells[7].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number;
			e.Row.Cells[8].Text = obj.VisitObjectInfo.VisitObjectName;
			e.Row.Cells[9].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone1 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone2 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone3;

			//e.Row.Cells[10].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;

			VisitData bll = new VisitData();

			// 상태
			String approveString = bll.getApproveStringKOR(obj);
			e.Row.Cells[10].Text = approveString;

            if (obj.ApprovalState == 2)
            {
                if (approveString.Equals("hoàn thành phê duyệt 결재 완료") && obj.VisitorDataInfoList[0].VisitDate.Equals(DateTime.Now.ToString("yyyy.MM.dd")))
                {
                    e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:confirmMove('입문 처리 하시겠습니까?','visitDatatimeUpdate.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&mode=inTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                    e.Row.Cells[11].Text += "<span style=\"color:blue\">Hoàn thành vào cổng 입문 처리</span></a>";
                }

                if (approveString.Equals("vào cổng 입문"))
                {
                    e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:confirmMove('출문 처리 하시겠습니까?','visitDatatimeUpdate.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&mode=outTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                    e.Row.Cells[11].Text += "<span style=\"color:red\"> ra cổng 출문 처리</span></a>";
                }

                if (approveString.Equals("ra cổng 출문"))
                {
                    e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:newWinByName('../visit/viewVisitTime.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&visitDataCode=" + obj.VisitDataCode + "','viewTime','400','200')\">";
                    e.Row.Cells[11].Text += "xem thời gian, quá trình 경과 시간 보기</a>";
                }
            }

			for (int i = 0; i < e.Row.Cells.Count; i++)
			{
				if (i > 0 & i < 11)
				{
					e.Row.Cells[i].Attributes.Add("onclick", "window.location='../visit/viewVisitManager.aspx?visitDataCode=" + obj.VisitDataCode + "&visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "';");
					e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
				}
			}

			e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
			e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
		}
	}

	/// <summary>
	/// 엑셀 다운
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    //protected void Button1_Click(object sender, EventArgs e)
    //{
        

    //    String code = "0";
    //    String[] selectCheckList = Request.Form.GetValues("selectCheck");

    //    VisitDataInfo checkVisitData = new VisitDataInfo();
    //    VisitDataInfo oldVisitDataInfo = new VisitDataInfo();
    //    VisitorDataInfo visitorDataInfo = new VisitorDataInfo();
    //    VisitData bllVisitData = new VisitData();
    //    VisitorData bllVisitorData = new VisitorData();

    //    int visitDataCode; // 내방 코드
        
    //    for (int i = 0; i < selectCheckList.Length; i++)
    //    {
    //        //내방객 내방내역 정보 가져오기
    //        visitorDataInfo = bllVisitorData.selectVisitorData(selectCheckList[i]);

    //        //내방정보 longVisitDataCode 오늘날짜 있는지 확인.
    //        checkVisitData = bllVisitData.checkLongVisitDataCode(visitorDataInfo.VisitDataCode.ToString(),code);

    //        //내방정보가 없을때 등록
    //        if (checkVisitData.VisitDataCode == 0)
    //        {
    //            code = "1";
    //            oldVisitDataInfo = bllVisitData.checkLongVisitDataCode(visitorDataInfo.VisitDataCode.ToString(), code);
    //            oldVisitDataInfo.VisitFlag = 2;
    //            oldVisitDataInfo.ApprovalState = 2;
    //            oldVisitDataInfo.StartDate = oldVisitDataInfo.StartDate.Substring(0, 10);
    //            oldVisitDataInfo.EndDate = oldVisitDataInfo.EndDate.Substring(0, 10);
    //            oldVisitDataInfo.LongVisitDataCode = oldVisitDataInfo.VisitDataCode;
    //            int resultCode = bllVisitData.insertVisitData(oldVisitDataInfo);

    //            // 마지막 입력된 visitDataCode 값 가져오기
    //            visitDataCode = bllVisitData.selectMaxCode();
    //            visitorDataInfo.VisitDataCode = visitDataCode;
    //        }
    //        else
    //        {
    //            visitorDataInfo.VisitDataCode = checkVisitData.VisitDataCode;
    //        }
    //        visitorDataInfo.VisitDate = DateTime.Today.ToString("yyyy.MM.dd");
    //        bllVisitorData.insertVisitorData(visitorDataInfo);

    //        // 마지막 입력된 visitorDataCode 값 가져오기
    //        visitorDataInfo.VisitorDataCode = bllVisitorData.selectMaxVisitorDataCode();
            
    //        bllVisitorData.updateInTime(visitorDataInfo);    
    //    }

    //    Response.Redirect("visitDataList.aspx");
    //    //String testyoyo = String.Empty;


    //    //foreach (String selectCheck in selectCheckList)
    //    //{
    //    //    //selectCheck;
    //    //}
    //    //String fileName = "Visit_Data_List_Security.xls";
    //    //GridViewExportUtil.Export(fileName, this.GridView1);
    //}
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
	{

	}

}
