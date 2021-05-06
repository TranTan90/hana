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

public partial class main_security_longVisitProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크   check login
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
        String code = "0";
        String[] selectCheckList = Request.Form.GetValues("selectCheck");
        String[] cardNoList = Request.Form.GetValues("cardNo");

        String[] cardNoList2 = new String[selectCheckList.Length];
        int k = 0;
        for (int i = 0; i < cardNoList.Length; i++)
        {
            
            if (!cardNoList[i].Equals(""))
            {
                cardNoList2[k] = cardNoList[i];
                k++;
            }
        }
        VisitDataInfo checkVisitData = new VisitDataInfo();
        VisitDataInfo oldVisitDataInfo = new VisitDataInfo();
        VisitorDataInfo visitorDataInfo = new VisitorDataInfo();
        VisitData bllVisitData = new VisitData();
        VisitorData bllVisitorData = new VisitorData();

        int visitDataCode; // 내방 코드  visit code 
        bool checkToday = false; // 금일날짜 내방 정보중 출문미처리 된 내역  //chi tiết thông tin khách thăm chưa được xử lý ra cổng ngày hôm nay

        // 금일날짜 내방 정보중 출문미처리 된 내역 확인      // kiểm tra chi tiết thông tin khách thăm chưa được xử lý ra cổng ngày hôm nay
        for (int i = 0; i < selectCheckList.Length; i++)
        {
            //내방객 내방내역 정보 가져오기(visitorCode 가져오기 위함)  // mang theo thông tin chi tiết khách thăm
            visitorDataInfo = bllVisitorData.selectVisitorData(selectCheckList[i]);

            // 금일날짜 내방 정보중 출문미처리 된 내역     //chi tiết thông tin khách thăm chưa được xử lý ra cổng ngày hôm nay
            checkToday = bllVisitorData.checkTodayVisitorData(visitorDataInfo.VisitorInfo.VisitorCode.ToString());

            if (checkToday == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", HanaMicron.COMS.Utility.JavaScriptBuilder.alert(visitorDataInfo.VisitorInfo.VisitorName + " đã hoàn thành vào cổng (님은 현재 입문처리 된 상태 입니다).", "longVisitDataList.aspx"));
                //Page.RegisterStartupScript("alert", JavaScriptBuilder.alert(visitorDataInfo.VisitorInfo.VisitorName + " 님은 현재 입문처리 된 상태 입니다.", "longVisitDataList.aspx"));
            }
        }

        if (checkToday == false)
        {
            for (int i = 0; i < selectCheckList.Length; i++)
            {
                code = "0";

                //내방객 내방내역 정보 가져오기  // mang theo thông tin chi tiết khách thăm
                visitorDataInfo = bllVisitorData.selectVisitorData(selectCheckList[i]);

                //내방정보 longVisitDataCode 오늘날짜 있는지 확인. 
                checkVisitData = bllVisitData.checkLongVisitDataCode(visitorDataInfo.VisitDataCode.ToString(), code);

                //내방정보가 없을때 등록    đăng ký khi không có thông tin khách thăm
                if (checkVisitData.VisitDataCode == 0)
                {
                    code = "1";
                    oldVisitDataInfo = bllVisitData.checkLongVisitDataCode(visitorDataInfo.VisitDataCode.ToString(), code);
                    oldVisitDataInfo.VisitFlag = 2;
                    oldVisitDataInfo.ApprovalState = 2;
                    oldVisitDataInfo.StartDate = oldVisitDataInfo.StartDate.Substring(0, 10);
                    oldVisitDataInfo.EndDate = oldVisitDataInfo.EndDate.Substring(0, 10);
                    oldVisitDataInfo.LongVisitDataCode = oldVisitDataInfo.VisitDataCode;
                    int resultCode = bllVisitData.insertVisitData(oldVisitDataInfo);

                    // 마지막 입력된 visitDataCode 값 가져오기
                    visitDataCode = bllVisitData.selectMaxCode();

                    visitorDataInfo.VisitDataCode = visitDataCode;
                }

                else
                {
                    visitorDataInfo.VisitDataCode = checkVisitData.VisitDataCode;
                }

                visitorDataInfo.VisitDate = DateTime.Today.ToString("yyyy.MM.dd");
                bllVisitorData.insertVisitorData(visitorDataInfo);

                // 마지막 입력된 visitorDataCode 값 가져오기
                visitorDataInfo.VisitorDataCode = bllVisitorData.selectMaxVisitorDataCode();


                visitorDataInfo.CardNo = cardNoList2[i];
                bllVisitorData.updateInTime(visitorDataInfo);           
            }
            Response.Redirect("visitDataList.aspx");
        }
    }
}
