


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
using System.Collections.Generic;
using HanaMicron.COMS.Utility;
using System.Text;

public partial class main_visit_inputVisit : System.Web.UI.Page
{
	// 전자 결재 연동을 위한 문서 코드
	public String approveDocCode;

	public String interviewUserName;
	public String interviewUserCode;
	public String visitObjectContents;
	//public String officeCodeChecked1;
	//public String officeCodeChecked2;
	public String officeContents;
	public String carCode;
	public String carNumber;
    public String startDate;
    public String endDate;
    public String check = "0";

	public String loginEmploeeDisplayName;
	public String loginEmploeeDepartmentName;
	public String loginEmployeeUpnid;
	public String loginEmployeeTitle;

	public String displayCellCount = "0";
	public String arrVisitorList;

	public String reqVisitData;

	public String tableApprove;

	VisitData bllVisitData = new VisitData();
	VisitorData bllVisitorData = new VisitorData();
    VisitorDataInfo visitorDataInfo = new VisitorDataInfo();
    Visitor bllVisitor = new Visitor();

    protected void Page_Load(object sender, EventArgs e)
	{
		// 로그인 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (Page.IsPostBack)
		{
			VisitDataInfo visitDataInfo = new VisitDataInfo();
			visitDataInfo.VisitObjectInfo = new VisitObjectInfo();
			visitDataInfo.ReqEmployeeInfo = new EmployeeInfo();
			visitDataInfo.InterviewEmployeeInfo = new EmployeeInfo();
			visitDataInfo.InSecurityEmployeeInfo = new EmployeeInfo();
			visitDataInfo.OutSecurityEmployeeInfo = new EmployeeInfo();
			visitDataInfo.CarDataInfo = new CarDataInfo();
			visitDataInfo.OfficeInfo = new OfficeInfo();
			visitDataInfo.VisitorDataInfoList = new List<VisitorDataInfo>();

			#region 파일 업로드 
            // upload file

            //String userFileMimeType1 = String.Empty;
            //String userFileMimeType2 = String.Empty;
            //String userFileMimeType3 = String.Empty;

            //String userFileName1 = String.Empty;
            //String userFileName2 = String.Empty;
            //String userFileName3 = String.Empty;

            //String userFileByte1 = String.Empty;
            //String userFileByte2 = String.Empty;
            //String userFileByte3 = String.Empty;

            //String userFileDBName1 = String.Empty;
            //String userFileDBName2 = String.Empty;
            //String userFileDBName3 = String.Empty;

            //String separator = "|";

            //String fileUploadDir = ConfigurationManager.AppSettings["fileUploadPath"];

            //string[] arrFileName;
            //string ext;

            //if (userFile1.HasFile)
            //{
            //    arrFileName = userFile1.FileName.Split('.');
            //    ext=arrFileName[arrFileName.Length - 1].ToLower();

            //    userFileName1 = HanaMicron.COMS.Utility.StringUtil.ReplaceSpecial(userFile1.FileName.Replace("."+ext,"")) + "." + ext;
            //    String savePath1 = fileUploadDir + "\\" + (userFileName1);
            //    userFileMimeType1 = userFile1.PostedFile.ContentType;
            //    userFileByte1 = userFile1.PostedFile.ContentLength.ToString();
            //    userFile1.SaveAs(savePath1);
            //    userFileDBName1 = userFileName1 + separator + userFileMimeType1 + separator + userFileByte1;
            //}

            //if (userFile2.HasFile)
            //{
            //    arrFileName = userFile2.FileName.Split('.');
            //    ext = arrFileName[arrFileName.Length - 1].ToLower();

            //    userFileName2 = HanaMicron.COMS.Utility.StringUtil.ReplaceSpecial(userFile2.FileName.Replace("." + ext, "")) + "." + ext;
            //    userFileMimeType2 = userFile2.PostedFile.ContentType;
            //    userFileByte2 = userFile2.PostedFile.ContentLength.ToString();
            //    String savePath2 = fileUploadDir + "\\" + userFileName2;
            //    userFile2.SaveAs(savePath2);
            //    userFileDBName2 = userFileName2 + separator + userFileMimeType2 + separator + userFileByte2;
            //}

            //if (userFile3.HasFile)
            //{
            //    arrFileName = userFile3.FileName.Split('.');
            //    ext = arrFileName[arrFileName.Length - 1].ToLower();

            //    userFileName3 = HanaMicron.COMS.Utility.StringUtil.ReplaceSpecial(userFile3.FileName.Replace("." + ext, "")) + "." + ext;
            //    userFileMimeType3 = userFile3.PostedFile.ContentType;
            //    userFileByte3 = userFile3.PostedFile.ContentLength.ToString();
            //    String savePath3 = fileUploadDir + "\\" + userFileName3;
            //    userFile3.SaveAs(savePath3);
            //    userFileDBName3 = userFileName3 + separator + userFileMimeType3 + separator + userFileByte3;
            //}
            #endregion

			#region 객체 만들기  
            //tạo Object

			// 수정하기 전에 보존 되어야 할 정보를 위해서 이전 Record 를 가져온다.// Để bảo quản thông tin, trước khi sửa phải mang theo Record trước đó
			if (!String.IsNullOrEmpty(Request.QueryString["visitDataCode"]))
			{
				visitDataInfo = bllVisitData.selectVisitData(Request.QueryString["visitDataCode"]);
			}

			visitDataInfo.ReqEmployeeInfo.Upnid = loginEmployee.Upnid;
			visitDataInfo.InterviewEmployeeInfo.Upnid = Request["upnid"];
			visitDataInfo.VisitObjectInfo.VisitObjectCode =Convert.ToInt32(DropDownList1.SelectedValue);
			visitDataInfo.VisitObjectContents = Request["visitObjectContents"];
			visitDataInfo.OfficeInfo.OfficeCode = Convert.ToInt32(DropDownList2.SelectedValue);
			visitDataInfo.OfficeContents = txtOfficeContents.Text;
			visitDataInfo.ElecApproveCode = Request["elecApproveCode"];
            //string test = Request.Form["longVisit"];
            if (Request.Form["longVisit"] == "1")
            {
                visitDataInfo.VisitFlag = 1;
                //if (longVisit.Checked==true) visitDataInfo.VisitFlag = 1;

                visitDataInfo.StartDate = txtStartDate.Text;
                visitDataInfo.EndDate = txtEndDate.Text;
            }
            else // 장기 내방이 아니면 시작일,종료일 데이터 입력 안되게 // Nếu không phải khách đến thăm dài hạn thì không thể nhập ngày bắt đầu, ngày kết thúc
            {
                visitDataInfo.VisitFlag = 0;
                visitDataInfo.StartDate = String.Empty;
                visitDataInfo.EndDate = String.Empty;
            }

			if (String.IsNullOrEmpty(Request["carCode"])) visitDataInfo.CarDataInfo.CarCode = 0;
			else visitDataInfo.CarDataInfo.CarCode = Convert.ToInt32(Request["carCode"]);

			#endregion

			#region 저장
            //save

			int visitDataCode; // 내방 코드 visit code

			// 수정 sửa
			if (Request.QueryString["mode"].Equals("modify"))
			{
				//visitDataInfo.InTime =new DateTime();
				//visitDataInfo.OutTime = new DateTime();
				visitDataInfo.VisitDataCode = Convert.ToInt32(Request.QueryString["visitDataCode"]);

                //if (!String.IsNullOrEmpty(userFileName1)) visitDataInfo.UserFile1 = userFileDBName1;
                //if (!String.IsNullOrEmpty(userFileName2)) visitDataInfo.UserFile2 = userFileDBName2;
                //if (!String.IsNullOrEmpty(userFileName3)) visitDataInfo.UserFile3 = userFileDBName3;

				bllVisitData.updateVisitData(visitDataInfo);

				visitDataCode = Convert.ToInt32(Request.QueryString["visitDataCode"]);
                
				// 이전에 저장된 내방객 정보 삭제 // xóa thông tin khách đến thăm được lưu trữ trước đây
				List<VisitorDataInfo> list = bllVisitorData.selectVisitorDataList(Request.QueryString["visitDataCode"]);
				for (int i = 0; i < list.Count; i++)
				{
					int resultDel = bllVisitorData.deleteVisitorData((VisitorDataInfo)list[i]);
				}
			}

			// 추가 thêm
			else
			{
                //visitDataInfo.UserFile1 = userFileDBName1;
                //visitDataInfo.UserFile2 = userFileDBName2;
                //visitDataInfo.UserFile3 = userFileDBName3;

				int resultCode = bllVisitData.insertVisitData(visitDataInfo);

				visitDataCode = bllVisitData.selectMaxCode();
			}
			#endregion

			#region 내방객 정보 넣기
            // Thêm thông tin khách đến thăm

            int freepassCount = 0;
            int flag;
			String reqVisitorCode=Request["visitorCode"];
			String[] arrVisitorCode = reqVisitorCode.Split(',');
			
			for (int i = 0; i < arrVisitorCode.Length; i++)
			{
                //VisitorDataInfo visitorDataInfo = new VisitorDataInfo();
				visitorDataInfo.VisitorInfo = new VisitorInfo();

				if (!String.IsNullOrEmpty(arrVisitorCode[i]))
				{
					visitorDataInfo.VisitDataCode = visitDataCode;
					visitorDataInfo.VisitorInfo.VisitorCode = Convert.ToInt32(arrVisitorCode[i]);
                    // 장기내방이면 내방일을 장기내방 시작일로 넣음.  // Nếu là khách đến thăm dài hạn thì thêm ngày bắt đầu thăm dài hạn
                    if (Request.Form["longVisit"] == "1")
                    {
                        visitorDataInfo.VisitDate = txtStartDate.Text;
                    }
                    else
                    {
                        visitorDataInfo.VisitDate = Request.Form["visitDate"];
                    }
                    // 내방객 중에 Free pass 내방객이 있는지 확인  Trong những khách đến thăm, Kiểm tra xem khách đến thăm có hay không có Free pass 
                    bool existsFree = bllVisitor.existsFreepassVisitor(visitorDataInfo.VisitorInfo.VisitorCode);

                    if (existsFree == true)
                    {
                        freepassCount++;
                    }
                   
					bllVisitorData.insertVisitorData(visitorDataInfo);
				}
			}

			#endregion
            // 장기 내방을 제외하고 단기 또는 Freepass는 VisitFlag 수정   // Ngoại trừ khách thăm dài hạn, Sửa VisitFlag của khách thăm ngắn hạn hoặc Freepass
            if (visitDataInfo.VisitFlag != 1)
            {
                // Freepass 인원이 한명이라도 있으면 visitFlag = 5   // cho dù chỉ có 1 người là Freepass thì visitFlag = 5
                if (freepassCount > 0)
                {
                    flag = 5;
                    bllVisitData.updateVisitData(visitDataCode,flag);
                }
                // Freepass 인원이 한명이라도 있으면 visitFlag = 0 (일반인원으로 모두 수정했을때를 예상하여)    cho dù chỉ có 1 người là Freepass thì visitFlag = 0 (dự đoán Khi đã sửa tất cả khách thường)
                else
                {
                    flag = 0;
                    bllVisitData.updateVisitData(visitDataCode,flag);
                }
            }
            List<VisitorDataInfo> visitorList = bllVisitorData.selectVisitorDataList(visitDataCode.ToString());

            Response.Redirect("viewVisitManager.aspx?visitDataCode=" + visitDataCode + "&visitorDataCode=" + visitorList[0].VisitorDataCode, true);
		}
		else
		{

			#region 수정 or 신규등록 정보 보이기
            // sửa hoặc đăng ký thông tin mới

			if (Request.QueryString["mode"].Equals("modify"))
			{
				VisitDataInfo visitData = bllVisitData.selectVisitData(Request.QueryString["visitDataCode"]);

				interviewUserCode = visitData.InterviewEmployeeInfo.Upnid;
				interviewUserName = visitData.InterviewEmployeeInfo.DisplayName;

				officeContents = visitData.OfficeContents;
				carCode = visitData.CarDataInfo.CarCode.ToString();
				carNumber = visitData.CarDataInfo.Header + visitData.CarDataInfo.Number;
				visitObjectContents = visitData.VisitObjectContents;

				txtOfficeContents.Text = visitData.OfficeContents;

				DropDownList1.SelectedValue = visitData.VisitObjectInfo.VisitObjectCode.ToString();
				DropDownList2.SelectedValue = visitData.OfficeInfo.OfficeCode.ToString();

                if (visitData.VisitFlag == 1)
                {
                    check = "1";
                    txtStartDate.Text = visitData.StartDate.Substring(0, 10);
                    txtEndDate.Text = visitData.EndDate.Substring(0, 10);
                }
                else //장기내방이 아니면 시작일,종료일(1800-01-01) 안나오게.. // nếu không phải khách đến thăm dài hạn thì không hiển thị ngày bắt đầu, ngày kết thúc
                {
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                }
                //else longVisit.Checked = false;

                //if (visitData.VisitFlag == 1) longVisit.Checked = true;
                //else longVisit.Checked = false;

				List<VisitorDataInfo> visitorList = bllVisitorData.selectVisitorDataList(visitData.VisitDataCode.ToString());

				for (int i = 0; i < visitorList.Count; i++)
				{
					VisitorDataInfo subVisitor = (VisitorDataInfo)visitorList[i];

					reqVisitData = subVisitor.VisitDate;

					arrVisitorList += "visitorCode[" + i + "]='" + subVisitor.VisitorInfo.VisitorCode + "';\n";
					//arrVisitorList += "visitorRegNumber[" + i + "]='" + subVisitor.VisitorInfo.VisitorRegNumber1 + "-" + subVisitor.VisitorInfo.VisitorRegNumber2 + "';\n";
                    arrVisitorList += "visitorRegNumber[" + i + "]='" + subVisitor.VisitorInfo.VisitorRegNumber1 + "';\n";
                    arrVisitorList += "visitorPassportNumber[" + i + "]='" + subVisitor.VisitorInfo.VisitorPassportNumber + "';\n";
                    arrVisitorList += "visitorName[" + i + "]='" + subVisitor.VisitorInfo.VisitorName + "';\n";
					arrVisitorList += "companyName[" + i + "]='" + subVisitor.CompanyInfo.CompanyName + "';\n";
					arrVisitorList += "phone[" + i + "]='" + subVisitor.VisitorInfo.VisitorPhone1 + "-" + subVisitor.VisitorInfo.VisitorPhone2 + "-" + subVisitor.VisitorInfo.VisitorPhone3 + "';\n";
				}

				displayCellCount = visitorList.Count.ToString();

				// 결재 코드 code phê duyệt
				approveDocCode = visitData.ElecApproveCode;

				//첨부 파일    đính kèm file
                //if (!String.IsNullOrEmpty(visitData.UserFile1))
                //{
                //    lblUserFile1.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + bllVisitData.GetFileName(visitData.UserFile1) + "' target='_blank'>" + bllVisitData.GetFileName(visitData.UserFile1) + "</a>";
                //    lblUserFile1.Text += "<a href='#;' onclick=\"confirmMove('Có chắc chắn xóa không? 정말로 삭제하시겠습니까?','userFileDelete.aspx?visitDataCode=" + visitData.VisitDataCode + "&fileNumber=1&fileName=" + HttpUtility.UrlEncode(bllVisitData.GetFileName(visitData.UserFile1)) + "',document.dummy)\"><img src='../../images/icon/fileDelete.gif' align='absmiddle'></a>";
                //}

                //if (!String.IsNullOrEmpty(visitData.UserFile2))
                //{
                //    String[] arrUserFile2 = visitData.UserFile2.Split('|');
                //    lblUserFile2.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + bllVisitData.GetFileName(visitData.UserFile2) + "' target='_blank'>" + bllVisitData.GetFileName(visitData.UserFile2) + "</a>";
                //    lblUserFile2.Text += "<a href='#;' onclick=\"confirmMove('Có chắc chắn xóa không? 정말로 삭제하시겠습니까?','userFileDelete.aspx?visitDataCode=" + visitData.VisitDataCode + "&fileNumber=2&fileName=" + HttpUtility.UrlEncode(bllVisitData.GetFileName(visitData.UserFile2)) + "',document.dummy)\"><img src='../../images/icon/fileDelete.gif' align='absmiddle'></a>";
                //}

                //if (!String.IsNullOrEmpty(visitData.UserFile3))
                //{
                //    String[] arrUserFile3 = visitData.UserFile3.Split('|');
                //    lblUserFile3.Text = "<a href='" + ConfigurationManager.AppSettings["fileOpenPath"] + "/" + bllVisitData.GetFileName(visitData.UserFile3) + "' target='_blank'>" + bllVisitData.GetFileName(visitData.UserFile3) + "</a>";
                //    lblUserFile3.Text += "<a href='#;' onclick=\"confirmMove('Có chắc chắn xóa không? 정말로 삭제하시겠습니까?','userFileDelete.aspx?visitDataCode=" + visitData.VisitDataCode + "&fileNumber=3&fileName=" + HttpUtility.UrlEncode(bllVisitData.GetFileName(visitData.UserFile3)) + "',document.dummy)\"><img src='../../images/icon/fileDelete.gif' align='absmiddle'></a>";
                //}
				
			}
			
			// 신규 등록하기    đăng ký mới
			else
			{
				// 신규 결재 코드 가져오기  mang theo code phê duyết mới
				approveDocCode = bllVisitData.GetNewApproveCode();
			}

			#endregion

			#region 임직원 정보 보이기
            // xem thông tin nhân viên

			loginEmploeeDisplayName = loginEmployee.DisplayName;
			loginEmploeeDepartmentName = loginEmployee.Dep_name;
			loginEmployeeUpnid = loginEmployee.Upnid;
			loginEmployeeTitle = loginEmployee.Title_name;
			lblDepartment.Text = loginEmployee.Dep_name;
			lblUpnid.Text = loginEmployee.Upnid;
			lblOfficeName.Text = loginEmployee.OfficeName;
			lblDisplayName.Text = loginEmployee.DisplayName;
			lblTitle.Text = loginEmployee.Title_name;
			lblPhone.Text = loginEmployee.MobilePhoneNumber;

			#endregion
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public string GetOnUnloadScript()
	{
		return "approveLineDelete()";
	}

	public String ShowApproveLine()
	{
		return "showApproveLine();";
	}

}
