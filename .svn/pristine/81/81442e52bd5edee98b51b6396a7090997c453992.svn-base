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

public partial class elecApprove_visitDataSend : System.Web.UI.Page
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

	public String loginEmploeeDepartmentName;
	public String loginEmploeeDisplayName;
	public String loginEmployeeUpnid;
    protected void Page_Load(object sender, EventArgs e)
    {

		// 로그인 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		loginEmploeeDepartmentName = loginEmployee.Dep_name;
		loginEmploeeDisplayName = loginEmployee.DisplayName;
		loginEmployeeUpnid = loginEmployee.Upnid;

		VisitData bll = new VisitData();
		VisitDataInfo obj = bll.selectVisitData(Request["visitDataCode"]);
		elecApproveContents = bll.MakeElecApproveContents(obj);

		form_code = ConfigurationManager.AppSettings["elecApproveFormCode"];
		doc_term = "1";
		sec_level = "M";
		user_id = loginEmployee.Upnid;
		user_Title = loginEmployee.Title_name;
		user_depName = loginEmployee.Dep_name;
		user_name = loginEmployee.DisplayName;
		attach_flag = "0";

		String[] arrUserFileNames;
		String ext;
		Char separator = '|';

		if (!String.IsNullOrEmpty(obj.UserFile1))
		{
			//A [b].doc:Ab.doc:doc:application/msword: 210432
			/**
			 * arrUserFile1[0] : 파일명
			 * arrUserFile1[1] : MimeType
			 * arrUserFile1[2] : 파일 사이즈 (바이트)
			 */
			String[] arrUserFile1 = obj.UserFile1.Split(separator);

			arrUserFileNames = arrUserFile1[0].Split('.');
			ext = arrUserFileNames[arrUserFileNames.Length - 1].ToLower();

			attach_str += arrUserFile1[0] + ":" + arrUserFile1[0] + ":" + ext + ":" + arrUserFile1[1] + ":" + arrUserFile1[2] + ";";
			attach_flag = "1";
		}

		if (!String.IsNullOrEmpty(obj.UserFile2))
		{
			//A [b].doc:Ab.doc:doc:application/msword: 210432
			/**
			 * arrUserFile1[0] : 파일명
			 * arrUserFile1[1] : MimeType
			 * arrUserFile1[2] : 파일 사이즈 (바이트)
			 */
			String[] arrUserFile2 = obj.UserFile2.Split(separator);

			arrUserFileNames = arrUserFile2[0].Split('.');
			ext = arrUserFileNames[arrUserFileNames.Length - 1].ToLower();

			attach_str += arrUserFile2[0] + ":" + arrUserFile2[0] + ":" + ext + ":" + arrUserFile2[1] + ":" + arrUserFile2[2] + ";";
			attach_flag = "1";
		}

		if (!String.IsNullOrEmpty(obj.UserFile3))
		{
			//A [b].doc:Ab.doc:doc:application/msword: 210432
			/**
			 * arrUserFile1[0] : 파일명
			 * arrUserFile1[1] : MimeType
			 * arrUserFile1[2] : 파일 사이즈 (바이트)
			 */
			String[] arrUserFile3 = obj.UserFile3.Split(separator);

			arrUserFileNames = arrUserFile3[0].Split('.');
			ext = arrUserFileNames[arrUserFileNames.Length - 1].ToLower();

			attach_str += arrUserFile3[0] + ":" + arrUserFile3[0] + ":" + ext + ":" + arrUserFile3[1] + ":" + arrUserFile3[2] + ";";
			attach_flag = "1";
		}

		bll.updateApprove(Request["visitDataCode"], "1", "");
    }
}
