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

public partial class main_security_inputSecCard : System.Web.UI.Page
{
    // 전자 결재 연동을 위한 문서 코드
    public String approveDocCode;
    public String officePhone;
    private SecCardData bllSecCardData;
    private ElecApprove bllElecApprove;
    int secCardCode; // 보안카드 코드
    public String ckRequire1; // 신규    // mới
    public String ckRequire2; // 변경    // thay đổi
    
    protected void Page_Load(object sender, EventArgs e)
    {
        bllSecCardData = new SecCardData();
        bllElecApprove = new ElecApprove();

        // 로그인 체크    check login
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        // 임직원 정보 보이기      //xem thông tin nhân viên 
        lblDepartment.Text = loginEmployee.Dep_name;
        lblUpnid.Text = loginEmployee.Upnid;
        lblOfficeName.Text = loginEmployee.OfficeName;
        lblDisplayName.Text = loginEmployee.DisplayName;
        lblTitle.Text = loginEmployee.Title_name;
        if(loginEmployee.OfficePhoneNumber.Equals(" "))
        {
            if (inOfficePhone.Text.Equals(" "))
            {
                inOfficePhone.Text = "";
            }
        }
        else
        {
            if (inOfficePhone.Text.Equals(""))
            {
                inOfficePhone.Text = loginEmployee.OfficePhoneNumber;
            }
        }
    
        if (Page.IsPostBack)
        {
           
            SecCardDataInfo secCardDataInfo = new SecCardDataInfo();
            ElecApproveInfo elecApproveInfo = new ElecApproveInfo();
            
            secCardDataInfo.RegDate = DateTime.Now.ToString("yyyyMMdd");


            secCardDataInfo.RequestUserCode = loginEmployee.Upnid;
            secCardDataInfo.RequestUserName = loginEmployee.DisplayName;
            secCardDataInfo.RequestDepCode = loginEmployee.Department;
            secCardDataInfo.RequestDepDesc = loginEmployee.Dep_name;

            secCardDataInfo.RoleCode = loginEmployee.Title;
            secCardDataInfo.RoleDesc = loginEmployee.Title_name;
            secCardDataInfo.OfficePhone = inOfficePhone.Text;

            secCardDataInfo.Comment = comment.Text;
            secCardDataInfo.ReqDateFrom = txtStartDate.Text;
            secCardDataInfo.ReqDateEnd = txtEndDate.Text;
          
            secCardDataInfo.Flag = Convert.ToInt32(hiddenflag.Value);
            secCardDataInfo.ApprovalState = 0;
       
            // 신규  mới
            if (Request.QueryString["mode"].Equals("write"))
            {
                approveDocCode = bllSecCardData.GetNewApproveCode();
                secCardDataInfo.ElecApproveCode = approveDocCode;
                elecApproveInfo.ElecApproveCode = approveDocCode;
                int result = bllSecCardData.insertSecCardData(secCardDataInfo);
                int result2 = bllElecApprove.insertElecApprove(elecApproveInfo);
                secCardCode = bllSecCardData.selectMaxCode();
            }
            // 수정  sửa
            else
            {
                secCardDataInfo.SecDataCode = Convert.ToInt32(Request["secCardDataCode"]);
                int result = bllSecCardData.updateSecCardData(secCardDataInfo);
                secCardCode = Convert.ToInt32(Request.QueryString["secCardDataCode"]);
            }

            Response.Redirect("viewSecCardManager.aspx?secCardDataCode=" + secCardCode, true);
        }
        else
        {
            // 신규  mới 
            if (Request.QueryString["mode"].Equals("write"))
            {
                // 신규 결재 코드 가져오기
                approveDocCode = bllSecCardData.GetNewApproveCode();
                //ckRequire1 = "checked";
            }
            else
            {
                SecCardDataInfo oldSecCardDataInfo = bllSecCardData.selectSecCardData(Request.QueryString["secCardDataCode"]);

                inOfficePhone.Text = oldSecCardDataInfo.OfficePhone;
                comment.Text = oldSecCardDataInfo.Comment;
                txtStartDate.Text = oldSecCardDataInfo.ReqDateFrom;
                txtEndDate.Text = oldSecCardDataInfo.ReqDateEnd;

                if (oldSecCardDataInfo.Flag == 1) ckRequire1 = "checked";
                else ckRequire2 = "checked";
               


            }
        }
    }
}
