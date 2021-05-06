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

public partial class elecApprove_ElecApproveSend : System.Web.UI.Page
{
	public String elecApproveContents;
	public String form_code;
	public String doc_term;
	public String sec_level;
	public String user_id;
	public String user_Title;
	public String user_depName;
	public String user_name;
	public String attach_flag;
	public String attach_str;
	public String elecCategoryCode;
    public String doc_title;

	public String loginEmploeeDepartmentName;
	public String loginEmploeeDisplayName;
	public String loginEmployeeUpnid;

    public String elecApproveType; //전자결재 타입(반출:takeOut,내방:visit,보안카드:secCard)  loại phê duyệt điện tử ()

	protected void Page_Load(object sender, EventArgs e)
	{
		// 로그인 체크  check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		loginEmploeeDepartmentName = loginEmployee.Dep_name;
		loginEmploeeDisplayName = loginEmployee.DisplayName;
		loginEmployeeUpnid = loginEmployee.Upnid;

        // 전자결재 타입
        elecApproveType = Request.QueryString["elecApproveType"];

        VisitData bll = new VisitData();
        VisitDataInfo obj = new VisitDataInfo();

        TakeOutData bllTakeOut = new TakeOutData();
        TakeOutDataInfo takeOutData = new TakeOutDataInfo();

        SecCardData bllSecCard = new SecCardData();
        SecCardDataInfo secCardData = new SecCardDataInfo();

        if (elecApproveType.Equals("visit")) // 내방 부분 phần visit
        {
            obj = bll.selectVisitData(Request["visitDataCode"]);

            if (obj.VisitFlag == 1)
            {
                doc_title = "[Đăng ký khách thăm dài hạn] ([장기내방신청])";
            }
            else
            {
                doc_title = "Đăng ký khách thăm ([내방신청])";
            }

            elecApproveContents = bll.MakeElecApproveContents(obj);
            //내방 전자결재 web.config에 등록된 카테고리 코드. 전자결재 Legacy 연동시 사용함.
            elecCategoryCode = ConfigurationManager.AppSettings["elecCategoryCode"]; 
        }
        else if(elecApproveType.Equals("secCard")) // 반출 부분
        {
            secCardData = bllSecCard.selectSecCardData(Request["secCardDataCode"]);

            doc_title = "[Mẫu đăng ký ra/vào (Card Reader)] ([출입(카드리더기)등록 신청서])";

            elecApproveContents = bllSecCard.MakeElecApproveContents(secCardData);
            //반출 전자결재 web.config에 등록된 카테고리 코드. 전자결재 Legacy 연동시 사용함.
            elecCategoryCode = ConfigurationManager.AppSettings["elecCategoryCodeAll"];

            bllSecCard.updateApprove(secCardData.ElecApproveCode, "1", "");
        }
        else // 반출 부분
        {
            takeOutData = bllTakeOut.selectTakeOutData(Request["takeOutDataCode"]);

            doc_title = "[Đăng ký mang ra] ([반출신청])";

            elecApproveContents = bllTakeOut.MakeElecApproveContentsTakeOut(takeOutData);
            //반출 전자결재 web.config에 등록된 카테고리 코드. 전자결재 Legacy 연동시 사용함.
            elecCategoryCode = ConfigurationManager.AppSettings["elecCategoryCodeTakeOut"];
        }

		form_code = ConfigurationManager.AppSettings["elecApproveFormCode"];
		doc_term = "1";
		sec_level = "M";
		user_id = loginEmployee.Upnid;
		user_Title = loginEmployee.Title_name;
		user_depName = loginEmployee.Dep_name;
		user_name = loginEmployee.DisplayName;
		attach_flag = "0";

        if (elecApproveType.Equals("visit")) //내방부분
        {
            if (!String.IsNullOrEmpty(obj.UserFile1))
            {
                attach_str += MakeFileString(obj.UserFile1) + ";";
                attach_flag = "1";
            }

            if (!String.IsNullOrEmpty(obj.UserFile2))
            {
                attach_str += MakeFileString(obj.UserFile2) + ";";
                attach_flag = "1";
            }

            if (!String.IsNullOrEmpty(obj.UserFile3))
            {
                attach_str += MakeFileString(obj.UserFile3) + ";";
                attach_flag = "1";
            }

            bll.updateApprove(Request["visitDataCode"], "1", "");
        }
        else //반출 부분
        {
            if (!String.IsNullOrEmpty(takeOutData.UserFile1))
            {
                attach_str += MakeFileString(takeOutData.UserFile1) + ";";
                attach_flag = "1";
            }

            if (!String.IsNullOrEmpty(takeOutData.UserFile2))
            {
                attach_str += MakeFileString(takeOutData.UserFile2) + ";";
                attach_flag = "1";
            }

            if (!String.IsNullOrEmpty(takeOutData.UserFile3))
            {
                attach_str += MakeFileString(takeOutData.UserFile3) + ";";
                attach_flag = "1";
            }

            bllTakeOut.updateApprove(Request["takeOutDataCode"], "1", "");
        }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="userFile"></param>
	/// <returns></returns>
	private String MakeFileString(String userFile)
	{
		//A [b].doc:Ab.doc:doc:application/msword: 210432
		/**
		 * arrUserFile1[0] : 파일명
		 * arrUserFile1[1] : MimeType
		 * arrUserFile1[2] : 파일 사이즈 (바이트)
		 */

		Char separator = '|';
		String ext;
		String temp_attach_str=String.Empty;

		String[] arrUserFile = userFile.Split(separator);

		String[] arrUserFileNames = arrUserFile[0].Split('.');
		ext = arrUserFileNames[arrUserFileNames.Length - 1].ToLower();

		temp_attach_str += Request["elecApproveCode"] + separator;
		temp_attach_str += ConfigurationManager.AppSettings["elecPhysicalPath"] + separator;
		temp_attach_str += ConfigurationManager.AppSettings["elecOpenPathHeader"] + separator;
		temp_attach_str += ConfigurationManager.AppSettings["elecOpenPathMiddle"] + separator;
		temp_attach_str += arrUserFile[1] + separator;
		temp_attach_str += arrUserFile[2] + separator;
		temp_attach_str += arrUserFile[0] + separator;
		temp_attach_str += arrUserFile[0] + separator;
		temp_attach_str += ext + separator;
		temp_attach_str += DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + separator;
		temp_attach_str += loginEmployeeUpnid;

		return temp_attach_str;
	}
}
