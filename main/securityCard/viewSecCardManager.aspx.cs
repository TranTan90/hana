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

public partial class main_secCard_viewSecCard : System.Web.UI.Page
{
    SecCardData bll = new SecCardData();
    ElecApprove bllelec = new ElecApprove();

	public String loginEmploeeDepartmentName;
	public String loginEmploeeDisplayName;
    public String reqEmploeeDisplayName;
	public String elecApproveCode;
	public String loginEmployeeUpnid;
	public String loginEmployeeTitle;
    public String title;
    public int visit;
    public String officePhone;
   
    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크  login check
		if (this.Context.User.Identity.Name == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
		EmployeeInfo loginEmployee = new EmployeeInfo();
		Employee bllEmployee = new Employee();
		loginEmployee = bllEmployee.selectEmployee(this.Context.User.Identity.Name);

		loginEmploeeDepartmentName = loginEmployee.Dep_name;
		loginEmploeeDisplayName = loginEmployee.DisplayName;
		loginEmployeeUpnid = loginEmployee.Upnid;
		loginEmployeeTitle = loginEmployee.Title_name;

        SecCardDataInfo secCardDataInfo = bll.selectSecCardData(Request.QueryString["secCardDataCode"]);
        ElecApproveInfo elecApproveInfo = bllelec.selectElecApproveStatus(secCardDataInfo.ElecApproveCode);
      
        reqEmploeeDisplayName = secCardDataInfo.RequestUserName;
	    // 임직원 정보 보이기     xem thông tin nhân viên
        lblDepartment.Text = secCardDataInfo.RequestDepDesc;
        lblUpnid.Text = secCardDataInfo.RequestUserCode;
        lblOfficeName.Text = loginEmployee.OfficeName;
        lblDisplayName.Text = secCardDataInfo.RequestUserName;
        lblTitle.Text = secCardDataInfo.RoleDesc;
        lblOfficePhone.Text = secCardDataInfo.OfficePhone;
        comment.Text = secCardDataInfo.Comment;
        txtStartDate.Text = secCardDataInfo.ReqDateFrom;
        txtEndDate.Text = secCardDataInfo.ReqDateEnd;
        if (secCardDataInfo.Flag == 1)
        {
            rbNew.Checked = true;
        }
        else
        {
            rbChange.Checked = true;
        }


        elecApproveCode = secCardDataInfo.ElecApproveCode;

		// 결재 상신 전이라면 
        if (elecApproveInfo.ApprovalState == 0)
		{
			// 결재라인 변경 이미지  
			btnElecApproveLine.Visible = true;

			// 결재 상신 버튼
			btnApproveStart.Visible = true;

			// 결재 상태 보기
			btnElectStatus.Visible = false;
		}
		else
		{
			btnElectStatus.Visible = true;
			btnApproveStart.Visible = false;
			btnElecApproveLine.Visible = false;
		}
    }

	private string ShowApproveLine()
	{
		return "showApproveLine();";
	}
}
