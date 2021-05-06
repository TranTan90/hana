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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        // 보안 요원 체크  nhân viên bảo an kiểm tra
        if (loginEmployee.ManagerLevel < 0)
        {
            Response.Redirect("~/login.aspx", true);
        }

        //VisitData bll = new VisitData();
        //GridView1.DataSource = bll.selectVisitDataList(ddlKeyWord.Text, txtKey.Text, txtStartDate.Text, txtEndDate.Text, "", "");
        //GridView1.DataBind();

        if (!Page.IsPostBack)
        {
            //2012-01-06 내방객 출일관리 처음 오픈시 한달로 조회 기간 설정(속도가 늦어서...)
            DateTime getEndDate = DateTime.Now;
            //DateTime getStartDate = DateTime.Now.AddMonths(-1);
            DateTime getStartDate = DateTime.Now.AddDays(-1);
            txtStartDate.Text = getStartDate.ToString("yyyy-MM-dd");
            txtEndDate.Text = getEndDate.ToString("yyyy-MM-dd");

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

            e.Row.Cells[0].Text = obj.VisitorDataInfoList[0].VisitDate;
            e.Row.Cells[1].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorName;

            if (String.IsNullOrEmpty(obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber))
            {
                //e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***";
                e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1;
            }
            else
            {
                e.Row.Cells[2].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber;
            }
            e.Row.Cells[3].Text = obj.VisitorDataInfoList[0].CompanyInfo.CompanyName;
            e.Row.Cells[4].Text = obj.ReqEmployeeInfo.Dep_name;
            e.Row.Cells[5].Text = obj.InterviewEmployeeInfo.DisplayName;
            e.Row.Cells[6].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number;
            e.Row.Cells[7].Text = obj.VisitObjectInfo.VisitObjectName;
            e.Row.Cells[8].Text = obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone1 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone2 + "-" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone3;


            //e.Row.Cells[10].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;

            VisitData bll = new VisitData();

            // 상태   trạng thái/ tình trạng 
            String approveString = bll.getApproveStringKOR(obj);
            e.Row.Cells[9].Text = approveString;

            // 2019-07-15-임종우 : ESD 교육 이수 처리 //xử lý hoàn thành đào tạo ESD
            if (obj.VisitorDataInfoList[0].VisitorInfo.EsdFlag == "N")
            {
                e.Row.Cells[10].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý hoàn thành đạo tạo không ? (교육 이수 처리 하시겠습니까?)','/COMS/main/security/visitDatatimeUpdate.aspx?visitorCode=" + obj.VisitorDataInfoList[0].VisitorInfo.VisitorCode + "&mode=esdTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                e.Row.Cells[10].Text += "<span style=\"color:red\">No</span></a>";
            }
            else
            {
                e.Row.Cells[10].Text = "Yes";
            }

            if (obj.ApprovalState == 2)
            {
                if (approveString.Equals("Hoàn thành phê duyệt (결재 완료)") && obj.VisitorDataInfoList[0].VisitDate.Equals(DateTime.Now.ToString("yyyy.MM.dd")))
                {
                    //2012-02-25-김민우: 입문 처리 시 card no. 를 입력 받도록 수정
                    //e.Row.Cells[10].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý vào cổng không ? (입문 처리 하시겠습니까?)','visitDatatimeUpdate.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&mode=inTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                    //e.Row.Cells[10].Text += "<span style=\"color:blue\">Xử lý vào cổng (입문 처리)</span></a>";

                    if (obj.VisitorDataInfoList[0].VisitorInfo.EsdFlag == "N")
                    {
                        e.Row.Cells[11].Text = "<span style=\"color:blue\"> Kiểm tra hoàn thành ESD (ESD 이수 확인)</span></a>";
                    }
                    else
                    {
                        e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:newWinByName('../security/visitorCardNo.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&mode=inTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "','CardNo','300','130')\">";
                        e.Row.Cells[11].Text += "<span style=\"color:blue\">Xử lý vào cổng (입문 처리)</span></a>";
                    }
                }

                if (approveString.Equals("Vào cổng (입문)"))
                {
                    e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý ra cổng không (출문 처리 하시겠습니까)?','visitDatatimeUpdate.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&mode=outTime&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                    e.Row.Cells[11].Text += "<span style=\"color:red\">Xử lý ra cổng (출문 처리)</span></a>";
                }

                if (approveString.Equals("Ra cổng (출문)"))
                {
                    e.Row.Cells[11].Text = "<a href='#;' onClick=\"javascript:newWinByName('../visit/viewVisitTime.aspx?visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "&visitDataCode=" + obj.VisitDataCode + "','viewTime','400','200')\">";
                    e.Row.Cells[11].Text += "Xem thời gian tiến hành (경과 시간 보기)</a>";
                }
            }

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (i < 10)
                {
                    e.Row.Cells[i].Attributes.Add("onclick", "window.location='/COMS/main/visit/viewVisitManager.aspx?visitDataCode=" + obj.VisitDataCode + "&visitorDataCode=" + obj.VisitorDataInfoList[0].VisitorDataCode + "';");
                    e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
                }
            }

            if (obj.VisitFlag == 5)
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
    }

    /// <summary>
    /// 엑셀 다운  tải excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        String fileName = "Visit_Data_List_Security.xls";
        GridViewExportUtil.Export(fileName, this.GridView1);
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {

    }
}
