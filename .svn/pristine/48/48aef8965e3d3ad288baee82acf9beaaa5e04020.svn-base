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
using HanaMicron.COMS.Utility;

public partial class main_visit_viewVisit : System.Web.UI.Page
{
	TakeOutData bll = new TakeOutData();

    public string scheduleDateTitle = null;
    public string ckRequire1; //반입필 Cần mang vào
    public string ckRequire2; //반입불가 Không thể mang vào 
    public string stNote; //비고 Ghi chú 

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크  check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		TakeOutDataInfo takeOutDataInfo = bll.selectTakeOutData(Request.QueryString["takeOutDataCode"]);
        
		// 신청자 보이기 xem người đăng ký 
		lblDepartment.Text = takeOutDataInfo.RequestUserDepartment;
		lblUpnid.Text = takeOutDataInfo.RequestUserCode;
		lblOfficeName.Text = takeOutDataInfo.RequestUserOfficeName;
		lblDisplayName.Text = takeOutDataInfo.RequestUserDisplayName;
		lblTitle.Text = takeOutDataInfo.RequestUserTitleName;
		lblPhone.Text = loginEmployee.MobilePhoneNumber;
        // 반출 정보 보이기 xem thông tin tài sản ra/vào
		lblTakeOutDataCode.Text = takeOutDataInfo.TakeOutDataCode;
        //lblScheduleDate.Text = takeOutDataInfo.ScheduleInDate;

        // 반입예정일,반입필->반입불가,비고 수정 가능하게  ngày dự định mang vào, cần mang vào -> cấm mang vào, ghi chú: có thể sửa
        // 2009-09-23 임종우
        scheduleDateTitle = takeOutDataInfo.ScheduleInDate;
		lblTakeOutObject.Text = takeOutDataInfo.TakeOutObjectName;
		lblTakeOutObjectContents.Text = takeOutDataInfo.ObjectContents;
		lblTakeOutPathStart.Text = takeOutDataInfo.TakeOutPathStartName;
		lblTakeOutPathEnd.Text = takeOutDataInfo.TakeOutPathEndName;
		lblCompanyName.Text = takeOutDataInfo.CompanyName;
		lblReceiveName.Text = takeOutDataInfo.RecieveName;
        //lblRequireIN.Text = bll.requireKor(takeOutDataInfo.RequireIN);
        if (takeOutDataInfo.RequireIN == 1)
        {
            ckRequire1 = "checked";
        }
        else
        {
            ckRequire2 = "checked";
        }

		lblDisApproveName.Text = takeOutDataInfo.DisApprovalCategoryName;
		lblDisApproveDetail.Text = takeOutDataInfo.DisApprovalCategoryDetail;
		lblCarNumber.Text = takeOutDataInfo.CarNumber;
        //lblNote.Text = takeOutDataInfo.Note;
        stNote = takeOutDataInfo.Note;
        lblINUserName.Text = takeOutDataInfo.TakeOutItemDataList[0].INSecurityUserName;
        lblOutUserName.Text = takeOutDataInfo.TakeOutItemDataList[0].OutSecurityUserName;
        lblINTime.Text = takeOutDataInfo.TakeOutItemDataList[0].TakeINTime.ToString();
		lblOutTime.Text = takeOutDataInfo.TakeOutItemDataList[0].TakeOutTime.ToString();

		
		
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{

	}
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] dataList = new string[4];

        dataList[0] = lblTakeOutDataCode.Text;

        if (Request["requireIN"] == "1")
        {
            dataList[1] = Request["scheduleInDate"];
        }
        dataList[2] = Request["requireIN"];
        dataList[3] = Request["txtNote"];

        int result = bll.updateTakeOutData(dataList);

        Response.Redirect("takeOutDataView.aspx?takeOutDataCode=" + dataList[0], true);
    }
}
